using Business.Services;
using Data.Services;
using Presentation_ContactsApp.MVVM.ViewModels;

namespace Presentation_ContactsApp.MVVM.Views;

public partial class AddView : ContentPage
{
    public AddView()
	{
		InitializeComponent();
        var fileService = new FileService();
        BindingContext = new AddViewModel(new ContactService(fileService), new FileService());
    }

    // GitHub Copilot helped me with this code to reset the form when opening the page.
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is AddViewModel viewModel)
        {
            viewModel.ResetForm();
        }
    }

    private async void NavToHomeView(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}