using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NavViewEx
{
    public partial class NavigationViewEx : NavigationView
    {
        private bool mIsLoaded;

        public NavigationViewEx()
        {
            Content = NavigationFrame = new Frame();

            SelectionChanged += _HandleSelectionChanged;
            Loaded += _HandleLoaded;

            SystemNavigationManager.GetForCurrentView().BackRequested += _HandleBackRequested;
        }

        private void _HandleLoaded(object sender, RoutedEventArgs e)
        {
            if (mIsLoaded)
            {
                return;
            }

            _UpdateBackButton();

            mIsLoaded = true;
        }

        private void _HandleSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem == SettingsItem)
            {
                _NavigateToNewPage(SettingsPageType);
            }
            else if (args.SelectedItem is NavigationViewItem item)
            {
                _NavigateToNewPage(GetPageType(item), GetPageParameter(item));
                if (GetClearNavigation(item))
                {
                    NavigationFrame?.BackStack.Clear();
                    NavigationFrame?.ForwardStack.Clear();
                }
            }

            _UpdateBackButton();
        }

        private void _UpdateBackButton()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                NavigationFrame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }
    }
}
