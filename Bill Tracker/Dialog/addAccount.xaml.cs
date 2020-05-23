using BillMate.Services.ViewModel.Models;
using BillMate.Services.ViewModel.Providers;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Bill_Tracker.Dialog
{
    public sealed partial class addAccount : ContentDialog
    {
        Account selectedAccount;
        Frame _mainframe;
        bool _isEdit;
        internal AccountDataProvider AP { get; set; }
        internal TransactionDataProvider TP { get; set; }
        public addAccount(Frame mainframe, bool isEdit = false, Account acct = null)
        {
            this.InitializeComponent();
            this.IsPrimaryButtonEnabled = false;
            AP = new AccountDataProvider();
            TP = new TransactionDataProvider();
            _mainframe = mainframe;
            if (isEdit == true)
            {
                this.Title = string.Format("Edit {0}", acct.acctName);
                tbxAcctName.Text = acct.acctName;
                dteAcctOpen.Date = acct.startDate;
                tbxMonthlyPay.Text = acct.mnthPayAmnt.ToString();
                tbxOpenBal.Text = acct.startBal.ToString();
                tbxCredLim.Text = acct.creditLimit.ToString();
                tbxAPR.Text = acct.APR.ToString();
                tbxCurrBal.Visibility = Visibility.Collapsed;
                lblCurBal.Visibility = Visibility.Collapsed;

                if (acct.acctType == AcctType.Credit)
                {
                    cbxAcctType.SelectedIndex = 0;
                } else
                {
                    cbxAcctType.SelectedIndex = 1;
                }
                selectedAccount = acct;
                _isEdit = true;
                this.IsPrimaryButtonEnabled = true;
                this.PrimaryButtonText = "Save";
                lblAssocBill.Visibility = Visibility.Visible;
                tbxAssocBill.Visibility = Visibility.Visible;
                tbxAssocBill.Text = "None";  
            } else
            {
                lblAssocBill.Visibility = Visibility.Collapsed;
                assocPanel.Visibility = Visibility.Collapsed;
            }

        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (_isEdit == false)
            {
                selectedAccount = new Account()
                {
                    acctBal = double.Parse(tbxCurrBal.Text.TrimStart('$')),
                    startDate = dteAcctOpen.Date.Date.Date,
                    APR = Double.Parse(tbxAPR.Text),
                    acctName = tbxAcctName.Text,
                    acctType = (AcctType)Enum.Parse(typeof(AcctType), (cbxAcctType.SelectedItem as ComboBoxItem).Name),
                    mnthPayAmnt = double.Parse(tbxMonthlyPay.Text.TrimStart('$'))
                };
                selectedAccount.startBal = (selectedAccount.acctType == AcctType.Credit) ? 0 : double.Parse(tbxOpenBal.Text.TrimStart('$'));
                selectedAccount.creditLimit = (selectedAccount.acctType == AcctType.Credit) ? double.Parse(tbxCredLim.Text.TrimStart('$')) : 0;
                AP.CreateAccount(selectedAccount);
                TP.CreateTransaction(new Trans() { accountID = AP.GetAccountTable().Find(a => a.acctName == selectedAccount.acctName).accountID ,
                entryAmount = double.Parse(tbxCurrBal.Text.TrimStart('$')), Desc="Opening Balance", isInterest=false, entryDate = dteAcctOpen.Date.Date.Date, paymentID = 0 });
                this.Hide();                                
            } else
            {                
                selectedAccount.startDate = dteAcctOpen.Date.Date.Date;
                selectedAccount.APR = Double.Parse(tbxAPR.Text);
                selectedAccount.acctName = tbxAcctName.Text;
                selectedAccount.acctType = (AcctType)System.Enum.Parse(typeof(AcctType), (cbxAcctType.SelectedItem as ComboBoxItem).Name);
                selectedAccount.mnthPayAmnt = double.Parse(tbxMonthlyPay.Text.TrimStart('$'));
                selectedAccount.startBal = (selectedAccount.acctType == AcctType.Credit) ? 0 : double.Parse(tbxOpenBal.Text.TrimStart('$'));
                selectedAccount.creditLimit = (selectedAccount.acctType == AcctType.Credit) ? double.Parse(tbxCredLim.Text.TrimStart('$')) : 0;
                AP.UpdateAccount(selectedAccount);
            }

        }


        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void cbxAcctType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cbxAcctType.SelectedItem as ComboBoxItem).Name == "Credit")
            {
                lblOpenBal.Visibility = Visibility.Collapsed;
                tbxOpenBal.Visibility = Visibility.Collapsed;
                tbxCredLim.Visibility = Visibility.Visible;
                lblCredLimit.Visibility = Visibility.Visible;
            } else
            {
                lblOpenBal.Visibility = Visibility.Visible;
                tbxOpenBal.Visibility = Visibility.Visible;
                tbxCredLim.Visibility = Visibility.Collapsed;
                lblCredLimit.Visibility = Visibility.Collapsed;
            }
        }

        private void tbxOpenBal_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            tbxOpenBal.Text = tbxOpenBal.Text.FormatCurrencyEntry();
            tbxOpenBal.SelectionStart = tbxOpenBal.Text.Length;
            button_check();
        }

        private void tbxCurrBal_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            tbxCurrBal.Text = tbxCurrBal.Text.FormatCurrencyEntry();
            tbxCurrBal.SelectionStart = tbxCurrBal.Text.Length;
            button_check();
        }

        private void tbxAPR_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            tbxAPR.Text = tbxAPR.Text.FormatNumberEntry();
            tbxAPR.SelectionStart = tbxAPR.Text.Length;
            button_check();
        }
        private void tbxAcctName_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            button_check();
        }


        private void button_check()
        {
            var test = cbxAcctType.SelectedItem;
            if (_isEdit == false)
            {
                if (tbxCurrBal.Text == "" || tbxAPR.Text == "" || tbxAcctName.Text == "" || cbxAcctType.SelectedItem == null)
                {
                    this.IsPrimaryButtonEnabled = false;
                }
                else
                {
                    this.IsPrimaryButtonEnabled = true;
                }
            } else
            {
                if (tbxAPR.Text == "" || tbxAcctName.Text == "" || cbxAcctType.SelectedItem == null)
                {
                    this.IsPrimaryButtonEnabled = false;
                }
                else
                {
                    this.IsPrimaryButtonEnabled = true;
                }
            }
        }

        private void tbxMonthlyPay_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            tbxMonthlyPay.Text = tbxMonthlyPay.Text.FormatCurrencyEntry();
            tbxMonthlyPay.SelectionStart = tbxMonthlyPay.Text.Length;
            button_check();
        }

        private void tbxCredLim_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            sender.Text = sender.Text.FormatCurrencyEntry();
            sender.SelectionStart = sender.Text.Length;
            button_check();
        }

        private void bttnDelAssoc_Click(object sender, RoutedEventArgs e)
        {
            selectedAccount.billID = 0;
            AP.UpdateAccount(selectedAccount);
            _mainframe.Navigate(typeof(Tracker));
            this.Hide();
        }

        private void bttnEditAssoc_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();            
        }
    }
}
;