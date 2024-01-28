using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Windows.VistaModelos
{
    public class CostoMembresiasVistaModelo
    {
        public int Id_Costo_Membresia { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public bool Estado { get; set; }
    }
}
