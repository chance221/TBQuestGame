﻿#pragma checksum "..\..\..\PresentationLayer\GameSessionView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C09559F39AF12BBB8872C5A20B9FF8E9153C7099"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TBQuestGame.PresentationLayer;


namespace TBQuestGame.PresentationLayer {
    
    
    /// <summary>
    /// GameSessionView
    /// </summary>
    public partial class GameSessionView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 489 "..\..\..\PresentationLayer\GameSessionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Previous_Area_Button;
        
        #line default
        #line hidden
        
        
        #line 491 "..\..\..\PresentationLayer\GameSessionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Next_Area_Button;
        
        #line default
        #line hidden
        
        
        #line 495 "..\..\..\PresentationLayer\GameSessionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Move_Up;
        
        #line default
        #line hidden
        
        
        #line 497 "..\..\..\PresentationLayer\GameSessionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Move_Down;
        
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
            System.Uri resourceLocater = new System.Uri("/TBQuestGame;component/presentationlayer/gamesessionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PresentationLayer\GameSessionView.xaml"
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
            this.Previous_Area_Button = ((System.Windows.Controls.Button)(target));
            
            #line 489 "..\..\..\PresentationLayer\GameSessionView.xaml"
            this.Previous_Area_Button.Click += new System.Windows.RoutedEventHandler(this.Previous_Area_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Next_Area_Button = ((System.Windows.Controls.Button)(target));
            
            #line 491 "..\..\..\PresentationLayer\GameSessionView.xaml"
            this.Next_Area_Button.Click += new System.Windows.RoutedEventHandler(this.Next_Area_Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Move_Up = ((System.Windows.Controls.Button)(target));
            
            #line 495 "..\..\..\PresentationLayer\GameSessionView.xaml"
            this.Move_Up.Click += new System.Windows.RoutedEventHandler(this.Move_Up_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Move_Down = ((System.Windows.Controls.Button)(target));
            
            #line 497 "..\..\..\PresentationLayer\GameSessionView.xaml"
            this.Move_Down.Click += new System.Windows.RoutedEventHandler(this.Move_Down_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
