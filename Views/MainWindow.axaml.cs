using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.VisualTree;
using DiagramClass.Models;
using DiagramClass.ViewModels;
using System.Drawing;
using System.Linq;

namespace DiagramClass.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();          
        }
        private Avalonia.Point pointerPressedEvent;
        private Avalonia.Point pointerPositionInShape;
        private void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            if (pointerPressedEventArgs.Source is Control control)
            {
                if (control.DataContext is MyClass myClass)
                {                 

                    if (pointerPressedEventArgs.Source is Ellipse)
                    {
                        if (this.DataContext is MainWindowViewModel viewModel)
                        {
                            //добавить конектор
                            //события двиганья конектора
                            //this.PointerMoved += PointerMoveDrawLine;
                            //this.PointerReleased += PointerPressedReleasedDrawLine;
                        }
                    }
                    else
                    {
                        this.PointerMoved += PointerMoveDragShape;
                        this.PointerReleased += PointerReleasedDragShape;
                    }
                }
            }
        }
        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (pointerEventArgs.Source is Control control)
            {
                if (control.DataContext is MyClass myClass)
                {
                    Avalonia.Point currentPointerPosition = pointerEventArgs
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
