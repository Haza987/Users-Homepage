using Business.Interfaces;
using Business.Services;
using Presentation_ContactsApp.MVVM.ViewModels;
using Microsoft.Extensions.Logging;
using Presentation_ContactsApp.MVVM.Views;
using Data.Interfaces;
using Data.Services;

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

            builder.Services.AddSingleton<IContactService, ContactService>();
            builder.Services.AddSingleton<IFileService, FileService>();

            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<AddViewModel>();
            builder.Services.AddSingleton<AddView>();

            builder.Services.AddTransient<ListContactsViewModel>();
            builder.Services.AddTransient<ListContactsView>();

            builder.Services.AddTransient<EditViewModel>();
            builder.Services.AddTransient<EditView>();

            builder.Services.AddSingleton<ExitAppViewModel>();
            builder.Services.AddSingleton<ExitAppView>();
#if DEBUG

            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
