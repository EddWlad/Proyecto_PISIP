using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicio
{
    public class ClienteServicio
    {
        readonly IClienteRepository clienteRepository;
        public ClienteServicio()
        {
            this.clienteRepository = new ClienteRepository();
        }
        
        public IEnumerable<Cliente> ListarCliente()
        {
            return this.clienteRepository.GetAll();
        }
        public void InsertarCliente(Cliente nuevoCliente) 
        { 
            this.clienteRepository.Add(nuevoCliente);
        }
        public void ModificarCliente(Cliente modificadoCliente)
        {
            this.clienteRepository.Modify(modificadoCliente);
        }
        public IEnumerable<Cliente> ListarClientesActivos()
        {
            return this.clienteRepository.ListarClientesActivos();
        }
        public IEnumerable<Cliente> ListarClientesNombre(String nombre)
        {
            return this.clienteRepository.ListarClienteNombre(nombre);
        }
        public IEnumerable<Cliente> ListarClientesEstado(Boolean estado)
        {
            return this.clienteRepository.ListarClientesEstados(estado);
        }
    }
}
