namespace Presentation_ContactsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NavToAddContact(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AddView");
        }

        private async void NavToViewContacts(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ListContactsView");
        }

        private async void NavToExitApp(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ExitAppView");
        }

    }
}
