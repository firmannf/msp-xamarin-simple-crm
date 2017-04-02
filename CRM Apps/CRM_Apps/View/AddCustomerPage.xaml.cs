using CRM_Apps.Model;
using CRM_Apps.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRM_Apps.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCustomerPage : ContentPage
    {
        public AddCustomerPage()
        {
            InitializeComponent();

            SaveButton.Clicked += async (sender, args) =>
            {
                var service = new DataService();
                var customer = new Customer
                {
                    Name = NameEntry.Text,
                    Address = AddressEntry.Text,
                    PhoneNumber = PhoneEntry.Text,
                    Company = CompanyPicker.Items[CompanyPicker.SelectedIndex],
                    ProfileImageUrl = "http://ottikert.hu/public/img/home-testimonial/testimonial-1.png",
                    Longitude = 0,
                    Latitude = 0
                };
                if (await service.PostNewCustomer(customer))
                    DisplayAlert("Success", "Success Add Customer", "Ok");
                else
                    DisplayAlert("Failed", "Failed Add Customer", "Cancel");
            };
            CancelButton.Clicked += (sender, args) => { Navigation.PopAsync(true); };
        }
    }
}
