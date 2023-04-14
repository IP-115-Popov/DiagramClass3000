using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.VisualTree;
using DiagramClass.Models;
using System.Linq;

namespace DiagramClass.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();          
        }
        private Point pointerPressedEvent;
        private Point pointerPositionInShape;
        private void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            if (pointerPressedEventArgs.Source is Control control)
            {
                if (control.DataContext is MyClass myClass)
                {
                    pointerPressedEvent = pointerPressedEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault());
                    this.PointerMoved += PointerMoveDragShape;
                    this.PointerReleased += PointerReleasedDragShape;
                }
            }
                //pointerPressedEvent = pointerPressedEventArgs.GetPosition(
                //    this.GetVisualDescendants()
                //    .OfType<Canvas>()
                //    .FirstOrDefault());
                //if ()
                //if (pointerPressedEventArgs.Source is Rectangle myClass)
                //{
                //    pointerPositionInShape = pointerPressedEventArgs.GetPosition(myClass);
                //    this.PointerMoved += PointerMoveDragShape;
                //    this.PointerReleased += PointerReleasedDragShape;
                //}
            }
        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (pointerEventArgs.Source is Control control)
            {
                if (control.DataContext is MyClass myClass)
                {
                    Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());
                    myClass.Margin = (currentPointerPosition.X).ToString() + "," + (currentPointerPosition.Y).ToString();
                    //rectangle.StartPoint = new Point(
                    //    currentPointerPosition.X - pointerPositionIntoShape.X,
                    //    currentPointerPosition.Y - pointerPositionIntoShape.Y);
                }
            }
            //if (pointerEventArgs.Source is Class myClassTab)
            //{
            //    Point currentPointPosition = pointerEventArgs
            //        .GetPosition(
            //        this.GetVisualDescendants()
            //        .OfType<Canvas>().FirstOrDefault());
            //    if (myClassTab.DataContext is MyClass myClass)
            //    {
            //        myClass.Margin = (currentPointPosition.X).ToString() + "," + (currentPointPosition.Y).ToString();
            //        //myClass.TranslateTransformY = currentPointPosition.Y - shape.Height / 2;
            //    }
            //}
        }
        private void PointerReleasedDragShape(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerReleasedDragShape;
        }
    }
}
