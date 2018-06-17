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
            var labelTask = TheLabel.MouseEnterAsync();

            await Task.WhenAll(firstButtonTask, secondButtonTask, labelTask);

            TheTextBlock.Text = "Clicked on both buttons and mouse moved over the label";
        }
    }
}
