using API.Models;
using DAL.Contracts;
using DAL.Tools;
using Data.Models;
using Data.Repository;
using Domain.DTO;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class CarritoDeCompraRepository : Repository<carrito_de_compra>, ICarritoDeCompraRepository
    {
        public readonly DbmindCareContext context;
        public CarritoDeCompraRepository(DbmindCareContext context, ILogger<Repository<carrito_de_compra>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<carrito_de_compra> CrearAsync(carrito_de_compra carrito)
        {
            await AddAsync(carrito);
            return carrito;
        }

        public async Task<carrito_de_compra> GetAsync(int IdCarrito)
        {
             return  await GetByIdAsync(IdCarrito);
        }

        public async Task<carrito_de_compra> UpdateCarritoAsync(carrito_de_compra carrito)
        {
            await UpdateAsync(carrito);
            return carrito;
        }
    }
}
