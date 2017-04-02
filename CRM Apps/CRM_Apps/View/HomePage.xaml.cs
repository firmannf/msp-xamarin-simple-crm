using CRM_Apps.Model;
using CRM_Apps.ViewModel;
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
    public partial class HomePage : TabbedPage
    {
        private readonly CustomersViewModel _customersViewModel;
        private readonly SalesViewModel _salesViewModel;

        public HomePage()
        {
            InitializeComponent();
            _salesViewModel = new SalesViewModel();
            _salesViewModel.Load();
            _customersViewModel = new CustomersViewModel();
            _customersViewModel.Load();
            SalesContentPage.BindingContext = _salesViewModel;
            CustomersContentPage.BindingContext = _customersViewModel;

            AddSaleTap.Tapped += (sender, args) => { Navigation.PushAsync(new AddSalePage()); };
            AddCustomerTap.Tapped += (sender, args) => { Navigation.PushAsync(new AddCustomerPage()); };
        }


        private void OnSalesItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedSale = e.SelectedItem as Sale;
            if (selectedSale != null)
            {
                Navigation.PushAsync(new DetailSalePage(selectedSale));
                var listview = sender as ListView;
                if (listview != null)
                    listview.SelectedItem = null;
            }

        }

        private void OnCustomersItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCustomer = e.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                Navigation.PushAsync(new DetailCustomerPage(selectedCustomer));
                var listview = sender as ListView;
                if (listview != null)
                    listview.SelectedItem = null;
            }

        }
    }
    
}
