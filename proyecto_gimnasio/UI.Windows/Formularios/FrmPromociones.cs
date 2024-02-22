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
    public partial class FrmPromociones : Form
    {
        private bool valorEstado;
        PromocionesVistaModelo promocionesVistaModelo = new PromocionesVistaModelo();
        PromocionesControlador promocionesControlador;
        List<Promociones> listaPromociones;
        public FrmPromociones()
        {
            InitializeComponent();
            promocionesControlador = new PromocionesControlador();
        }

        public void InsertarPromocion()
        {
            if (promocionesControlador.InsertarPromocion(promocionesVistaModelo))
            {
                MessageBox.Show("Promocion insertada correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al promocion membresia");
            }
        }
        private void modificarPromocion()
        {
            if (promocionesControlador.ModificarPromocion(promocionesVistaModelo))
            {
                MessageBox.Show("Promocion modficada correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al modificar promocion");
            }
        }

        private void FrmPromociones_Load(object sender, EventArgs e)
        {
            Limpiar();
            BusquedaDataGrid();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo 'Descripcion' es obligatorio.");
                isValid = false;
            }
            
            if (string.IsNullOrWhiteSpace(ConvertirFechaFin().ToString()))
            {
                
                MessageBox.Show("El campo 'Fecha fin' es obligatorio.");
                isValid = false;
            }
            else
            {
                DateTime inicio = DateTime.Parse(ConvertirFechaInicio().ToString());
                DateTime fin = DateTime.Parse(ConvertirFechaFin().ToString());
                if (fin < inicio)
                {
                    MessageBox.Show("La fecha de fin debe ser mayor a la fecha de inicio");
                    Limpiar();
                    return;
                }
            }
            
            if (string.IsNullOrWhiteSpace(ConvertirFechaInicio().ToString()))
            {
                MessageBox.Show("El campo 'Fecha inicio' es obligatorio.");
                isValid = false;
            }
            else
            {
                DateTime inicio = DateTime.Parse(ConvertirFechaInicio().ToString());
                if (inicio < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha de inicio debe ser mayor a la fecha actual");
                    Limpiar();
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("La promocion ya existe");
                Limpiar();
                return;
                
            }

            var promocionEncontrada = listaPromociones.Where(x => x.descripcion.ToLower().Trim().Equals(txtDescripcion.Text.ToLower().Trim())).ToList();
            if (promocionEncontrada.Count > 0)
            {
                MessageBox.Show("La promocion existe");
                Limpiar();
                return;
            }
            if (isValid)
            {
                promocionesVistaModelo.Fecha_registro = DateTime.Now;
                promocionesVistaModelo.Descripcion = txtDescripcion.Text;
                promocionesVistaModelo.Fecha_inicio = ConvertirFechaInicio();
                promocionesVistaModelo.Fecha_fin = ConvertirFechaFin();
                promocionesVistaModelo.Estado = true;
                Limpiar();
                InsertarPromocion();
                dataGridPromociones.Rows.Clear();
                Listar();
            }
        }

        public DateTime ConvertirFechaInicio()
        {
            DateTime fechaInicio;
            if (DateTime.TryParse(txtFechaInicio.Text, out fechaInicio))
            {
                return fechaInicio;
            }
            else
            {
                MessageBox.Show("La fecha de inicio invalida se colocara fecha actual, sino desea, corregir");
                return DateTime.Now;
            }
        }
        public DateTime ConvertirFechaFin()
        {
            DateTime fechaFin;
            if (DateTime.TryParse(txtFechaFin.Text, out fechaFin))
            {
                return fechaFin;
            }
            else
            {
                MessageBox.Show("La fecha de fin invalida se colocara fecha actual, sino desea, corregir");
                return DateTime.Now;
            }
        }

        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            txtBusqueda.Text = "";
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        
        
        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dataGridPromociones.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "fecha" && columna.Name != "fecha_inicio" && columna.Name != "fecha_fin")
                {
                    cboBusqueda.Items.Add(new OpComboEstadoPromociones() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }
        public void Listar()
        {
            listaPromociones = (List<Promociones>)promocionesControlador.ListarPromocionesActivas();
            foreach (Promociones item in listaPromociones)
            {
                dataGridPromociones.Rows.Add(new object[] {"",item.id_promocion,item.fecha_registro,item.descripcion,item.fecha_inicio?.ToString("dd/MM/yyyy"),
                item.fecha_fin?.ToString("dd/MM/yyyy")});
            }

        }

        public void ListarPromocionesTipo()
        {
            dataGridPromociones.Rows.Clear();
            List<Promociones> listaPromocionesTipo = (List<Promociones>)promocionesControlador.ListarPromocionesTipo(txtBusqueda.Text);
            foreach (Promociones item in listaPromocionesTipo)
            {
                dataGridPromociones.Rows.Add(new object[] {"",item.id_promocion,item.fecha_registro,item.descripcion,
                item.fecha_inicio, item.fecha_fin,});
            }

        }
        private void dataGridPromociones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridPromociones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridPromociones.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGridPromociones.Rows[indice].Cells["id_promocion"].Value.ToString();
                    txtFecha.Text = DateTime.Parse(dataGridPromociones.Rows[indice].Cells["fecha"].Value.ToString()).ToString("dd/MM/yyyy");
                    txtDescripcion.Text = dataGridPromociones.Rows[indice].Cells["descripcion"].Value.ToString();
                    txtFechaInicio.Text = dataGridPromociones.Rows[indice].Cells["fecha_inicio"].Value.ToString();
                    txtFechaFin.Text = dataGridPromociones.Rows[indice].Cells["fecha_fin"].Value.ToString();
   
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "Descripcion")
            {
                ListarPromocionesTipo();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El Id del cliente no fue encontrado");
                return;
            }
            promocionesVistaModelo.Id_promocion = int.Parse(txtId.Text);
            promocionesVistaModelo.Fecha_registro = DateTime.Now;
            promocionesVistaModelo.Descripcion = txtDescripcion.Text;
            promocionesVistaModelo.Fecha_inicio = ConvertirFechaInicio();
            promocionesVistaModelo.Fecha_fin = ConvertirFechaFin();
            promocionesVistaModelo.Estado = true;
            modificarPromocion();
            dataGridPromociones.Rows.Clear();
            Listar();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El Id del cliente no fue encontrado");
                return;
            }

            var eliminacionPromocion = promocionesControlador.EliminarPromocion(int.Parse(txtId.Text));
            if (eliminacionPromocion)
            {
                MessageBox.Show("Promocion eliminada correctamente");
                dataGridPromociones.Rows.Clear();
                Listar();

            }
            else
            {
                MessageBox.Show("Error: Al elimnar promocion");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridPromociones.Rows.Clear();
            Listar();
            Limpiar();
        }
    }
}
