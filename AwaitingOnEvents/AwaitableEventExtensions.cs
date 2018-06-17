using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AwaitingOnEvents
{
    public static class AwaitableEventExtensions
    {
        public static async Task ClickAsync(this Button button)
        {
            var source = new TaskCompletionSource<object>();
            RoutedEventHandler handler = (sender, args) =>
            {
                source.TrySetResult("ignored");
            };

            try
            {
                button.Click += handler;
                await source.Task;
            }
            finally
            {
                button.Click -= handler;
            }
        }
    }
}
