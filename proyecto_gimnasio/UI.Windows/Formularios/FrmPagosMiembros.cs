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
using System.Windows.Forms;
using UI.Windows.Controladores;
using UI.Windows.Formularios.Utilitarios;
using UI.Windows.VistaModelos;

namespace UI.Windows.Formularios
{
    public partial class FrmPagosMiembros : Form
    {
        PagoDiarioVistaModelo pagoDiarioVistaModelo = new PagoDiarioVistaModelo();
        PagoDiarioControlador pagoDiarioControlador;
        ClienteControlador clienteControlador;
        RegistroAsistenciaControlador registroAsistenciaControlador;
        public FrmPagosMiembros()
        {
            InitializeComponent();
            pagoDiarioControlador = new PagoDiarioControlador();
            clienteControlador = new ClienteControlador();
            registroAsistenciaControlador = new RegistroAsistenciaControlador();
            this.txtCosto.KeyPress += new KeyPressEventHandler(txtCosto_KeyPress);
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

        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dtgClientesMiembros.Columns)
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
            foreach (DataGridViewColumn columnapago in dtListaPagosMiembros.Columns)
            {
                if (columnapago.Visible == true && columnapago.Name != "btnSeleccionarPago" && columnapago.Name != "id_pago_diario" && columnapago.Name != "costo" && columnapago.Name != "nombre_pago")
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
            List<AsistenciaCliente> listaClientes = (List<AsistenciaCliente>)registroAsistenciaControlador.ListarAsistenciasClientesMiembros();
            foreach (AsistenciaCliente item in listaClientes)
            {
                dtgClientesMiembros.Rows.Add(new object[] { "", item.id_registro, item.cedula, item.nombre, item.tipo_cliente, item.membresia });
            }
        }
        private void ListarPagosRegistros()
        {
            List<PagoDiarioRegistro> listaPagos = (List<PagoDiarioRegistro>)pagoDiarioControlador.ListarPagoDiarioActivosMiembros();
            foreach (PagoDiarioRegistro item in listaPagos)
            {
                dtListaPagosMiembros.Rows.Add(new object[] { "", item.id_pago_diario, item.cedula, item.nombre, item.fecha, item.costo, item.tipo_cliente });

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
            txtNombre.Text = "";
            txtBusqueda.Text = "";
        }
        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIndice2.Text))
            {
                MessageBox.Show("El pago ya existe");
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
                    pagoDiarioVistaModelo.Id_Registro = int.Parse(txtId.Text);
                    dtListaPagosMiembros.Rows.Add(new object[] {"",pagoDiarioVistaModelo.Id_Pago_Diario,txtCedula.Text,txtNombre.Text,
                    pagoDiarioVistaModelo.Fecha,pagoDiarioVistaModelo.Monto,txtTipoCliente.Text});
                    Limpiar();
                    InsertarPagoDiario();
                }
            }
            dtListaPagosMiembros.Rows.Clear();
            ListarPagosRegistros();
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

        private void dtgClientesMiembros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgClientesMiembros.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dtgClientesMiembros.Rows[indice].Cells["id_asistencia"].Value.ToString();
                    txtCedula.Text = dtgClientesMiembros.Rows[indice].Cells["cedula"].Value.ToString();
                    txtNombre.Text = dtgClientesMiembros.Rows[indice].Cells["nombre"].Value.ToString();
                    txtTipoCliente.Text = dtgClientesMiembros.Rows[indice].Cells["tipo_cliente"].Value.ToString();
                    txtMembresia.Text = dtgClientesMiembros.Rows[indice].Cells["membresia"].Value.ToString();
                }

            }
        }

        private void dtgClientesMiembros_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
            dtgClientesMiembros.Rows.Clear();
            List<ClienteTipoCliente> listaClientesTipo = (List<ClienteTipoCliente>)clienteControlador.ListarClientesTipo(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesTipo)
            {
                dtgClientesMiembros.Rows.Add(new object[] { "", item.id_cliente, item.cedula, item.nombre,
                    item.tipoCliente, item.membresia });
            }

        }
        public void ListarPagosCedula()
        {
            dtListaPagosMiembros.Rows.Clear();
            List<PagoDiarioRegistro> listaPagosCedula = (List<PagoDiarioRegistro>)pagoDiarioControlador.ListarPagosCedula(txtBusquedaPagos.Text);
            foreach (PagoDiarioRegistro item in listaPagosCedula)
            {
                dtListaPagosMiembros.Rows.Add(new object[] { "", item.id_pago_diario, item.cedula, item.nombre,
                    item.fecha, item.costo, item.tipo_cliente});
            }
        }
        public void ListarPagosTipo()
        {
            dtListaPagosMiembros.Rows.Clear();
            List<PagoDiarioRegistro> listaPagosTipo = (List<PagoDiarioRegistro>)pagoDiarioControlador.ListarPagosTipo(txtBusquedaPagos.Text);
            foreach (PagoDiarioRegistro item in listaPagosTipo)
            {
                dtListaPagosMiembros.Rows.Add(new object[] { "", item.id_pago_diario, item.cedula, item.nombre,
                    item.fecha, item.costo, item.tipo_cliente});
            }
        }
        public void ListarPagosDiario()
        {
            dtListaPagosMiembros.Rows.Clear();
            List<PagoDiarioRegistro> listaPagosDiario = (List<PagoDiarioRegistro>)pagoDiarioControlador.ListarPagoDiarioFecha(ConvertirFecha());
            foreach (PagoDiarioRegistro item in listaPagosDiario)
            {
                dtListaPagosMiembros.Rows.Add(new object[] { "", item.id_pago_diario, item.cedula, item.nombre,
                    item.fecha, item.costo, item.tipo_cliente});
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (dtListaPagosMiembros.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dtListaPagosMiembros.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }
                foreach (DataGridViewRow fila in dtListaPagosMiembros.Rows)
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

        private void dtListaPagosMiembros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtListaPagosMiembros.Columns[e.ColumnIndex].Name == "btnSeleccionarPago")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice2.Text = indice.ToString();
                    txtId2.Text = dtListaPagosMiembros.Rows[indice].Cells["id_pago_diario"].Value.ToString();
                    txtCedula.Text = dtListaPagosMiembros.Rows[indice].Cells["cedula_pago"].Value.ToString();
                    txtNombre.Text = dtListaPagosMiembros.Rows[indice].Cells["nombre_pago"].Value.ToString();
                    txtFechaRegistro.Text = DateTime.Parse(dtListaPagosMiembros.Rows[indice].Cells["fecha"].Value.ToString()).ToString("dd/MM/yyyy");
                    txtCosto.Text = dtListaPagosMiembros.Rows[indice].Cells["costo"].Value.ToString();
                    txtTipoCliente.Text = dtListaPagosMiembros.Rows[indice].Cells["cliente_tipo"].Value.ToString();
                    //txtMembresia.Text = dtListaPagos.Rows[indice].Cells["membresia"].Value.ToString();
                }
            }
        }

        private void dtListaPagosMiembros_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
            dtListaPagosMiembros.Rows.Clear();
            Limpiar();
            ListarPagosRegistros();
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

        private void btnBuscar_Click(object sender, EventArgs e)
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
        public void ListarClientesCedula()
        {
            dtgClientesMiembros.Rows.Clear();
            List<ClienteTipoCliente> listaClientesTipo = (List<ClienteTipoCliente>)clienteControlador.ListarClientesCedula(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesTipo)
            {
                dtgClientesMiembros.Rows.Add(new object[] { "", item.id_cliente, item.cedula, item.nombre,
                    item.tipoCliente, item.membresia });
            }
        }
        public void ListarClientesMembresia()
        {
            dtgClientesMiembros.Rows.Clear();
            List<ClienteTipoCliente> listaClientesTipo = (List<ClienteTipoCliente>)clienteControlador.ListarClientesMembresia(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesTipo)
            {
                dtgClientesMiembros.Rows.Add(new object[] { "", item.id_cliente, item.cedula, item.nombre,
                    item.tipoCliente, item.membresia });
            }

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtgClientesMiembros.Rows.Clear();
            Listar();
            Limpiar();
        }

        private void btnLimpiarPagos_Click(object sender, EventArgs e)
        {
            dtListaPagosMiembros.Rows.Clear();
            ListarPagosRegistros();
            Limpiar();
        }

        private void FrmPagosMiembros_Load(object sender, EventArgs e)
        {
                BusquedaDataGrid();
                BusquedaDataGridPagos();
                Listar();
                txtFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");
                ListarPagosRegistros();
                Limpiar();
        }
    }
}
