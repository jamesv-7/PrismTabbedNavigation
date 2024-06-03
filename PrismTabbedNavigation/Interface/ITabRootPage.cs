using System;
namespace PrismTabbedNavigation.Interface
{
	public interface ITabRootPage
    {
        Prism.Navigation.INavigationService NavigationService { get; }
    }
}