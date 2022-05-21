using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DDD
{
    public class Invoice
    {
        
        public Contract Contract { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public bool isPaid { get; set; } = false;
    }
}
