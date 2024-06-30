using AutoMapper;
using Azure;
using Azure.Core;
using DBSenorialModels.Senorial;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Office;
using IBusiness.Schema_Usuarios.Personas;
using IBusiness.Schema_Usuarios.Roles;
using IBusiness.Schema_Usuarios.Usuarios;
using IRepository.Schema_Usuarios.Personas;
using IRepository.Schema_Usuarios.Roles;
using IRepository.Schema_Usuarios.Usuarios;
using IRepository.Schema_Ventas.Clientes;
using Microsoft.Extensions.Logging;
using Repository.Schema_Usuarios.Personas;
using Repository.Schema_Usuarios.Roles;
using Repository.Schema_Usuarios.Usuarios;
using Repository.Schema_Ventas.Clientes;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
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
        private readonly IClienteRepository _clienteRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly OtpGenerator _otpGenerator;
        private readonly SendEmailWithGoogleSMTP _sendEmailService;
        private readonly Dictionary<string, OtpData> _otpStorage;
        public UsuarioBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepository = new UsuarioRepository();
            _encriptar = new EncriptarDesencriptar();
            _personaRepository = new PersonaRepository();
            _clienteRepository = new ClienteRepository();
            _rolesRepository = new RolesRepository();
            _otpGenerator = new OtpGenerator();
            _sendEmailService = new SendEmailWithGoogleSMTP();
            _otpStorage = new Dictionary<string, OtpData>();
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
        public async Task<UsuarioResponse> BuscarPorCorreo(string email)
        {
            var usuario = _mapper.Map<UsuarioResponse>(_usuarioRepository.ObtenerPorCorreo(email));
            return usuario;

        }

        public async Task<UsuarioResponse> BuscarCorreoEcommerce(string email)
        {

            var usuario =_mapper.Map<UsuarioResponse>(_usuarioRepository.ObtenerCorreoEccomerce(email));
            return usuario;
        }

        public async Task<UsuarioResponse> BuscarCorreoMobile(string email)
        {
            var usuarios = _usuarioRepository.ObtenerCorreoMobile(email);
            var usuario = _mapper.Map<UsuarioResponse>(_usuarioRepository.ObtenerCorreoMobile(email));
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
                PrimerNombre = request.Nombres,
                SegundoNombre = "",
                ApellidoPaterno = request.Apellidos,
                ApellidoMaterno = "",
                NroDocumento = request.NumeroDocumento,
                Email = request.Email,
                Telefono = request.Celular,
                Direccion = "",
                IdTipoDocumento = 1,
                Genero = "",
                TipoPersona = "",
                //falta la los nombres y apellidos
            });
            var buscarRol = await _rolesRepository.GetByRol("Cliente");
            // 3. Crear el Cliente asociado a la Persona
            var nuevoCliente = new Cliente
            {
                IdPersona = nuevaPersona.IdPersona,
                // Completar otros campos de Cliente según sea necesario
            };

            // Guardar el Cliente en el repositorio
            var clienteCreado = await _clienteRepository.Create(nuevoCliente);
            //idIMG
            //crear un funcion que retorne el id img |es necesario?
            var nuevoUsuario = new Usuario
            {
                IdPersona = nuevaPersona.IdPersona,
                IdRol = buscarRol.IdRol,
                Email = request.Email,
                UserName = request.Email.ToLower(),
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
                PrimerNombre = request.Nombres,
                SegundoNombre = "",
                ApellidoPaterno = request.Apellidos,
                ApellidoMaterno = "",
                NroDocumento = request.Dni,
                Email = request.Email,
                Telefono = request.Telefono,
                Direccion = "",
                IdTipoDocumento = 1,
                Genero = "",
                TipoPersona = "Natural",
                
            });
            
            var buscarRol = await _rolesRepository.GetByRol("Mozo"); 

            var nuevoUsuario = new Usuario
            {
                IdPersona = persona.IdPersona,
                Email = request.Email,
                Password = _encriptar.AES_encriptar(request.Password),
                IdRol = buscarRol.IdRol,
            };

            nuevoUsuario = await _usuarioRepository.RegistrarUsuarioMobile(nuevoUsuario);
            var response = _mapper.Map<SignInMobileResponse>(nuevoUsuario);
            response.Persona = _mapper.Map<PersonaResponse>(persona);

            return response;
        }
        #endregion
        #region RECOVERY PASSWORD

        public async Task<bool> EnviarCodigoRecuperacionMovil(EnviarCodigoRecuperacionMovilRequest request)
        {
            // Validar que el correo electrónico no esté vacío
            if (string.IsNullOrEmpty(request.Email))
            {
                throw new ArgumentException("El correo electrónico es requerido para enviar el código de recuperación.");
            }

            // Verificar si el usuario existe para enviar el código de recuperación
            var usuario = _usuarioRepository.ObtenerCorreoMobile(request.Email);
            if (usuario == null)
            {
                throw new ArgumentException("No se encontró ningún usuario con el correo electrónico proporcionado.");
            }
            string codigoOtp = _otpGenerator.GenerateOtp();

            var oneTimeP = _usuarioRepository.OneTimePass(request.Email, codigoOtp);

            await _sendEmailService.SendEmail(request.Email, codigoOtp);
            
            return true;
        }

        public async Task<bool> EnviarCodigoRecuperacionEcommerce(EnviarCodigoRecuperacionEcommerceRequest request)
        {
            // Validar que el correo electrónico no esté vacío
            if (string.IsNullOrEmpty(request.Email))
            {
                throw new ArgumentException("El correo electrónico es requerido para enviar el código de recuperación.");
            }

            // Verificar si el usuario existe para enviar el código de recuperación
            var usuario = _usuarioRepository.ObtenerCorreoEccomerce(request.Email);
            if (usuario == null)
            {
                throw new ArgumentException("No se encontró ningún usuario con el correo electrónico proporcionado.");
            }
            string codigoOtp = _otpGenerator.GenerateOtp();

            var oneTimeP = _usuarioRepository.OneTimePass(request.Email, codigoOtp);

            await _sendEmailService.SendEmail(request.Email, codigoOtp);

            return true;
        }

        public async Task<UsuarioResponse> RestablecerContrasenaMovil(RestablecerPasswordMovilRequest request)
        {
            // Validar que el código OTP no esté vacío
            if (string.IsNullOrEmpty(request.CodigoOtp))
            {
                throw new ArgumentException("El código OTP es requerido para restablecer la contraseña.");
            }

            // Buscar el usuario asociado al correo electrónico en el almacenamiento
            var usuario =  _usuarioRepository.ObtenerCorreoMobile(request.Email);
            if (usuario == null)
            {
                throw new ArgumentException("No se encontró ningún usuario asociado al correo electrónico proporcionado.");
            }
            string enviadoPorElUsuario = request.CodigoOtp;
           
            var codigoDeComparacion = await _usuarioRepository.ObtenerCodigoOtp(request.Email);// traer de la BD
            if (enviadoPorElUsuario != codigoDeComparacion.CodigoRecuperacion)
            {
                throw new ArgumentException("Los codigos no coinciden.");
            }
                // Validar que la nueva contraseña y su confirmación coincidan
                if (request.NuevoPassword != request.ConfirmarContraseña)
            {
                throw new ArgumentException("Las contraseñas no coinciden.");
            }

            // Encriptar la nueva contraseña
            string newPassword = _encriptar.AES_encriptar(request.NuevoPassword);
            usuario.Password = newPassword;

            // Actualizar la contraseña en la base de datos
            await _usuarioRepository.Update(usuario);

            // Remover el código OTP utilizado
            _otpStorage.Remove(request.Email);

            // Retornar el usuario actualizado como UsuarioResponse
            return _mapper.Map<UsuarioResponse>(usuario);
        }    

        public async Task<UsuarioResponse> RestablecerContrasenaEcommerce(RestablecerPasswordEcommerceRequest request)
        {
            /// Validar que el código OTP no esté vacío
            if (string.IsNullOrEmpty(request.CodigoOtp))
            {
                throw new ArgumentException("El código OTP es requerido para restablecer la contraseña.");
            }

            // Buscar el usuario asociado al correo electrónico en el almacenamiento
            var usuario = _usuarioRepository.ObtenerCorreoEccomerce(request.Email);
            if (usuario == null)
            {
                throw new ArgumentException("No se encontró ningún usuario asociado al correo electrónico proporcionado.");
            }
            string enviadoPorElUsuario = request.CodigoOtp;

            var codigoDeComparacion = await _usuarioRepository.ObtenerCodigoOtp(request.Email);// traer de la BD
            if (enviadoPorElUsuario != codigoDeComparacion.CodigoRecuperacion)
            {
                throw new ArgumentException("Los codigos no coinciden.");
            }
            // Validar que la nueva contraseña y su confirmación coincidan
            if (request.NuevoPassword != request.ConfirmarContraseña)
            {
                throw new ArgumentException("Las contraseñas no coinciden.");
            }

            // Encriptar la nueva contraseña
            string newPassword = _encriptar.AES_encriptar(request.NuevoPassword);
            usuario.Password = newPassword;

            // Actualizar la contraseña en la base de datos
            await _usuarioRepository.Update(usuario);

            // Remover el código OTP utilizado
            _otpStorage.Remove(request.Email);

            // Retornar el usuario actualizado como UsuarioResponse
            return _mapper.Map<UsuarioResponse>(usuario);
        }

        #endregion
        #region Insert,Update,Delete Usuarios
        public async Task<List<UsuarioUiRequest>> GetUiUsuarios()
        {
            return await _usuarioRepository.UiUsuarios();
        }

        public async Task<UsuarioUiResponse> InsertUiUsuarios(UsuarioUiRequest request)
        {
            var existingUser = _personaRepository.BuscarCorreo(request.Correo);
            if (existingUser != null)
            {
                throw new ArgumentException("El correo electrónico ya está registrado.");
            }

            var existingPersona = _personaRepository.BuscarTelefono(request.Telefono);
            if (existingPersona != null)
            {
                throw new ArgumentException("El número de teléfono ya está registrado.");
            }

            // Crear persona
            var persona = await _personaRepository.Create(new Persona
            {
                PrimerNombre = request.Nombres,
                ApellidoPaterno = "",
                Email = request.Correo,
                Telefono = request.Telefono,
                Genero = "",
                IdTipoDocumento = 1,
            });
            string role = request.Rol.ToLower() switch
            {
                "cajero" => "Cajero",
                "mozo" => "Mozo",
                _ => throw new ArgumentException("Rol no válido. Debe ser 'Cajero' o 'Mozo'.")
            };
            // Buscar rol
            var buscarRol = await _rolesRepository.GetByRol(role);

            // Crear usuario
            var nuevoUsuario = new Usuario
            {
                IdPersona = persona.IdPersona,
                Email = request.Correo,
                Password = _encriptar.AES_encriptar(request.Contrasena),
                IdRol = buscarRol.IdRol,
            };

            nuevoUsuario = await _usuarioRepository.InsertUiUsuarios(nuevoUsuario);

            // Mapear respuesta
            var response = _mapper.Map<UsuarioUiResponse>(nuevoUsuario);
            response.Persona = _mapper.Map<PersonaResponse>(persona);

            return response;
        }

        public async Task<UsuarioUiResponse> UpdateUiUsuarios(UsuarioUiUpdateRequest request)
        {
            // Find the existing user
            var existingUser = await _usuarioRepository.GetById(request.IdUsuario);
            if (existingUser == null)
            {
                throw new ArgumentException("El usuario no existe.");
            }

            // Find the existing persona
            var existingPersona = await _personaRepository.GetById(existingUser.IdPersona);
            if (existingPersona == null)
            {
                throw new ArgumentException("La persona asociada no existe.");
            }

            // Check if the new email is already in use by another user
            var userWithEmail = _personaRepository.BuscarCorreo(request.Correo);
            if (userWithEmail != null && userWithEmail.IdPersona != existingUser.IdPersona)
            {
                throw new ArgumentException("El correo electrónico ya está registrado.");
            }

            // Check if the new phone number is already in use by another user
            var userWithPhone = _personaRepository.BuscarTelefono(request.Telefono);
            if (userWithPhone != null && userWithPhone.IdPersona != existingUser.IdPersona)
            {
                throw new ArgumentException("El número de teléfono ya está registrado.");
            }

            // Update persona details
            existingPersona.PrimerNombre = request.Nombres;
            existingPersona.Email = request.Correo;
            existingPersona.Telefono = request.Telefono;
            // Update other persona fields as needed

            await _personaRepository.Update(existingPersona);

            // Determine the role (Cajero or Empleado) and fetch its details
            string role = request.Rol.ToLower() switch
            {
                "cajero" => "Cajero",
                "mozo" => "Mozo",
                _ => throw new ArgumentException("Rol no válido. Debe ser 'Cajero' o 'Mozo'.")
            };

            var buscarRol = await _rolesRepository.GetByRol(role);

            // Update user details
            existingUser.Email = request.Correo.ToLower();
            existingUser.Password = _encriptar.AES_encriptar(request.Contrasena);
            existingUser.IdRol = buscarRol.IdRol;
            // Update other user fields as needed

            await _usuarioRepository.Update(existingUser);

            // Map the response
            var response = _mapper.Map<UsuarioUiResponse>(existingUser);
            response.Persona = _mapper.Map<PersonaResponse>(existingPersona);

            return response;
        }
        public async Task DeleteUiUser(int idUsuario)
        {
            var usuario = await _usuarioRepository.GetById(idUsuario);
            if (usuario == null)
            {
                throw new ArgumentException("El usuario no existe.");
            }

            var persona = await _personaRepository.GetById(usuario.IdPersona);
            if (persona == null)
            {
                throw new ArgumentException("La persona asociada no existe.");
            }

            // Delete user
            await _usuarioRepository.DeleteUiUsuarios(idUsuario);

            // Delete associated person
            await _personaRepository.DeletePersona(persona.IdPersona);
        }
        #endregion
    }
}


    