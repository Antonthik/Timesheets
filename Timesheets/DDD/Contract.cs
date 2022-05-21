using System;

namespace Timesheets.DDD
{
    /// <summary>
    /// Договор с клиентом
    /// </summary>
    public class Contract
    {
        public int id { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public Decimal PricePerHour { get; set; } = 50;
    }
}