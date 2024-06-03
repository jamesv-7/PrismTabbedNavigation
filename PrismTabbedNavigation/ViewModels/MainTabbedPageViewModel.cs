using System;
using DryIoc;
using PrismTabbedNavigation.Interface;
using PrismTabbedNavigation.Pages;

namespace PrismTabbedNavigation.ViewModels
{
	public class MainTabbedPageViewModel : BasePageViewModel, ITabbedPageNavigation
    {
        private readonly DryIoc.IContainer _container;

        public int SelectedTab { get; set; }
        public ITabbedPageView View { get; set; }

        public string SelectedTabName => View.TabNameFromIndex(SelectedTab);

        public MainTabbedPageViewModel(IBasePageService basePageService,
                                       DryIoc.IContainer container)
            : base(basePageService)
        {
            _container = container;

            // Register ITabbedPageNavigation as a singleton using this ViewModel instance            
            _container.RegisterDelegate<ITabbedPageNavigation>(_ => this);
        }

        #region ITabbedPageNavigation

        public void SwitchTab(string tabName)
        {
            var tabIndex = View.TabIndexFromName(tabName);
            if (tabIndex != -1)
                SelectedTab = tabIndex;
        }

        public async Task NavigateTabAsync(string tabName, string pageName, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true)
        {
            await View.NavigateTabAsync(tabName, pageName, parameters);
        }

        public async Task NavigateTabAsync(string tabName, Uri uri, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true)
        {
            await View.NavigateTabAsync(tabName, uri, parameters);
        }

        #endregion
    }
}


