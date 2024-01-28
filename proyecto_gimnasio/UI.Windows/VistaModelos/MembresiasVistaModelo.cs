using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Windows.VistaModelos
{
    public class MembresiasVistaModelo
    {
        public int Id_Membresia { get; set; }
        public Nullable<System.DateTime> Fecha_Registro { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> Fecha_Inicio { get; set; }
        public Nullable<System.DateTime> Fecha_Fin { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> Id_Tipo_Membresia { get; set; }
        public Nullable<int> Id_Costo_Membresia { get; set; }
        public Nullable<int> Id_Promocion { get; set; }
    }
}
