﻿#pragma checksum "..\..\Profil.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99044E87AED3F6B669F9D7C87BEB10E9EE294CBE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ObicanKorisnik;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ObicanKorisnik {
    
    
    /// <summary>
    /// Profil
    /// </summary>
    public partial class Profil : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Profil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEmail;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Profil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUsername;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Profil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPassword;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Profil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPasswordConfirm;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Profil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzmeni;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Profil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOdjava;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Profil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEnableIzmenu;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Profil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbProfilID;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ObicanKorisnik;component/profil.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Profil.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbPasswordConfirm = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnIzmeni = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Profil.xaml"
            this.btnIzmeni.Click += new System.Windows.RoutedEventHandler(this.BtnIzmeni_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnOdjava = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Profil.xaml"
            this.btnOdjava.Click += new System.Windows.RoutedEventHandler(this.BtnOdjava_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnEnableIzmenu = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Profil.xaml"
            this.btnEnableIzmenu.Click += new System.Windows.RoutedEventHandler(this.BtnEnableIzmenu_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tbProfilID = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

