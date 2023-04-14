using Avalonia;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramClass.Models
{
    public class Connector : AbstractNotifyPropertyChanged
    {
        private Point startPoint;
        private Point endPoint;
        public MyClass myClassA;
        public MyClass myClassB;
        public Point StartPoint
        {
            get => startPoint;
            set => SetAndRaise(ref startPoint, value);
        }
        public Point EndPoint
        {
            get => endPoint;
            set => SetAndRaise(ref endPoint, value);
        }
        private Avalonia.Point Dpoint = new Avalonia.Point(0, 0);
        public void ChangeStartPoint(Point point)
        {
            this.StartPoint = point;
        }
        public void ChangeEndPoint(Point point)
        {
            this.EndPoint = point;
        }
    }
}
