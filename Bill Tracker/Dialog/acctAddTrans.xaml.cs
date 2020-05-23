using BillMate.Services.ViewModel.Models;
using BillMate.Services.ViewModel.Providers;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Bill_Tracker.Dialog
{
    public sealed partial class acctAddTrans : ContentDialog
    {
        Account _account;
        internal AccountDataProvider AP { get; set; }
        internal TransactionDataProvider TP { get; set; }
        public acctAddTrans(Account acct)
        {
            this.InitializeComponent();
            AP = new AccountDataProvider();
            TP = new TransactionDataProvider();
            _account = acct;
            this.Title = _account.acctName + ": Add Transaction";
            cbxTransAction.SelectedIndex = 0;
            Charge.Visibility = (_account.acctType == AcctType.Loan) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            double amount = 0;
            double interest = 0;

            if (_account.dispBal.ToCurrency() != 0)
            {

                switch ((cbxTransAction.SelectedItem as ComboBoxItem).Content)
                {
                    case "Payment":
                        if (_account.acctType == AcctType.Loan)
                        {
                                amount = AP.CalculateLoanPaymentPrincipal(_account.APR, AP.getAcctBal(_account), tbxAmnt.Text.ToCurrency());
                                interest = Math.Truncate(AP.CalculateMonthlyInterest(AP.getAcctBal(_account), _account.APR) * 100) / 100;
                        }
                        else
                        {
                            amount = tbxAmnt.Text.ToCurrency();
                            interest = 0;
                        }
                        break;
                    case "Charge":
                        amount = tbxAmnt.Text.ToCurrency();
                        break;
                
                }

                Trans aTrans = new Trans()
                {
                    accountID = _account.accountID,
                    entryAmount = amount,
                    intrestAmount = interest,
                    Desc = (tbxDesc.Text == "") ? (cbxTransAction.SelectedItem as ComboBoxItem).Content.ToString() : tbxDesc.Text,
                    isInterest = false,
                    entryDate = dtePaid.Date.Date.Date
                };

                TP.CreateTransaction(aTrans);

            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void text_change(TextBox sender, TextBoxTextChangingEventArgs e)
        {
            sender.Text = sender.Text.FormatCurrencyEntry();
            sender.SelectionStart = sender.Text.Length;
        }
    }
}
