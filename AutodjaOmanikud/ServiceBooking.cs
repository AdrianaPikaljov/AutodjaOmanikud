using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodjaOmanikud
{
    public class ServiceBooking
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public DateTime BookingDate { get; set; }
        public bool IsCancelled { get; set; }
    }

}
