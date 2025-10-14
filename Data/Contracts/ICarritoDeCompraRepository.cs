using DAL.Tools;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface ICarritoDeCompraRepository
    {
        Task<carrito_de_compra> CrearAsync(carrito_de_compra carrito);
        Task<carrito_de_compra>? GetAsync(int IdCarrito);
        Task<carrito_de_compra> UpdateCarritoAsync(carrito_de_compra carrito);
    }
}
