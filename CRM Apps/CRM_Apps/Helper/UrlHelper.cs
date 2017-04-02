using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Apps.Helper
{
    public class UrlHelper
    {
        private const string BASE_URL = "https://msp-xamarin-maranatha.azurewebsites.net/index.php/";

        public const string LOGIN_URL = BASE_URL + "login";

        public const string SALES_URL = BASE_URL + "sales";

        public const string CUSTOMERS_URL = BASE_URL + "customers";

    }
}
