using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace NavViewEx
{
    public partial class NavigationViewEx
    {
        public static readonly DependencyProperty NavigationFrameProperty = DependencyProperty.Register(
            "NavigationFrame", typeof(Frame), typeof(NavigationViewEx),
            new PropertyMetadata(default(Frame), _HandleNavigationFrameChanged));

        private bool mIsNavigatingInternally;

        public Frame NavigationFrame
        {
            get => (Frame) GetValue(NavigationFrameProperty);
            set => SetValue(NavigationFrameProperty, value);
        }

        private void _HandleBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (NavigationFrame.CanGoBack)
            {
                NavigationFrame.GoBack();
            }
        }

        private void _HandleFrameNavigated(object sender, NavigationEventArgs e)
        {
            if (!mIsNavigatingInternally)
            {
                SelectedItem = FindItemForPage(e.SourcePageType);
            }

            _UpdateHeader(
                e.Content as INavigationViewExHeaderProvider,
                e.Content as INavigationViewExHeaderTemplateProvider);
        }

        private static void _HandleNavigationFrameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is NavigationViewEx navView))
            {
                return;
            }

            if (e.OldValue is Frame oldFrame)
            {
                oldFrame.Navigated -= navView._HandleFrameNavigated;
            }

            if (e.NewValue is Frame newFrame)
            {
                newFrame.Navigated += navView._HandleFrameNavigated;
            }
        }

        private void _NavigateToNewPage(Type pageType, object parameter = null, NavigationTransitionInfo infoOverride = null)
        {
            if (NavigationFrame != null && pageType != null)
            {
                mIsNavigatingInternally = true;

                try
                {
                    NavigationFrame.Navigate(pageType, parameter, infoOverride);
                }
                finally
                {
                    mIsNavigatingInternally = false;
                }
            }
        }
    }
}
