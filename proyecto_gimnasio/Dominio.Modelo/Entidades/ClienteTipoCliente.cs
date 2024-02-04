using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Entidades
{
    public class ClienteTipoCliente
    {
        public int id_cliente { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public decimal altura { get; set; }
        public decimal peso { get; set; }
        public string tipoCliente { get; set; }
        public bool estado { get; set; }
        public string membresia { get; set; }
        public byte[] foto { get; set; }
    }
}
