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
        public IEnumerable<ClienteTipoCliente> ListarClientesActivos()
        {
            return this.clienteRepository.ListarClientesActivos();
        }
        public IEnumerable<ClienteTipoCliente> ListarClientesNombre(String nombre)
        {
            return this.clienteRepository.ListarClienteNombre(nombre);
        }
        public Cliente ObtenerCliente(int id)
        {
            return this.clienteRepository.GetById(id);
        }
        public bool EliminarCliente(int id)
        {
            return this.clienteRepository.ElminarCliente(id);
        }
        public IEnumerable<ClienteTipoCliente> ListarClientesTipo(String tipo)
        {
            return this.clienteRepository.ListarClientesTipo(tipo);
        }
        public IEnumerable<ClienteTipoCliente> ListarClientesCedula(String cedula)
        {
            return this.clienteRepository.ListarClientesCedula(cedula);
        }
        public IEnumerable<ClienteTipoCliente> ListarClientesMembresia(String membresia)
        {
            return this.clienteRepository.ListarClienteMembresia(membresia);
        }
        public void GuardarFoto(int id, byte[] foto)
        {
            this.clienteRepository.Guardarfoto(id, foto);
        }
    }
}
