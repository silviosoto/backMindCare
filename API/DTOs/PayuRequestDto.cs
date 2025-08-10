using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class PayuRequestDto
    {
        public string ReferenceCode { get; set; }
        public decimal Amount { get; set; }
    }
}
