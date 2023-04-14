using DiagramClass.Models;
using ReactiveUI;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiagramClass.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<MyClass> canvasList;
        public MainWindowViewModel()
        {
            canvasList = new ObservableCollection<MyClass>
            {
                new MyClass()
            };
        }
        private ObservableCollection<MyClass> CanvasList
        {
            get => canvasList;
            set => this.RaiseAndSetIfChanged(ref canvasList, value);
        }

    }
}
