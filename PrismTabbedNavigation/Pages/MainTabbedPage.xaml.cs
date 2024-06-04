using PrismTabbedNavigation.Conttrols;
using PrismTabbedNavigation.Interface;
using PrismTabbedNavigation.ViewModels;

namespace PrismTabbedNavigation.Pages;

public partial class MainTabbedPage : BottomBarPage, ITabbedPageView
{
    private bool _isTabPageVisible;
    private bool _updateTabIndexOnly;

    public MainTabbedPageViewModel ViewModel { get; private set; }

    public MainTabbedPage(MainTabbedPageViewModel viewModel)
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception ex)
        {

        }
        //BarBackgroundColor = Colors.White;

        ViewModel = viewModel;
        BindingContext = ViewModel;

        ViewModel.View = this;

        SetBindings();
    }

    private void SetBindings()
    {
        this.SetBinding(SelectedTabIndexProperty, nameof(ViewModel.SelectedTab), BindingMode.TwoWay);
    }

    #region For switching tabs and navigating across tabs

    public static readonly BindableProperty SelectedTabIndexProperty =
        BindableProperty.Create(
            nameof(SelectedTabIndex),
            typeof(int),
            typeof(BottomBarPage),
            0,
            BindingMode.TwoWay,
            null,
            propertyChanged: OnSelectedTabIndexChanged);

    private static void OnSelectedTabIndexChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var tabbedPage = (MainTabbedPage)bindable;

        if (tabbedPage._updateTabIndexOnly) return;

        if (tabbedPage._isTabPageVisible)
        {
            var index = (int)newValue;
            if (tabbedPage.Children.Count > index)
            {
                var navigationPage = (NavigationPage)tabbedPage.Children[index];
                tabbedPage.CurrentPage = navigationPage;
                var rootPage = navigationPage.RootPage as ITabRootPage;
                rootPage.NavigationService.GoBackToRootAsync();
            }
        }
    }

    public int SelectedTabIndex
    {
        get { return (int)GetValue(SelectedTabIndexProperty); }
        set { SetValue(SelectedTabIndexProperty, value); }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _isTabPageVisible = true;

        CurrentPage = Children[SelectedTabIndex];
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        _isTabPageVisible = false;
    }

    protected override void OnCurrentPageChanged()
    {
        base.OnCurrentPageChanged();

        _updateTabIndexOnly = true;
        SelectedTabIndex = Children.IndexOf(CurrentPage);
        _updateTabIndexOnly = false;
    }

    public int TabIndexFromName(string tabName)
    {
        var tabPage = Children.SingleOrDefault(x => x.Title == tabName);
        return tabPage != null ? Children.IndexOf(tabPage) : -1;
    }

    public string TabNameFromIndex(int index)
    {
        return Children[index].Title;
    }

    public async Task NavigateTabAsync(string tabName, string pageName, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true)
    {
        var childreen = Children;

        var index = TabIndexFromName(tabName);
        if (Children.Count > index && index != -1)
        {
            SelectedTabIndex = index;

            var navigationPage = CurrentPage as NavigationPage;
            if (navigationPage?.RootPage is ITabRootPage rootPage)
            {
                if (IsRootPage(pageName))
                    await rootPage.NavigationService.GoBackToRootAsync(parameters);
                else
                {
                    await rootPage.NavigationService.NavigateAsync(pageName, parameters);
                }
            }
        }
    }

    public async Task NavigateTabAsync(string tabName, Uri uri, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true)
    {
        var index = TabIndexFromName(tabName);
        if (Children.Count > index && index != -1)
        {
            SelectedTabIndex = index;

            var navigationPage = CurrentPage as NavigationPage;
            if (navigationPage?.RootPage is ITabRootPage rootPage)
            {
                if (IsRootPage(uri))
                    await rootPage.NavigationService.GoBackToRootAsync(parameters);
                else
                    await rootPage.NavigationService.NavigateAsync(uri.ToString(), parameters);
            }
        }
    }

    private bool IsRootPage(string pageName)
    {
        var bo = UIConstants.RootTabs.Any(x => x == pageName);
        return bo;
    }

    private bool IsRootPage(Uri uri)
    {
        var url = uri.AbsoluteUri;
        var startPosition = url.LastIndexOf('/') + 1;
        if (startPosition < url.Length)
        {
            var pageNamePart = url.Substring(startPosition);

            return UIConstants.RootTabs.Any(pageNamePart.Contains);
        }

        return false;
    }

    #endregion
}

