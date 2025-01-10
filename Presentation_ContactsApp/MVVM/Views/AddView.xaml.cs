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
}