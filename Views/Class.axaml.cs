using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using DiagramClass.Models;
using System.Collections.ObjectModel;

namespace DiagramClass.Views
{
    public class Class : TemplatedControl
    {
        public static readonly StyledProperty<ObservableCollection<Metod>> CustomMethListProperty =
            AvaloniaProperty.Register<Class, ObservableCollection<Metod>>("CustomMethList");
        public ObservableCollection<Metod> CustomMethList
        {
            get => GetValue(CustomMethListProperty);
            set => SetValue(CustomMethListProperty, value);
        }

        public static readonly StyledProperty<ObservableCollection<Properti>> CustomProListProperty =
            AvaloniaProperty.Register<Class, ObservableCollection<Properti>>("CustomProList");
        public ObservableCollection<Properti> CustomProList
        {
            get => GetValue(CustomProListProperty);
            set => SetValue(CustomProListProperty, value);
        }
    }
}
