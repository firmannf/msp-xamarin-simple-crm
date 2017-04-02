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
    public class SalesViewModel : INotifyPropertyChanged
    {
        private List<Sale> _sales;
        public List<Sale> Sales
        {
            get { return _sales; }
            set
            {
                _sales = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;        

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task Load()
        {
            var service = new DataService();
            Sales = await service.GetListSales();
        }
    }

}
