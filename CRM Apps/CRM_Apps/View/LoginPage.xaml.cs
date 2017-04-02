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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            SignInButton.Clicked += async (sender, e) =>            {
                var service = new DataService();
                if (await service.Login(EmailEntry.Text, PasswordEntry.Text))
                    Navigation.PushAsync(new HomePage());
                else
                    DisplayAlert("Error", "Invalid username or password", "Cancel");
            };

        }
    }
}