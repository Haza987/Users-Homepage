using Business.Services;
using Data.Services;
using Presentation_ContactsApp.MVVM.ViewModels;

namespace Presentation_ContactsApp.MVVM.Views;

public partial class AddView : ContentPage
{
    public AddView(AddViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

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
