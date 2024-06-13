using PrismTabbedNavigation.Interface;
using PrismTabbedNavigation.ViewModels;

namespace PrismTabbedNavigation.Pages;

public partial class FoodPage : BasePage, ITabRootPage
{

    public FoodPageViewModel ViewModel { get; private set; }

    public INavigationService NavigationService => ViewModel.NavigationService;

    public FoodPage(FoodPageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;

        this.BindingContext = ViewModel;


    }
}