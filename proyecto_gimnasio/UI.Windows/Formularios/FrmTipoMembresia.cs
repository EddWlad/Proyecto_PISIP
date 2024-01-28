using Dominio.Modelo.Entidades;
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
    public partial class FrmTipoMembresia : Form
    {
        TipoMembresiaVistaModelo tipoMembresiaVistaModelo = new TipoMembresiaVistaModelo();
        TipoMembresiaControlador tipoMembresiaControlador;
        public FrmTipoMembresia()
        {
            InitializeComponent();
            tipoMembresiaControlador = new TipoMembresiaControlador();
        }
        public void InsertarTipoMembresia()
        {
            if (tipoMembresiaControlador.InsertarTipoMembresia(tipoMembresiaVistaModelo))
            {
                MessageBox.Show("Tipo de membresia insertada correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al insertar tipo de membresia");
            }
        }
        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dataGridTipoMembresia.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "id_tipo_cliente")
                {
                    cboBusqueda.Items.Add(new OpComboBusquedaTipoMembresia() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }
        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtDescripcion.Text = "";

        }
        public void Listar()
        {
            List<Tipo_Membresia> listaTipos = (List<Tipo_Membresia>)tipoMembresiaControlador.ListarTipoMembresiasActivas();
            foreach (Tipo_Membresia item in listaTipos)
            {
                dataGridTipoMembresia.Rows.Add(new object[] { "", item.id_tipo_membresia, item.descripcion });
            }

        }

        private void FrmTipoMembresia_Load(object sender, EventArgs e)
        {
            BusquedaDataGrid();
            Listar();
        }

        private void dataGridTipoMembresia_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridTipoMembresia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridTipoMembresia.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGridTipoMembresia.Rows[indice].Cells["id_tipo_membresia"].Value.ToString();
                    txtDescripcion.Text = dataGridTipoMembresia.Rows[indice].Cells["descripcion"].Value.ToString();

                }
            }
        }
        public void ListarMembresiaTipo()
        {
            dataGridTipoMembresia.Rows.Clear();
            List<Tipo_Membresia> listaMembresiaTipo = (List<Tipo_Membresia>)tipoMembresiaControlador.ListarTipoMembresiaDescripcion(txtBusqueda.Text);
            foreach (Tipo_Membresia item in listaMembresiaTipo)
            {
                dataGridTipoMembresia.Rows.Add(new object[] { "", item.id_tipo_membresia, item.descripcion });
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (cboBusqueda.Text == "Descripcion")
            {
                ListarMembresiaTipo();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            tipoMembresiaVistaModelo.Descripcion = txtDescripcion.Text;
            tipoMembresiaVistaModelo.Estado = true;
            dataGridTipoMembresia.Rows.Add(new object[] { "", tipoMembresiaVistaModelo.Id_Tipo_Membresia, tipoMembresiaVistaModelo.Descripcion, });
            Limpiar();
            InsertarTipoMembresia();
        }
    }
}
