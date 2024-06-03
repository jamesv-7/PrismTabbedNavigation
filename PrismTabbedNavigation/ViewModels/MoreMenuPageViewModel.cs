using System;
using PrismTabbedNavigation.Interface;
using PrismTabbedNavigation.Pages;

namespace PrismTabbedNavigation.ViewModels
{
	public class MoreMenuPageViewModel : BaseViewModel
    {

        private ITabbedPageNavigation _tabbedPageNavigation;

        public MoreMenuPageViewModel(IBasePageService basePageService) : base(basePageService)
        {
            try
            {
                _tabbedPageNavigation = _tabbedPageNavigation ?? (ITabbedPageNavigation)Container.Resolve(typeof(ITabbedPageNavigation), DryIoc.IfUnresolved.Throw); ;
            }
            catch(Exception ex)
            {

            }

        }
        private DelegateCommand _logInCommand;
        public DelegateCommand LogInCommand => _logInCommand ?? (_logInCommand = new DelegateCommand(NavigateToCreateAccountPage, () => !IsBusy).ObservesProperty(() => IsBusy));
        private async void NavigateToCreateAccountPage()
        {
            IsBusy = true;

            await _tabbedPageNavigation.NavigateTabAsync("Dashboard", "CreateAccountPage");

            IsBusy = false;
        }
    }
}
