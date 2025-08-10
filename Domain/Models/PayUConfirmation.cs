using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PayUConfirmation
    {
        public int Id { get; set; }
        public string MerchantId { get; set; }
        public string StatePol { get; set; }
        public string ResponseCodePol { get; set; }
        public string PaymentMethodType { get; set; }
        public decimal Value { get; set; }
        public string Currency { get; set; }
        public string ReferenceSale { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string RawBody { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
