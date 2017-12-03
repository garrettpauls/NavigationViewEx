using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NavViewEx.Sample.Pages
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Enum.TryParse(e.Parameter?.ToString() ?? "", out SettingsPageTab targetTab))
            {
                switch (targetTab)
                {
                    case SettingsPageTab.About:
                        Pivot.SelectedItem = TabAbout;
                        break;
                    case SettingsPageTab.Settings:
                        Pivot.SelectedItem = TabSettings;
                        break;
                }
            }
            else
            {
                Pivot.SelectedItem = TabSettings;
            }
        }
    }

    public enum SettingsPageTab
    {
        About,
        Settings
    }
}
