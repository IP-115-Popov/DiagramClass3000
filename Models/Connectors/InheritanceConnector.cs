using Avalonia;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramClass.Models.Connectors
{
    public class InheritanceConnector : Connector
    {
        private Point a;
        private Point b;
        private Point c;
        public InheritanceConnector() { }
        public Point A
        {
            get => a;
            set => SetAndRaise(ref a, value);
        }
        private Point B
        {
            get => b;
            set => SetAndRaise(ref b, value);
        }
        private Point C
        {
            get => c;
            set => SetAndRaise(ref c, value);
        }
    }
}
