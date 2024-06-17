using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Usuarios.Personas;
using IRepository.Schema_Usuarios.Personas;
using Repository.Schema_Usuarios.Personas;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Usuarios.Personas
{
    public class PersonaBusiness : IPersonaBusiness
    {
        #region Dependency Injecction
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;
        public PersonaBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _personaRepository = new PersonaRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<PersonaResponse>> GetAll()
        {
            List<Persona> persona = await _personaRepository.GetAll();
            var response = _mapper.Map<List<PersonaResponse>>(persona);
            return response;
        }
        public async Task<PersonaResponse> GetById(int id)
        {
            Persona persona = await _personaRepository.GetById(id);
            var response = _mapper.Map<PersonaResponse>(persona);
            return response;
        }

        public async Task<PersonaResponse> Create(PersonaRequest entity)
        {
            Persona persona = _mapper.Map<Persona>(entity);
            persona = await _personaRepository.Create(persona);
            var response = _mapper.Map<PersonaResponse>(persona);
            return response;
        }

        public async Task<List<PersonaResponse>> CreateMultiple(List<PersonaRequest> list)
        {
            var persona = _mapper.Map<List<Persona>>(list);
            persona = await _personaRepository.CreateMultiple(persona);
            var response = _mapper.Map<List<PersonaResponse>>(persona);
            return response;
        }

        public async Task<PersonaResponse> Update(PersonaRequest entity)
        {
            var persona = _mapper.Map<Persona>(entity);
            persona = await _personaRepository.Update(persona);
            var response = _mapper.Map<PersonaResponse>(persona);
            return response; ;
        }

        public async Task<List<PersonaResponse>> UpdateMultiple(List<PersonaRequest> list)
        {
            var persona = _mapper.Map<List<Persona>>(list);
            persona = await _personaRepository.UpdateMultiple(persona);
            var response = _mapper.Map<List<PersonaResponse>>(persona);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _personaRepository.Delete(id);
            return result;
        }

        public async Task<List<PersonaRequest>> DeleteMultiple(List<PersonaRequest> list)
        {
            var persona = _mapper.Map<List<Persona>>(list);
            var deletedCount = await _personaRepository.DeleteMultiple(persona);
            return list;

        }

        public async Task<GenericFilterResponse<PersonaResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _personaRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<PersonaResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _personaRepository.Dispose();
        }

        #endregion
    }
}
