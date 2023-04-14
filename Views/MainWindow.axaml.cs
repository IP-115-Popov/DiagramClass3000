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
                    this.PointerMoved += PointerMoveDragShape;
                    this.PointerReleased += PointerReleasedDragShape;
                }
            }
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
                    myClass.Margin = (currentPointerPosition.X - myClass.Width / 2).ToString() + "," + (currentPointerPosition.Y - myClass.Height / 2).ToString();
                }
            }
        }
        private void PointerReleasedDragShape(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerReleasedDragShape;
        }
    }
}
