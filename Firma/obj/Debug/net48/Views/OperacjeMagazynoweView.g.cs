﻿#pragma checksum "..\..\..\..\Views\OperacjeMagazynoweView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E4297206F11B4902041974995B320F769C509D8B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Firma.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Firma.Views {
    
    
    /// <summary>
    /// OperacjeMagazynoweView
    /// </summary>
    public partial class OperacjeMagazynoweView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 202 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbZlecone;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbBufor;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbZatwierdzone;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbWszystkie;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Firma;component/views/operacjemagazynoweview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbZlecone = ((System.Windows.Controls.CheckBox)(target));
            
            #line 202 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
            this.cbZlecone.Checked += new System.Windows.RoutedEventHandler(this.cb_CheckedChanged);
            
            #line default
            #line hidden
            
            #line 202 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
            this.cbZlecone.Unchecked += new System.Windows.RoutedEventHandler(this.cb_CheckedChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbBufor = ((System.Windows.Controls.CheckBox)(target));
            
            #line 203 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
            this.cbBufor.Checked += new System.Windows.RoutedEventHandler(this.cb_CheckedChanged);
            
            #line default
            #line hidden
            
            #line 203 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
            this.cbBufor.Unchecked += new System.Windows.RoutedEventHandler(this.cb_CheckedChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbZatwierdzone = ((System.Windows.Controls.CheckBox)(target));
            
            #line 204 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
            this.cbZatwierdzone.Checked += new System.Windows.RoutedEventHandler(this.cb_CheckedChanged);
            
            #line default
            #line hidden
            
            #line 204 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
            this.cbZatwierdzone.Unchecked += new System.Windows.RoutedEventHandler(this.cb_CheckedChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbWszystkie = ((System.Windows.Controls.CheckBox)(target));
            
            #line 205 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
            this.cbWszystkie.Checked += new System.Windows.RoutedEventHandler(this.cbWszystkie_CheckedChanged);
            
            #line default
            #line hidden
            
            #line 205 "..\..\..\..\Views\OperacjeMagazynoweView.xaml"
            this.cbWszystkie.Unchecked += new System.Windows.RoutedEventHandler(this.cbWszystkie_CheckedChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

