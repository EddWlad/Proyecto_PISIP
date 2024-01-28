﻿using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Windows.Controladores;
using UI.Windows.Formularios.Utilitarios;
using UI.Windows.VistaModelos;


namespace UI.Windows.Formularios
{
    public partial class FrmClientes : Form
    {
        
        ClienteVistaModelo clienteVistaModelo = new ClienteVistaModelo();
        ClienteControlador clienteControlador;
        TipoClienteControlador tipoClienteControlador;
        MembresiasControlador membresiasControlador;
        
        public FrmClientes()
        {
            InitializeComponent();
            clienteControlador = new ClienteControlador();
            tipoClienteControlador = new TipoClienteControlador();
            membresiasControlador = new MembresiasControlador();
        }

        public void InsertarCliente()
        {
            if(clienteControlador.InsertarCliente(clienteVistaModelo))
            {
                MessageBox.Show("Cliente insertado correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al insertar cliente");
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            BusquedaDataGrid();
            contenidoTipoCliente();
            contenidoMembresia();
            //ContenidoCboEstado();
            Listar();
        }
        private void contenidoMembresia()
        {
            cboTipoMembresia.DataSource = membresiasControlador.ListarMembresiasActivas();
            cboTipoMembresia.DisplayMember = "descripcion";
            cboTipoMembresia.ValueMember = "id_membresia";

        }
        private void BusquedaDataGrid()
        {
            foreach(DataGridViewColumn columna in dataGridClientes.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "foto" && columna.Name != "apellido" && columna.Name != "telefono" && columna.Name != "email" && columna.Name != "peso" && columna.Name != "altura")
                {
                    cboBusqueda.Items.Add(new OpComboEstadoCliente() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }
        //private void ContenidoCboEstado()
        //{
            //cboEstado.Items.Add(new OpComboEstadoCliente() { Valor = true, Texto = "Activo" });
            //cboEstado.Items.Add(new OpComboEstadoCliente() { Valor = false, Texto = "Inactivo" });

            //cboEstado.DisplayMember = "Texto";
            //cboEstado.ValueMember = "Valor";
            //cboEstado.SelectedIndex = 0;
            //OpComboEstadoCliente seleccionado = (OpComboEstadoCliente)cboEstado.SelectedItem;
            //valorEstado = (bool)seleccionado.Valor;
        //}
        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";

            txtPeso.Text = "";
            txtAltura.Text = "";

        }

        private void contenidoTipoCliente()
        {
            cboTipoCliente.DataSource = tipoClienteControlador.ListarTipoClientesActivos();
            cboTipoCliente.DisplayMember = "descripcion";
            cboTipoCliente.ValueMember = "id_tipo_cliente";

        }
        private bool ConversionAltura(string txtAltura)
        {
            // Convertir el texto de altura a decimal
            decimal valoraltura;
            if (decimal.TryParse(txtAltura, out  valoraltura))
            {
                clienteVistaModelo.Altura = valoraltura;
                return true;
            }
            else
            {
                // Manejar el caso en el que el valor no es un número válido
                MessageBox.Show("Por favor, ingresa un valor válido para la altura.");
                return false;
            }
        }

        private bool ConversionPeso(string txtPeso)
        {
            // Convertir el texto de altura a decimal
            decimal valoraPeso;
            if (decimal.TryParse(txtPeso, out valoraPeso))
            {
                clienteVistaModelo.Peso = valoraPeso;
                return true;
            }
            else
            {
                // Manejar el caso en el que el valor no es un número válido
                MessageBox.Show("Por favor, ingresa un valor válido para el peso.");
                return false;
            }
        }

        

        public void Listar()
        {  
            List<ClienteTipoCliente> listaClientes = (List<ClienteTipoCliente>)clienteControlador.ListarClientesActivos();
            foreach (ClienteTipoCliente item in listaClientes)
            {
                dataGridClientes.Rows.Add(new object[] {"",item.id_cliente,item.tipoCliente,item.cedula,item.nombre,item.apellido,item.direccion, item.telefono,item.email,
                item.peso,item.altura,item.membresia,"",});
            }
                
        }

        private void dataGridClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex <0)
            {
                return;
            }
            if(e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var imgWidth = Properties.Resources.check_circle_solid_24.Width;
                var imgHeight = Properties.Resources.check_circle_solid_24.Height;
                var imgX = e.CellBounds.Left + (e.CellBounds.Width - imgWidth) / 2;
                var imgY = e.CellBounds.Top + (e.CellBounds.Height - imgHeight) / 2;

                e.Graphics.DrawImage(Properties.Resources.check_circle_solid_24,new Rectangle(imgX,imgY,imgWidth,imgHeight));
                e.Handled = true;
            }
        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridClientes.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if(indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGridClientes.Rows[indice].Cells["id_cliente"].Value.ToString();
                    txtCedula.Text = dataGridClientes.Rows[indice].Cells["cedula"].Value.ToString();
                    txtNombre.Text = dataGridClientes.Rows[indice].Cells["nombre"].Value.ToString();
                    txtApellido.Text = dataGridClientes.Rows[indice].Cells["apellido"].Value.ToString();
                    txtDireccion.Text = dataGridClientes.Rows[indice].Cells["direccion"].Value.ToString();
                    txtTelefono.Text = dataGridClientes.Rows[indice].Cells["telefono"].Value.ToString();
                    txtEmail.Text = dataGridClientes.Rows[indice].Cells["email"].Value.ToString();
                    txtPeso.Text = dataGridClientes.Rows[indice].Cells["peso"].Value.ToString();
                    txtAltura.Text = dataGridClientes.Rows[indice].Cells["altura"].Value.ToString();
                }
            }
        }
        public void ListarClientesNombre()
        {
            dataGridClientes.Rows.Clear();
            List<Cliente> listaClientesNombre = (List<Cliente>)clienteControlador.ListarClientesNombres(txtBusqueda.Text);
                foreach (Cliente item in listaClientesNombre)
                {
                    dataGridClientes.Rows.Add(new object[] {"",item.id_cliente,item.cedula,item.nombre,item.apellido,item.direccion, item.telefono,item.email,
                    item.peso,item.altura,"",""});
                }
            
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "Nombre")
            {
                ListarClientesNombre();
            }
            if (cboBusqueda.Text == "Estado")
            {
                //ListarClientesEstados();
            }
        }

       

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            clienteVistaModelo.Id_Tipo_Cliente = (int)cboTipoCliente.SelectedValue;
            clienteVistaModelo.Cedula = txtCedula.Text;
            clienteVistaModelo.Nombre = txtNombre.Text;
            clienteVistaModelo.Apellido = txtApellido.Text;
            clienteVistaModelo.Direccion = txtDireccion.Text;
            clienteVistaModelo.Telefono = txtTelefono.Text;
            clienteVistaModelo.Email = txtEmail.Text;
            clienteVistaModelo.Id_Membresia = (int)cboTipoMembresia.SelectedValue;
            // Validacion de valores de peso y altura correctos
            if (ConversionAltura(txtAltura.Text) && ConversionPeso(txtPeso.Text))
            {
                clienteVistaModelo.Estado = true;
                dataGridClientes.Rows.Add(new object[] {"",clienteVistaModelo.Id_Cliente,cboTipoCliente.Text,clienteVistaModelo.Cedula, clienteVistaModelo.Nombre,clienteVistaModelo.Apellido,clienteVistaModelo.Direccion, clienteVistaModelo.Telefono,clienteVistaModelo.Email,
                clienteVistaModelo.Peso,clienteVistaModelo.Altura,cboTipoMembresia.Text,"",});
                Limpiar();
                InsertarCliente();
            }
            else
            {
                // Manejar el caso en el que el valor no es un número válido
                MessageBox.Show("Por favor,ingrese el valor correcto");
            }
        }

       
    }
}
