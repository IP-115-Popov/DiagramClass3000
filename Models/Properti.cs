using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramClass.Models
{
    public class Properti : AbstractNotifyPropertyChanged
    {
        private string access;
        private string myReturn;
        private string name;
        public string Аccess
        {
            get => access;
            set => SetAndRaise(ref access, value);
        }
        public string Return
        {
            get => myReturn;
            set => SetAndRaise(ref myReturn, value);
        }

        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }
    }
}
