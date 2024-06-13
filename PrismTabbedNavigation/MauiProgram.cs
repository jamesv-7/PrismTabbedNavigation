using System.Diagnostics;
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
                    containerRegistry.RegisterForNavigation<FoodPage>();
                    containerRegistry.RegisterForNavigation<PricePage>();
                    containerRegistry.RegisterForNavigation<ChestPage>();
                    containerRegistry.Register<IBasePageService, BasePageService>(); // Need to register this as per instance or else navigation won't work;
                    containerRegistry.RegisterForNavigation<SplashPage>();
                })
                .OnInitialized((IContainerProvider obj) =>
                {

                    Debug.WriteLine("MAUI BUILDER - OnInitialized IContainerRegistry");

                    var eventAggregator = obj.Resolve<IEventAggregator>();
                    eventAggregator?.GetEvent<NavigationRequestEvent>().Subscribe(context => {

                        Debug.WriteLine("\nNAVIGATIONSERVICE");
                        Debug.WriteLine("Uri = " + context.Uri);
                        Debug.WriteLine("Parameters = " + context.Parameters);
                        Debug.WriteLine("Type = " + context.Type);
                        Debug.WriteLine("Cancelled = " + context.Cancelled);
                        Debug.WriteLine("NAVIGATIONSERVICE RESULT");
                        Debug.WriteLine("Success = " + context.Result.Success);
                        Debug.WriteLine("Context = " + context.Result.Context);

                        var exc = context.Result.Exception;
                        if (exc != null)
                        {
                            Debug.WriteLine("NAVIGATIONSERVICE EXCEPTION");
                            Debug.WriteLine("Exception = " + exc);
                            Debug.WriteLine("Data = " + exc.Data);
                            Debug.WriteLine("HelpLink = " + exc.HelpLink);
                            Debug.WriteLine("HResult = " + exc.HResult);
                            Debug.WriteLine("InnerException = " + exc.InnerException);
                            Debug.WriteLine("Message = " + exc.Message);
                            Debug.WriteLine("Source = " + exc.Source);
                            Debug.WriteLine("StackTrace = " + exc.StackTrace);
                            Debug.WriteLine("TargetSite = " + exc.TargetSite);
                        }


                    });
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

