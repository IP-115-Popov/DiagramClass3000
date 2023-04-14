using Avalonia;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramClass.Models
{
    public class MyClass : AbstractNotifyPropertyChanged
    {
        private string attribute;
        private string oldMargin;
        private string margin;
        private int width;
        private int height;
        public MyClass()
        {
            attribute = "Null";
            Margin = "100,300";
            Height = 128;
            Width = 128;
        }
        public string Attribute 
        {
            get => attribute;
            set => SetAndRaise(ref attribute, value);
        }
        public string Margin
        {
            get => margin;
            set
            {
                //запоминаю прошлое положение
                oldMargin = margin;
                //изменяем положение на новое
                SetAndRaise(ref margin, value);
                //тригерим ивент оповешаюший конекторы об изменениях
                //вычесляем дельту
                MarginHandlerNotify?.Invoke(new Avalonia.Point(Avalonia.Point.Parse(margin).X - Avalonia.Point.Parse(oldMargin).X, Avalonia.Point.Parse(margin).Y - Avalonia.Point.Parse(oldMargin).Y));
            }
        }
        public int Width
        {
            get => width;
            set => SetAndRaise(ref width, value);
        }
        public int Height
        {
            get => height;
            set => SetAndRaise(ref height, value);
        }
        //public void MarginHandlerNotifyImvoker(Avalonia.Point point)
        //{

        //}
        public delegate void MarginHandler(Avalonia.Point point);
        public event MarginHandler? MarginHandlerNotify;
    }
}
