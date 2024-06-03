using System;
namespace PrismTabbedNavigation.Interface
{
	public interface ITabbedPageView
    {
        int TabIndexFromName(string tabName);
        string TabNameFromIndex(int index);
        Task NavigateTabAsync(string tabName, string pageName, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true);
        Task NavigateTabAsync(string tabName, Uri uri, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true);
    }
}

