using PrismTabbedNavigation.Interface;
using PrismTabbedNavigation.ViewModels;

namespace PrismTabbedNavigation.Pages;

public partial class MoreMenuItemsPage : BasePage, ITabRootPage
{
    public Prism.Navigation.INavigationService NavigationService => ViewModel.NavigationService;

    public MoreMenuPageViewModel ViewModel { get; private set; }

    public MoreMenuItemsPage(MoreMenuPageViewModel vm)
    {
        ViewModel = vm;

        this.BindingContext = vm;
        InitializeComponent();
    }


}