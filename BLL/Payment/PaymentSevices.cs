using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositorys;
using Microsoft.Extensions.Logging;
using AutoMapper; 
using Domain.Models;
using Domain.DTO;
using API.Models;
using Data.Models;
using Data.Contracts;

namespace BLL.HobbiesBLL
{
    public class PaymentSevices
    {
        private readonly PaymentRepository _Repopsitory;
        private readonly IMapper _mapper;

        public PaymentSevices(PaymentRepository Repopsitory, IMapper mapper)
        {
            _Repopsitory = Repopsitory;
            _mapper = mapper;
        }

        public async Task<PayUConfirmation> Insert(PayUConfirmation payUConfirmation)
        {
            try
            {
               
                await _Repopsitory.AddAsync(payUConfirmation);

                return payUConfirmation;
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }
         
    }
}
