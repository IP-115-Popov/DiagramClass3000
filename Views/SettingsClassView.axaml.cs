using Avalonia.Controls;
using Avalonia.ReactiveUI;
using DiagramClass.Models;
using DiagramClass.ViewModels;
using ReactiveUI;
using System;
using System.Reactive;

namespace DiagramClass.Views
{
    public partial class SettingsClassView :  ReactiveWindow<SettingsClassViewModel>
    {
        public SettingsClassView()
        {
            InitializeComponent();
            DataContext = new SettingsClassViewModel();

            if (this.DataContext is SettingsClassViewModel dataContext) 
            {
                //RetyrnedMyClass передаст MyClass в Close который пиринемает object и там где вызвано окно вернйтся MyClass
                //dataContext.RetyrnedMyClass.Subscribe(Close);
                this.WhenActivated(d => d(dataContext.RetyrnedMyClass.Subscribe(Close)));
            }
            //this.WhenActivated(d => d(ViewModel!.RetyrnedMyClass.Subscribe(Close)));
        }
    }
}
