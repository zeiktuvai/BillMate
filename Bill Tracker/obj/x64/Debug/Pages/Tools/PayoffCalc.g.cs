﻿#pragma checksum "C:\Users\zeiktuvai\Source\Workspaces\Cs Projects\Personal\Bill Tracker-Backend-Update\Bill Tracker\Pages\Tools\PayoffCalc.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "11E2DE61E702013A726AA4BFB1302308"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bill_Tracker.Pages.Tools
{
    partial class PayoffCalc : 
        global::Windows.UI.Xaml.Controls.Page, 
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
            case 2: // Pages\Tools\PayoffCalc.xaml line 26
                {
                    this.lvAcct = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 3: // Pages\Tools\PayoffCalc.xaml line 94
                {
                    this.addAccount = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.addAccount).Click += this.addAccount_Click;
                }
                break;
            case 5: // Pages\Tools\PayoffCalc.xaml line 37
                {
                    global::Windows.UI.Xaml.Controls.TextBox element5 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)element5).KeyDown += this.tbxAcctName_KeyDown;
                    ((global::Windows.UI.Xaml.Controls.TextBox)element5).LostFocus += this.tbxAcctName_LostFocus;
                }
                break;
            case 7: // Pages\Tools\PayoffCalc.xaml line 85
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element7 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element7).Click += this.bttnDel_Click;
                }
                break;
            case 12: // Pages\Tools\PayoffCalc.xaml line 41
                {
                    global::Windows.UI.Xaml.Controls.TextBox element12 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)element12).KeyDown += this.tbxStart_KeyDown;
                    ((global::Windows.UI.Xaml.Controls.TextBox)element12).LostFocus += this.tbxStart_LostFocus;
                }
                break;
            case 13: // Pages\Tools\PayoffCalc.xaml line 43
                {
                    global::Windows.UI.Xaml.Controls.TextBox element13 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)element13).KeyDown += this.tbxMonthly_KeyDown;
                    ((global::Windows.UI.Xaml.Controls.TextBox)element13).LostFocus += this.tbxMonthly_LostFocus;
                }
                break;
            case 14: // Pages\Tools\PayoffCalc.xaml line 45
                {
                    global::Windows.UI.Xaml.Controls.TextBox element14 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)element14).KeyDown += this.tbxStart_KeyDown;
                    ((global::Windows.UI.Xaml.Controls.TextBox)element14).LostFocus += this.tbxStart_LostFocus;
                }
                break;
            case 15: // Pages\Tools\PayoffCalc.xaml line 20
                {
                    this.cbxNextMonth = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                    ((global::Windows.UI.Xaml.Controls.CheckBox)this.cbxNextMonth).Checked += this.cbxNextMonth_Checked;
                    ((global::Windows.UI.Xaml.Controls.CheckBox)this.cbxNextMonth).Unchecked += this.cbxNextMonth_Checked;
                }
                break;
            case 16: // Pages\Tools\PayoffCalc.xaml line 21
                {
                    this.sep1 = (global::Windows.UI.Xaml.Controls.AppBarSeparator)(target);
                }
                break;
            case 17: // Pages\Tools\PayoffCalc.xaml line 22
                {
                    this.lblAutoSave = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // Pages\Tools\PayoffCalc.xaml line 23
                {
                    this.tgglAutoSave = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                    ((global::Windows.UI.Xaml.Controls.ToggleSwitch)this.tgglAutoSave).Toggled += this.tgglAutoSave_Toggled;
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

