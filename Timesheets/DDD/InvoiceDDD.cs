using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DDD
{
    public class InvoiceDDD
    {
        public int Id { get; set; }
        public Contract Contract { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime InvoiceDate { get;  set; }
        public bool isPaid { get;  set; } = false;



        /* Domain Driven Design - предполагает концепцию инварианта
* InvoiceDate и isPaid - должны иницироваться вместе, они - инварианты
*/


        public void  InvoiceTrue()
        {
            InvoiceDate = DateTime.Now;
            isPaid = true;
        }
 
    }
}
