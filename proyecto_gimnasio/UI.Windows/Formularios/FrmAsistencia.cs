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
    public partial class FrmAsistencia : Form
    {
        RegistroAsistenciaVistaModelo registroAsistenciaVistaModelo = new RegistroAsistenciaVistaModelo();
        RegistroAsistenciaControlador registroAsistenciaControlador;
        ClienteControlador clienteControlador;
        public FrmAsistencia()
        {
            InitializeComponent();
            BusquedaDataGrid();
            BusquedaDataGridAsistencia();
            registroAsistenciaControlador = new RegistroAsistenciaControlador();
            clienteControlador = new ClienteControlador();
            this.txtTelefono.KeyPress += new KeyPressEventHandler(txtTelefono_KeyPress);
            this.txtCedula.KeyPress += new KeyPressEventHandler(txtCedula_KeyPress);
        }
        public void Listar()
        {
            List<ClienteTipoCliente> listaClientes = (List<ClienteTipoCliente>)clienteControlador.ListarClientesActivos();
            foreach (ClienteTipoCliente item in listaClientes)
            {
                dataGridClientesMiembros.Rows.Add(new object[] {"",item.id_cliente,item.cedula,item.nombre,item.telefono});
            }

        }
        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dataGridClientesMiembros.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "telefono")
                {
                    cboBusqueda.Items.Add(new OpComboAsistencia() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }
        private void BusquedaDataGridAsistencia()
        {
            foreach (DataGridViewColumn columna in dataGirdDetalleAsistencia.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionarAsistencia" && columna.Name != "fecha" && columna.Name != "nombre_asistencia" && columna.Name != "telefono_asistencia")
                {
                    cboBusquedaA.Items.Add(new OpComboAsistencia() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusquedaA.DisplayMember = "Texto";
            cboBusquedaA.ValueMember = "Valor";
            cboBusquedaA.SelectedIndex = 0;
        }

        public void ListarAsistencias()
        {
            List<AsistenciaCliente> listaAsistencias = (List<AsistenciaCliente>) registroAsistenciaControlador.ListarAsistenciasClientes();
            foreach (AsistenciaCliente item in listaAsistencias)
            {
                dataGirdDetalleAsistencia.Rows.Add(new object[] { "", item.id_registro, item.cedula, item.nombre, item.telefono,item.fecha });
            }

        }

        public void InsertarAsistencia()
        {
            if (registroAsistenciaControlador.InsertarAsistencia(registroAsistenciaVistaModelo))
            {
                MessageBox.Show("Asistencia registrada correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al registrar asistencia");
            }
        }

        private void FrmAsistencia_Load(object sender, EventArgs e)
        {
            Listar();
            ListarAsistencias();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtId1.Text = "";
            txtIndex2.Text ="";
            txtId.Text = "";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            registroAsistenciaVistaModelo.Fecha = DateTime.Now;
            registroAsistenciaVistaModelo.Estado = true;
            registroAsistenciaVistaModelo.Id_Cliente = ConversionIdCliente(txtId1.Text);
            dataGirdDetalleAsistencia.Rows.Add(new object[] {"", txtId.Text, txtCedula.Text, txtNombre.Text, txtTelefono.Text, registroAsistenciaVistaModelo.Fecha });
            Limpiar();
            dataGirdDetalleAsistencia.Rows.Clear();
            InsertarAsistencia();
            ListarAsistencias();
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

        private void dataGridClientesMiembros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridClientesMiembros.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndex2.Text = indice.ToString();
                    txtId1.Text = dataGridClientesMiembros.Rows[indice].Cells["id_tipo_cliente"].Value.ToString();
                    txtNombre.Text = dataGridClientesMiembros.Rows[indice].Cells["nombre"].Value.ToString();
                    txtTelefono.Text = dataGridClientesMiembros.Rows[indice].Cells["telefono"].Value.ToString();
                    txtCedula.Text = dataGridClientesMiembros.Rows[indice].Cells["cedula"].Value.ToString();
                }
            }
        }

        private void dataGirdDetalleAsistencia_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dataGirdDetalleAsistencia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGirdDetalleAsistencia.Columns[e.ColumnIndex].Name == "btnSeleccionarAsistencia")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGirdDetalleAsistencia.Rows[indice].Cells["id_asistencia"].Value.ToString();
                    txtCedula.Text = dataGirdDetalleAsistencia.Rows[indice].Cells["cedula_asistencia"].Value.ToString();
                    txtNombre.Text = dataGirdDetalleAsistencia.Rows[indice].Cells["nombre_asistencia"].Value.ToString();
                    txtTelefono.Text = dataGirdDetalleAsistencia.Rows[indice].Cells["telefono_asistencia"].Value.ToString();
                    txtFecha.Text = DateTime.Parse(dataGirdDetalleAsistencia.Rows[indice].Cells["fecha"].Value.ToString()).ToString("dd/MM/yyyy");
                }
            }
        }

        public void ListarClientesCedula()
        {
            dataGridClientesMiembros.Rows.Clear();
            List<ClienteTipoCliente> listaClientesCedula = (List<ClienteTipoCliente>)clienteControlador.ListarClientesCedula(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesCedula)
            {
                dataGridClientesMiembros.Rows.Add(new object[] { "", item.id_cliente, item.cedula, item.nombre, item.telefono });
            }

        }

        public void ListarClientesNombre()
        {
            dataGridClientesMiembros.Rows.Clear();
            List<ClienteTipoCliente> listaClientesNombre = (List<ClienteTipoCliente>)clienteControlador.ListarClientesNombres(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesNombre)
            {
                dataGridClientesMiembros.Rows.Add(new object[] { "", item.id_cliente, item.cedula, item.nombre, item.telefono });
            }

        }

        public void ListarAsistenciaCedula()
        {
            dataGirdDetalleAsistencia.Rows.Clear();
            List<AsistenciaCliente> listaAsisteciaCedula = (List<AsistenciaCliente>)registroAsistenciaControlador.ListarAsistenciasCedula(txtBusquedaA.Text);
            foreach (AsistenciaCliente item in listaAsisteciaCedula)
            {
                dataGirdDetalleAsistencia.Rows.Add(new object[] { "",item.id_registro, item.cedula, item.nombre, item.telefono, item.fecha, "", });
            }

        }

        public void ListarAsistenciaFechas()
        {
            dataGirdDetalleAsistencia.Rows.Clear();
            List<AsistenciaCliente> listaAsistenciaFecha = (List<AsistenciaCliente>)registroAsistenciaControlador.ListarAsistenciaFechas(txtBusquedaA.Text);
            foreach (AsistenciaCliente item in listaAsistenciaFecha)
            {
                dataGirdDetalleAsistencia.Rows.Add(new object[] { "", item.id_registro, item.cedula, item.nombre, item.telefono, item.fecha, "", });
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "Cedula")
            {
                dataGridClientesMiembros.Rows.Clear();
                ListarClientesCedula();
            }
            if (cboBusqueda.Text == "Nombre")
            {
                dataGridClientesMiembros.Rows.Clear();
                ListarClientesNombre();
            }
            txtBusqueda.Text = "";
        }

        private void btnBuscarA_Click(object sender, EventArgs e)
        {
            if (cboBusquedaA.Text == "Cedula")
            {
                dataGirdDetalleAsistencia.Rows.Clear();
                ListarAsistenciaCedula();
            }
            if (cboBusquedaA.Text == "Fecha")
            {
                dataGirdDetalleAsistencia.Rows.Clear();
                ListarAsistenciaFechas();
            }
            txtBusquedaA.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El Id del registro no fue encontrado");
                return;
            }

            var eliminarRegistro = registroAsistenciaControlador.EliminarRegistro(int.Parse(txtId.Text));
            if (eliminarRegistro)
            {
                MessageBox.Show("El registro fue eliminado correctamente");

            }
            else
            {
                MessageBox.Show("Error: Al elimnar registro");
            }
            dataGirdDetalleAsistencia.Rows.Clear();
            Limpiar();
            ListarAsistencias();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridClientesMiembros.Rows.Clear();
            txtBusqueda.Text = "";
            Listar();
            Limpiar();
        }

        private void btnLimpiarA_Click(object sender, EventArgs e)
        {
            dataGirdDetalleAsistencia.Rows.Clear();
            txtBusquedaA.Text = "";
            ListarAsistencias();
            Limpiar();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
