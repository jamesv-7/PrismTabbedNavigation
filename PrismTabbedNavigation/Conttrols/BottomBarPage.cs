using System;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace PrismTabbedNavigation.Conttrols
{
	public class BottomBarPage : Microsoft.Maui.Controls.TabbedPage
    {
        public enum BarThemeTypes
        {
            Light,
            DarkWithAlpha,
            DarkWithoutAlpha
        }

        public bool FixedMode { get; set; }
        public BarThemeTypes BarTheme { get; set; }

        public BottomBarPage()
        {
            On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }

        protected override async void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
        }
    }
}


