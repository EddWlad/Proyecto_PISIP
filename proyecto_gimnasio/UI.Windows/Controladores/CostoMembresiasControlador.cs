using Aplicacion.Servicio;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Windows.VistaModelos;

namespace UI.Windows.Controladores
{
    public class CostoMembresiasControlador
    {
        private CostoMembresiasServicio servicio;
        public CostoMembresiasControlador()
        {
            servicio = new CostoMembresiasServicio();
        }
        public bool InsertarCostoMembresia(CostoMembresiasVistaModelo costoMembresiasVistaModelo)
        {
            Costo_Membresia costoMembresiaDB = new Costo_Membresia();
            try
            {
                costoMembresiaDB.descripcion = costoMembresiasVistaModelo.Descripcion;
                costoMembresiaDB.valor = costoMembresiasVistaModelo.Valor;
                costoMembresiaDB.estado = costoMembresiasVistaModelo.Estado;
                servicio.InsertarCostoMembresia(costoMembresiaDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ModificarCostoMembresia(CostoMembresiasVistaModelo costoMembresiasVistaModelo)
        {
            Costo_Membresia costoMembresiaDB = new Costo_Membresia();
            try
            {
                costoMembresiaDB.id_costo_membresia = costoMembresiasVistaModelo.Id_Costo_Membresia;
                costoMembresiaDB.descripcion = costoMembresiasVistaModelo.Descripcion;
                costoMembresiaDB.valor = costoMembresiasVistaModelo.Valor;
                costoMembresiaDB.estado = costoMembresiasVistaModelo.Estado;
                servicio.ModificarCostoMembresia(costoMembresiaDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<Costo_Membresia> ListarCostoMembresiasDescripcion(string descripcion)
        {
            return servicio.ListarCostosMembresiasDescripcion(descripcion);
        }
        public IEnumerable<Costo_Membresia> ListarCostoMembresiasActivas()
        {
            return servicio.ListarCostosMembresiasActivas();
        }
        public IEnumerable<Costo_Membresia> ListarCostoMembresiasCosto(decimal costo)
        {
            return servicio.ListarCostoMembresiaCosto(costo);
        }
        public bool EliminarCostoMembresia(int id)
        {
            return servicio.EliminarCostoMembresia(id);

        }
    }
}
