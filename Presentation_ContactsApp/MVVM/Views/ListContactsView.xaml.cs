using Presentation_ContactsApp.MVVM.ViewModels;
using System.Diagnostics;

namespace Presentation_ContactsApp.MVVM.Views;

public partial class ListContactsView : ContentPage
{
	public ListContactsView(ListContactsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ListContactsViewModel viewModel)
        {
            Debug.WriteLine("ListContactsView OnAppearing called");
            viewModel.UpdateContactList();
        }
    }

    private async void NavToHomeView(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}