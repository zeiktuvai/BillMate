﻿#pragma checksum "C:\Users\zeiktuvai\Source\Workspaces\Cs Projects\Personal\Bill Tracker-Backend-Update\Bill Tracker\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "132B1BD08779944AFF4A8F8D63A7F8B8"
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
    partial class Login : 
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
            case 2: // Login.xaml line 13
                {
                    this.tbxPass = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                    ((global::Windows.UI.Xaml.Controls.PasswordBox)this.tbxPass).KeyDown += this.tbxPass_KeyDown;
                }
                break;
            case 3: // Login.xaml line 14
                {
                    this.bttnLoginP = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.bttnLoginP).Click += this.bttnLoginP_Click;
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

