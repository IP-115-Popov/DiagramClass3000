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
        private double angleHead = 0;
        public Point StartPoint
        {
            get => startPoint;
            set
            {
                SetAndRaise(ref startPoint, value);
                //angleHeadChange();
                //AngleHead = Math.Atan(System.Convert.ToDouble(((startPoint.X - endPoint.X) / (startPoint.X - endPoint.X)).ToString()));
                AngleHead = Math.Atan((endPoint - startPoint).Y / (endPoint - startPoint).X);
                //AngleHead += 0.1;
            }
        }
        public Point EndPoint
        {
            get => endPoint;
            set
            { 
                SetAndRaise(ref endPoint, value);
                //System.Convert.ToDouble((((Avalonia.Point)value).Y).ToString());
                AngleHead = Math.Atan2((endPoint-startPoint).Y,(endPoint - startPoint).X)* 57.29577951308;
                                               
                //AngleHead += 0.1;
            }
        }
        public double AngleHead
        {
            get => angleHead;
            set => SetAndRaise(ref angleHead, value);
        }
        private Avalonia.Point Dpoint = new Avalonia.Point(0, 0);
        public void ChangeStartPoint(Point dPoint)
        {
            this.StartPoint += dPoint;
        }
        public void ChangeEndPoint(Point dPoint)
        {
            this.EndPoint += dPoint;
        }
        public void angleHeadChange()
        {
            AngleHead = Math.Atan(System.Convert.ToDouble(((startPoint.X - endPoint.X)/(startPoint.X - endPoint.X)).ToString())); 
        }

    }
}
