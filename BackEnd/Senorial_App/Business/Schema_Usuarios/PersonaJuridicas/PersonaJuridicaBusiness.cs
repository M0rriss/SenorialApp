using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Usuarios.PersonaJuridica;
using IRepository.Schema_Usuarios.PersonaJuridicas;
using Repository.Schema_Usuarios.PersonaJuridicas;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.PersonaJuridica;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.PersonaJuridica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Usuarios.PersonaJuridicas
{
    public class PersonaJuridicaBusiness : IPersonaJuridicaBusiness
    {
        #region Dependency Injecction
        private readonly IPersonaJuridicaRepository _personaJuridicaRepository;
        private readonly IMapper _mapper;
        public PersonaJuridicaBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _personaJuridicaRepository = new PersonaJuridicaRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<PersonaJuridicaResponse>> GetAll()
        {
            List<PersonaJuridica> personaJuridica = await _personaJuridicaRepository.GetAll();
            var response = _mapper.Map<List<PersonaJuridicaResponse>>(personaJuridica);
            return response;
        }
        public async Task<PersonaJuridicaResponse> GetById(int id)
        {
            PersonaJuridica personaJuridica = await _personaJuridicaRepository.GetById(id);
            var response = _mapper.Map<PersonaJuridicaResponse>(personaJuridica);
            return response;
        }

        public async Task<PersonaJuridicaResponse> Create(PersonaJuridicaRequest entity)
        {
            PersonaJuridica personaJuridica = _mapper.Map<PersonaJuridica>(entity);
            personaJuridica = await _personaJuridicaRepository.Create(personaJuridica);
            var response = _mapper.Map<PersonaJuridicaResponse>(personaJuridica);
            return response;
        }

        public async Task<List<PersonaJuridicaResponse>> CreateMultiple(List<PersonaJuridicaRequest> list)
        {
            var personaJuridica = _mapper.Map<List<PersonaJuridica>>(list);
            personaJuridica = await _personaJuridicaRepository.CreateMultiple(personaJuridica);
            var response = _mapper.Map<List<PersonaJuridicaResponse>>(personaJuridica);
            return response;
        }

        public async Task<PersonaJuridicaResponse> Update(PersonaJuridicaRequest entity)
        {
            var personaJuridica = _mapper.Map<PersonaJuridica>(entity);
            personaJuridica = await _personaJuridicaRepository.Update(personaJuridica);
            var response = _mapper.Map<PersonaJuridicaResponse>(personaJuridica);
            return response; ;
        }

        public async Task<List<PersonaJuridicaResponse>> UpdateMultiple(List<PersonaJuridicaRequest> list)
        {
            var personaJuridica = _mapper.Map<List<PersonaJuridica>>(list);
            personaJuridica = await _personaJuridicaRepository.UpdateMultiple(personaJuridica);
            var response = _mapper.Map<List<PersonaJuridicaResponse>>(personaJuridica);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _personaJuridicaRepository.Delete(id);
            return result;
        }

        public async Task<List<PersonaJuridicaRequest>> DeleteMultiple(List<PersonaJuridicaRequest> list)
        {
            var personaJuridica = _mapper.Map<List<PersonaJuridica>>(list);
            var deletedCount = await _personaJuridicaRepository.DeleteMultiple(personaJuridica);
            return list;

        }

        public async Task<GenericFilterResponse<PersonaJuridicaResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _personaJuridicaRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<PersonaJuridicaResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _personaJuridicaRepository.Dispose();
        }

        #endregion
    }
}
