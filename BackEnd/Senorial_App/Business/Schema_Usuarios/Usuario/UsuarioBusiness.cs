using AutoMapper;
using Azure;
using Azure.Core;
using Business.Schema_Generico.Imagenes;
using CommonModels.Common;
using DBSenorialModels.Senorial;
using DBSenorialModels.View.Auth.Usuario;
using DBSenorialModels.View.Usuario.User;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Office;
using Google.Apis.Auth;
using IBusiness.Schema_Generico.Imagenes;
using IBusiness.Schema_Usuarios.Personas;
using IBusiness.Schema_Usuarios.Roles;
using IBusiness.Schema_Usuarios.Usuarios;
using IRepository.Schema_Generico.Imagenes;
using IRepository.Schema_Usuarios.Personas;
using IRepository.Schema_Usuarios.Roles;
using IRepository.Schema_Usuarios.Usuarios;
using IRepository.Schema_Ventas.Clientes;
using IRepository.Schema_Ventas.Empleados;
using Microsoft.Extensions.Logging;
using Repository.Schema_Generico.Imagenes;
using Repository.Schema_Usuarios.Personas;
using Repository.Schema_Usuarios.Roles;
using Repository.Schema_Usuarios.Usuarios;
using Repository.Schema_Ventas.Clientes;
using Repository.Schema_Ventas.Empleados;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.CloudinaryRes;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Schema_Ventas.Empleados;
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
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IImagenesBusiness _imagenesBusiness;
        private readonly IImagenesRepository _imagenesRepository;
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
            _empleadoRepository = new EmpleadoRepository();
            _imagenesBusiness = new ImagenesBusiness(mapper);
            _imagenesRepository = new ImagenesRepository();
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
        public async Task<VwUsuario> BuscarPorCorreo(string email)
        {
            VwUsuario usuario =  await _usuarioRepository.ObtenerPorCorreo(email);
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

            // Separar nombres y apellido paterno
            string[] nombresSeparados = request.Nombres.Split(' ');
            string primerNombre = nombresSeparados[0];
            string apellidoPaterno = nombresSeparados.Length > 1 ? nombresSeparados[nombresSeparados.Length - 1] : string.Empty;

            // Crear Persona
            var persona = new Persona
            {
                PrimerNombre = primerNombre,
                ApellidoPaterno = apellidoPaterno,
                NroDocumento = request.Dni,
                Email = request.Email,
                Telefono = request.Telefono,
                IdTipoDocumento = 1, // Este valor es arbitrario, ajústalo según sea necesario
                Genero = "",
                TipoPersona = "Natural",
            };

            persona = await _personaRepository.Create(persona);

            if (persona == null || persona.IdPersona == 0)
            {
                throw new Exception("Error al crear la persona");
            }

            // Obtener Rol
            var buscarRol = await _rolesRepository.GetByRol("Mozo");

            // Crear y guardar Empleado
            var nuevoEmpleado = new Empleado
            {
                IdPersona = persona.IdPersona,
                IdSucursal = 1, // Este valor es arbitrario, ajústalo según sea necesario
                IdRol = buscarRol.IdRol,
            };

            var nuevoEmpleadoCreado = await _empleadoRepository.Create(nuevoEmpleado);
            if (nuevoEmpleadoCreado == null)
            {
                throw new Exception("Error al crear el empleado");
            }

            // Crear y guardar Usuario
            var nuevoUsuario = new Usuario
            {
                IdPersona = persona.IdPersona,
                Email = request.Email,
                Password = _encriptar.AES_encriptar(request.Password),
                IdRol = buscarRol.IdRol,
            };

            nuevoUsuario = await _usuarioRepository.RegistrarUsuarioMobile(nuevoUsuario);

            // Mapear y devolver la respuesta
            var response = _mapper.Map<SignInMobileResponse>(nuevoUsuario);
            response.Persona = _mapper.Map<PersonaResponse>(persona);

            return response;
        }

        public async Task<UsuarioResponse> AutenticarConGoogleEcommerce(string tokenId)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId);
            if (payload == null)
            {
                throw new ArgumentException("Invalid Google token.");
            }

            string email = payload.Email;
            string nombre = payload.Name;

            // Verifica si el usuario ya existe en tu base de datos
            var usuarioExistente = _usuarioRepository.ObtenerPorCorreo(email);
            if (usuarioExistente != null)
            {
                return _mapper.Map<UsuarioResponse>(usuarioExistente);
            }

            // Si el usuario no existe, procede a registrarlo
            var nuevaPersona = await _personaRepository.Create(new Persona
            {
                PrimerNombre = nombre.Split(' ')[0],
                ApellidoPaterno = nombre.Split(' ').Length > 1 ? nombre.Split(' ')[1] : "",
                Email = email,
                Direccion = "",
                TipoPersona = "Natural",
                IdTipoDocumento = 1,
                Telefono = "",
                // Otros campos necesarios
            });

            var nuevoCliente = new Cliente
            {
                IdPersona = nuevaPersona.IdPersona,
                // Completar otros campos de Cliente según sea necesario
            };

            await _clienteRepository.Create(nuevoCliente);

            var nuevoUsuario = new Usuario
            {
                IdPersona = nuevaPersona.IdPersona,
                Email = email,
                UserName = email,
                Password = _encriptar.AES_encriptar(Guid.NewGuid().ToString()), // Genera una contraseña aleatoria
                IdRol = (await _rolesRepository.GetByRol("Cliente")).IdRol // Asigna el rol de cliente
            };

            nuevoUsuario = await _usuarioRepository.RegistrarUsuarioEcommerce(nuevoUsuario);

            return _mapper.Map<UsuarioResponse>(nuevoUsuario);
        }
        public async Task<UsuarioResponse> AutenticarConGoogleMobile(string tokenId)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId);
            if (payload == null)
            {
                throw new ArgumentException("Invalid Google token.");
            }

            string email = payload.Email;
            string nombre = payload.Name;

            // Verifica si el usuario ya existe en tu base de datos
            var usuarioExistente = _usuarioRepository.ObtenerPorCorreo(email);
            if (usuarioExistente != null)
            {
                return _mapper.Map<UsuarioResponse>(usuarioExistente);
            }

            // Si el usuario no existe, procede a registrarlo
            var nuevaPersona = await _personaRepository.Create(new Persona
            {
                PrimerNombre = nombre.Split(' ')[0],
                ApellidoPaterno = nombre.Split(' ').Length > 1 ? nombre.Split(' ')[1] : "",
                Email = email,
                NroDocumento = "",
                Telefono = "",
                IdTipoDocumento = 1, // Este valor es arbitrario, ajústalo según sea necesario
                Genero = "",
                TipoPersona = "Natural",
                // Otros campos necesarios
            });

            var nuevoEmpleado = new Empleado
            {
                IdPersona = nuevaPersona.IdPersona,
                IdSucursal = 1, // Este valor es arbitrario, ajústalo según sea necesario
                IdRol = (await _rolesRepository.GetByRol("Mozo")).IdRol
            };

            await _empleadoRepository.Create(nuevoEmpleado);

            var nuevoUsuario = new Usuario
            {
                IdPersona = nuevaPersona.IdPersona,
                Email = email,
                UserName = email,
                Password = _encriptar.AES_encriptar(Guid.NewGuid().ToString()), // Genera una contraseña aleatoria
                IdRol = (await _rolesRepository.GetByRol("Mozo")).IdRol // Asigna el rol de mozo
            };

            nuevoUsuario = await _usuarioRepository.RegistrarUsuarioMobile(nuevoUsuario);

            return _mapper.Map<UsuarioResponse>(nuevoUsuario);
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
        public async Task<bool> DeleteUiUser(int idUsuario)
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
            return true;
        }
        #endregion

        #region MetodoUsuario
        public async Task<GenericFilterResponse<VwUsuarios>> ListarUsuarioAsync(GenericFilterRequest req)
        {
            return await _usuarioRepository.GetByFilterViewAsync(req);
        }

        public async Task<CustomResponse> CrearNuevoUsuarioAsync(UsuarioAddRequest req)
        {
            EncriptarDesencriptar encriptar = new();
            //Registra Imagen
            UploadImageResponse imagen = await _imagenesBusiness.SubirImagenAsync(req.File);
            Imagene img = new()
            {
                FileName = imagen.PublicId,
                ImageData = imagen.Url,
            };
            img = await _imagenesRepository.Create(img);

            //Crear Persona
            Guid guid = Guid.NewGuid();
            string guidString = guid.ToString();
            Persona persona = new() 
            {
                PrimerNombre = "test",
                SegundoNombre = "",
                ApellidoMaterno = "test",
                ApellidoPaterno = "",
                NroDocumento = guidString,
                Email = req.Email,
                Telefono = req.Contact,
                Direccion = "",
                IdTipoDocumento = 1,
                TipoPersona = "Natural",
                RazonSocial = "",
                Genero = "",
            };
            persona = await _personaRepository.Create(persona);
            
            //Crear Usuario
            Usuario usuario = new()
            {
                UserName = guidString,
                Password = encriptar.AES_encriptar(req.Password),
                CreatedAt = DateTime.Now,
                IdPersona = persona.IdPersona,
                UpdateAt = DateTime.Now,
                IdRol = req.Role,
                Email = req.Email,
                CambiarPassword = "",
                CodigoRecuperacion = "",
                IdImg = img.Id,
            };
            await _usuarioRepository.Create(usuario);

            //Respuesta
            CustomResponse res = new()
            {
                Code = "2000",
                Message = "Se registro Correctamente"
            };
            return res;
        }
        public async Task<CustomResponse> ActulizarUsuarioAsync(UsuarioUpdateRequest req)
        {
            //Campos
            EncriptarDesencriptar encriptar = new();
            Imagene img = new();
            Usuario user = await _usuarioRepository.GetById(req.IdUsuario);
            if(user == null)
            {
                throw new Exception("Usuaro No encontrado");
            }
            Persona persona = await _personaRepository.GetById(user.IdPersona);

            

            //Registra Imagen
            if (req.Nuevo) 
            {
                UploadImageResponse imagen = await _imagenesBusiness.SubirImagenAsync(req.File);
                img.FileName = imagen.PublicId;
                img.ImageData = imagen.Url;
                img = await _imagenesRepository.Create(img);
            }
            else
            {
                 img = await _imagenesRepository.GetById(user.IdImg);
            }
            //Editar Persona
            persona.Telefono = req.Contact;
            persona.Email = req.Email;
            await _personaRepository.Update(persona);

            //Editar Usuario
            if(user.Password != req.Password)
            {
                user.Password = encriptar.AES_encriptar(req.Password);
            }
            user.Email = req.Email;
            user.IdRol = req.Role;
            await _usuarioRepository.Update(user);

            //Respuesta
            CustomResponse res = new()
            {
                Code = "2000",
                Message = "Se actulizo Correctamente"
            };

            return res;
        }
        #endregion MetodoUsuario
    }
}


    