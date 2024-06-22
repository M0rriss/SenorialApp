using AutoMapper;
using DBSenorialModels.Senorial;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Almacen.Insumo;
using RequestResponseModels.Request.Schema_Almacen.Proveedor;
using RequestResponseModels.Request.Schema_Generico.Estado;
using RequestResponseModels.Request.Schema_Generico.Imagenes;
using RequestResponseModels.Request.Schema_Generico.UnidadMedicion;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using RequestResponseModels.Request.Schema_Usuarios.Roles;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Request.Schema_Ventas.Empleados;
using RequestResponseModels.Request.Schema_Ventas.Productos;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Almacen.Insumo;
using RequestResponseModels.Response.Schema_Almacen.Proveedor;
using RequestResponseModels.Response.Schema_Generico.Estado;
using RequestResponseModels.Response.Schema_Generico.Imagenes;
using RequestResponseModels.Response.Schema_Generico.UnidadMedicion;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Usuarios.Roles;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Schema_Ventas.Cliente;
using RequestResponseModels.Response.Schema_Ventas.Empleados;
using RequestResponseModels.Response.Schema_Ventas.Productos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityAutoMapper
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            #region AUTHORIZATION
            CreateMap<Usuario, SignInEcommerceResponse>().ReverseMap();
            CreateMap<Usuario, SignInMobileResponse>().ReverseMap();
            CreateMap<Persona, PersonaResponse>().ReverseMap();
            CreateMap<Usuario, RestablecerPasswordMovilRequest>().ReverseMap();
            CreateMap<UsuarioResponse, LoginDashboardResponse>().ReverseMap();
            CreateMap<UsuarioResponse, LoginEcommerceResponse>().ReverseMap();
            CreateMap<UsuarioResponse, LoginMobileResponse>().ReverseMap();
            CreateMap<UsuarioResponse, LoginUserRequest>().ReverseMap();
            #endregion


            #region Schema_Almacen

            #region Categoria
            CreateMap<Categoria, CategoriaRequest>().ReverseMap();
            CreateMap<Categoria,CategoriaResponse>().ReverseMap();
            CreateMap<CategoriaRequest,CategoriaResponse>().ReverseMap();
            #endregion
            #region Insumo
            CreateMap<Insumo, InsumoRequest>().ReverseMap();
            CreateMap<Insumo, InsumoResponse>().ReverseMap();
            CreateMap<InsumoRequest, InsumoResponse>().ReverseMap();
            #endregion
            #region Proveedor
            CreateMap<Proveedor, ProveedorRequest>().ReverseMap();
            CreateMap<Proveedor, ProveedorResponse>().ReverseMap();
            CreateMap<ProveedorRequest,ProveedorResponse>().ReverseMap();
            CreateMap<ProveedorUiRequest,Proveedor>().ReverseMap();
            #endregion

            #endregion
            #region Schema_Generico
            #region Estado
            CreateMap<Estado, EstadoRequest>().ReverseMap();
            CreateMap<Estado, EstadoResponse>().ReverseMap();
            CreateMap<EstadoRequest, EstadoResponse>().ReverseMap();
            #endregion
            #region Imagenes
            CreateMap<Imagene, ImagenesRequest>().ReverseMap();
            CreateMap<Imagene, ImagenesResponse>().ReverseMap();
            CreateMap<ImagenesRequest, ImagenesResponse>().ReverseMap();
            #endregion
            #region UnidadMedicion
            CreateMap<UnidadMedicion, UnidadMedicionRequest>().ReverseMap();
            CreateMap<UnidadMedicion, UnidadMedicionResponse>().ReverseMap();
            CreateMap<UnidadMedicionRequest, UnidadMedicionResponse>().ReverseMap();
            #endregion
            #endregion
            #region Schema_Produccion
            #endregion
            #region Schema_Usuarios
            #region Usuarios
            CreateMap<Usuario,UsuarioRequest>().ReverseMap();
            CreateMap<Usuario,UsuarioResponse>().ReverseMap();
            CreateMap<UsuarioRequest, UsuarioResponse>().ReverseMap();

            #endregion
            #region Roles
            CreateMap<Role, RolesRequest>().ReverseMap();
            CreateMap<Role, RolesResponse>().ReverseMap();
            CreateMap<RolesRequest, RolesResponse>().ReverseMap();
            #endregion
            #region Personas
            CreateMap<Persona, PersonaRequest>().ReverseMap();
            CreateMap<Persona, PersonaResponse>().ReverseMap();
            CreateMap<PersonaRequest, PersonaResponse>().ReverseMap();
            #endregion
            
            #endregion
            #region Schema_Ventas
            #region Producto
            CreateMap<Producto, ProductoRequest>().ReverseMap();
            CreateMap<Producto, ProductoResponse>().ReverseMap();
            CreateMap<ProductoRequest, ProductoResponse>().ReverseMap();
            #endregion
            #region Cliente
            CreateMap<Cliente, ClienteRequest>().ReverseMap();
            CreateMap<Cliente, ClienteResponse>().ReverseMap();
            CreateMap<ClienteRequest, ClienteResponse>().ReverseMap();
            CreateMap<Cliente, ClienteUiRequest>().ReverseMap();
            #endregion
            #region Empleado
            CreateMap<Empleado, EmpleadoRequest>().ReverseMap();
            CreateMap<Empleado, EmpleadoResponse>().ReverseMap();
            CreateMap<EmpleadoRequest, EmpleadoResponse>().ReverseMap();
            CreateMap<Empleado, EmpleadoUiRequest>().ReverseMap();

            #endregion
            #endregion

        }
    }
}
