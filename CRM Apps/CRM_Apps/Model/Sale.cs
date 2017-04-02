using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Apps.Model
{
    public class Sale
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long Amount { get; set; }

        public int Percentage { get; set; }

        public string Deal { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }
    }

}
