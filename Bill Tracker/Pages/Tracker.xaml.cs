using Bill_Tracker.Dialog;
using BillMate.Services.ViewModel.Models;
using BillMate.Services.ViewModel.Providers;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Bill_Tracker.UI;


namespace Bill_Tracker
{
    public sealed partial class Tracker : Page
    {
        internal AccountDataProvider AP { get; set; }
        internal TransactionDataProvider TP { get; set; }
        public Tracker()
        {
            this.InitializeComponent();
            AP = new AccountDataProvider();
            TP = new TransactionDataProvider();
            var accounts = AP.GetAccountTable();

            foreach (Account ac in accounts)
            {
                if (ac.startDate.Date == new DateTime(0001,1,1))
                {
                    ac.startDate = DateTime.Now.Date;                    
                    AP.UpdateAccount(ac);
                }
            }
            
            gvAcct.ItemsSource = accounts;

            lblAcctCnt.Text = accounts.Count.ToString();
            lblTotal.Text = accounts.Sum(t => t.dispBal.ToCurrency()).ToString().ToCurrencyString();
            lblPaid.Text = accounts.Sum(p => p.mnthPayAmnt).ToCurrencyString();
            double _totAcc = accounts.Sum(t => t.dispBal.ToCurrency() / accounts.Sum(l => l._Limit.ToCurrency()) * 100);
            if (_totAcc == 0 || !double.IsNaN(_totAcc) )
            {
                radCred.Value = Convert.ToInt32(_totAcc);
            } else
            {
                radCred.Value = 0;
            }

            if (accounts.Count == 0)
            {
                stkNoItems.Visibility = Visibility.Visible;
                gvAcct.Visibility = Visibility.Collapsed;
            } else
            {
                stkNoItems.Visibility = Visibility.Collapsed;
                gvAcct.Visibility = Visibility.Visible;
            }
        }
        private async void bttnAdd_Click(object sender, RoutedEventArgs e)
        {
            var mainFrame = this.Frame;
            Dialog.addAccount addAcctD = new Dialog.addAccount(mainFrame);
            await addAcctD.ShowAsync();
            mainFrame.Navigate(typeof(Tracker));
            
        }

        private async void delAcctount (Account acct)
        {
            string diaText = string.Format("Account {0} will be deleted. \n Do you wish to continue?", acct.acctName);
            var dialog = new Windows.UI.Popups.MessageDialog(diaText, "Delete Account?");
            dialog.Options = Windows.UI.Popups.MessageDialogOptions.AcceptUserInputAfterDelay;
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 1 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 0 });
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;

            var action = await dialog.ShowAsync();

            if (action.Id.ToString() == "1")
            {
               AP.DeleteAccount(acct);
            }

            var frame = this.Frame;
            frame.Navigate(typeof(Tracker));
        }
        private async void editAccount (Account acct)
        {
            var frame = this.Frame;
            addAccount edita = new addAccount(frame, true, acct);
            await edita.ShowAsync();
            frame.Navigate(typeof(Tracker));
        }
        private async void transAccount (Account acct)
        {
            acctAddTrans aTrans = new acctAddTrans(acct);
            await aTrans.ShowAsync();
            var frame = this.Frame;
            frame.Navigate(typeof(Tracker));
        }

        private void accGvDelClick_Click(object sender, RoutedEventArgs e)
        {
            delAcctount((Account)(sender as Button).DataContext);            
        }

        private void accGvEditClick_Click(object sender, RoutedEventArgs e)
        {
            editAccount((Account)(sender as Button).DataContext);
        }

        private void accGvAddClick_Click(object sender, RoutedEventArgs e)
        {
            transAccount((Account)(sender as Button).DataContext);
        }
        private void AccGvClose_Click(object sender, RoutedEventArgs e)
        {
            var test = (Account)(sender as Button).DataContext;
        }


        private void SwipeDel_Invoked(SwipeItem sender, SwipeItemInvokedEventArgs args)
        {
           delAcctount((Account)args.SwipeControl.DataContext);
        }
        private void SwipeEdit_Invoked(SwipeItem sender, SwipeItemInvokedEventArgs args)
        {
            editAccount((Account)args.SwipeControl.DataContext);
        }
        private void SwipeTrans_Invoked(SwipeItem sender, SwipeItemInvokedEventArgs args)
        {
           transAccount((Account)args.SwipeControl.DataContext);
        }
        private void SwipeTran_Invoked(SwipeItem sender, SwipeItemInvokedEventArgs args)
        {
            foreach (var child in (args.SwipeControl.Content as Grid).Children)
            {
                if (child is Expander)
                {
                    if (child.Visibility == Visibility.Collapsed)
                    {
                        child.Visibility = Visibility.Visible;
                        sender.Text = "Collapse";
                        (child as Expander).IsExpanded = true;
                    } else
                    {
                        child.Visibility = Visibility.Collapsed;
                            sender.Text = "Expand";                        
                        (child as Expander).IsExpanded = false;
                    }
                }
            }            
        }

        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            UIFunctions.pointerEnter(sender, e);
            if (e.Pointer.PointerDeviceType != Windows.Devices.Input.PointerDeviceType.Touch)
            {

                Grid item = sender as Grid;
                foreach (var child in item.Children)
                {
                    if (child is Expander)
                    {                        
                            child.Visibility = Visibility.Visible;                        
                    }
                }
            }
        }

        private void Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            UIFunctions.pointerExit(sender, e);
            if (e.Pointer.PointerDeviceType != Windows.Devices.Input.PointerDeviceType.Touch)
            {

                Grid item = sender as Grid;
                foreach (var child in item.Children)
                {
                    if (child is Expander)
                    {
                        child.Visibility = Visibility.Collapsed;
                        (child as Expander).IsExpanded = false;
                    }
                }
            }
        }

        private void Expander_Expanded(object sender, EventArgs e)
        {           
           List<Trans> tlist = TP.getTransTable().FindAll(t => t.accountID == ((Account)(sender as Expander).DataContext).accountID).ToList();
           cvsTrans.Source = tlist;
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            UIFunctions.swipe(sender, e);
        }

    }
}
