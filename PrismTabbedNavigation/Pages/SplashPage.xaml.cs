using PrismTabbedNavigation.ViewModels;

namespace PrismTabbedNavigation.Pages;

public partial class SplashPage : BasePage
{
    public SplashPageViewModel ViewModel { get; private set; }

    public SplashPage(SplashPageViewModel splashPageViewModel)
        : base(withControlTemplate: false)
    {
        InitializeComponent();

        ViewModel = splashPageViewModel;
        this.BindingContext = ViewModel;


        SetBindings();
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        //await ViewModel.StartUp();
    }

    private void SetBindings()
    {
    }
}
