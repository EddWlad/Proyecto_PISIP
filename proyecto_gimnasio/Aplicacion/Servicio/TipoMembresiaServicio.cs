using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicio
{
    public class TipoMembresiaServicio
    {
        readonly ITipoMembresiaRepository tipoMembresiaRepository;
        public TipoMembresiaServicio()
        {
            this.tipoMembresiaRepository = new TipoMembresiasRepository();
        }
        public IEnumerable<Tipo_Membresia> ListarTipoMembresia()
        {
            return this.tipoMembresiaRepository.GetAll();
        }
        public void InsertarTipoMembresia(Tipo_Membresia nuevoTipoMembresia)
        {
            this.tipoMembresiaRepository.Add(nuevoTipoMembresia);
        }
        public void ModificarTipoMembresia(Tipo_Membresia modificadoTipoMembresia)
        {
            this.tipoMembresiaRepository.Modify(modificadoTipoMembresia);
        }
        public IEnumerable<Tipo_Membresia> ListarTipoMembresiaDescripcion(String descripcion)
        {
            return this.tipoMembresiaRepository.ListarTipoMembresias(descripcion);
        }
        public IEnumerable<Tipo_Membresia> ListarTiposMembresiasActivos()
        {
            return this.tipoMembresiaRepository.ListarTipoMembresiasActivas();
        }
    }
}
