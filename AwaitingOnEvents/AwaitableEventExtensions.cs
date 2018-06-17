using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AwaitingOnEvents
{
    public static class AwaitableEventExtensions
    {
        public static async Task ClickAsync(this Button button)
        {
            var tcs = new TaskCompletionSource<object>();
            RoutedEventHandler handler = (s, e) =>
            {
                tcs.TrySetResult(null);
            };

            try
            {
                button.Click += handler;
                await tcs.Task;
            }
            finally
            {
                button.Click -= handler;
            }
        }
    }
}
