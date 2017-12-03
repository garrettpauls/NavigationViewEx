using System;
using Windows.UI.Xaml;

namespace NavViewEx
{
    public partial class NavigationViewEx
    {
        public static readonly DependencyProperty SettingsPageTypeProperty = DependencyProperty.Register(
            "SettingsPageType", typeof(Type), typeof(NavigationViewEx), new PropertyMetadata(default(Type)));

        public Type SettingsPageType
        {
            get => (Type) GetValue(SettingsPageTypeProperty);
            set => SetValue(SettingsPageTypeProperty, value);
        }
    }
}
