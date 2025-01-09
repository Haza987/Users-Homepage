using Presentation_ContactsApp.MVVM.Views;

namespace Presentation_ContactsApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AddView), typeof(AddView));
            Routing.RegisterRoute(nameof(ListContactsView), typeof(ListContactsView));
            Routing.RegisterRoute(nameof(ExitAppView), typeof(ExitAppView));
        }
    }
}
