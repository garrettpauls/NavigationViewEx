using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using NavViewEx.Sample.Pages;

namespace NavViewEx.Sample
{
    public sealed partial class Shell : UserControl
    {
        public Shell()
        {
            InitializeComponent();
        }

        private void _HandleLoaded(object sender, RoutedEventArgs e)
        {
            NavView.NavigationFrame.Navigate(typeof(HomePage));
        }
    }
}
