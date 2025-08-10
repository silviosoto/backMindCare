using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class PayUConfirmationDto
    {
        public string merchant_id { get; set; }
        public string state_pol { get; set; }
        public string response_code_pol { get; set; }
        public string payment_method_type { get; set; }
        public string value { get; set; }
        public string currency { get; set; }
        public string reference_sale { get; set; }
        public string payment_date { get; set; }
    }
}
