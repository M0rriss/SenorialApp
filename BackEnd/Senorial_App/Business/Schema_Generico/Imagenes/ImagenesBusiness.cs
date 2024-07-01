using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Generico.Imagenes;
using IRepository.Schema_Generico.Imagenes;
using Repository.Schema_Generico.Imagenes;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Generico.Imagenes;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Imagenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Generico.Imagenes
{
    public class ImagenesBusiness : IImagenesBusiness
    {
        #region Dependency Injecction
        private readonly IImagenesRepository _imagenesRepository;
        private readonly IMapper _mapper;
        public ImagenesBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _imagenesRepository = new ImagenesRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<ImagenesResponse>> GetAll()
        {
            List<Imagene> imagen = await _imagenesRepository.GetAll();
            var response = _mapper.Map<List<ImagenesResponse>>(imagen);
            return response;
        }
        public async Task<ImagenesResponse> GetById(int id)
        {
            var imagen = await _imagenesRepository.GetById(id);
            var response = _mapper.Map<ImagenesResponse>(imagen);
            return response;
        }

        public async Task<ImagenesResponse> Create(ImagenesRequest entity)
        {
            var imagen = _mapper.Map<Imagene>(entity);
            imagen = await _imagenesRepository.Create(imagen);
            var response = _mapper.Map<ImagenesResponse>(imagen);
            return response;
        }

        public async Task<List<ImagenesResponse>> CreateMultiple(List<ImagenesRequest> list)
        {
            var imagen = _mapper.Map<List<Imagene>>(list);
            imagen = await _imagenesRepository.CreateMultiple(imagen);
            var response = _mapper.Map<List<ImagenesResponse>>(imagen);
            return response;
        }

        public async Task<ImagenesResponse> Update(ImagenesRequest entity)
        {
            var imagen = _mapper.Map<Imagene>(entity);
            imagen = await _imagenesRepository.Update(imagen);
            var response = _mapper.Map<ImagenesResponse>(imagen);
            return response; ;
        }

        public async Task<List<ImagenesResponse>> UpdateMultiple(List<ImagenesRequest> list)
        {
            var imagen = _mapper.Map<List<Imagene>>(list);
            imagen = await _imagenesRepository.UpdateMultiple(imagen);
            var response = _mapper.Map<List<ImagenesResponse>>(imagen);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _imagenesRepository.Delete(id);
            return result;
        }

        public async Task<List<ImagenesRequest>> DeleteMultiple(List<ImagenesRequest> list)
        {
            var imagen = _mapper.Map<List<Imagene>>(list);
            var deletedCount = await _imagenesRepository.DeleteMultiple(imagen);
            return list;

        }

        public async Task<GenericFilterResponse<ImagenesResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _imagenesRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<ImagenesResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _imagenesRepository.Dispose();
        }

        #endregion
    }
}
