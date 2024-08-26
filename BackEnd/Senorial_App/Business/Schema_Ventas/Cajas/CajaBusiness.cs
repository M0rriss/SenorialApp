using AutoMapper;
using DBSenorialModels.Senorial;
using DBSenorialModels.View.Auth.Usuario;
using IBusiness.Schema_Ventas.Cajas;
using IRepository.Schema_Usuarios.Usuarios;
using IRepository.Schema_Ventas.AperturaCajas;
using IRepository.Schema_Ventas.Cajas;
using IRepository.Schema_Ventas.Empleados;
using Microsoft.AspNetCore.Http;
using Repository.Schema_Usuarios.Usuarios;
using Repository.Schema_Ventas.AperturaCajas;
using Repository.Schema_Ventas.Cajas;
using Repository.Schema_Ventas.Empleados;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja.HistorialCaja;
using RequestResponseModels.Request.Schema_Ventas.Cajas;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja.Historial;
using RequestResponseModels.Response.Schema_Ventas.Cajas;
using RequestResponseModels.Response.Schema_Ventas.DetalleVentas;
using RequestResponseModels.Response.Schema_Ventas.Ventas.Detalle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.Cajas
{
    public class CajaBusiness : ICajaBusiness
    {
        #region Dependency Injecction
        private readonly ICajaRepository _cajaRepository;
        private readonly IAperturaCajaRepository _aperturaCajaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CajaBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _cajaRepository = new CajaRepository();
            _aperturaCajaRepository = new AperturaCajaRepository();
            _usuarioRepository = new UsuarioRepository();
            _empleadoRepository = new EmpleadoRepository();
            _httpContextAccessor = new HttpContextAccessor();
        }
        #endregion
        #region CRUD
        public async Task<List<CajaResponse>> GetAll()
        {
            List<Caja> caja = await _cajaRepository.GetAll();
            var response = _mapper.Map<List<CajaResponse>>(caja);
            return response;
        }
        public async Task<CajaResponse> GetById(int id)
        {
            var caja = await _cajaRepository.GetById(id);
            var response = _mapper.Map<CajaResponse>(caja);
            return response;
        }

        public async Task<CajaResponse> Create(CajaRequest entity)
        {
            var caja = _mapper.Map<Caja>(entity);
            caja = await _cajaRepository.Create(caja);
            var response = _mapper.Map<CajaResponse>(caja);
            return response;
        }

        public async Task<List<CajaResponse>> CreateMultiple(List<CajaRequest> list)
        {
            var caja = _mapper.Map<List<Caja>>(list);
            caja = await _cajaRepository.CreateMultiple(caja);
            var response = _mapper.Map<List<CajaResponse>>(caja);
            return response;
        }

        public async Task<CajaResponse> Update(CajaRequest entity)
        {
            var caja = _mapper.Map<Caja>(entity);
            caja = await _cajaRepository.Update(caja);
            var response = _mapper.Map<CajaResponse>(caja);
            return response; ;
        }

        public async Task<List<CajaResponse>> UpdateMultiple(List<CajaRequest> list)
        {
            var caja = _mapper.Map<List<Caja>>(list);
            caja = await _cajaRepository.UpdateMultiple(caja);
            var response = _mapper.Map<List<CajaResponse>>(caja);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _cajaRepository.Delete(id);
            return result;
        }

        public async Task<List<CajaRequest>> DeleteMultiple(List<CajaRequest> list)
        {
            var caja = _mapper.Map<List<Caja>>(list);
            var deletedCount = await _cajaRepository.DeleteMultiple(caja);
            return list;

        }

        public async Task<GenericFilterResponse<CajaResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _cajaRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<CajaResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _cajaRepository.Dispose();
        }

        #endregion
        public async Task<AperturaCajaResponse> AperturarCaja(AperturaCajaRequest request)
        {
            // Obtener el correo del usuario autenticado
            var email = _httpContextAccessor.HttpContext.User.Identity.Name;

            // Buscar el usuario usando el correo del usuario autenticado
            VwUsuario usuario = await _usuarioRepository.ObtenerPorCorreo(email);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado para el correo autenticado");
            }

            // Buscar el empleado asociado al usuario
            var empleado = await _empleadoRepository.BuscarporId(usuario.IdUsuario);
            if (empleado == null)
            {
                throw new Exception("Empleado no encontrado para el usuario autenticado");
            }

            var aperturaCaja = new AperturaCaja
            {
                IdCaja = request.IdCaja,
                IdUsuario = empleado.IdEmpleado,
                MontoInicio = request.MontoInicio,
                HoraFechaInicio = DateTime.Now,
                Activo = true
            };

            var result = await _cajaRepository.AperturarCaja(aperturaCaja);
            var response = _mapper.Map<AperturaCajaResponse>(result);
            return response;
        }

        public async Task<List<HistorialAperturaResponse>> ObtenerHistorialApertura(HistorialAperturaRequest request)
        {
            var aperturas = await _cajaRepository.ObtenerHistorialAperturas(request);

            var response = aperturas.Select(apertura => new HistorialAperturaResponse
            {
                IdApertura = apertura.IdApertura,
                FechaInicio = apertura.HoraFechaInicio,
                TotalIngresos = apertura.Venta.Sum(v => v.MontoTotal ?? 0),
                Ventas = apertura.Venta.Select(v => new VentaDetalleResponse
                {
                    IdVenta = v.IdVenta,
                    Cliente = $"{v.IdClienteNavigation.IdPersonaNavigation.PrimerNombre} {v.IdClienteNavigation.IdPersonaNavigation.ApellidoPaterno}",
                    Monto = v.MontoTotal ?? 0,
                    TipoTransaccion = v.IdMetodoNavigation.Descripcion,
                    FechaHoraVenta = v.FechaVenta ?? DateTime.MinValue,
                    Empleado = $"{v.IdEmpleadoNavigation.IdPersonaNavigation.PrimerNombre} {v.IdEmpleadoNavigation.IdPersonaNavigation.ApellidoPaterno}",
                    Detalles = v.DetalleVenta.Select(dv => new DetalleVentaResponse
                    {
                        IdDetalleVenta = dv.IdDetalleVenta,
                        Cantidad = dv.Cantidad,
                        PrecioUnitario = dv.PrecioUnitario,
                        //IdProductoSucursal = dv.IdProductoSucursal,
                        ProductoNombre = dv.Producto.Nombre
                    }).ToList()
                }).ToList()
            }).ToList();

            return response;
        }
    }


}




