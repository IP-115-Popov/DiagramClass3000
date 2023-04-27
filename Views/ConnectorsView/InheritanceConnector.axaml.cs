using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace DiagramClass.Views.ConnectorsView
{
    public class InheritanceConnector : TemplatedControl
    {
        public static readonly StyledProperty<Point?> StartPointCastomProperty =
         AvaloniaProperty.Register<InheritanceConnector, Point?>("StartPointCastom");
        public Point? StartPointCastom
        {
            get => GetValue(StartPointCastomProperty);
            set => SetValue(StartPointCastomProperty, value);
        }
        public static readonly StyledProperty<Point?> EndPointCastomProperty =
        AvaloniaProperty.Register<InheritanceConnector, Point?>("EndPointCastom");
        public Point? EndPointCastom
        {
            get => GetValue(EndPointCastomProperty);
            set => SetValue(EndPointCastomProperty, value);
        }
    }
}
