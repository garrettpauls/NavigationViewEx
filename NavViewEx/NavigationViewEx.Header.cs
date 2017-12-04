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
        public static readonly DependencyProperty HeaderHeightProperty = DependencyProperty.Register(
            "HeaderHeight", typeof(double), typeof(NavigationViewEx),
            new PropertyMetadata(48));

        private object mOriginalHeader;
        private Binding mOriginalHeaderBinding;
        private DataTemplate mOriginalHeaderTemplate;
        private Binding mOriginalHeaderTemplateBinding;

        /// <summary>
        ///     By default the header container's height is fixed to 48, which breaks using things like CommandBar for the header.
        ///     To fix this, specify HeaderHeight="NaN" which will allow variable sizing, provided the applied template
        ///     contains a control named "HeaderContent" which is the container for the header.
        /// </summary>
        public double HeaderHeight
        {
            get => (double) GetValue(HeaderHeightProperty);
            set => SetValue(HeaderHeightProperty, value);
        }

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
