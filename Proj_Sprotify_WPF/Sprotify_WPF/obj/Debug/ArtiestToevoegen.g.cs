﻿#pragma checksum "..\..\ArtiestToevoegen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "48E19F845933E157E8890D19534D7DF3F2E7FEAA3EDF565B9F7C595C76834F22"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Sprotify_WPF;
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


namespace Sprotify_WPF {
    
    
    /// <summary>
    /// ArtiestToevoegen
    /// </summary>
    public partial class ArtiestToevoegen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\ArtiestToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbArtiest;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\ArtiestToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbNummer;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ArtiestToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNaam;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ArtiestToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbCheckbox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ArtiestToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRegio;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\ArtiestToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGenre;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\ArtiestToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLengte;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\ArtiestToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPlaten;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\ArtiestToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbArtiest;
        
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
            System.Uri resourceLocater = new System.Uri("/Sprotify_WPF;component/artiesttoevoegen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ArtiestToevoegen.xaml"
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
            
            #line 16 "..\..\ArtiestToevoegen.xaml"
            ((Sprotify_WPF.ArtiestToevoegen)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rbArtiest = ((System.Windows.Controls.RadioButton)(target));
            
            #line 34 "..\..\ArtiestToevoegen.xaml"
            this.rbArtiest.Checked += new System.Windows.RoutedEventHandler(this.Check_Change);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rbNummer = ((System.Windows.Controls.RadioButton)(target));
            
            #line 35 "..\..\ArtiestToevoegen.xaml"
            this.rbNummer.Checked += new System.Windows.RoutedEventHandler(this.Check_Change);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtNaam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.txtRegio = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtGenre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtLengte = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtPlaten = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.cmbArtiest = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            
            #line 48 "..\..\ArtiestToevoegen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Toevoegen_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

