using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.AperturaCajas;
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
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja.Cierre;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja.Cierre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.AperturaCajas
{
    public class AperturaCajaBusiness : IAperturaCajaBusiness
    {
        #region Dependency Injecction
        private readonly IAperturaCajaRepository _aperturaCajaRepository;
        private readonly ICajaRepository _cajaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AperturaCajaBusiness(IMapper mapper)
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
        public async Task<List<AperturaCajaResponse>> GetAll()
        {
            List<AperturaCaja> aperturacaja = await _aperturaCajaRepository.GetAll();
            var response = _mapper.Map<List<AperturaCajaResponse>>(aperturacaja);
            return response;
        }
        public async Task<AperturaCajaResponse> GetById(int id)
        {
            var aperturacaja = await _aperturaCajaRepository.GetById(id);
            var response = _mapper.Map<AperturaCajaResponse>(aperturacaja);
            return response;
        }

        public async Task<AperturaCajaResponse> Create(AperturaCajaRequest entity)
        {
            var aperturacaja = _mapper.Map<AperturaCaja>(entity);
            aperturacaja = await _aperturaCajaRepository.Create(aperturacaja);
            var response = _mapper.Map<AperturaCajaResponse>(aperturacaja);
            return response;
        }

        public async Task<List<AperturaCajaResponse>> CreateMultiple(List<AperturaCajaRequest> list)
        {
            var aperturacaja = _mapper.Map<List<AperturaCaja>>(list);
            aperturacaja = await _aperturaCajaRepository.CreateMultiple(aperturacaja);
            var response = _mapper.Map<List<AperturaCajaResponse>>(aperturacaja);
            return response;
        }

        public async Task<AperturaCajaResponse> Update(AperturaCajaRequest entity)
        {
            var aperturacaja = _mapper.Map<AperturaCaja>(entity);
            aperturacaja = await _aperturaCajaRepository.Update(aperturacaja);
            var response = _mapper.Map<AperturaCajaResponse>(aperturacaja);
            return response; ;
        }

        public async Task<List<AperturaCajaResponse>> UpdateMultiple(List<AperturaCajaRequest> list)
        {
            var aperturacaja = _mapper.Map<List<AperturaCaja>>(list);
            aperturacaja = await _aperturaCajaRepository.UpdateMultiple(aperturacaja);
            var response = _mapper.Map<List<AperturaCajaResponse>>(aperturacaja);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _aperturaCajaRepository.Delete(id);
            return result;
        }

        public async Task<List<AperturaCajaRequest>> DeleteMultiple(List<AperturaCajaRequest> list)
        {
            var aperturacaja = _mapper.Map<List<AperturaCaja>>(list);
            var deletedCount = await _aperturaCajaRepository.DeleteMultiple(aperturacaja);
            return list;

        }

        public async Task<GenericFilterResponse<AperturaCajaResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _aperturaCajaRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<AperturaCajaResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _aperturaCajaRepository.Dispose();
        }
        #endregion

        public async Task<CierreCajaResponse> CerrarCajaAsync(CierreCajaRequest request)
        {
            var apertura = await _aperturaCajaRepository.ObtenerAperturaPorId(request.IdApertura);

            foreach (var conteoDto in request.Conteos)
            {
                var conteo = new ConteoDinero
                {
                    IdApertura = request.IdApertura,
                    Denominacion = conteoDto.Denominacion,
                    Cantidad = conteoDto.Cantidad
                };

                await _aperturaCajaRepository.RegistrarConteoDinero(conteo);
            }

            apertura.MontoCierre = apertura.Venta.Sum(v => v.MontoTotal ?? 0);
            apertura.TotalContado = request.Conteos.Sum(c => c.Denominacion * c.Cantidad);
            apertura.HoraFechaCierre = DateTime.Now;

            decimal diferencia = apertura.TotalContado.GetValueOrDefault() - apertura.MontoCierre.GetValueOrDefault();

            if (diferencia > 0)
            {
                apertura.Sobrante = diferencia;
                apertura.Faltante = 0;
            }
            else
            {
                apertura.Sobrante = 0;
                apertura.Faltante = Math.Abs(diferencia);
            }

            await _aperturaCajaRepository.Update(apertura);

            var response = new CierreCajaResponse
            {
                TotalContado = apertura.TotalContado ?? 0,
                Sobrante = apertura.Sobrante ?? 0,
                Faltante = apertura.Faltante ?? 0
            };

            return response;
        }




    }
}
