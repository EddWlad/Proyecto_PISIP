using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
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
        ClienteControlador clienteControlador;
        public FmrPagoDiario()
        {
            InitializeComponent();
            pagoDiarioControlador = new PagoDiarioControlador();
            clienteControlador = new ClienteControlador();
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
            ListarPagosRegistros();


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ConversionCosto(txtCosto.Text))
            {
                pagoDiarioVistaModelo.Fecha = DateTime.Now;
                pagoDiarioVistaModelo.Estado = true;
                pagoDiarioVistaModelo.Id_Registro = ConversionIdCliente(txtId2.Text);
                dataGridView1.Rows.Add(new object[] {"",pagoDiarioVistaModelo.Id_Pago_Diario,txtCedula.Text,txtNombre.Text, 
                pagoDiarioVistaModelo.Fecha,pagoDiarioVistaModelo.Monto});
                Limpiar();
                InsertarPagoDiario();
            }
        }
        private int ConversionIdCliente(string txtId)
        {
            // Convertir el texto de altura a decimal
            int id;
            if (int.TryParse(txtId, out id))
            {
                return id;
            }
            else
            {
                // Manejar el caso en el que el valor no es un número válido
                MessageBox.Show("No se encontro el ID del cliente.");
                return 0;
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
            txtCedula.Text = "";
            txtNombre.Text = "";
        }
        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dataGridClientesMiembros.Columns)
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
            List<ClienteTipoCliente> listaClientes = (List<ClienteTipoCliente>)clienteControlador.ListarClientesActivos();
            foreach (ClienteTipoCliente item in listaClientes)
            {
                dataGridClientesMiembros.Rows.Add(new object[] { "", item.id_cliente, item.cedula, item.nombre});

            }    
        }
        private void ListarPagosRegistros()
        {
            List<PagoDiarioRegistro> listaPagos = (List<PagoDiarioRegistro>)pagoDiarioControlador.ListarPagoDiarioActivos();
            foreach (PagoDiarioRegistro item in listaPagos)
            {
                dataGridView1.Rows.Add(new object[] { "", item.id_pago_diario, item.cedula, item.nombre,item.fecha,item.costo });

            }
        }

        //}
        //public void ListarPagoDiarioFecha()
        //{
        //DateTime fechaTxtBusqueda = ConvertirFecha();
        //dataGridPagoDiario.Rows.Clear();
        //List<Pago_diario> listaPagoDiarioFecha = (List<Pago_diario>)pagoDiarioControlador.ListarPagoDiarioFecha(fechaTxtBusqueda);
        //foreach (Pago_diario item in listaPagoDiarioFecha)
        //{
        // dataGridPagoDiario.Rows.Add(new object[] { "",item.id_pago_diario,item.fecha,item.monto,item.estado,item.id_usuario,"" });
        //}

        //}

        public DateTime ConvertirFecha()
        {
            DateTime fecha;
            if (DateTime.TryParse(txtBusqueda.Text, out fecha))
            {
                return fecha;
            }
            else
            {
                return DateTime.Now;
            }
        }
            
        private void dataGridClientesMiembros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridClientesMiembros.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId2.Text = dataGridClientesMiembros.Rows[indice].Cells["id_cliente"].Value.ToString();
                    txtCedula.Text = dataGridClientesMiembros.Rows[indice].Cells["cedula"].Value.ToString();
                    txtNombre.Text = dataGridClientesMiembros.Rows[indice].Cells["nombre"].Value.ToString();
                }
    
            }

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "Fecha")
            {
                //ListarPagoDiarioFecha();
            }
            
        }


        private void dataGridClientesMiembros_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGridView1.Rows[indice].Cells["id_pago_diario"].Value.ToString();
                    txtCedula.Text = dataGridView1.Rows[indice].Cells["cedula_pago"].Value.ToString();
                    txtNombre.Text = dataGridView1.Rows[indice].Cells["nombre_pago"].Value.ToString();
                    txtFecha.Text = dataGridView1.Rows[indice].Cells["fecha"].Value.ToString();
                    txtCosto.Text = dataGridView1.Rows[indice].Cells["costo"].Value.ToString();

                }
            }
        }
    }
}
