using PrismTabbedNavigation.Interface;
using PrismTabbedNavigation.ViewModels;

namespace PrismTabbedNavigation.Pages;

public partial class PricePage : BasePage, ITabRootPage
{

    public PricePageViewModel ViewModel { get; private set; }

    public INavigationService NavigationService => ViewModel.NavigationService;

    public PricePage(PricePageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;

        this.BindingContext = ViewModel;


    }
}