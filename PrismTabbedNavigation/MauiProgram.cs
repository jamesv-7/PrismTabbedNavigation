using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PrismTabbedNavigation.Pages;

namespace PrismTabbedNavigation;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UsePrism(prism =>
                prism.RegisterTypes(containerRegistry =>
                {
                    //containerRegistry.RegisterGlobalNavigationObserver();
                    containerRegistry.RegisterForNavigation<MainTabbedPage>();
                    containerRegistry.RegisterForNavigation<MainPage>();
                    containerRegistry.RegisterForNavigation<HomePage>();
                    containerRegistry.RegisterForNavigation<ChestPage>();
                    containerRegistry.RegisterForNavigation<MoreMenuItemsPage>();
                    containerRegistry.RegisterForNavigation<CreateAccountPage>();
                    containerRegistry.Register<IBasePageService, BasePageService>(); // Need to register this as per instance or else navigation won't work;
                    containerRegistry.RegisterForNavigation<SplashPage>();
                })
                .AddGlobalNavigationObserver(context => context.Subscribe(x =>
                {
                    if (x.Type == NavigationRequestType.Navigate)
                        Console.WriteLine($"Navigation: {x.Uri}");
                    else
                        Console.WriteLine($"Navigation: {x.Type}");

                    var status = x.Cancelled ? "Cancelled" : x.Result.Success ? "Success" : "Failed";
                    Console.WriteLine($"Result: {status}");

                    if (status == "Failed" && !string.IsNullOrEmpty(x.Result?.Exception?.Message))
                        Console.Error.WriteLine(x.Result.Exception.Message);
                }))
                .CreateWindow(async (container, navigation) => {
                 var result = await navigation.NavigateAsync("SplashPage");
                })
            )
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

