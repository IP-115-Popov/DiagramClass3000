using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using DiagramClass.Models;
using DiagramClass.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DiagramClass.Views
{
    public class Class : TemplatedControl
    {
        private MyClass? retyrnedFormSetings;
        //static Class()
        //{
        //    DoubleTappedEvent.AddClassHandler<Class>(
        //        (sender, args) => sender.OnDoubleTappedAsync(args));
        //}
        //protected virtual async Task OnDoubleTappedAsync(RoutedEventArgs routedEventArgs)
        //{ 
        //    SettingsClassView window = new SettingsClassView();
        //    //retyrnedFormSetings =
        //    //окно заглушка
        //    //var mainWindow = new MainWindow
        //    if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        //    {
        //       retyrnedFormSetings = await window.ShowDialog<MyClass>(desktop.MainWindow);
        //    }

        //}


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


        public static readonly StyledProperty<string?> MyTupeTextProperty =
           AvaloniaProperty.Register<Class, string?>("MyTupeText");
        public string? MyTupeText
        {
            get => GetValue(MyTupeTextProperty);
            set => SetValue(MyTupeTextProperty, value);
        }
        public static readonly StyledProperty<string> MyExtensionProperty =
           AvaloniaProperty.Register<Class, string>("MyExtension");
        public string MyExtension
        {
            get => GetValue(MyExtensionProperty);
            set => SetValue(MyExtensionProperty, value);
        }
        public static readonly StyledProperty<string> TupeNameProperty =
           AvaloniaProperty.Register<Class, string>("TupeName");
        public string TupeName
        {
            get => GetValue(TupeNameProperty);
            set => SetValue(TupeNameProperty, value);
        }
    }
}
