using DiagramClass.Models;
using DynamicData;
using ReactiveUI;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Reactive;
using System.Text;
using System.Xml.Linq;

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
        private bool drawClass;
        private bool drawInterface;
        private ObservableCollection<object> canvasList;
        public MainWindowViewModel()
        {
            canvasList = new ObservableCollection<object>
            {
                new MyClass()
                {
                    Attribute ="public",
                    Name = "Name",
                    MyType ="Class",
                }
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
        public bool DrawClass
        {
            get => drawClass;
            set => this.RaiseAndSetIfChanged(ref drawClass, value);
        }
        public bool DrawInterface
        {
            get => drawInterface;
            set => this.RaiseAndSetIfChanged(ref drawInterface, value);
        }
        public void AddClassOnCanvas()
        {
            canvasList.Add(new MyClass()
            {
                MyType = "Class",
                Margin = "0,0"
            });
        }
        public void AddInterfaceOnCanvas()
        {
            canvasList.Add(new MyClass()
            {
                MyType = "Interface",
                Margin = "0,0"
            });
        }
    }
}
