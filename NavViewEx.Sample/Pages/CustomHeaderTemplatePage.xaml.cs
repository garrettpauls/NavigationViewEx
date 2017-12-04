using System;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NavViewEx.Sample.Pages
{
    public sealed class CustomHeaderTemplatePageViewModel
    {
        public async void OpenFileClicked()
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".txt");
            picker.CommitButtonText = "Opening a file will do nothing";

            await picker.PickSingleFileAsync();
        }
    }

    public sealed partial class CustomHeaderTemplatePage : Page, INavigationViewExHeaderProvider, INavigationViewExHeaderTemplateProvider
    {
        public CustomHeaderTemplatePage()
        {
            InitializeComponent();
        }

        public object Header => DataContext;
        public DataTemplate HeaderTemplate => CustomHeaderTemplate;
    }
}
