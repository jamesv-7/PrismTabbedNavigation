using System;
namespace PrismTabbedNavigation.Pages
{
	public class BasePageService : IBasePageService
    {
        public Prism.Navigation.INavigationService NavigationService { get; }
        public DryIoc.IContainer Container { get; }
        public Prism.Common.IPageAccessor PageAccessor { get; }

        public BasePageService(Prism.Navigation.INavigationService navigationService,
                                              DryIoc.IContainer container,
                               Prism.Common.IPageAccessor pageAccessor)
        {
            NavigationService = navigationService;
            PageAccessor = pageAccessor;
            Container = container;
        }
    }
}

