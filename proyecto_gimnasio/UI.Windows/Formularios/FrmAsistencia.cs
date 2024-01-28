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
            registroAsistenciaControlador = new RegistroAsistenciaControlador();
            clienteControlador = new ClienteControlador();
        }
        public void Listar()
        {
            List<ClienteTipoCliente> listaClientes = (List<ClienteTipoCliente>)clienteControlador.ListarClientesActivos();
            foreach (ClienteTipoCliente item in listaClientes)
            {
                dataGridClientesMiembros.Rows.Add(new object[] {"",item.id_cliente,item.cedula,item.nombre,item.telefono});
            }

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
                InsertarAsistencia();
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
                    txtCedula.Text = dataGridClientesMiembros.Rows[indice].Cells["cedula"].Value.ToString();
                    txtNombre.Text = dataGridClientesMiembros.Rows[indice].Cells["nombre"].Value.ToString();
                    txtTelefono.Text = dataGridClientesMiembros.Rows[indice].Cells["telefono"].Value.ToString();
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
    }
}
