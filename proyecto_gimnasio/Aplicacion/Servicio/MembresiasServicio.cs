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
    public class MembresiasServicio
    {
        readonly IMembresiasRepository membresiasRepository;
        public MembresiasServicio()
        {
            this.membresiasRepository = new MembresiasRepository();
        }
        public IEnumerable<Membresias> ListarMembresias()
        {
            return this.membresiasRepository.GetAll();
        }
        public void InsertarMembresias(Membresias nuevaMembresia)
        {
            this.membresiasRepository.Add(nuevaMembresia);
        }
        public void ModificarMembresia(Membresias modificadoMembresia)
        {
            this.membresiasRepository.Modify(modificadoMembresia);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasActivas()
        {
            return this.membresiasRepository.ListarMembresiasActivas();
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasCosto(decimal valor)
        {
            return this.membresiasRepository.MembresiaCosto(valor);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasFechaFin(DateTime fecha_fin)
        {
            return this.membresiasRepository.MembresiaFechaFin(fecha_fin);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasFechaInicio(DateTime fecha_inicio)
        {
            return this.membresiasRepository.MembresiaFechaInicio(fecha_inicio);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasFechaRegistro(DateTime fecha_registro)
        {
            return this.membresiasRepository.MembresiaFechaRegistro(fecha_registro);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasPromocion(string promocion)
        {
            return this.membresiasRepository.MembresiaPromocion(promocion);
        }
        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasTipo(string tipo)
        {
            return this.membresiasRepository.MembresiaTipos(tipo);
        }
        public bool EliminarMembresia(int id)
        {
            return this.membresiasRepository.ElminarMmebresia(id);
        }
    }
}
