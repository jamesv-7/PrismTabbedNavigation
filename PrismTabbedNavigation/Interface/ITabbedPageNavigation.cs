using System;
namespace PrismTabbedNavigation.Interface
{
	public interface ITabbedPageNavigation
    {
        void SwitchTab(string tabName);
        Task NavigateTabAsync(string tabName, string pageName, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true);
        Task NavigateTabAsync(string tabName, Uri uri, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true);
        int SelectedTab { get; }
        string SelectedTabName { get; }
    }
}
