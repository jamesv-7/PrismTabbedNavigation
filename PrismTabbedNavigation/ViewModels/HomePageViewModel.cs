using System;
using PrismTabbedNavigation.Pages;

namespace PrismTabbedNavigation.ViewModels
{
	public class HomePageViewModel : BasePageViewModel
    {
        public HomePageViewModel(IBasePageService basePageService)
            : base(basePageService)
        {
        }

        private DelegateCommand _logInCommand;
        public DelegateCommand NavigateCommand => _logInCommand ?? (_logInCommand = new DelegateCommand(NavigateToCreateAccountPage, () => !IsBusy).ObservesProperty(() => IsBusy));
        private async void NavigateToCreateAccountPage()
        {
            IsBusy = true;

            await NavigationService.NavigateAsync($"CreateAccountPage");

            IsBusy = false;
        }
    }
}


