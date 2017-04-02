using CRM_Apps.Model;
using CRM_Apps.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Apps.ViewModel
{
    public class CustomersViewModel : INotifyPropertyChanged
    {
        private List<Customer> _customers;
        private readonly DataService _service = new DataService();

        public List<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task Load()
        {
            Customers = await _service.GetListCustomers();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
