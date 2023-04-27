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
        private List<MyClassForSaveLoad> myClassList;
        private List<InheritanceConnectorForSaveLoad> inheritanceConnectorList;
        private List<ImplementationConnectorForSaveLoad> implementationConnectorList;
        private List<AddictionConnectorForSaveLoad> addictionConnectorList;
        private List<AggregationConnectorForSaveLoad> aggregationConnectorList;
        private List<CompositionConnectorForSaveLoad> compositionConnectorList;
        private List<AssociationConnectorForSaveLoad> associationConnectorList;
        public ToSerialisedListConverter() 
        {
            myClassList = new List<MyClassForSaveLoad>();
            inheritanceConnectorList = new List<InheritanceConnectorForSaveLoad>();
            implementationConnectorList = new List<ImplementationConnectorForSaveLoad>();
            addictionConnectorList = new List<AddictionConnectorForSaveLoad>();
            aggregationConnectorList = new List<AggregationConnectorForSaveLoad>();
            compositionConnectorList = new List<CompositionConnectorForSaveLoad>();
            associationConnectorList = new List<AssociationConnectorForSaveLoad>();
        }
        public void Converter(ObservableCollection<object> myLst)
        {
            foreach (object i in myLst)
            {
                if (i is MyClass)
                {
                    myClassList.Add(new MyClassForSaveLoad()
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
                        myClassList[myClassList.Count - 1].MethodList.Add(metod);
                    }
                    foreach (Properti properti in ((MyClass)i).PropertiList)
                    {
                        myClassList[myClassList.Count - 1].PropertiList.Add(properti);
                    }
                }
                else if (i is InheritanceConnector)
                {
                    inheritanceConnectorList.Add(new InheritanceConnectorForSaveLoad()
                    {
                        StartPoint = (((InheritanceConnector)i).StartPoint).ToString(),
                        EndPoint = (((InheritanceConnector)i).EndPoint).ToString(),
                        AngleHead = ((InheritanceConnector)i).AngleHead
                    });
                }
                else if (i is ImplementationConnector)
                {
                    implementationConnectorList.Add(new ImplementationConnectorForSaveLoad()
                    {
                        StartPoint = (((InheritanceConnector)i).StartPoint).ToString(),
                        EndPoint = (((InheritanceConnector)i).EndPoint).ToString(),
                        AngleHead = ((InheritanceConnector)i).AngleHead
                    });
                }
                else if (i is AddictionConnector)
                {
                    addictionConnectorList.Add(new AddictionConnectorForSaveLoad()
                    {
                        StartPoint = (((AddictionConnector)i).StartPoint).ToString(),
                        EndPoint = (((AddictionConnector)i).EndPoint).ToString(),
                        AngleHead = ((AddictionConnector)i).AngleHead
                    });
                }
                else if (i is AggregationConnector)
                {
                    aggregationConnectorList.Add(new()
                    {
                        StartPoint = (((AggregationConnector)i).StartPoint).ToString(),
                        EndPoint = (((AggregationConnector)i).EndPoint).ToString(),
                        AngleHead = ((AddictionConnector)i).AngleHead
                    });
                }
                else if (i is CompositionConnector)
                {
                    compositionConnectorList.Add(new CompositionConnectorForSaveLoad()
                    {
                        StartPoint = (((CompositionConnector)i).StartPoint).ToString(),
                        EndPoint = (((CompositionConnector)i).EndPoint).ToString(),
                        AngleHead = ((CompositionConnector)i).AngleHead
                    });
                }
                else if (i is AssociationConnector)
                {
                    associationConnectorList.Add(new AssociationConnectorForSaveLoad()
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
            foreach (MyClassForSaveLoad i in MyClassList) rezList.Add(i);
            foreach (InheritanceConnectorForSaveLoad i in InheritanceConnectorList) rezList.Add(i);
            foreach (ImplementationConnectorForSaveLoad i in ImplementationConnectorList) rezList.Add(i);
            foreach (AddictionConnectorForSaveLoad i in AddictionConnectorList) rezList.Add(i);
            foreach (AggregationConnectorForSaveLoad i in AggregationConnectorList) rezList.Add(i);
            foreach (CompositionConnectorForSaveLoad i in CompositionConnectorList) rezList.Add(i);
            foreach (AssociationConnectorForSaveLoad i in AssociationConnectorList) rezList.Add(i);
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
