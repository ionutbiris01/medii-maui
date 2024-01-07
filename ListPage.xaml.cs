using Medii_maui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
namespace Medii_maui;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
        BindingContext = this; // Set the BindingContext
        LoadStatusesAsync(); // Load statuses into the picker
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

        private ObservableCollection<Status> _statuses;
        public ObservableCollection<Status> Statuses
        {
            get { return _statuses; }
            set
            {
                if (_statuses != value)
                {
                    _statuses = value;
                    OnPropertyChanged(); // Notify that the property has changed
                }
            }
        }

        private Status _selectedStatus;
        public Status SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                if (_selectedStatus != value)
                {
                    _selectedStatus = value;
                    OnPropertyChanged(); // Notify that the property has changed
                }
            }
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
        private async Task LoadStatusesAsync()
        {
            var statuses = await App.Database.GetStatusesAsync();
            Statuses = new ObservableCollection<Status>(statuses);
            OnPropertyChanged(nameof(Statuses));
        }

        private void OnStatusCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Status selectedStatus)
            {
                var delivery = (Delivery)BindingContext;

                if (selectedStatus != null)
                {
                    delivery.StatusID = selectedStatus.ID;
                }
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Delivery)BindingContext;

            await LoadStatusesAsync();
        }

    }
