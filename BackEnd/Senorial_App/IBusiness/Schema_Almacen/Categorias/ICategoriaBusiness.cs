using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IBusiness.Schema_Almacen.Categorias
{
    public interface ICategoriaBusiness : ICrudBusiness<CategoriaRequest, CategoriaResponse>
    {
    }
}
