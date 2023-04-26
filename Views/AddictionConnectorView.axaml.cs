using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace DiagramClass.Views
{
    public class AddictionConnectorView : TemplatedControl
    {
        public static readonly StyledProperty<Point?> StartPointCastomProperty =
          AvaloniaProperty.Register<AddictionConnectorView, Point?>("StartPointCastom");
        public Point? StartPointCastom
        {
            get => GetValue(StartPointCastomProperty);
            set => SetValue(StartPointCastomProperty, value);
        }
        public static readonly StyledProperty<Point?> EndPointCastomProperty =
        AvaloniaProperty.Register<AddictionConnectorView, Point?>("EndPointCastom");
        public Point? EndPointCastom
        {
            get => GetValue(EndPointCastomProperty);
            set => SetValue(EndPointCastomProperty, value);
        }
    }
}
