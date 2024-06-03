using System;
namespace PrismTabbedNavigation.Pages
{
	public class BasePage : ContentPage
    {
        public static BindableProperty IsBusyVisibleProperty = BindableProperty.Create("IsBusyVisible", typeof(bool), typeof(BasePage), false, BindingMode.TwoWay);

        public bool IsBusyVisible
        {
            get { return (bool)GetValue(IsBusyVisibleProperty); }
            set { SetValue(IsBusyVisibleProperty, value); }
        }

        public BasePage(bool withControlTemplate = true, bool withLine = true)
        {
            if (withControlTemplate)
            {

            }

            // Remove the previous page name from the Back button
            NavigationPage.SetBackButtonTitle(this, string.Empty);

            this.SetBinding(IsBusyVisibleProperty, nameof(IsBusy));

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}


