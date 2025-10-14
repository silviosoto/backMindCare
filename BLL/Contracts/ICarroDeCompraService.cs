using BLL.DTOs;
using Domain.Models;

namespace BLL.Contracts
{
    public interface ICarroDeCompraService
    {
        public Task<carrito_de_compra> Crear(CarritoDeComraCreateDTO factura, int idUser);
        public Task<carrito_de_compra> ConfirmarCarritoCompra(int idCarrito);
    }
}
