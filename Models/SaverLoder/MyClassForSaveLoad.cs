using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramClass.Models.SaverLoder
{
    public class MyClassForSaveLoad
    {
        public string Margin { get; set; }
        public string MyType { get; set; }
        public string Attribute { get; set; }
        public string Name { get; set; }
        public List<Metod> MethodList { get; set; }
        public List<Properti> PropertiList { get; set; }
    }
}
