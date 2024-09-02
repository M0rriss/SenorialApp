using DBSenorialModels.Senorial;
using Repository.Schema_Ventas.TbDetallePedidoLlevar;
using IRepository.Schema_Ventas.TbDetallePedidoLlevar;
using RequestResponseModels.Request.Schema_Ventas.TbDetallePedidoLlevar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonModels.Common;
using IBusiness.Schema_Ventas.TbDetallePedidoLlevar;
using IRepository.Schema_Ventas.Productos;
using Repository.Schema_Ventas.Productos;
using Microsoft.AspNetCore.Mvc;

namespace Business.Schema_Ventas.TbDetallePedidoLlevar
{
    public class TbDetallePedidoLlevarBusiness : IDetallePedidoLlevarBusiness
    {

        private readonly IDetallePedidoLlevarRepository _detallePedidoLlevarRepository;
        private readonly IProductoRepository _productoRepository;

        public TbDetallePedidoLlevarBusiness()
        {
            _detallePedidoLlevarRepository = new DetallePedidoLlevarRepository();
            _productoRepository = new ProductoRepository();
        }

        public async Task<CustomResponse> RegistarDetallePedido(List<DetallePedidoLlevarRequest> req)
        {
            List<DetallePedidoLlevar> list = [];
            foreach(DetallePedidoLlevarRequest p in req)
            {
                DetallePedidoLlevar tmp = new()
                {
                    IdPedidoLlevar = p.IdPedidoLlevar,
                    IdProducto = p.IdProducto,
                    Cantidad = p.Cantidad,
                    PrecioUnitario = p.PrecioUnitario,
                };
             
                list.Add(tmp);
            }
           
            await _detallePedidoLlevarRepository.CreateMultiple(list);

            CustomResponse res = new()
            {
                Code = "2001",
                Message = "Registro Corectamente"
            };
            return res;
        }
    }

}
