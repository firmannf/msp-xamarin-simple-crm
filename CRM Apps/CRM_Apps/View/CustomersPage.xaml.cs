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
    public partial class CustomersPage : ContentPage
    {
        public CustomersPage()
        {
            InitializeComponent();
            var customersViewModel = new CustomersViewModel();
            customersViewModel.Load();
            BindingContext = customersViewModel;
        }

        private void OnCustomersItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}
