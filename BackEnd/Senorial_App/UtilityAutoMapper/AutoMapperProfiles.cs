using AutoMapper;
using DBSenorialModels.Senorial;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Usuarios.Roles;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
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




            #endregion
            #region Schema_Ventas
            #endregion

        }
    }
}
