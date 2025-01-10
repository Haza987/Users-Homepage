using Presentation_ContactsApp.MVVM.ViewModels;

namespace Presentation_ContactsApp.MVVM.Views;

public partial class ListContactsView : ContentPage
{
	public ListContactsView(ListContactsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    private async void NavToHomeView(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}