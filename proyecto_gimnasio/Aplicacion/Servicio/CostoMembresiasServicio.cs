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
    public class CostoMembresiasServicio
    {
        readonly ICostoMembresiaRepository costoMembresiaRepository;
        public CostoMembresiasServicio()
        {
            this.costoMembresiaRepository = new CostoMembresiasRepository();
        }
        public IEnumerable<Costo_Membresia> ListarCostoMembresias()
        {
            return this.costoMembresiaRepository.GetAll();
        }
        public void InsertarCostoMembresia(Costo_Membresia nuevoCostoMembresia)
        {
            this.costoMembresiaRepository.Add(nuevoCostoMembresia);
        }
        public void ModificarCostoMembresia(Costo_Membresia modificadoCostoMembresia)
        {
            this.costoMembresiaRepository.Modify(modificadoCostoMembresia);
        }
        public IEnumerable<MembresiaTipoCosto> ListarCostosMembresiasDescripcion(String descripcion)
        {
            return this.costoMembresiaRepository.ListarCostoMembresia(descripcion);
        }
        public IEnumerable<Costo_Membresia> ListarCostosMembresiasActivas()
        {
            return this.costoMembresiaRepository.ListarCostosMembresiasActivas();
        }
        public bool EliminarCostoMembresia(int id)
        {
            return this.costoMembresiaRepository.EliminarCostoMembresia(id);
        }
        public IEnumerable<MembresiaTipoCosto> ListarCostoMembresiaCosto(Decimal costo)
        {
            return this.costoMembresiaRepository.ListarCosto(costo);
        }
        public IEnumerable<MembresiaTipoCosto> ListarCostosMembresiasTipos()
        {
            return this.costoMembresiaRepository.ListarMembresiasCostoTipo();
        }
    }
}
