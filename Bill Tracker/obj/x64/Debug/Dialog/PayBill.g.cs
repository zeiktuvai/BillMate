﻿#pragma checksum "C:\Users\zeiktuvai\Source\Workspaces\Cs Projects\Personal\Bill Tracker-Backend-Update\Bill Tracker\Dialog\PayBill.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4D325EDD0F532A47E9733CD001D18BC9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bill_Tracker.Dialog
{
    partial class PayBill : 
        global::Windows.UI.Xaml.Controls.ContentDialog, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Dialog\PayBill.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.ContentDialog_PrimaryButtonClick;
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.ContentDialog_SecondaryButtonClick;
                }
                break;
            case 2: // Dialog\PayBill.xaml line 17
                {
                    this.PayDiag_lblAmnt = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // Dialog\PayBill.xaml line 18
                {
                    this.PayDiag_tbxAmnt = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.PayDiag_tbxAmnt).TextChanging += this.payDiag_tbxAmnt_TextChanging;
                }
                break;
            case 4: // Dialog\PayBill.xaml line 19
                {
                    this.PayDiag_lblDatePay = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // Dialog\PayBill.xaml line 20
                {
                    this.PayDiag_dtePaid = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
