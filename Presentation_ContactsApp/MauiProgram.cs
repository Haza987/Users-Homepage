using Business.Interfaces;
using Business.Services;
using Presentation_ContactsApp.MVVM.ViewModels;
using Microsoft.Extensions.Logging;

namespace Presentation_ContactsApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Services.AddSingleton<IContactService, ContactService>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
