using System;
using PrismTabbedNavigation.Pages;

namespace PrismTabbedNavigation.ViewModels
{
	public class SplashPageViewModel : BasePageViewModel
    {
        protected string MainTabbedPage => "MainTabbedPage";

        public SplashPageViewModel(IBasePageService basePageService) : base(basePageService)
        {
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);


            await StartUp();
        }

        public async Task StartUp()
        {
            //await NavigationService.NavigateAsync($"/{MainTabbedPage}?createTab=NavigationPage|{"HomePage"}&createTab=NavigationPage|{"ChestPage"}&createTab=NavigationPage|{"ChestPage"}&createTab=NavigationPage|{"MoreMenuItemsPage"}&{KnownNavigationParameters.SelectedTab}={"HomePage"}");
            NavigationService.CreateBuilder().UseRelativeNavigation()
                        .AddTabbedSegment(nameof(MainTabbedPage), b =>
                            b
                             .CreateTab(t => t.AddNavigationPage().AddSegment("HomePage"))
                             .CreateTab(t => t.AddNavigationPage().AddSegment("ChestPage"))
                             .CreateTab(t => t.AddNavigationPage().AddSegment("PricePage"))
                             .CreateTab(t => t.AddNavigationPage().AddSegment("FoodPage"))
                             .CreateTab(t => t.AddNavigationPage().AddSegment("MoreMenuItemsPage"))
                             ).Navigate();
        }
    }
}


