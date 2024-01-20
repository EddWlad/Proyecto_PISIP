using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Windows.VistaModelos
{
    public class ClienteVistaModelo
    {
        public int Idcliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public Nullable<decimal> Altura { get; set; }
        public Nullable<decimal> Peso { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> Idpromocion_membresia { get; set; }
    }
}
