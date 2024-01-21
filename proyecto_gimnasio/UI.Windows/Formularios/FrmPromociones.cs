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

        private void FrmPromociones_Load(object sender, EventArgs e)
        {
            BusquedaDataGrid();
            ContenidoCboEstado();
            Listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            promocionesVistaModelo.Tipo = txtTipo.Text;
            if (ConversionCosto(txtCosto.Text))
            {
                //bool estadoMembresias = Convert.ToBoolean(cboEstado.SelectedValue.ToString());
                promocionesVistaModelo.Descripcion = txtDescripcion.Text;
                promocionesVistaModelo.Estado = valorEstado;
                dataGridPromociones.Rows.Add(new object[] {"",promocionesVistaModelo.IdPromocion, promocionesVistaModelo.Tipo,promocionesVistaModelo.Costo,promocionesVistaModelo.Descripcion,
                ((OpComboEstadoPromociones)cboEstado.SelectedItem).Texto.ToString(),"",((OpComboEstadoPromociones)cboEstado.SelectedItem).Valor.ToString()});
                Limpiar();
                InsertarPromocion();
            }
        }
        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtTipo.Text = "";
            txtCosto.Text = "";
            txtDescripcion.Text = "";
            cboEstado.SelectedIndex = 0;
        }
        private bool ConversionCosto(string costo)
        {
            // Convertir el texto de altura a decimal
            decimal valoraCosto;
            if (decimal.TryParse(costo, out valoraCosto))
            {
                promocionesVistaModelo.Costo = valoraCosto;
                return true;
            }
            else
            {
                // Manejar el caso en el que el valor no es un número válido
                MessageBox.Show("Por favor, ingresa un valor válido para el costo.");
                return false;
            }
        }
        private void ContenidoCboEstado()
        {
            cboEstado.Items.Add(new OpComboEstadoPromociones() { Valor = true, Texto = "Activo" });
            cboEstado.Items.Add(new OpComboEstadoPromociones() { Valor = false, Texto = "Inactivo" });

            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;
            OpComboEstadoPromociones seleccionado = (OpComboEstadoPromociones)cboEstado.SelectedItem;
            valorEstado = (bool)seleccionado.Valor;
        }
        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dataGridPromociones.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "costo" && columna.Name != "descripcion" && columna.Name != "id_usuario")
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
            List<Promociones> listaPromociones = (List<Promociones>)promocionesControlador.ListarPromocionesActivas();
            foreach (Promociones item in listaPromociones)
            {
                dataGridPromociones.Rows.Add(new object[] {"",item.id_promocion,item.tipo,item.costo,item.descripcion,
                item.estado == true ? "Activo" : "Inactivo","",
                item.estado == true ? 1:0});
            }

        }
        public void ListarPromocionesTipo()
        {
            dataGridPromociones.Rows.Clear();
            List<Promociones> listaPromocionesTipo = (List<Promociones>)promocionesControlador.ListarPromocionesTipo(txtBusqueda.Text);
            foreach (Promociones item in listaPromocionesTipo)
            {
                dataGridPromociones.Rows.Add(new object[] {"",item.id_promocion,item.tipo,item.costo,item.descripcion,
                    item.estado == true ? "Activo" : "Inactivo","",
                    item.estado == true ? 1:0});
            }

        }
        public void ListarPromocionesEstados()
        {
            dataGridPromociones.Rows.Clear();
            bool busquedaEnGrid = ConversionBooleanaBusqueda();
            List<Promociones> listaPromocionesEstado = (List<Promociones>)promocionesControlador.ListarPromocionesEstado(busquedaEnGrid);
            foreach (Promociones item in listaPromocionesEstado)
            {
                dataGridPromociones.Rows.Add(new object[] {"",item.id_promocion,item.tipo,item.costo,item.descripcion,
                    item.estado == true ? "Activo" : "Inactivo","",
                    item.estado == true ? 1:0});
            }
        }
        private bool ConversionBooleanaBusqueda()
        {
            string busqueda = txtBusqueda.Text.ToLower();
            if (busqueda == "activo")
            {
                return true;
            }
            else if (busqueda == "inactivo")
            {
                return false;
            }
            else
            {
                throw new ArgumentException("El texto debe ser 'activo' o 'inactivo'");
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
                    txtId.Text = dataGridPromociones.Rows[indice].Cells["idusuario"].Value.ToString();
                    txtTipo.Text = dataGridPromociones.Rows[indice].Cells["tipo"].Value.ToString();
                    txtCosto.Text = dataGridPromociones.Rows[indice].Cells["costo"].Value.ToString();
                    txtDescripcion.Text = dataGridPromociones.Rows[indice].Cells["descripcion"].Value.ToString();
                    //Seleciondo el id se cambia el combo box
                    foreach (OpComboEstadoPromociones opcPromocion in cboEstado.Items)
                    {
                        if (Convert.ToBoolean(opcPromocion.Valor) == Convert.ToBoolean(dataGridPromociones.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboEstado.Items.IndexOf(opcPromocion);
                            cboEstado.SelectedIndex = indice_combo;
                            break;
                        }

                    }

                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "Tipo")
            {
                ListarPromocionesTipo();
            }
            if (cboBusqueda.Text == "Estado")
            {
                ListarPromocionesEstados();
            }
        }
    }
}
