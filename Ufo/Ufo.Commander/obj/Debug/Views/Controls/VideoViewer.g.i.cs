﻿#pragma checksum "..\..\..\..\Views\Controls\VideoViewer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6E33265F4AD8CABC90575F3DD9E9A221"
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


namespace Ufo.Commander.Views.Controls {
    
    
    /// <summary>
    /// VideoViewer
    /// </summary>
    public partial class VideoViewer : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Views\Controls\VideoViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrMain;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\Controls\VideoViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement Player;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Views\Controls\VideoViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPlay;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Views\Controls\VideoViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPause;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Views\Controls\VideoViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnStop;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Views\Controls\VideoViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblProgressStatus;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Views\Controls\VideoViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblProgressEnd;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Views\Controls\VideoViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar SliProgress;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Views\Controls\VideoViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider SliVolume;
        
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
            System.Uri resourceLocater = new System.Uri("/Ufo.Commander;component/views/controls/videoviewer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Controls\VideoViewer.xaml"
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
            
            #line 10 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Play_CanExecute);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Play_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 11 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Pause_CanExecute);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Pause_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 12 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Stop_CanExecute);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Stop_Executed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GrMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.Player = ((System.Windows.Controls.MediaElement)(target));
            
            #line 33 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            this.Player.MediaOpened += new System.Windows.RoutedEventHandler(this.MediaOpened);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            this.Player.MediaEnded += new System.Windows.RoutedEventHandler(this.MediaEnded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnPlay = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.BtnPause = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.BtnStop = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.LblProgressStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.LblProgressEnd = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.SliProgress = ((System.Windows.Controls.ProgressBar)(target));
            
            #line 68 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            this.SliProgress.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.SliProgress_OnValueChanged);
            
            #line default
            #line hidden
            
            #line 69 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            this.SliProgress.ManipulationDelta += new System.EventHandler<System.Windows.Input.ManipulationDeltaEventArgs>(this.SliProgress_OnManipulationDelta);
            
            #line default
            #line hidden
            
            #line 70 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            this.SliProgress.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.SliProgress_OnMouseDown);
            
            #line default
            #line hidden
            
            #line 71 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            this.SliProgress.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.SliProgress_OnMouseUp);
            
            #line default
            #line hidden
            return;
            case 12:
            this.SliVolume = ((System.Windows.Controls.Slider)(target));
            
            #line 83 "..\..\..\..\Views\Controls\VideoViewer.xaml"
            this.SliVolume.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.SliVolume_OnValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

