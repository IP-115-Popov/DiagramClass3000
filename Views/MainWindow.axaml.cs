using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.VisualTree;
using DiagramClass.Models;
using DiagramClass.Models.Connectors;
using DiagramClass.ViewModels;
using System.Diagnostics;
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
        private async void OnDoubleTapped(object? sender, RoutedEventArgs routedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerReleasedDragShape;
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;
            if (routedEventArgs.Source is Control control)
            {
                if (control.DataContext is MyClass myClass)
                {
                    SettingsClassView window = new SettingsClassView(myClass);
                    if (this.DataContext is MainWindowViewModel viewModel)
                    {              
                        viewModel.RetyrnedFormSetings = await window.ShowDialog<MyClass>(this);
                        viewModel.CanvasList.Remove(myClass);
                    }
                }
            }
        }
        private Avalonia.Point pointerPressedEvent;
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
                    if (pointerPressedEventArgs.Source is Ellipse)
                    {
                        if (this.DataContext is MainWindowViewModel viewModel)
                        {
                            //добавить конектор
                            Connector? conector = null;
                            if (viewModel.Inheritance == true)
                            {
                                conector = new InheritanceConnector()
                                {
                                    StartPoint = pointerPressedEvent,
                                    EndPoint = pointerPressedEvent,
                                };
                            } 
                            else if (viewModel.Implementation == true) 
                            {
                                conector = new ImplementationConnector()
                                {
                                    StartPoint = pointerPressedEvent,
                                    EndPoint = pointerPressedEvent,
                                };
                            }
                            else if (viewModel.Addiction == true)
                            {
                                conector = new AddictionConnector()
                                {
                                    StartPoint = pointerPressedEvent,
                                    EndPoint = pointerPressedEvent,
                                };
                            }
                            else if (viewModel.Aggregation == true)
                            {
                                conector = new AggregationConnector()
                                {
                                    StartPoint = pointerPressedEvent,
                                    EndPoint = pointerPressedEvent,
                                };
                            }
                            else if (viewModel.Composition == true)
                            {
                                conector = new CompositionConnector()
                                {
                                    StartPoint = pointerPressedEvent,
                                    EndPoint = pointerPressedEvent,
                                };
                            }
                            else if (viewModel.Association == true)
                            {
                                conector = new AssociationConnector()
                                {
                                    StartPoint = pointerPressedEvent,
                                    EndPoint = pointerPressedEvent,
                                };
                            }
                            if (conector != null)
                            {
                                myClass.MarginHandlerNotify += conector.ChangeStartPoint;
                                viewModel.CanvasList.Add(conector);
                                //события двиганья конектора
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }                           
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
            this.PointerMoved -= PointerMoveDrawConectedLine;
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerReleasedDragShape;
        }
        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                Connector connector = viewModel.CanvasList[viewModel.CanvasList.Count - 1] as Connector;
                Avalonia.Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                connector.EndPoint = new Avalonia.Point(
                        currentPointerPosition.X - 1,
                        currentPointerPosition.Y - 1);
               
            }
        }

        private void PointerPressedReleasedDrawLine(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;


            var canvas = this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault();

            var element = canvas.InputHitTest(pointerReleasedEventArgs.GetPosition(canvas));

            MainWindowViewModel viewModel = this.DataContext as MainWindowViewModel;

            if (element is Ellipse ellipse)
            {
                if (ellipse.DataContext is MyClass myClass)
                {
                    Connector connector = viewModel.CanvasList[viewModel.CanvasList.Count - 1] as Connector;
                    myClass.MarginHandlerNotify += connector.ChangeEndPoint;
                    return;
                }     
            }
            else
            {
                viewModel.CanvasList.RemoveAt(viewModel.CanvasList.Count - 1);
            }
        }
        Avalonia.Point oldPoint = new Avalonia.Point(0,0);
        private void PointerMoveDrawConectedLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                Connector connector = viewModel.CanvasList[viewModel.CanvasList.Count - 1] as Connector;
                Avalonia.Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());
               
                connector.EndPoint = new Avalonia.Point(connector.EndPoint.X + oldPoint.X, connector.EndPoint.Y + oldPoint.Y);
                oldPoint = new Avalonia.Point(currentPointerPosition.X - oldPoint.X, currentPointerPosition.Y - oldPoint.Y);
            }
        }
        //добавление элементов

        private async void AddClassOnCanvasEvent(object sender, RoutedEventArgs eventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                viewModel.AddClassOnCanvas();
            }
        }
        private async void AddInterfaceOnCanvasEvent(object sender, RoutedEventArgs eventArgs)
        {
                if (this.DataContext is MainWindowViewModel viewModel)
                {
                    viewModel.AddInterfaceOnCanvas();
                }
        }
        // Сохранение выгрузка элементов
        //#############################################################################################################
        //События кнопок сохранения
        private async void OpenFileXml(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });
            string[]? path = await openFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Load(path[0], "xml");
                }
            }
        }
        private async void OpenFileJson(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });
            string[]? path = await openFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Load(path[0], "json");
                }
            }
        }
        private async void OpenFileYaml(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "YAML files",
                    Extensions = new string[] { "yaml" }.ToList()
                });
            string[]? path = await openFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Load(path[0], "yaml");
                }
            }
        }
        private async void SaveFileXml(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });
            string? path = await saveFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Save(path, "xml");
                }
            }
        }
        private async void SaveFileJson(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });
            string? path = await saveFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Save(path, "json");
                }
            }
        }
        private async void SaveFileYaml(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "YAML files",
                    Extensions = new string[] { "yaml" }.ToList()
                });
            string? path = await saveFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Save(path, "yaml");
                }
            }
        }
            private async void SaveFilePng(object sender, RoutedEventArgs eventArgs)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filters.Add(
                    new FileDialogFilter
                    {
                        Name = "Png files",
                        Extensions = new string[] { "png" }.ToList()
                    });
                string? result = await saveFileDialog.ShowAsync(this);
                var canvas = this.GetVisualDescendants().OfType<Canvas>().Where(canvas => canvas.Name.Equals("canvas")).FirstOrDefault();
                if (DataContext is MainWindowViewModel mainWindowViewModel)
                {
                    if (result != null)
                    {
                        var pxsize = new PixelSize((int)canvas.Bounds.Width, (int)canvas.Bounds.Height);
                        var size = new Avalonia.Size(canvas.Bounds.Width, canvas.Bounds.Height);
                        using (RenderTargetBitmap bitmap = new RenderTargetBitmap(pxsize, new Avalonia.Vector(96, 96)))
                        {
                            canvas.Measure(size);
                            canvas.Arrange(new Rect(size));
                            bitmap.Render(canvas);
                            bitmap.Save(result);
                        }
                    }
                }
            }
        }
}

