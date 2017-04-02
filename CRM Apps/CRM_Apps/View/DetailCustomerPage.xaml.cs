using CRM_Apps.Model;
using CRM_Apps.NativeFeature;
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
    public partial class DetailCustomerPage : ContentPage
    {
        public DetailCustomerPage(Customer customer)
        {
            InitializeComponent();
            ProfileImage.Source = customer.ProfileImageUrl;
            NameLabel.Text = customer.Name;
            CompanyLabel.Text = customer.Company;
            PhoneLabel.Text = customer.PhoneNumber;
            AddressLabel.Text = customer.Address;

            PhoneTapImage.Tapped +=
            (sender, args) => { DependencyService.Get<ICallNumber>().CallNumber(customer.PhoneNumber); };

        }
    }

}

