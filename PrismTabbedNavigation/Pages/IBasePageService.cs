using System;
namespace PrismTabbedNavigation.Pages
{
    public interface IBasePageService
    {
        Prism.Navigation.INavigationService NavigationService { get; }
        DryIoc.IContainer Container { get; }
        Prism.Common.IPageAccessor PageAccessor { get; }
    }
}