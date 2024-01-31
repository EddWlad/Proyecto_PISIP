using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Windows.Controladores;
using UI.Windows.Formularios.Utilitarios;
using UI.Windows.VistaModelos;

namespace UI.Windows.Formularios
{
    public partial class FrmTipoCliente : Form
    {
        TipoClienteVistaModelo tipoClienteVistaModelo = new TipoClienteVistaModelo();
        TipoClienteControlador tipoClienteControlador;
        public FrmTipoCliente()
        {
            InitializeComponent();
            tipoClienteControlador = new TipoClienteControlador();
        }
        public void InsertarTipoCliente()
        {
            if (tipoClienteControlador.InsertarTipoCliente(tipoClienteVistaModelo))
            {
                MessageBox.Show("Tipo de cliente insertado correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al insertar tipo cliente");
            }
        }
        public void ModificarTipoCliente()
        {
            if (tipoClienteControlador.ModificarTipoCliente(tipoClienteVistaModelo))
            {
                MessageBox.Show("Tipo de cliente modificado correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al modificar tipo de cliente");
            }
        }

        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dataGridTipoClientes.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "id_tipo_cliente")
                {
                    cboBusqueda.Items.Add(new OpcionBusquedaTipoCliente() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }
        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "";
            txtDescripcion.Text = "";

        }
        public void Listar()
        {
            List<Tipo_Cliente> listaTipos = (List<Tipo_Cliente>)tipoClienteControlador.ListarTipoClientesActivos();
            foreach (Tipo_Cliente item in listaTipos)
            {
                dataGridTipoClientes.Rows.Add(new object[] {"",item.id_tipo_cliente,item.descripcion});
            }

        }
        private void FrmTipoCliente_Load(object sender, EventArgs e)
        {
            BusquedaDataGrid();
            Listar();
            Limpiar();
        }

        private void dataGridTipoClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var imgWidth = Properties.Resources.check_circle_solid_24.Width;
                var imgHeight = Properties.Resources.check_circle_solid_24.Height;
                var imgX = e.CellBounds.Left + (e.CellBounds.Width - imgWidth) / 2;
                var imgY = e.CellBounds.Top + (e.CellBounds.Height - imgHeight) / 2;

                e.Graphics.DrawImage(Properties.Resources.check_circle_solid_24, new Rectangle(imgX, imgY, imgWidth, imgHeight));
                e.Handled = true;
            }
        }

        private void dataGridTipoClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridTipoClientes.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGridTipoClientes.Rows[indice].Cells["id_tipo_cliente"].Value.ToString();
                    txtDescripcion.Text = dataGridTipoClientes.Rows[indice].Cells["descripcion"].Value.ToString();
                    
                }
            }
        }
        public void ListarClientesTipo()
        {
            dataGridTipoClientes.Rows.Clear();
            List<Tipo_Cliente> listaClientesTipo = (List<Tipo_Cliente>)tipoClienteControlador.ListarTipoClienteDescripcion(txtBusqueda.Text);
            foreach (Tipo_Cliente item in listaClientesTipo)
            {
                dataGridTipoClientes.Rows.Add(new object[] {"",item.id_tipo_cliente,item.descripcion});
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cboBusqueda.Text == "Descripcion")
            {
                ListarClientesTipo();
            }
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El tipo ya existe");
                Limpiar();
                return;
            }
            tipoClienteVistaModelo.Descripcion = txtDescripcion.Text;
            tipoClienteVistaModelo.Estado = true;
            dataGridTipoClientes.Rows.Add(new object[] {"",tipoClienteVistaModelo.Id_tipo_cliente,tipoClienteVistaModelo.Descripcion,});
            Limpiar();
            InsertarTipoCliente();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El Id del tipo cliente no fue encontrado");
                return;
            }
            tipoClienteVistaModelo.Id_tipo_cliente = int.Parse(txtId.Text);
            tipoClienteVistaModelo.Descripcion = txtDescripcion.Text;
            tipoClienteVistaModelo.Estado = true;
            dataGridTipoClientes.Rows.Add(new object[] { "", tipoClienteVistaModelo.Id_tipo_cliente, 
                tipoClienteVistaModelo.Descripcion,});
            ModificarTipoCliente();
            dataGridTipoClientes.Rows.Clear();
            Limpiar();
            Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El Id del cliente no fue encontrado");
                return;
            }

            var eliminacionTipo = tipoClienteControlador.EliminarTipoCleinte(int.Parse(txtId.Text));
            if (eliminacionTipo)
            {
                MessageBox.Show("Tipo cliente eliminado correctamente");

            }
            else
            {
                MessageBox.Show("Error: Al elimnar tipo cliente");
            }
            dataGridTipoClientes.Rows.Clear();
            Limpiar();
            Listar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridTipoClientes.Rows.Clear();
            Limpiar();
            Listar();
        }
    }
}
