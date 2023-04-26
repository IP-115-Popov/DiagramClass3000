using Avalonia.Controls;
using DiagramClass.Models;
using DiagramClass.ViewModels;
using ReactiveUI;
using System.Reactive;

namespace DiagramClass.Views
{
    public partial class SettingsClassView : Window
    {
        public SettingsClassView()
        {
            InitializeComponent();
            DataContext = new SettingsClassViewModel();

            CloseMyWindow = ReactiveCommand.Create<Unit, MyClass>(
                _ =>
                new MyClass()
                {

                }
                );
        }
        public ReactiveCommand<Unit, MyClass> CloseMyWindow;
    }
}
