namespace Presentation_ContactsApp.MVVM.Views;

public partial class ExitAppView : ContentPage
{
	public ExitAppView()
	{
		InitializeComponent();
	}

    private void ExitApp(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }

    private async void NavToMainPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}