﻿#pragma checksum "C:\Users\zeiktuvai\Source\Workspaces\Cs Projects\Personal\Bill Tracker-Backend-Update\Bill Tracker\Dialog\addBill.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7AA928CE075750207DD8F9E88A1A214F"
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
    partial class addBill : 
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
            case 1: // Dialog\addBill.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.ContentDialog_PrimaryButtonClick;
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.ContentDialog_SecondaryButtonClick;
                }
                break;
            case 2: // Dialog\addBill.xaml line 36
                {
                    this.tbxName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.tbxName).TextChanged += this.tbxName_TextChanged;
                }
                break;
            case 3: // Dialog\addBill.xaml line 37
                {
                    this.cbxFreq = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cbxFreq).SelectionChanged += this.cbxFreq_SelectionChanged;
                }
                break;
            case 4: // Dialog\addBill.xaml line 44
                {
                    this.tbxDue = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 5: // Dialog\addBill.xaml line 45
                {
                    this.tbxDue2 = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 6: // Dialog\addBill.xaml line 46
                {
                    this.cbxDayDue = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 7: // Dialog\addBill.xaml line 55
                {
                    this.tbxAmnt = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.tbxAmnt).TextChanging += this.tbxAmnt_TextChanging;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.tbxAmnt).TextChanged += this.tbxName_TextChanged;
                }
                break;
            case 8: // Dialog\addBill.xaml line 56
                {
                    this.tbxCat = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // Dialog\addBill.xaml line 57
                {
                    this.cbkRemind = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 10: // Dialog\addBill.xaml line 47
                {
                    this.Monday = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 11: // Dialog\addBill.xaml line 48
                {
                    this.Tuesday = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 12: // Dialog\addBill.xaml line 49
                {
                    this.Wednesday = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 13: // Dialog\addBill.xaml line 50
                {
                    this.Thursday = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 14: // Dialog\addBill.xaml line 51
                {
                    this.Friday = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 15: // Dialog\addBill.xaml line 52
                {
                    this.Saturday = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 16: // Dialog\addBill.xaml line 53
                {
                    this.Sunday = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 17: // Dialog\addBill.xaml line 38
                {
                    this.lbxFreqMonth = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 18: // Dialog\addBill.xaml line 39
                {
                    this.lbxFreqBiM = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 19: // Dialog\addBill.xaml line 40
                {
                    this.lbxFreqWkly = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 20: // Dialog\addBill.xaml line 41
                {
                    this.lbxFreqAnnl = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 21: // Dialog\addBill.xaml line 42
                {
                    this.lbxOTP = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 22: // Dialog\addBill.xaml line 28
                {
                    this.lblDueDate = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 23: // Dialog\addBill.xaml line 29
                {
                    this.lblDueDate2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 24: // Dialog\addBill.xaml line 30
                {
                    this.lblDueDay = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 25: // Dialog\addBill.xaml line 31
                {
                    this.lblAmnt = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 26: // Dialog\addBill.xaml line 32
                {
                    this.lblCat = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

