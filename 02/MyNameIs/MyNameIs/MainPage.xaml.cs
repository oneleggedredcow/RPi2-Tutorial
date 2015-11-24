using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyNameIs
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            OutputText.Text = $"Hi, my name is {MyName.Text}";
        }
    }
}
