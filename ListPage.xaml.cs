using Medii_maui.Models;

namespace Medii_maui;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Delivery)BindingContext;
        await App.Database.SaveDeliveryAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Delivery)BindingContext;
        await App.Database.DeleteDeliveryAsync(slist);
        await Navigation.PopAsync();
    }

}