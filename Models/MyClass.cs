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
        private string margin;
        public MyClass()
        {
            attribute = "Null";
            Margin = "100,300";
        }
        public string Attribute 
        {
            get => attribute;
            set => SetAndRaise(ref attribute, value);
        }
        public string Margin
        {
            get => margin;
            set => SetAndRaise(ref margin, value);
        }
    }
}
