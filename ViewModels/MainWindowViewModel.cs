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
        private bool inheritance;
        private bool implementation;
        private bool addiction;
        private bool aggregation;
        private bool composition;
        private bool association;
        private ObservableCollection<object> canvasList;
        public MainWindowViewModel()
        {
            canvasList = new ObservableCollection<object>
            {
                new MyClass(),
                 new MyClass() { Margin = "400,300" }
            };
        }
        public ObservableCollection<object> CanvasList
        {
            get => canvasList;
            set => this.RaiseAndSetIfChanged(ref canvasList, value);
        }

        public bool Inheritance
        {
            get => inheritance;
            set => this.RaiseAndSetIfChanged(ref inheritance, value);
        }
        public bool Implementation
        {
            get => implementation;
            set => this.RaiseAndSetIfChanged(ref implementation, value);
        }
        public bool Addiction
        {
            get => addiction;
            set => this.RaiseAndSetIfChanged(ref addiction, value);
        }
        public bool Aggregation
        {
            get => aggregation;
            set => this.RaiseAndSetIfChanged(ref aggregation, value);
        }
        public bool Composition
        {
            get => composition;
            set => this.RaiseAndSetIfChanged(ref composition, value);
        }
        public bool Association
        {
            get => association;
            set => this.RaiseAndSetIfChanged(ref association, value);
        }
    }
}
