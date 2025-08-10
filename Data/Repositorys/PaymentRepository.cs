using API.Models;
using DAL.Contracts;
using Data.Contracts;
using Data.Models;
using Data.Repository;
using Domain.DTO;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class PaymentRepository : Repository<PayUConfirmation>, IPayment
    {
        public readonly DbmindCareContext context;
        public PaymentRepository(DbmindCareContext context, ILogger<Repository<PayUConfirmation>> logger) : base(context, logger)
        {
            this.context = context;
        }

    }
}
