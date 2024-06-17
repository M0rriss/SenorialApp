using AutoMapper;
using Azure;
using DBSenorialModels.Senorial;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using IBusiness.Schema_Usuarios.Personas;
using IBusiness.Schema_Usuarios.Roles;
using IBusiness.Schema_Usuarios.Usuario;
using IRepository.Schema_Usuarios.PersonaJuridicas;
using IRepository.Schema_Usuarios.PersonaNaturales;
using IRepository.Schema_Usuarios.Personas;
using IRepository.Schema_Usuarios.Roles;
using IRepository.Schema_Usuarios.Usuarios;
using Repository.Schema_Usuarios.PersonaJuridicas;
using Repository.Schema_Usuarios.PersonaNaturales;
using Repository.Schema_Usuarios.Personas;
using Repository.Schema_Usuarios.Roles;
using Repository.Schema_Usuarios.Usuarios;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Usuarios.PersonaNatural;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using Services.Gmail;
using UtilitySecurity.Encriptar;
using UtilitySecurity.OneTimePassword;

namespace Business.Schema_Usuarios.Usuarios
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        #region Dependency Injecction
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly EncriptarDesencriptar _encriptar;
        private readonly IPersonaRepository _personaRepository;
        private readonly IPersonaNaturalRepository _personaNaturalRepository;
        private readonly IPersonaJuridicaRepository _personaJuridicaRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly OtpGenerator _otpGenerator;
        private readonly SendEmailWithGoogleSMTP _sendEmailService;
        public UsuarioBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepository = new UsuarioRepository();
            _encriptar = new EncriptarDesencriptar();
            _personaRepository = new PersonaRepository();
            _rolesRepository = new RolesRepository();
            _personaNaturalRepository = new PersonaNaturalRepository();
            _personaJuridicaRepository = new PersonaJuridicaRepository();
            _otpGenerator = new OtpGenerator();
            _sendEmailService = new SendEmailWithGoogleSMTP();
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

            if (request == null)
            {
                throw new ArgumentException("La solicitud no puede ser nula");
            }
            var nuevaPersona = await _personaRepository.Create(new Persona()
            {
                NroDocumento = request.NumeroDocumento,
                Email = request.Email,
                Telefono = request.Celular,
                Direccion = "",
                TipoDocumento = request.TipoDocumento,
                Genero = "",
                TipoPersona = "",
                //falta la los nombres y apellidos
            });
            var buscarRol = await _rolesRepository.GetById(1);
            //idIMG
            //crear un funcion que retorne el id img |es necesario?
            var nuevoUsuario = new Usuario
            {
                IdPersona = nuevaPersona.IdPersona,
                IdRol = buscarRol.IdRol,
                Email = request.Email,
                UserName = request.Email,
                Password = _encriptar.AES_encriptar(request.Password),
                CambiarPassword = "",
                
            };

            nuevoUsuario = await _usuarioRepository.RegistrarUsuarioEcommerce(nuevoUsuario);

            return _mapper.Map<SignInEcommerceResponse>(nuevoUsuario);
        }

        public async Task<SignInMobileResponse> UsuarioRegistroMoblie(SignInMobileRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("La solicitud no puede ser nula");
            }

            if (request.Password != request.ConfirmarPassword)
            {
                throw new ArgumentException("Las contraseñas no coinciden");
            }
            var persona = await _personaRepository.Create(new Persona
            {
                NroDocumento = request.Dni,
                Email = request.Email,
                Telefono = request.Telefono,
                Direccion = "",
                TipoDocumento = "",
                Genero = "",
                TipoPersona = "",
                
            });
            var personaNatural = new PersonaNatural
            {
                IdPersona = persona.IdPersona,
                PrimerNombre = request.Nombres,
                SegundoNombre = "",
                ApellidoPaterno = "",
                ApellidoMaterno = ""
            };

            personaNatural = await _personaNaturalRepository.Create(personaNatural);
            
            var buscarRol = await _rolesRepository.GetById(3); 

            var nuevoUsuario = new Usuario
            {
                IdPersona = personaNatural.IdPersona,
                Email = request.Email,
                Password = _encriptar.AES_encriptar(request.Password),
                IdRol = buscarRol.IdRol,
            };

            nuevoUsuario = await _usuarioRepository.RegistrarUsuarioMobile(nuevoUsuario);
            var response = _mapper.Map<SignInMobileResponse>(nuevoUsuario);
            response.PersonaNatural = _mapper.Map<PersonaNaturalResponse>(personaNatural);

            return response;
        }
        #endregion

        #region RECOVERY PASSWORD

        public async Task<bool> EnviarCodigoRecuperacionMovil(EnviarCodigoRecuperacionMovilRequest request)
        {
            // Verificar si el usuario existe para enviar el código de recuperación
            var usuario = _usuarioRepository.ObtenerCorreoMobile(request.Email);
            await _sendEmailService.SendEmail(request.Email);
            return true;
        }

        public async Task<bool> EnviarCodigoRecuperacionEcommerce(EnviarCodigoRecuperacionEcommerceRequest request)
        {
            var usuario = _usuarioRepository.ObtenerCorreoEccomerce(request.Email);
            await _sendEmailService.SendEmail(request.Email);
            return true;
        }

        public Task<bool> RestablecerContrasenaMovil(RestablecerPasswordMovilRequest request)
        {

            //Se obtiene el correo con el codigo otp
            //var verficacion = EnviarCodigoRecuperacionMovil();
            //necesito el correo q se quiere cambiar la contraseña

            //luego ingreso los datos de la nueva contraseña y confirmo la nueva contraseña
            //actualizo los datos en la bd
            throw new NotImplementedException();
        }

        public Task<bool> RestablecerContrasenaEcommerce(RestablecerPasswordEcommerceRequest request)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        
    }
}

    