using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Usuarios.Usuario;
using IRepository.Schema_Usuarios.Usuarios;
using Repository.Schema_Usuarios.Usuarios;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Encriptar;

namespace Business.Schema_Usuarios.Usuarios
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        #region Dependency Injecction
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly EncriptarDesencriptar _encriptar;
        public UsuarioBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepository = new UsuarioRepository();
            _encriptar = new EncriptarDesencriptar();
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
        #region LOGIN
        public UsuarioResponse BuscarPorCorreo(string email)
        {
            UsuarioResponse usuario = _mapper.Map<UsuarioResponse>(_usuarioRepository);
            return usuario;
        }

        public UsuarioResponse BuscarCorreoEcommerce(string email)
        {

            UsuarioResponse usuario =_mapper.Map<UsuarioResponse>(_usuarioRepository);
            return usuario;
        }

        public UsuarioResponse BuscarCorreoMobile(string email)
        {
            var usuarios = _usuarioRepository.ObtenerPorCorreo(email);
            var usuario = _mapper.Map<UsuarioResponse>(_usuarioRepository);
            return usuario;
        }
        #endregion
        #region SIGN IN
        public async Task<SignInEcommerceResponse> UsuarioRegistroEcommerce(SignInEcommerceRequest request)
        {
            var usuario = new Usuario
            {
                //Nombres = request.Nombres,
                //Apellidos = request.Apellidos,
                //TipoDocumento = request.TipoDocumento,
                //NumeroDocumento = request.NumeroDocumento,
                //Celular = request.Celular,
                Email = request.Email,
                Password = _encriptar.AES_encriptar(request.Password),
            };
            usuario = await _usuarioRepository.RegistrarUsuarioEcommerce(usuario);
            return _mapper.Map<SignInEcommerceResponse>(usuario);
        }

        public async Task<SignInMobileResponse> UsuarioRegistroMoblie(SignInMobileRequest request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                throw new ArgumentException("Las contraseñas no coinciden");
            }

            var usuario = new Usuario
            {
                //Nombre = request.Nombre,
                Email = request.Email,
                Password = _encriptar.AES_encriptar(request.Password),
            };

            usuario = await _usuarioRepository.RegistrarUsuarioMobile(usuario);
            return _mapper.Map<SignInMobileResponse>(usuario);
        }
        #endregion
    }
}

    