﻿

#pragma checksum "C:\Users\swanand.pathak\documents\visual studio 2013\Projects\MessengerApp\MessengerApp\PivotPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E5929254CE26EBF13F9EAF89752F35B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MessengerApp
{
    partial class PivotPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 27 "..\..\PivotPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.AddAppBarButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 75 "..\..\PivotPage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.MyMap_Loaded;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 42 "..\..\PivotPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.ItemView_ItemClick;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


