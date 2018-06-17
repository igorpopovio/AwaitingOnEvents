using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        public static async Task MouseEnterAsync(this Label label)
        {
            var source = new TaskCompletionSource<object>();
            MouseEventHandler handler = (sender, args) =>
            {
                source.TrySetResult("ignored");
            };

            try
            {
                label.MouseEnter += handler;
                await source.Task;
            }
            finally
            {
                label.MouseEnter -= handler;
            }
        }
    }
}
