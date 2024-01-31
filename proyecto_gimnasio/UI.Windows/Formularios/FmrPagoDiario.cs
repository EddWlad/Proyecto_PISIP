using ClosedXML.Excel;
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
            BusquedaDataGridPagos();
            Listar();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ListarPagosRegistros();
            Limpiar();


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIndice2.Text))
            {
                MessageBox.Show("El cliente ya existe");
                Limpiar();
                return;
            }
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtCosto.Text))
            {
                MessageBox.Show("El campo 'Costo' es obligatorio.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("El campo 'Cedula' es obligatorio.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtTipoCliente.Text))
            {
                MessageBox.Show("El campo 'Tipo de cliente' es obligatorio.");
                isValid = false;
            }
            if (isValid)
            {
                if (ConversionCosto(txtCosto.Text))
                {

                    pagoDiarioVistaModelo.Fecha = DateTime.Now;
                    pagoDiarioVistaModelo.Estado = true;
                    //pagoDiarioVistaModelo.Id_Registro = pagoDiarioVistaModelo.Id_Registro;
                    dtListaPagos.Rows.Add(new object[] {"",pagoDiarioVistaModelo.Id_Pago_Diario,txtCedula.Text,txtNombre.Text, 
                    pagoDiarioVistaModelo.Fecha,pagoDiarioVistaModelo.Monto,txtTipoCliente.Text});
                    Limpiar();
                    InsertarPagoDiario();
                }
            }
            dtListaPagos.Rows.Clear();
            Listar();
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
            txtId.Text = "";
            txtId2.Text = "";
            txtIndice2.Text = "";
            txtCosto.Text = "";
            txtCedula.Text = "";
            txtMembresia.Text = "";
            txtTipoCliente.Text = "";
        }
        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dataGridClientesMiembros.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "nombre" && columna.Name != "id_cliente")
                {
                    cboBusqueda.Items.Add(new OpComboBusquedaPagoDiario() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }
        private void BusquedaDataGridPagos()
        {
            foreach (DataGridViewColumn columnapago in dtListaPagos.Columns)
            {
                if (columnapago.Visible == true && columnapago.Name != "btnSeleccionarPago" && columnapago.Name != "id_pago_diario"  && columnapago.Name != "costo" && columnapago.Name != "nombre_pago")
                {
                    cboBuscarPago.Items.Add(new OpComboBusquedaPagos() { Valor = columnapago.Name, Texto = columnapago.HeaderText });
                }
            }
            cboBuscarPago.DisplayMember = "Texto";
            cboBuscarPago.ValueMember = "Valor";
            cboBuscarPago.SelectedIndex = 0;
        }
        public void Listar()
        {
            List<ClienteTipoCliente> listaClientes = (List<ClienteTipoCliente>)clienteControlador.ListarClientesActivos();
            foreach (ClienteTipoCliente item in listaClientes)
            {
                dataGridClientesMiembros.Rows.Add(new object[] { "", item.id_cliente, item.cedula, item.nombre, item.tipoCliente,item.membresia});

            }    
        }
        private void ListarPagosRegistros()
        {
            List<PagoDiarioRegistro> listaPagos = (List<PagoDiarioRegistro>)pagoDiarioControlador.ListarPagoDiarioActivos();
            foreach (PagoDiarioRegistro item in listaPagos)
            {
                dtListaPagos.Rows.Add(new object[] { "", item.id_pago_diario, item.cedula, item.nombre,item.fecha,item.costo,item.tipo_cliente});

            }
        }


        public DateTime ConvertirFecha()
        {
            DateTime fecha;
            if (DateTime.TryParse(txtBusquedaPagos.Text, out fecha))
            {
                return fecha;
            }
            else
            {
                throw new Exception("Fecha invalida");
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
                    txtId.Text = dataGridClientesMiembros.Rows[indice].Cells["id_cliente"].Value.ToString();
                    txtCedula.Text = dataGridClientesMiembros.Rows[indice].Cells["cedula"].Value.ToString();
                    txtNombre.Text = dataGridClientesMiembros.Rows[indice].Cells["nombre"].Value.ToString();
                    txtTipoCliente.Text = dataGridClientesMiembros.Rows[indice].Cells["tipo_cliente"].Value.ToString();
                    txtMembresia.Text = dataGridClientesMiembros.Rows[indice].Cells["membresia"].Value.ToString();
                }
    
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

        public void ListarClientesTipo()
        {
            dataGridClientesMiembros.Rows.Clear();
            List<ClienteTipoCliente> listaClientesTipo = (List<ClienteTipoCliente>)clienteControlador.ListarClientesTipo(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesTipo)
            {
                dataGridClientesMiembros.Rows.Add(new object[] { "", item.id_cliente, item.cedula, item.nombre, 
                    item.tipoCliente, item.membresia });
            }

        }
        public void ListarClientesCedula()
        {
            dataGridClientesMiembros.Rows.Clear();
            List<ClienteTipoCliente> listaClientesTipo = (List<ClienteTipoCliente>)clienteControlador.ListarClientesCedula(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesTipo)
            {
                dataGridClientesMiembros.Rows.Add(new object[] { "", item.id_cliente, item.cedula, item.nombre,
                    item.tipoCliente, item.membresia });
            }
        }
        public void ListarClientesMembresia()
        {
            dataGridClientesMiembros.Rows.Clear();
            List<ClienteTipoCliente> listaClientesTipo = (List<ClienteTipoCliente>)clienteControlador.ListarClientesMembresia(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesTipo)
            {
                dataGridClientesMiembros.Rows.Add(new object[] { "", item.id_cliente, item.cedula, item.nombre,
                    item.tipoCliente, item.membresia });
            }

        }

        public void ListarPagosCedula()
        {
            dtListaPagos.Rows.Clear();
            List<PagoDiarioRegistro> listaPagosCedula = (List<PagoDiarioRegistro>)pagoDiarioControlador.ListarPagosCedula(txtBusquedaPagos.Text);
            foreach (PagoDiarioRegistro item in listaPagosCedula)
            {
                dtListaPagos.Rows.Add(new object[] { "", item.id_pago_diario, item.cedula, item.nombre,
                    item.fecha, item.costo, item.tipo_cliente});
            }
        }
        public void ListarPagosTipo()
        {
            dtListaPagos.Rows.Clear();
            List<PagoDiarioRegistro> listaPagosTipo = (List<PagoDiarioRegistro>)pagoDiarioControlador.ListarPagosTipo(txtBusquedaPagos.Text);
            foreach (PagoDiarioRegistro item in listaPagosTipo)
            {
                dtListaPagos.Rows.Add(new object[] { "", item.id_pago_diario, item.cedula, item.nombre,
                    item.fecha, item.costo, item.tipo_cliente});
            }
        }
        public void ListarPagosDiario()
        {
            dtListaPagos.Rows.Clear();
            List<PagoDiarioRegistro> listaPagosDiario = (List<PagoDiarioRegistro>)pagoDiarioControlador.ListarPagoDiarioFecha(ConvertirFecha());
            foreach (PagoDiarioRegistro item in listaPagosDiario)
            {
                dtListaPagos.Rows.Add(new object[] { "", item.id_pago_diario, item.cedula, item.nombre,
                    item.fecha, item.costo, item.tipo_cliente});
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (dtListaPagos.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dtListaPagos.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }
                foreach (DataGridViewRow fila in dtListaPagos.Rows)
                {
                    if (fila.Visible)
                        dt.Rows.Add(new object[] {
                           fila.Cells[2].Value.ToString(),
                           fila.Cells[3].Value.ToString(),
                           fila.Cells[4].Value.ToString(),
                           fila.Cells[5].Value.ToString(),
                        });
                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReportePagos_{0}.xlsx", DateTime.Now.ToString("dd-MM-yyyy"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte de pagos generado");
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte");
                    }
                }
            }
        }

        private void dtListaPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtListaPagos.Columns[e.ColumnIndex].Name == "btnSeleccionarPago")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice2.Text = indice.ToString();
                    txtId2.Text = dtListaPagos.Rows[indice].Cells["id_pago_diario"].Value.ToString();
                    txtCedula.Text = dtListaPagos.Rows[indice].Cells["cedula_pago"].Value.ToString();
                    txtFecha.Text = DateTime.Parse(dtListaPagos.Rows[indice].Cells["fecha"].Value.ToString()).ToString("dd/MM/yyyy");
                    txtCosto.Text = dtListaPagos.Rows[indice].Cells["costo"].Value.ToString();
                    txtTipoCliente.Text = dtListaPagos.Rows[indice].Cells["cliente_tipo"].Value.ToString();

                }
            }
        }

        private void dtListaPagos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId2.Text))
            {
                MessageBox.Show("El Id del pago no fue encontrado");
                return;
            }

            var eliminacionPago = pagoDiarioControlador.EliminarCliente(int.Parse(txtId2.Text));
            if (eliminacionPago)
            {
                MessageBox.Show("Pago eliminado correctamente");

            }
            else
            {
                MessageBox.Show("Error: Al elimnar pago");
            }
            dtListaPagos.Rows.Clear();
            Limpiar();
            ListarPagosRegistros();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "Tipo cliente")
            {
                ListarClientesTipo();
            }
            if (cboBusqueda.Text == "Cedula")
            {
                ListarClientesCedula();
            }
            if (cboBusqueda.Text == "Membresia")
            {
                ListarClientesMembresia();
            }
        }

        private void btnBuscarPago_Click(object sender, EventArgs e)
        {
            if (cboBuscarPago.Text == "Tipo Cliente")
            {
                ListarPagosTipo();
            }
            if (cboBuscarPago.Text == "Cedula")
            {
                ListarPagosCedula();
            }
            if (cboBuscarPago.Text == "Fecha")
            {
                ListarPagosDiario();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridClientesMiembros.Rows.Clear();
            Listar();
            Limpiar();
        }

        private void btnLimpiarPagos_Click(object sender, EventArgs e)
        {
            dtListaPagos.Rows.Clear();
            ListarPagosRegistros();
            Limpiar();
        }
    }
}
