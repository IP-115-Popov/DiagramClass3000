using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using DiagramClass.ViewModels.ConnectorsView;

namespace DiagramClass.Views.ConnectorsView
{
    public class InheritanceConnectorView : TemplatedControl
    {
        public InheritanceConnectorView()
        {
            DataContext = new InheritanceConnectorViewModel();
        }
        public static readonly StyledProperty<Point?> StartPointCastomProperty =
        AvaloniaProperty.Register<InheritanceConnectorView, Point?>("StartPointCastom");
        public Point? StartPointCastom
        {
            get => GetValue(StartPointCastomProperty);
            set => SetValue(StartPointCastomProperty, value);
        }
        public static readonly StyledProperty<Point?> EndPointCastomProperty =
        AvaloniaProperty.Register<InheritanceConnectorView, Point?>("EndPointCastom");
        public Point? EndPointCastom
        {
            get => GetValue(EndPointCastomProperty);
            set => SetValue(EndPointCastomProperty, value);
        }
    }
}
