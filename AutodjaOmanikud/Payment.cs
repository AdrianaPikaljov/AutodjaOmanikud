using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodjaOmanikud
{
    public class Payment
    {
        public int Id { get; set; }

        public int CarServiceId { get; set; }
        public CarService CarService { get; set; }

        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
    }

}
