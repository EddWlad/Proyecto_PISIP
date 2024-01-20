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
    public class ClienteControlador
    {
        private ClienteServicio servicio;
        public ClienteControlador() 
        {
            servicio = new ClienteServicio(); 
        }

        public bool InsertarCliente(ClienteVistaModelo clienteVistaModelo)
        {
            Cliente clienteDB = new Cliente();
            try 
            {
                clienteDB.nombre = clienteVistaModelo.Nombre;
                clienteDB.apellido = clienteVistaModelo.Apellido;
                clienteDB.direccion = clienteVistaModelo.Direccion;
                clienteDB.telefono = clienteVistaModelo.Telefono;
                clienteDB.email = clienteVistaModelo.Email;
                clienteDB.altura = clienteVistaModelo.Altura;
                clienteDB.peso = clienteVistaModelo.Peso;
                clienteDB.estado = clienteVistaModelo.Estado;
                servicio.InsertarCliente(clienteDB);
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public bool ModificarCliente(ClienteVistaModelo clienteVistaModelo)
        {
            Cliente clienteDB = new Cliente();
            try
            {
                clienteDB.nombre = clienteVistaModelo.Nombre;
                clienteDB.apellido = clienteVistaModelo.Apellido;
                clienteDB.direccion = clienteVistaModelo.Direccion;
                clienteDB.telefono = clienteVistaModelo.Telefono;
                clienteDB.email = clienteVistaModelo.Email;
                clienteDB.altura = clienteVistaModelo.Altura;
                clienteDB.peso = clienteVistaModelo.Peso;
                clienteDB.estado = clienteVistaModelo.Estado;
                servicio.ModificarCliente(clienteDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Cliente> ListarClientesActivos()
        {
            return servicio.ListarClientesActivos();
        }
        public IEnumerable<Cliente> ListarClientesNombres(string nombre)
        {
            return servicio.ListarClientesNombre(nombre);
        }
        public IEnumerable<Cliente> ListarClientesEstado(bool estado)
        {
            return servicio.ListarClientesEstado(estado);
        }

        
    }
}
