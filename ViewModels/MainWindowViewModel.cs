using DiagramClass.Models;
using DiagramClass.Models.SaverLoder;
using DynamicData;
using ReactiveUI;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.IO;
using System.Reactive;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace DiagramClass.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private MyClass? retyrnedFormSetings;
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
        public MyClass? RetyrnedFormSetings
        {
            get => retyrnedFormSetings;
            set
            {
                retyrnedFormSetings = value;
                CanvasList.Add(retyrnedFormSetings);
            }
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
        public void Save(string path, string extension)
        {
            if (extension == "json")
            {
                ToSerialisedListConverter toSerialisedListConverter = new ToSerialisedListConverter();
                toSerialisedListConverter.Converter(canvasList);

                string? jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(toSerialisedListConverter);
                if (jsonData != null)
                {
                    using (StreamWriter file = new StreamWriter(path, false))
                    {
                        file.Write(jsonData);
                    }
                }
            }
            else if (extension == "xml")
            {
                ToSerialisedListConverter toSerialisedListConverter = new ToSerialisedListConverter();
                toSerialisedListConverter.Converter(canvasList);

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToSerialisedListConverter));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, toSerialisedListConverter);
                }
            }
            else if (extension == "yaml")
            {
                ToSerialisedListConverter toSerialisedListConverter = new ToSerialisedListConverter();
                toSerialisedListConverter.Converter(canvasList);

                Serializer serializer;
                string yaml;

                serializer = (Serializer)new SerializerBuilder().Build();

                yaml = serializer.Serialize(toSerialisedListConverter);
                if (yaml != null)
                {
                    using (StreamWriter file = new StreamWriter(path, false))
                    {
                        file.Write(yaml);
                    }
                }
            }
        }
        public void Load(string path, string extension)
        {
            if (extension == "json")
            {
                CanvasList.Clear();
                using (StreamReader file = new StreamReader(path))
                {
                    ToSerialisedListConverter toSerialisedListConverter = Newtonsoft.Json.JsonConvert.DeserializeObject<ToSerialisedListConverter>(file.ReadToEnd());
                    CanvasList = toSerialisedListConverter.ConverterBack();
                }
            }
            else if (extension == "xml")
            {
                CanvasList.Clear();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToSerialisedListConverter));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    ToSerialisedListConverter toSerialisedListConverter = xmlSerializer.Deserialize(fs) as ToSerialisedListConverter;
                    CanvasList = toSerialisedListConverter.ConverterBack();
                }
            }
            else if (extension == "yaml")
            {
                Deserializer deserializer;

                deserializer = (Deserializer)new DeserializerBuilder().Build();

                using (Stream stream = File.OpenRead(path))
                {
                    using (TextReader reader = new StreamReader(stream))
                    {
                        ToSerialisedListConverter toSerialisedListConverter = deserializer.Deserialize<ToSerialisedListConverter>(reader);
                        CanvasList = toSerialisedListConverter.ConverterBack();
                    }
                }
            }           
        }
    }
}
