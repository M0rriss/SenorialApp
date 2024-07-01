using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Request.Schema_Almacen.Proveedor
{
    public class ProveedorRequest
    {
        public int IdProveedor { get; set; }
        public int IdPersona { get; set; }
        public string? Vende { get; set; }
    }
    public class ProveedorUiRequest
    {
        public string ProveedorNombre { get; set; }
        [EmailAddress]
        public string Correo {  get; set; }
        [Phone]
        public string Telefono {  get; set; }
        [DocumentType]
        public string Dni { get; set; }
        public string Distribuye { get; set; }
    }
    public class ProveedorUpdateUiRequest
    {
        public int IdProveedor { get; set; }
        public string ProveedorNombre { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        [Phone]
        public string Telefono { get; set; }
        [DocumentType]
        public string Dni { get; set; }
        public string Distribuye { get; set; }
    }
}
