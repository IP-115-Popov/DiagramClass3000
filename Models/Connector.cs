﻿using Avalonia;
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
        protected Point startPoint;
        protected Point endPoint;
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
        protected Avalonia.Point Dpoint = new Avalonia.Point(0, 0);
        public void ChangeStartPoint(Point dPoint)
        {
            this.StartPoint += dPoint;
        }
        public void ChangeEndPoint(Point dPoint)
        {
            this.EndPoint += dPoint;
        }
    }
}
