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
    public partial class SalesPage : ContentPage
    {
        public SalesPage()
        {
            InitializeComponent();
            var salesViewModel = new SalesViewModel();
            salesViewModel.Load();
            BindingContext = salesViewModel;
        }

        private void OnSalesItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}
