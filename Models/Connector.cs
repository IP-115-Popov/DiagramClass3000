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
        protected string startPoint;
        protected string endPoint;
        public string StartPoint
        {
            get => startPoint;
            set => SetAndRaise(ref startPoint, value);
        }
        public string EndPoint
        {
            get => endPoint;
            set => SetAndRaise(ref endPoint, value);
        }
        protected Avalonia.Point Dpoint = new Avalonia.Point(0, 0);
        public void ChangeStartPoint(string dPoint)
        {
            this.StartPoint += dPoint;
        }
        public void ChangeEndPoint(string dPoint)
        {
            this.EndPoint += dPoint;
        }
    }
}
