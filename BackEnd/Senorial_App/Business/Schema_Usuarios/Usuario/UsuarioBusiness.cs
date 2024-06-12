using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Usuarios.Usuario;
using IRepository.Schema_Usuarios.Usuarios;
using Repository.Schema_Usuarios.Usuarios;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Usuarios.Usuarios
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        #region Dependency Injecction
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepository = new UsuarioRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<UsuarioResponse>> GetAll()
        {
            List<Usuario> usuario = await _usuarioRepository.GetAll();
            var response = _mapper.Map<List<UsuarioResponse>>(usuario);
            return response;
        }
        public async Task<UsuarioResponse> GetById(int id)
        {
            Usuario usuario = await _usuarioRepository.GetById(id);
            var response = _mapper.Map<UsuarioResponse>(usuario);
            return response;
        }

        public async Task<UsuarioResponse> Create(UsuarioRequest entity)
        {
            Usuario usuario = _mapper.Map<Usuario>(entity);
            usuario = await _usuarioRepository.Create(usuario);
            var response = _mapper.Map<UsuarioResponse>(usuario);
            return response;
        }

        public async Task<List<UsuarioResponse>> CreateMultiple(List<UsuarioRequest> list)
        {
            var usuario = _mapper.Map<List<Usuario>>(list);
            usuario = await _usuarioRepository.CreateMultiple(usuario);
            var response = _mapper.Map<List<UsuarioResponse>>(usuario);
            return response;
        }

        public async Task<UsuarioResponse> Update(UsuarioRequest entity)
        {
            var usuario = _mapper.Map<Usuario>(entity);
            usuario = await _usuarioRepository.Update(usuario);
            var response = _mapper.Map<UsuarioResponse>(usuario);
            return response; ;
        }

        public async Task<List<UsuarioResponse>> UpdateMultiple(List<UsuarioRequest> list)
        {
            var usuario = _mapper.Map<List<Usuario>>(list);
            usuario = await _usuarioRepository.UpdateMultiple(usuario);
            var response = _mapper.Map<List<UsuarioResponse>>(usuario);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _usuarioRepository.Delete(id);
            return result;
        }

        public async Task<List<UsuarioRequest>> DeleteMultiple(List<UsuarioRequest> list)
        {
            var usuario = _mapper.Map<List<Usuario>>(list);
            var deletedCount = await _usuarioRepository.DeleteMultiple(usuario);
            return list;

        }

        public async Task<GenericFilterResponse<UsuarioResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _usuarioRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<UsuarioResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
        #endregion
        public UsuarioResponse BuscarPorUserName(string userName)
        {
            UsuarioResponse usuario = _mapper.Map<UsuarioResponse>(_usuarioRepository);
            return usuario;
        }
    }
}

    