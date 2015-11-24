using System;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FlashCard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static readonly Random _random = new Random();
        private int _answer;

        public MainPage()
        {
            this.InitializeComponent();

            GenerateNewProblem();
        }

        private void GenerateNewProblem()
        {
            var x = _random.Next(10) + 1;
            var y = _random.Next(10) + 1;
            _answer = x * y;
            ProblemText.Text = $"{x} * {y} =";
        }

        private void CheckAnswer()
        {
            int value;
            if (int.TryParse(AnswerText.Text, out value))
            {
                if (value == _answer)
                {
                    AnswerText.BorderBrush = new SolidColorBrush(Colors.Black);
                    AnswerText.Text = string.Empty;
                    GenerateNewProblem();
                    return;
                }
            }

            AnswerText.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
        }

        private void AnswerText_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                CheckAnswer();
                e.Handled = true;
            }
        }
    }
}
