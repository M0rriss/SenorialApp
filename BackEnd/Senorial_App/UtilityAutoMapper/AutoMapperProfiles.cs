using AutoMapper;
using DBSenorialModels.Senorial;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
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
        }
    }
}
