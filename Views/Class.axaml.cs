using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using DiagramClass.Models;
using System.Collections.ObjectModel;

namespace DiagramClass.Views
{
    public class Class : TemplatedControl
    {
        public static readonly StyledProperty<ObservableCollection<Metod>> CustomListProperty =
            AvaloniaProperty.Register<Class, ObservableCollection<Metod>>("CustomList");
        public ObservableCollection<Metod> CustomList
        {
            get => GetValue(CustomListProperty);
            set => SetValue(CustomListProperty, value);
        }
    }
}
