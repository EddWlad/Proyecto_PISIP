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
    public partial class FrmCostoMembresias : Form
    {
        CostoMembresiasVistaModelo costoMembresiasVistaModelo = new CostoMembresiasVistaModelo();
        CostoMembresiasControlador costoMembresiasControlador;
        public FrmCostoMembresias()
        {
            InitializeComponent();
            costoMembresiasControlador = new CostoMembresiasControlador();
        }
        public void InsertarCostoMembresias()
        {
            if (costoMembresiasControlador.InsertarCostoMembresia(costoMembresiasVistaModelo))
            {
                MessageBox.Show("Costo de membresias insertado correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al insertar costo de membresias");
            }
        }
        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dataGridCostoMembresia.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "id_costo_membresia")
                {
                    cboBusqueda.Items.Add(new OpComboBusquedaCostoMembresia() { Valor = columna.Name, Texto = columna.HeaderText });
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
            txtValor.Text = "0";
        }
        public void Listar()
        {
            List<Costo_Membresia> listaCostosMembresias = (List<Costo_Membresia>)costoMembresiasControlador.ListarCostoMembresiasActivas();
            foreach (Costo_Membresia item in listaCostosMembresias)
            {
                dataGridCostoMembresia.Rows.Add(new object[] { "", item.id_costo_membresia, item.descripcion });
            }

        }
        private void FrmCostoMembresias_Load(object sender, EventArgs e)
        {
            BusquedaDataGrid();
            Listar();
        }

        private void dataGridCostoMembresia_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridCostoMembresia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridCostoMembresia.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGridCostoMembresia.Rows[indice].Cells["id_costo_membresia"].Value.ToString();
                    txtDescripcion.Text = dataGridCostoMembresia.Rows[indice].Cells["descripcion"].Value.ToString();
                    txtValor.Text = dataGridCostoMembresia.Rows[indice].Cells["valor"].Value.ToString();
                }
            }
        }
        public void ListarCostosMembresia()
        {
            dataGridCostoMembresia.Rows.Clear();
            List<Costo_Membresia> listaCostoMembresia = (List<Costo_Membresia>)costoMembresiasControlador.ListarCostoMembresiasDescripcion(txtBusqueda.Text);
            foreach (Costo_Membresia item in listaCostoMembresia)
            {
                dataGridCostoMembresia.Rows.Add(new object[] { "", item.id_costo_membresia, item.descripcion, item.valor });
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "Descripcion")
            {
                ListarCostosMembresia();
            }
        }

        private decimal ConversionCosto(string costo)
        {
            // Convertir el texto de altura a decimal
            decimal valoraCosto;
            if (decimal.TryParse(costo, out valoraCosto))
            {
                return valoraCosto;
            }
            else
            {
                // Manejar el caso en el que el valor no es un número válido
                MessageBox.Show("Por favor, ingresa un valor válido para el costo.");
                return 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal valor = ConversionCosto(txtValor.Text);
            costoMembresiasVistaModelo.Descripcion = txtDescripcion.Text;
            costoMembresiasVistaModelo.Estado = true;
            costoMembresiasVistaModelo.Valor = valor;
            dataGridCostoMembresia.Rows.Add(new object[] { "", costoMembresiasVistaModelo.Id_Costo_Membresia, costoMembresiasVistaModelo.Descripcion,
            costoMembresiasVistaModelo.Valor});
            Limpiar();
            InsertarCostoMembresias();
        }
    }
}
