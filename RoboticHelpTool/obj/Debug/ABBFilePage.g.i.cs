﻿#pragma checksum "..\..\ABBFilePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4AE1517C5939D65632A9C4AB58D77C11D57941CAA11756D70B5C0F093F3EF449"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using RoboticHelpTool;
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


namespace RoboticHelpTool {
    
    
    /// <summary>
    /// ABBFilePage
    /// </summary>
    public partial class ABBFilePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\ABBFilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar Prb;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ABBFilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DateiZiel;
        
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
            System.Uri resourceLocater = new System.Uri("/RoboticHelpTool;component/abbfilepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ABBFilePage.xaml"
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
            this.Prb = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 2:
            this.DateiZiel = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\ABBFilePage.xaml"
            this.DateiZiel.PreviewDragOver += new System.Windows.DragEventHandler(this.DateiZiel_PreviewDragOver);
            
            #line default
            #line hidden
            
            #line 13 "..\..\ABBFilePage.xaml"
            this.DateiZiel.PreviewDrop += new System.Windows.DragEventHandler(this.DateiZiel_PreviewDrop);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 15 "..\..\ABBFilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Einlesen);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 16 "..\..\ABBFilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Ausgeben);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 17 "..\..\ABBFilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Umrechnen);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 18 "..\..\ABBFilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.XYZShift_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 19 "..\..\ABBFilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RelTool_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 20 "..\..\ABBFilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Mirror_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 21 "..\..\ABBFilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Multi_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 22 "..\..\ABBFilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Bereinigen);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 23 "..\..\ABBFilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Sortieren);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 24 "..\..\ABBFilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Einlesen_Bereinigen_Sortieren);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

