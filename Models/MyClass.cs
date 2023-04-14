using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramClass.Models
{
    public class MyClass : AbstractNotifyPropertyChanged
    {
        private string attribute;
        public MyClass()
        {
            attribute = "Null";
        }
        public string Attribute 
        {
            get => attribute;
            set => SetAndRaise(ref attribute, value);
        }
    }
}
