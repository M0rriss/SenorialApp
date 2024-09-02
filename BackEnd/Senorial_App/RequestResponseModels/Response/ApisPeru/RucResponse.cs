using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.ApisPeru
{
    public class RucResponse
    {
        private string _ruc = string.Empty;
        private string _razonSocial = string.Empty;
        private string _nombreComercial = string.Empty;
        private List<string> _telefonos = [];
        private string _tipo = string.Empty;
        private string _estado = string.Empty;
        private string _condicion = string.Empty;
        private string _direccion = string.Empty;
        private string _departamento = string.Empty;
        private string _provincia = string.Empty;
        private string _distrito = string.Empty;
        private string _fechaInscripcion = string.Empty;
        private string _sistEmsion = string.Empty;
        private string _sistContabilidad = string.Empty;
        private string _actExterior = string.Empty;
        private List<string> _actEconomicas = [];
        private List<string> _cpPago = [];
        private List<string> _sistElectronica = [];
        private string _fechaEmisorFe = string.Empty;
        private List<string> _cpeElectronico = [];
        private string _fechaPle = string.Empty;
        private List<string> _padrones = [];
        private string _fechaBaja = string.Empty;
        private string _profesion = string.Empty;
        private string _ubigeo = string.Empty;
        private string _capital = string.Empty;

        public string Ruc { get => _ruc; set => _ruc = value; }
        public string RazonSocial { get => _razonSocial; set => _razonSocial = value; }
        public string NombreComercial { get => _nombreComercial; set => _nombreComercial = value; }
        public List<string> Telefonos { get => _telefonos; set => _telefonos = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Condicion { get => _condicion; set => _condicion = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Departamento { get => _departamento; set => _departamento = value; }
        public string Provincia { get => _provincia; set => _provincia = value; }
        public string Distrito { get => _distrito; set => _distrito = value; }
        public string FechaInscripcion { get => _fechaInscripcion; set => _fechaInscripcion = value; }
        public string SistEmsion { get => _sistEmsion; set => _sistEmsion = value; }
        public string SistContabilidad { get => _sistContabilidad; set => _sistContabilidad = value; }
        public string ActExterior { get => _actExterior; set => _actExterior = value; }
        public List<string> ActEconomicas { get => _actEconomicas; set => _actEconomicas = value; }
        public List<string> CpPago { get => _cpPago; set => _cpPago = value; }
        public List<string> SistElectronica { get => _sistElectronica; set => _sistElectronica = value; }
        public string FechaEmisorFe { get => _fechaEmisorFe; set => _fechaEmisorFe = value; }
        public List<string> CpeElectronico { get => _cpeElectronico; set => _cpeElectronico = value; }
        public string FechaPle { get => _fechaPle; set => _fechaPle = value; }
        public List<string> Padrones { get => _padrones; set => _padrones = value; }
        public string FechaBaja { get => _fechaBaja; set => _fechaBaja = value; }
        public string Profesion { get => _profesion; set => _profesion = value; }
        public string Ubigeo { get => _ubigeo; set => _ubigeo = value; }
        public string Capital { get => _capital; set => _capital = value; }
    }
}
