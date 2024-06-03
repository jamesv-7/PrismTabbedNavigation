using System;
using PrismTabbedNavigation.Pages;

namespace PrismTabbedNavigation.ViewModels
{
	public class BaseViewModel : BindableBase
    {
        public readonly Prism.Navigation.INavigationService NavigationService;
        public readonly DryIoc.IContainer Container;


        protected bool HasInitialized { get; set; }

        public bool IsBusy { get; set; }

        public bool IsUserLoggedIn { get; private set; }

        public BaseViewModel(IBasePageService basePageService)
        {
            NavigationService = basePageService.NavigationService;
            Container = basePageService.Container;
        }
    }
}

