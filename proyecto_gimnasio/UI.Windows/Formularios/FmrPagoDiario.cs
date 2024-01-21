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
    public partial class FmrPagoDiario : Form
    {
        
        PagoDiarioVistaModelo pagoDiarioVistaModelo = new PagoDiarioVistaModelo();
        PagoDiarioControlador pagoDiarioControlador;
        public FmrPagoDiario()
        {
            InitializeComponent();
            pagoDiarioControlador = new PagoDiarioControlador();
        }
        public void InsertarPagoDiario()
        {
            if (pagoDiarioControlador.InsertarPagoDiario(pagoDiarioVistaModelo))
            {
                MessageBox.Show("Pago insertado correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al ingresar pago");
            }
        }
        private void FmrPagoDiario_Load(object sender, EventArgs e)
        {
            BusquedaDataGrid();
            Listar();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ConversionCosto(txtCosto.Text))
            {
                pagoDiarioVistaModelo.Fecha = DateTime.Now;
                pagoDiarioVistaModelo.Estado = true;
                dataGridPagoDiario.Rows.Add(new object[] {"",pagoDiarioVistaModelo.IdPagodiario, pagoDiarioVistaModelo.Fecha,pagoDiarioVistaModelo.Monto,pagoDiarioVistaModelo.Estado,pagoDiarioVistaModelo.IdUsuario,""});
                Limpiar();
                InsertarPagoDiario();
            }
        }
        private bool ConversionCosto(string costo)
        {
            // Convertir el texto de altura a decimal
            decimal valoraCosto;
            if (decimal.TryParse(costo, out valoraCosto))
            {
                pagoDiarioVistaModelo.Monto = valoraCosto;
                return true;
            }
            else
            {
                // Manejar el caso en el que el valor no es un número válido
                MessageBox.Show("Por favor, ingresa un valor válido para el costo.");
                return false;
            }
        }
        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtCosto.Text = "";    
        }
        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dataGridPagoDiario.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "costo" && columna.Name != "estado" && columna.Name != "id_usuario")
                {
                    cboBusqueda.Items.Add(new OpComboBusquedaPagoDiario() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }
        public void Listar()
        {
            List<Pago_diario> listaPagoDiario = (List<Pago_diario>)pagoDiarioControlador.ListarPagoDiarioActivos();
            foreach (Pago_diario item in listaPagoDiario)
            {
                dataGridPagoDiario.Rows.Add(new object[] {"",item.id_pago_diario,item.fecha,item.monto,item.estado,item.id_usuario,"" });
            }

        }
        public void ListarPagoDiarioFecha()
        {
            DateTime fechaTxtBusqueda = ConvertirFecha();
            dataGridPagoDiario.Rows.Clear();
            List<Pago_diario> listaPagoDiarioFecha = (List<Pago_diario>)pagoDiarioControlador.ListarPagoDiarioFecha(fechaTxtBusqueda);
            foreach (Pago_diario item in listaPagoDiarioFecha)
            {
                dataGridPagoDiario.Rows.Add(new object[] { "",item.id_pago_diario,item.fecha,item.monto,item.estado,item.id_usuario,"" });
            }

        }

        public DateTime ConvertirFecha()
        {
            DateTime fecha;
            if (DateTime.TryParse(txtFecha.Text, out fecha))
            {
                return fecha;
            }
            else
            {
                return DateTime.Now;
            }
        }

        private void dataGridPagoDiario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridPagoDiario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridPagoDiario.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGridPagoDiario.Rows[indice].Cells["idpagodiario"].Value.ToString();
                    txtFecha.Text = dataGridPagoDiario.Rows[indice].Cells["fecha"].Value.ToString();
                    txtCosto.Text = dataGridPagoDiario.Rows[indice].Cells["costo"].Value.ToString();

                }
            }
        }
    }
}
