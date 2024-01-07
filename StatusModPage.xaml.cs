using Medii_maui.Models;

namespace Medii_maui;

public partial class StatusModPage : ContentPage
{
	public StatusModPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Status)BindingContext;
        await App.Database.SaveStatusAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Status)BindingContext;
        await App.Database.DeleteStatusAsync(slist);
        await Navigation.PopAsync();
    }
}