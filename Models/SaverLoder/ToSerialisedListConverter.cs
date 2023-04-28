using DiagramClass.Models.Connectors;
using DynamicData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiagramClass.Models.SaverLoder
{
    public class ToSerialisedListConverter
    {
        //private List<MyClassForSaveLoad> myClassList;
        //private List<InheritanceConnectorForSaveLoad> inheritanceConnectorList;
        //private List<ImplementationConnectorForSaveLoad> implementationConnectorList;
        //private List<AddictionConnectorForSaveLoad> addictionConnectorList;
        //private List<AggregationConnectorForSaveLoad> aggregationConnectorList;
        //private List<CompositionConnectorForSaveLoad> compositionConnectorList;
        //private List<AssociationConnectorForSaveLoad> associationConnectorList;
        public ToSerialisedListConverter() 
        {
            MyClassList = new List<MyClassForSaveLoad>();
            InheritanceConnectorList = new List<InheritanceConnectorForSaveLoad>();
            ImplementationConnectorList = new List<ImplementationConnectorForSaveLoad>();
            AddictionConnectorList = new List<AddictionConnectorForSaveLoad>();
            AggregationConnectorList = new List<AggregationConnectorForSaveLoad>();
            CompositionConnectorList = new List<CompositionConnectorForSaveLoad>();
            AssociationConnectorList = new List<AssociationConnectorForSaveLoad>();
        }
        public void Converter(ObservableCollection<object> myLst)
        {
            foreach (object i in myLst)
            {
                if (i is MyClass)
                {
                    MyClassList.Add(new MyClassForSaveLoad()
                    {
                        Margin = ((MyClass)i).Margin,
                        MyType = ((MyClass)i).MyType,
                        Attribute = ((MyClass)i).Attribute,
                        Name = ((MyClass)i).Name,
                        MethodList = new List<Metod>(),
                        PropertiList = new List<Properti>()
                    });
                    foreach(Metod metod in ((MyClass)i).MethodList)
                    {
                        MyClassList[MyClassList.Count - 1].MethodList.Add(metod);
                    }
                    foreach (Properti properti in ((MyClass)i).PropertiList)
                    {
                        MyClassList[MyClassList.Count - 1].PropertiList.Add(properti);
                    }
                }
                else if (i is InheritanceConnector)
                {
                    InheritanceConnectorList.Add(new InheritanceConnectorForSaveLoad()
                    {
                        StartPoint = (((InheritanceConnector)i).StartPoint).ToString(),
                        EndPoint = (((InheritanceConnector)i).EndPoint).ToString(),
                        AngleHead = ((InheritanceConnector)i).AngleHead
                    });
                }
                else if (i is ImplementationConnector)
                {
                    ImplementationConnectorList.Add(new ImplementationConnectorForSaveLoad()
                    {
                        StartPoint = (((ImplementationConnector)i).StartPoint).ToString(),
                        EndPoint = (((ImplementationConnector)i).EndPoint).ToString(),
                        AngleHead = ((ImplementationConnector)i).AngleHead
                    });
                }
                else if (i is AddictionConnector)
                {
                    AddictionConnectorList.Add(new AddictionConnectorForSaveLoad()
                    {
                        StartPoint = (((AddictionConnector)i).StartPoint).ToString(),
                        EndPoint = (((AddictionConnector)i).EndPoint).ToString(),
                        AngleHead = ((AddictionConnector)i).AngleHead
                    });
                }
                else if (i is AggregationConnector)
                {
                    AggregationConnectorList.Add(new()
                    {
                        StartPoint = (((AggregationConnector)i).StartPoint).ToString(),
                        EndPoint = (((AggregationConnector)i).EndPoint).ToString(),
                        AngleHead = ((AggregationConnector)i).AngleHead
                    });
                }
                else if (i is CompositionConnector)
                {
                    CompositionConnectorList.Add(new CompositionConnectorForSaveLoad()
                    {
                        StartPoint = (((CompositionConnector)i).StartPoint).ToString(),
                        EndPoint = (((CompositionConnector)i).EndPoint).ToString(),
                        AngleHead = ((CompositionConnector)i).AngleHead
                    });
                }
                else if (i is AssociationConnector)
                {
                    AssociationConnectorList.Add(new AssociationConnectorForSaveLoad()
                    {
                        StartPoint = (((AssociationConnector)i).StartPoint).ToString(),
                        EndPoint = (((AssociationConnector)i).EndPoint).ToString(),
                        AngleHead = ((AssociationConnector)i).AngleHead
                    });
                }
            }
        }
        public ObservableCollection<object>? ConverterBack()
        {
            ObservableCollection<object> rezList = new ObservableCollection<object>();
            foreach (MyClassForSaveLoad i in MyClassList)
            {
                rezList.Add(new MyClass()
                {
                    Margin = i.Margin,
                    MyType = i.MyType,
                    Attribute = i.Attribute,
                    Name = i.Name,
                    MethodList = new ObservableCollection<Metod>(),
                    PropertiList = new ObservableCollection<Properti>()
                });
                foreach (Metod metod in i.MethodList)
                {
                    ((MyClass)(rezList[rezList.Count - 1])).MethodList.Add(metod);
                }
                foreach (Properti properti in i.PropertiList)
                {
                    ((MyClass)(rezList[rezList.Count - 1])).PropertiList.Add(properti);
                }         
            }
            foreach (InheritanceConnectorForSaveLoad i in InheritanceConnectorList)
            {
                rezList.Add(new InheritanceConnector()
                {
                    StartPoint = Avalonia.Point.Parse(i.StartPoint),
                    EndPoint = Avalonia.Point.Parse(i.EndPoint),
                    AngleHead = i.AngleHead
                }); 
            }
            foreach (ImplementationConnectorForSaveLoad i in ImplementationConnectorList)
            {
                rezList.Add(new ImplementationConnector()
                {
                    StartPoint = Avalonia.Point.Parse(i.StartPoint),
                    EndPoint = Avalonia.Point.Parse(i.EndPoint),
                    AngleHead = i.AngleHead
                });
            }
            foreach (AddictionConnectorForSaveLoad i in AddictionConnectorList)
            {
                rezList.Add(new AddictionConnector()
                {
                    StartPoint = Avalonia.Point.Parse(i.StartPoint),
                    EndPoint = Avalonia.Point.Parse(i.EndPoint),
                    AngleHead = i.AngleHead
                });
            }
            foreach (AggregationConnectorForSaveLoad i in AggregationConnectorList)
            {
                rezList.Add(new AggregationConnector()
                {
                    StartPoint = Avalonia.Point.Parse(i.StartPoint),
                    EndPoint = Avalonia.Point.Parse(i.EndPoint),
                    AngleHead = i.AngleHead
                });
            }
            foreach (CompositionConnectorForSaveLoad i in CompositionConnectorList)
            {
                rezList.Add(new CompositionConnector()
                {
                    StartPoint = Avalonia.Point.Parse(i.StartPoint),
                    EndPoint = Avalonia.Point.Parse(i.EndPoint),
                    AngleHead = i.AngleHead
                });
            }
            foreach (AssociationConnectorForSaveLoad i in AssociationConnectorList)
            {
                rezList.Add(new AssociationConnector()
                {
                    StartPoint = Avalonia.Point.Parse(i.StartPoint),
                    EndPoint = Avalonia.Point.Parse(i.EndPoint),
                    AngleHead = i.AngleHead
                });
            }
            return rezList;
        }
        public List<MyClassForSaveLoad> MyClassList { get; set; }
        public List<InheritanceConnectorForSaveLoad> InheritanceConnectorList { get; set; }
        public List<ImplementationConnectorForSaveLoad> ImplementationConnectorList { get; set; }
        public List<AddictionConnectorForSaveLoad> AddictionConnectorList { get; set; }
        public List<AggregationConnectorForSaveLoad> AggregationConnectorList { get; set; }
        public List<CompositionConnectorForSaveLoad> CompositionConnectorList { get; set; }
        public List<AssociationConnectorForSaveLoad> AssociationConnectorList { get; set; }
    }
}
