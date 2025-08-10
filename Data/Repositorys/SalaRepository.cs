using API.Models;
using DAL.Contracts;
using DAL.Tool;
using Data.Contracts;
using Data.Models;
using Data.Repository;
using Domain.DTO;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class SalaRepository : Repository<Sala>, ISala
    {
        public readonly DbmindCareContext context;
        public SalaRepository(DbmindCareContext context, ILogger<Repository<Sala>> logger) : base(context, logger)
        {
            this.context = context;
        }
       
        

    }
}
