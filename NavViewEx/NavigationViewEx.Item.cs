using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NavViewEx
{
    public partial class NavigationViewEx
    {
        public static readonly DependencyProperty ClearNavigationProperty = DependencyProperty.RegisterAttached(
            "ClearNavigation", typeof(bool), typeof(NavigationViewEx), new PropertyMetadata(false));

        public static readonly DependencyProperty PageParameterProperty = DependencyProperty.RegisterAttached(
            "PageParameter", typeof(object), typeof(NavigationViewEx), new PropertyMetadata(null));

        public static readonly DependencyProperty PageTypeProperty = DependencyProperty.RegisterAttached(
            "PageType", typeof(Type), typeof(NavigationViewEx), new PropertyMetadata(null));

        public NavigationViewItem FindItemForPage(Type pageType)
        {
            if (pageType == SettingsPageType)
            {
                return SettingsItem as NavigationViewItem;
            }

            return MenuItems
                .OfType<NavigationViewItem>()
                .FirstOrDefault(item => GetPageType(item) == pageType);
        }

        public static bool GetClearNavigation(DependencyObject element)
        {
            return (bool) element.GetValue(ClearNavigationProperty);
        }

        public static object GetPageParameter(NavigationViewItem element)
        {
            return (object) element.GetValue(PageParameterProperty);
        }

        public static Type GetPageType(NavigationViewItem element)
        {
            return (Type) element.GetValue(PageTypeProperty);
        }

        public static void SetClearNavigation(DependencyObject element, bool value)
        {
            element.SetValue(ClearNavigationProperty, value);
        }

        public static void SetPageParameter(NavigationViewItem element, object value)
        {
            element.SetValue(PageParameterProperty, value);
        }

        public static void SetPageType(NavigationViewItem element, Type value)
        {
            element.SetValue(PageTypeProperty, value);
        }
    }
}
