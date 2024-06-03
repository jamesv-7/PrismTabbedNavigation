using PrismTabbedNavigation.Interface;
using PrismTabbedNavigation.ViewModels;

namespace PrismTabbedNavigation.Pages;

public partial class HomePage : BasePage, ITabRootPage
{

    public HomePageViewModel ViewModel { get; private set; }

    public INavigationService NavigationService => ViewModel.NavigationService;

    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;

        this.BindingContext = ViewModel;


    }

    
}
