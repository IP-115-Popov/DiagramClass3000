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
        private ObservableCollection<object> canvasList;
        public MainWindowViewModel()
        {
            canvasList = new ObservableCollection<object>
            {
                new MyClass()
            };
        }
        private ObservableCollection<object> CanvasList
        {
            get => canvasList;
            set => this.RaiseAndSetIfChanged(ref canvasList, value);
        }

    }
}
