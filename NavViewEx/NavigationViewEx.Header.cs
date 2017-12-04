using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace NavViewEx
{
    public interface INavigationViewExHeaderProvider
    {
        object Header { get; }
    }

    public interface INavigationViewExHeaderTemplateProvider
    {
        DataTemplate HeaderTemplate { get; }
    }

    public partial class NavigationViewEx : NavigationView
    {
        private object mOriginalHeader;
        private Binding mOriginalHeaderBinding;
        private DataTemplate mOriginalHeaderTemplate;
        private Binding mOriginalHeaderTemplateBinding;

        private void _LoadOriginalHeader()
        {
            mOriginalHeader = Header;
            mOriginalHeaderBinding = GetBindingExpression(HeaderProperty)?.ParentBinding;
            mOriginalHeaderTemplate = HeaderTemplate;
            mOriginalHeaderTemplateBinding = GetBindingExpression(HeaderTemplateProperty)?.ParentBinding;
        }

        private void _UpdateHeader(
            INavigationViewExHeaderProvider headerProvider,
            INavigationViewExHeaderTemplateProvider headerTemplateProvider)
        {
            if (!mIsLoaded)
            {
                return;
            }

            if (headerProvider == null)
            {
                if (mOriginalHeaderBinding != null)
                {
                    SetBinding(HeaderProperty, mOriginalHeaderBinding);
                }
                else
                {
                    Header = mOriginalHeader;
                }
            }
            else
            {
                Header = headerProvider.Header;
            }

            if (headerTemplateProvider == null)
            {
                if (mOriginalHeaderTemplateBinding != null)
                {
                    SetBinding(HeaderTemplateProperty, mOriginalHeaderTemplateBinding);
                }
                else
                {
                    HeaderTemplate = mOriginalHeaderTemplate;
                }
            }
            else
            {
                HeaderTemplate = headerTemplateProvider.HeaderTemplate;
            }
        }
    }
}
