using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.Documentos;
using RequestResponseModels.Response.Schema_Ventas.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.Documentos
{
    public interface IDocumentoBusiness : ICrudBusiness<DocumentoRequest, DocumentoResponse>
    {
    }
}
