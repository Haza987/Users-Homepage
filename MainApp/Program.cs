using Data.Interfaces;
using Data.Services;
using Business.Interfaces;
using Business.Services;
using MainApp.Interfaces;
using MainApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IMenuService, MenuService>();
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<IFileService, FileService>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var mainMenu = scope.ServiceProvider.GetService<IMenuService>();

mainMenu?.ShowMenu(); 