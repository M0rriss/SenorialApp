using AutoMapper;
using Azure.Core;
using DBSenorialModels.Estados;
using DBSenorialModels.Senorial;
using DBSenorialModels.View.Mesa;
using DocumentFormat.OpenXml.Office2016.Excel;
using IBusiness.Schema_Ventas.Mesas;
using IRepository.Schema_Ventas.Mesas;
using Repository.Schema_Ventas.Mesas;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.Mesas;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.Mesas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.Mesas
{
    public class MesaBusiness : IMesaBusiness
    {
        #region Dependency Injecction
        private readonly IMesaRepository _mesaRepository;
        private readonly IMapper _mapper;
        public MesaBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _mesaRepository = new MesaRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<MesaResponse>> GetAll()
        {
            List<Mesa> mesas = await _mesaRepository.GetAll();
            var response = _mapper.Map<List<MesaResponse>>(mesas);
            return response;
        }

        public async Task<MesaResponse> GetById(int id)
        {
            Mesa mesa = await _mesaRepository.GetById(id);
            var response = _mapper.Map<MesaResponse>(mesa);
            return response;
        }

        public async Task<MesaResponse> Create(MesaRequest request)
        {
            var estado = ConvertToBoolean(request.Estado);

            var mesa = new Mesa
            {
                Nombre = request.Nombre,
                Estado = estado
            };

            mesa = await _mesaRepository.Create(mesa);
            var response = new MesaResponse
            {
                IdMesa = mesa.IdMesa,
                Nombre = mesa.Nombre,
                Estado = estado ? "Activo" : "Inactivo"
            };

            return response;
        }

        public async Task<List<MesaResponse>> CreateMultiple(List<MesaRequest> list)
        {
            var mesas = new List<Mesa>();
            foreach (var request in list)
            {
                var estado = ConvertToBoolean(request.Estado);

                var mesa = new Mesa
                {
                    Nombre = request.Nombre,
                    Estado = estado
                };
                mesas.Add(mesa);
            }

            var createdMesas = await _mesaRepository.CreateMultiple(mesas);
            var response = _mapper.Map<List<MesaResponse>>(createdMesas);
            return response;
        }
        public async Task<MesaResponse> UpdateMesa(MesaUpdateRequest request)
        {
            var estado = ConvertToBoolean(request.Estado);

            var mesa = await _mesaRepository.GetById(request.IdMesa);
            if (mesa == null)
            {
                throw new ArgumentException("Mesa no encontrada.");
            }
            if (request.EstadoMesaLocal != 0 )
            {
                mesa.EstadoMesaLocal = request.EstadoMesaLocal;
            }

            mesa.Nombre = request.Nombre;
            mesa.Estado = estado;

            mesa = await _mesaRepository.Update(mesa);
            var response = _mapper.Map<MesaResponse>(mesa);
            return response;
        }
        public async Task<MesaResponse> Update(MesaRequest request)
        {
            var estado = ConvertToBoolean(request.Estado);

            var mesa = _mapper.Map<Mesa>(request);
            mesa.Estado = estado;

            mesa = await _mesaRepository.Update(mesa);
            var response = _mapper.Map<MesaResponse>(mesa);
            return response;
        }

        public async Task<List<MesaResponse>> UpdateMultiple(List<MesaRequest> list)
        {
            var mesas = new List<Mesa>();
            foreach (var request in list)
            {
                var estado = ConvertToBoolean(request.Estado);

                var mesa = _mapper.Map<Mesa>(request);
                mesa.Estado = estado;
                mesas.Add(mesa);
            }

            var updatedMesas = await _mesaRepository.UpdateMultiple(mesas);
            var response = _mapper.Map<List<MesaResponse>>(updatedMesas);
            return response;
        }

        public async Task<int> Delete(int id)
        {
            int result = await _mesaRepository.Delete(id);
            return result;
        }

        public async Task<List<MesaRequest>> DeleteMultiple(List<MesaRequest> list)
        {
            var mesas = _mapper.Map<List<Mesa>>(list);
            var deletedCount = await _mesaRepository.DeleteMultiple(mesas);
            return list;
        }

        public async Task<GenericFilterResponse<MesaResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _mesaRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<MesaResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _mesaRepository.Dispose();
        }
        #endregion

        #region MESA LOCAL
        public async Task<List<VwMesa>> MesasLocal()
        {
            // Obtener la lista de mesas desde el repositorio
            var mesas = await _mesaRepository.MesasLocal();

            // Iterar sobre las mesas para inicializar el estado usando la clase EstadoLocal
            foreach (var mesa in mesas)
            {
                // Inicializar el estado basado en el valor de IdEstadoMesa
                mesa.Estado = InicializarEstado(mesa.Estado);
            }
            //var mesasSinDuplicados = mesas
            //       .GroupBy(m => m.IdMesa) // Agrupar por ID de mesa
            //       .Select(g => g.First()) // Seleccionar el primer elemento de cada grupo
            //       .ToList();

            //return mesasSinDuplicados;

            return mesas;
        }
        private int InicializarEstado(int idEstadoMesa)
        {
            // Buscar el estado correspondiente en EstadoLocal
            var estado = EstadoLocal.EstadoMesasL.FirstOrDefault(e => e.IdEstadoMesa == idEstadoMesa);

            // Si no se encuentra el estado, devolver el estado "Disponible" por defecto
            return estado?.IdEstadoMesa ?? EstadoLocal.Disponible.IdEstadoMesa;
        }
        public async Task<List<VwMesaDetalle>> ObtenerDetallesMesa(int idMesa, int idPedido)
        {
            return await _mesaRepository.ObtenerDetallesMesaAsync(idMesa, idPedido);
        }
        #endregion

        private bool ConvertToBoolean(string estado)
        {
            if (string.IsNullOrEmpty(estado))
                throw new ArgumentException("Estado no puede ser nulo o vacío.");
            if (estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                return true;
            if (estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                return false;

            throw new ArgumentException("Estado no válido. Debe ser 'Activo' o 'Inactivo'.");
        }

       
    }
}