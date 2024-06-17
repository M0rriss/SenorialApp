using AutoMapper;
using DBSenorialModels.Senorial;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using RequestResponseModels.Request.Schema_Usuarios.PersonaNatural;
using RequestResponseModels.Request.Schema_Usuarios.Roles;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Usuarios.PersonaNatural;
using RequestResponseModels.Response.Schema_Usuarios.Roles;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
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
            CreateMap<PersonaNatural, PersonaNaturalResponse>().ReverseMap();
            #endregion


            #region Schema_Almacen

            #region Categoria
            CreateMap<Categoria, CategoriaRequest>().ReverseMap();
            CreateMap<Categoria,CategoriaResponse>().ReverseMap();
            CreateMap<CategoriaRequest,CategoriaResponse>().ReverseMap();
            #endregion
            #region Compra

            #endregion

            #endregion
            #region Schema_Generico
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
            #region PersonaNatural
            CreateMap<PersonaNatural, PersonaNaturalRequest>().ReverseMap();
            CreateMap<PersonaNatural, PersonaNaturalResponse>().ReverseMap();
            CreateMap<PersonaNaturalRequest, PersonaNaturalResponse>().ReverseMap();
            #endregion
            

            #endregion
            #region Schema_Ventas
            #endregion

        }
    }
}
