﻿#pragma checksum "C:\Users\zeiktuvai\Source\Workspaces\Cs Projects\Personal\Bill Tracker-Backend-Update\Bill Tracker\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "442EB923A563EDD73A6C8CDAAB7E066E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bill_Tracker
{
    partial class MainPage : 
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
            case 1: // MainPage.xaml line 1
                {
                    this.BillMate = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)this.BillMate).Loaded += this.BillMate_Loaded;
                }
                break;
            case 16: // MainPage.xaml line 166
                {
                    this.VisualStateGroup = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 17: // MainPage.xaml line 167
                {
                    this.VisualStatePhone = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 18: // MainPage.xaml line 175
                {
                    this.VisualStateTablet = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 19: // MainPage.xaml line 193
                {
                    this.menSplit = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 20: // MainPage.xaml line 196
                {
                    this.lstMen = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.lstMen).SelectionChanged += this.lstMen_SelectionChanged;
                }
                break;
            case 21: // MainPage.xaml line 273
                {
                    this.lstSttngs = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.lstSttngs).SelectionChanged += this.lstSttngs_SelectionChanged;
                }
                break;
            case 22: // MainPage.xaml line 287
                {
                    this.bttnSttngs = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.bttnSttngs).Click += this.bttnSttngs_Click;
                }
                break;
            case 23: // MainPage.xaml line 274
                {
                    this.Feedback = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 24: // MainPage.xaml line 280
                {
                    this.Settings = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 25: // MainPage.xaml line 197
                {
                    this.Home = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 26: // MainPage.xaml line 203
                {
                    this.Bills = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 27: // MainPage.xaml line 222
                {
                    this.Calendar = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 28: // MainPage.xaml line 228
                {
                    this.Ledger = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 29: // MainPage.xaml line 234
                {
                    this.Single = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 30: // MainPage.xaml line 240
                {
                    this.History = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 31: // MainPage.xaml line 246
                {
                    this.Debt = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 32: // MainPage.xaml line 252
                {
                    this.SaveGoal = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 33: // MainPage.xaml line 258
                {
                    this.IOU = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 34: // MainPage.xaml line 264
                {
                    this.Tools = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 35: // MainPage.xaml line 210
                {
                    this.menDueBillNotification = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                }
                break;
            case 36: // MainPage.xaml line 216
                {
                    this.menDueBill = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                }
                break;
            case 37: // MainPage.xaml line 217
                {
                    this.lblMenDueBill = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 38: // MainPage.xaml line 297
                {
                    this.mainFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    ((global::Windows.UI.Xaml.Controls.Frame)this.mainFrame).Navigated += this.mainFrame_Navigated;
                }
                break;
            case 39: // MainPage.xaml line 188
                {
                    this.bttnHmbrgr = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.bttnHmbrgr).Click += this.HamburgerButton_Click;
                }
                break;
            case 40: // MainPage.xaml line 189
                {
                    this.tbxTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
