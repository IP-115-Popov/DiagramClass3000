using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using DiagramClass.Models;
using DiagramClass.ViewModels;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace DiagramClass.Views
{
    public partial class SettingsClassView : Window
    {
        public SettingsClassView()
        {
            InitializeComponent();
            DataContext = new SettingsClassViewModel();
        }
        public SettingsClassView(MyClass myClass)
        {         
                InitializeComponent();
            DataContext = new SettingsClassViewModel();
            if (myClass != null)
            {
                if (this.DataContext is SettingsClassViewModel dataContext)
                {
                    dataContext.margin = myClass.Margin;
                    dataContext.myType = myClass.MyType;
                    dataContext.Attribute = myClass.Attribute;
                    dataContext.Name = myClass.Name;
                    dataContext.MethodList = myClass.MethodList;
                    dataContext.PropertiList = myClass.PropertiList;
                }
            }
        }
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is SettingsClassViewModel dataContext)
            {
                Close(dataContext.RetyrnedMyClassF());
            }
        }
    }
}
