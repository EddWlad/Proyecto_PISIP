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
    public class TipoClienteServicio
    {
        readonly ITipoClienteRepository tipoClienteRepository;
        public TipoClienteServicio()
        {
            this.tipoClienteRepository = new TipoClienteRepository();
        }
        public IEnumerable<Tipo_Cliente> ListarTipoCliente()
        {
            return this.tipoClienteRepository.GetAll();
        }
        public void InsertarTipoCliente(Tipo_Cliente nuevoTipoCliente)
        {
            this.tipoClienteRepository.Add(nuevoTipoCliente);
        }
        public void ModificarTipoCliente(Tipo_Cliente modificadoTipoCliente)
        {
            this.tipoClienteRepository.Modify(modificadoTipoCliente);
        }
        public IEnumerable<Tipo_Cliente> ListarTipoClientesDescripcion(String descripcion)
        {
            return this.tipoClienteRepository.ListarTipoClientes(descripcion);
        }
        public IEnumerable<Tipo_Cliente> ListarTiposActivos()
        {
            return this.tipoClienteRepository.ListarTiposActivos();
        }
    }
}
