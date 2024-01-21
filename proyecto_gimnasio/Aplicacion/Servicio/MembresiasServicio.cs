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
        public IEnumerable<Membresias> ListarMembresiasTipo(String tipo)
        {
            return this.membresiasRepository.ListarMembresiasTipo(tipo);
        }
        public IEnumerable<Membresias> ListarMembresiasActivas()
        {
            return this.membresiasRepository.ListarMembresiasActivas();
        }
        public IEnumerable<Membresias> ListarMembresiasEstado(Boolean estado)
        {
            return this.membresiasRepository.ListarMembresiasEstados(estado);
        }
    }
}
