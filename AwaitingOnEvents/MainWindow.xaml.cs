using System.Threading.Tasks;
using System.Windows;

namespace AwaitingOnEvents
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var firstButtonTask = FirstButton.ClickAsync();
            var secondButtonTask = SecondButton.ClickAsync();

            await Task.WhenAll(firstButtonTask, secondButtonTask);

            TheTextBlock.Text = "Clicked on both buttons";
        }
    }
}
