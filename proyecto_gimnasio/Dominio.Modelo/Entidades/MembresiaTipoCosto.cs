using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Entidades
{
    public class MembresiaTipoCosto
    {
        public int id_costo_membresia { get; set; }
        public string tipo_membresia { get; set; }
        public decimal costo { get; set; }
        public bool estado { get; set; }
    }
}
