using API.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IPsicologoRepository : IRepository<Psicologo>
    {
        IEnumerable<Psicologo> GetProductsByCategory(int categoryId);
        Psicologo GetMostExpensiveProduct();
        Task<Psicologo> GetPsicologoConRelacionesAsync(int id);
    }
}
