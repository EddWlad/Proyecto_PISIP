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
                clienteDB.id_tipo_cliente = clienteVistaModelo.Id_Tipo_Cliente;
                clienteDB.foto = clienteVistaModelo.Foto;
                clienteDB.cedula = clienteVistaModelo.Cedula;
                clienteDB.nombre = clienteVistaModelo.Nombre;
                clienteDB.apellido = clienteVistaModelo.Apellido;
                clienteDB.direccion = clienteVistaModelo.Direccion;
                clienteDB.telefono = clienteVistaModelo.Telefono;
                clienteDB.email = clienteVistaModelo.Email;
                clienteDB.altura = clienteVistaModelo.Altura;
                clienteDB.peso = clienteVistaModelo.Peso;
                clienteDB.id_membresia = clienteVistaModelo.Id_Membresia;
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
                clienteDB.id_cliente = clienteVistaModelo.Id_Cliente;
                clienteDB.foto = clienteVistaModelo.Foto;
                clienteDB.id_tipo_cliente = clienteVistaModelo.Id_Tipo_Cliente;
                clienteDB.cedula = clienteVistaModelo.Cedula;
                clienteDB.nombre = clienteVistaModelo.Nombre;
                clienteDB.apellido = clienteVistaModelo.Apellido;
                clienteDB.direccion = clienteVistaModelo.Direccion;
                clienteDB.telefono = clienteVistaModelo.Telefono;
                clienteDB.email = clienteVistaModelo.Email;
                clienteDB.altura = clienteVistaModelo.Altura;
                clienteDB.peso = clienteVistaModelo.Peso;
                clienteDB.id_membresia = clienteVistaModelo.Id_Membresia;
                clienteDB.estado = clienteVistaModelo.Estado;
                servicio.ModificarCliente(clienteDB);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Cliente ObtenerCliente(int id)
        {
            return servicio.ObtenerCliente(id);
        }

        public IEnumerable<ClienteTipoCliente> ListarClientesActivos()
        {
            return servicio.ListarClientesActivos();
        }
        public IEnumerable<ClienteTipoCliente> ListarClientesNombres(string nombre)
        {
            return servicio.ListarClientesNombre(nombre);
        }
        
        public IEnumerable<ClienteTipoCliente> ListarClientesTipo(string tipo)
        {
            return servicio.ListarClientesTipo(tipo);
        }
        public IEnumerable<ClienteTipoCliente> ListarClientesCedula(string cedula)
        {
            return servicio.ListarClientesCedula(cedula);
        }
        public IEnumerable<ClienteTipoCliente> ListarClientesMembresia(string membresia)
        {
            return servicio.ListarClientesMembresia(membresia);
        }

        public bool EliminarCliente(int id)
        {
            return servicio.EliminarCliente(id);
            
        }
        public void CargarFoto(int idCliente, byte[]foto)
        {
            this.servicio.GuardarFoto(idCliente,foto);
        }
        
    }
}
