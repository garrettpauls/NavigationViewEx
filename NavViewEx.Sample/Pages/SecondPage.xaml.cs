using Windows.UI.Xaml.Controls;

namespace NavViewEx.Sample.Pages
{
    public sealed partial class SecondPage : Page, INavigationViewExHeaderProvider
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        public object Header => "Second Page (Custom Header)";
    }
}
