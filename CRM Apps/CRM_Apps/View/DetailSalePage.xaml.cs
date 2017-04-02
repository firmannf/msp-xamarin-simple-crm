using CRM_Apps.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRM_Apps.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailSalePage : ContentPage
    {
        public DetailSalePage(Sale sale)
        {
            InitializeComponent();
            TitleLabel.Text = sale.Title;
            DescriptionLabel.Text = sale.Description;
            OrderDateLabel.Text = sale.OrderDate.ToString("dd MMM yyyy");
            DealValueLabel.Text = "Rp" + sale.Amount.ToString("N0", new CultureInfo("id-id"));
        }
    }
}
