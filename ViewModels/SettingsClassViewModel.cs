using DiagramClass.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using DynamicData;
using SkiaSharp;
using System.Drawing.Printing;
using System.Xml.Linq;

namespace DiagramClass.ViewModels
{
    public class SettingsClassViewModel : ViewModelBase
    {
        public string? myType;
        public string? margin;

        private string? attribute;
        private string? name;
        private ObservableCollection<Metod>? methodList;
        private ObservableCollection<Properti>? propertiList;
        private Metod selectedMethod;
        private Properti selectedProperti;
        //настроики метода
        private string? attributeСhangeMethod;
        private string? tupeСhangeMethod;
        private string? nameСhangeMethod;
        private string? argumentsСhangeMethod;
        //настройки своиства
        private string? attributeСhangeProperti;
        private string? tupeСhangeProperti;
        private string? nameСhangeProperti;
        public SettingsClassViewModel()
        {
            Attribute = "private";
            methodList = new ObservableCollection<Metod>();
            propertiList = new ObservableCollection<Properti>();
            AddMethod = ReactiveCommand.Create(() =>
            {
                methodList.Add(new Metod()
                {
                    Аccess = attributeСhangeMethod,
                    Return = tupeСhangeMethod,
                    Name = nameСhangeMethod,
                    Arguments = argumentsСhangeMethod
                });
            });
            AddProperti = ReactiveCommand.Create(() =>
            {
                propertiList.Add(new Properti()
                {
                    Аccess = attributeСhangeProperti,
                    Return = tupeСhangeProperti,
                    Name = nameСhangeProperti
                });
            });

        }
        public string? Attribute
        {
            get => attribute;
            set => this.RaiseAndSetIfChanged(ref attribute, value);
        }
        public string? Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }
        public ObservableCollection<Metod>? MethodList
        {
            get => methodList;
            set => this.RaiseAndSetIfChanged(ref methodList, value);
        }
        public ObservableCollection<Properti>? PropertiList
        {
            get => propertiList;
            set => this.RaiseAndSetIfChanged(ref propertiList, value);
        }
        public Metod SelectedMethod
        {
            get => selectedMethod;
            set => this.RaiseAndSetIfChanged(ref selectedMethod, value);
        }
        public Properti  SelectedProperti
        {
            get => selectedProperti;
            set => this.RaiseAndSetIfChanged(ref selectedProperti, value);
        }
        //своиства метода
        public string? AttributeСhangeMethod
        {
            get => attributeСhangeMethod;
            set => this.RaiseAndSetIfChanged(ref attributeСhangeMethod, value);
        }
        public string? TupeСhangeMethod
        {
            get => tupeСhangeMethod;
            set => this.RaiseAndSetIfChanged(ref tupeСhangeMethod, value);
        }
        public string? NameСhangeMethod
        {
            get => nameСhangeMethod;
            set => this.RaiseAndSetIfChanged(ref nameСhangeMethod, value);
        }
        public string? ArgumentsСhangeMethod
        {
            get => argumentsСhangeMethod;
            set => this.RaiseAndSetIfChanged(ref argumentsСhangeMethod, value);
        }
        //своиства своиств
        public string? AttributeСhangeProperti
        {
            get => attributeСhangeProperti;
            set => this.RaiseAndSetIfChanged(ref attributeСhangeProperti, value);
        }
        public string? TupeСhangeProperti
        {
            get => tupeСhangeProperti;
            set => this.RaiseAndSetIfChanged(ref tupeСhangeProperti, value);
        }
        public string? NameСhangeProperti
        {
            get => nameСhangeProperti;
            set => this.RaiseAndSetIfChanged(ref nameСhangeProperti, value);
        }
        public ReactiveCommand<Unit, Unit> AddMethod { get; set; }
        public ReactiveCommand<Unit, Unit> AddProperti { get; set; }

        //public ReactiveCommand<Unit, MyClass> RetyrnedMyClass { get; set; }
        public MyClass RetyrnedMyClassF()
        {
            return new MyClass()
            { 
                Margin = this.margin,
                MyType = this.myType,
                Attribute = this.Attribute,
                Name = this.Name,
                MethodList = this.methodList,
                PropertiList = this.PropertiList,
            };
        }
    }
}
