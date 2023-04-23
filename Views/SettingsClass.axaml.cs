using Avalonia.Controls;
using DiagramClass.Models;
using ReactiveUI;
using System.Reactive;

namespace DiagramClass.Views
{
    public partial class SettingsClass : Window
    {
        public SettingsClass()
        {
            InitializeComponent();
            CloseMyWindow = ReactiveCommand.Create<Unit, MyClass>(
                _ =>
                new MyClass()
                {

                }
                );
        }
        private string? mod;
        public string? Mod
        {
            get;
            set;
        }
        public ReactiveCommand<Unit, MyClass> CloseMyWindow;
    }
}
