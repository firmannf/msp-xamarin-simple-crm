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
    public partial class AddSalePage : ContentPage
    {
        public AddSalePage()
        {
            InitializeComponent();

            SaveButton.Clicked += async (sender, args) =>
            {
                var service = new DataService();
                var random = new Random();
                var sale = new Sale
                {
                    Title = ProductEntry.Text,
                    Description = "Lorem Ipsum",
                    Amount = long.Parse(PriceEntry.Text),
                    OrderDate = OrderedDatePicker.Date,
                    CustomerId = 1,
                    Deal = StatusPicker.Items[StatusPicker.SelectedIndex],
                    Percentage = random.Next(1, 100)
                };
                if (await service.PostNewSale(sale))
                    DisplayAlert("Success", "Success Add Sale", "Ok");
                else
                    DisplayAlert("Failed", "Failed Add Sale", "Cancel");
            };
            CancelButton.Clicked += (sender, args) => { Navigation.PopAsync(true); };
        }
    }
}
