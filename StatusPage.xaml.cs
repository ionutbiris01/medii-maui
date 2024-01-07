using Medii_maui.Models;

namespace Medii_maui;

public partial class StatusPage : ContentPage
{
	public StatusPage()
	{
		InitializeComponent();
	}
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new StatusModPage
            {
                BindingContext = e.SelectedItem as Status
            });
        }
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var status = (Status)BindingContext;
        await App.Database.SaveStatusAsync(status);
        listView.ItemsSource = await App.Database.GetStatusesAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var status = (Status)BindingContext;
        await App.Database.DeleteStatusAsync(status);
        listView.ItemsSource = await App.Database.GetStatusesAsync();
    }
    async void OnStatusAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StatusModPage
        {
            BindingContext = new Status()
        });
    }
    async void OnAddStatusButtonClicked(object sender, EventArgs e)
    {
        Status s;
        if (listView.SelectedItem != null)
        {
            s = listView.SelectedItem as Status;
            var ls = new ListStatus()
            {
                StatusID = s.ID
            };
            await App.Database.SaveListStatusAsync(ls);
            s.ListStatuses = new List<ListStatus> { ls };
            await Navigation.PopAsync();
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetStatusesAsync();
    }

}