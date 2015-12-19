using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace DrawingCircles
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private Polyline _line = null;
        private Stack<Polyline> _undo = new Stack<Polyline>();
        private Stack<Polyline> _redo = new Stack<Polyline>();

        private void MainCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _line = new Polyline()
            {
                StrokeThickness = 1,
                Stroke = new SolidColorBrush(Colors.Red),
            };

            var position = e.GetCurrentPoint(MainCanvas).Position;
            _line.Points.Add(position);

            MainCanvas.Children.Add(_line);
        }

        private void MainCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (_line != null)
            {
                var position = e.GetCurrentPoint(MainCanvas).Position;
                _line.Points.Add(position);
            }
        }

        private void MainCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _undo.Push(_line);
            _redo.Clear();
            _line = null;
        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            if (_undo.Any())
            {
                var line = _undo.Pop();
                MainCanvas.Children.Remove(line);
                _redo.Push(line);
            }
        }

        private void Redo(object sender, RoutedEventArgs e)
        {
            if (_redo.Any())
            {
                var line = _redo.Pop();
                MainCanvas.Children.Add(line);
                _undo.Push(line);
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            _undo.Clear();
            _redo.Clear();
            MainCanvas.Children.Clear();
        }
    }
}
