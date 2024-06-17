using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Usuarios.PersonaNatural;
using IRepository.Schema_Usuarios.PersonaNaturales;
using IRepository.Schema_Usuarios.Personas;
using Repository.Schema_Usuarios.PersonaNaturales;
using Repository.Schema_Usuarios.Personas;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using RequestResponseModels.Request.Schema_Usuarios.PersonaNatural;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Usuarios.PersonaNatural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Usuarios.PersonaNaturales
{
    public class PersonaNaturalBusiness : IPersonaNaturalBusiness
    {
        #region Dependency Injecction
        private readonly IPersonaNaturalRepository _personaNaturalRepository;
        private readonly IMapper _mapper;
        public PersonaNaturalBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _personaNaturalRepository = new PersonaNaturalRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<PersonaNaturalResponse>> GetAll()
        {
            List<PersonaNatural> personaNatural = await _personaNaturalRepository.GetAll();
            var response = _mapper.Map<List<PersonaNaturalResponse>>(personaNatural);
            return response;
        }
        public async Task<PersonaNaturalResponse> GetById(int id)
        {
            PersonaNatural personaNatural = await _personaNaturalRepository.GetById(id);
            var response = _mapper.Map<PersonaNaturalResponse>(personaNatural);
            return response;
        }

        public async Task<PersonaNaturalResponse> Create(PersonaNaturalRequest entity)
        {
            PersonaNatural personaNatural = _mapper.Map<PersonaNatural>(entity);
            personaNatural = await _personaNaturalRepository.Create(personaNatural);
            var response = _mapper.Map<PersonaNaturalResponse>(personaNatural);
            return response;
        }

        public async Task<List<PersonaNaturalResponse>> CreateMultiple(List<PersonaNaturalRequest> list)
        {
            var personaNatural = _mapper.Map<List<PersonaNatural>>(list);
            personaNatural = await _personaNaturalRepository.CreateMultiple(personaNatural);
            var response = _mapper.Map<List<PersonaNaturalResponse>>(personaNatural);
            return response;
        }

        public async Task<PersonaNaturalResponse> Update(PersonaNaturalRequest entity)
        {
            var personaNatural = _mapper.Map<PersonaNatural>(entity);
            personaNatural = await _personaNaturalRepository.Update(personaNatural);
            var response = _mapper.Map<PersonaNaturalResponse>(personaNatural);
            return response; ;
        }

        public async Task<List<PersonaNaturalResponse>> UpdateMultiple(List<PersonaNaturalRequest> list)
        {
            var personaNatural = _mapper.Map<List<PersonaNatural>>(list);
            personaNatural = await _personaNaturalRepository.UpdateMultiple(personaNatural);
            var response = _mapper.Map<List<PersonaNaturalResponse>>(personaNatural);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _personaNaturalRepository.Delete(id);
            return result;
        }

        public async Task<List<PersonaNaturalRequest>> DeleteMultiple(List<PersonaNaturalRequest> list)
        {
            var personaNatural = _mapper.Map<List<PersonaNatural>>(list);
            var deletedCount = await _personaNaturalRepository.DeleteMultiple(personaNatural);
            return list;

        }

        public async Task<GenericFilterResponse<PersonaNaturalResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _personaNaturalRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<PersonaNaturalResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _personaNaturalRepository.Dispose();
        }

        #endregion
    }
}
