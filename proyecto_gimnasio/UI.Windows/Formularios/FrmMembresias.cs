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
    public partial class FrmMembresias : Form
    {
        private bool valorEstado;
        MembresiasVistaModelo membresiasVistaModelo = new MembresiasVistaModelo();
        MembresiasControlador membresiasControlador;
        public FrmMembresias()
        {
            InitializeComponent();
            membresiasControlador = new MembresiasControlador();
        }
        //public void InsertarMembresia()
        //{
            //if (membresiasControlador.InsertarMembresia(membresiasVistaModelo))
            //{
                //MessageBox.Show("Membresia insertada correctamente");
            //}
            //else
            //{
                //MessageBox.Show("Error: Al insertar membresia");
            //}
       // }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            membresiasVistaModelo.Tipo = txtTipo.Text;
            if(ConversionCosto(txtCosto.Text))
            {
                //bool estadoMembresias = Convert.ToBoolean(cboEstado.SelectedValue.ToString());
                membresiasVistaModelo.Descripcion = txtDescripcion.Text;
                membresiasVistaModelo.Estado = valorEstado;
                dataGridMembresias.Rows.Add(new object[] {"",membresiasVistaModelo.IdMembresia, membresiasVistaModelo.Tipo,membresiasVistaModelo.Costo,membresiasVistaModelo.Descripcion,
                ((OpComboEstadoMembresia)cboEstado.SelectedItem).Texto.ToString(),"",((OpComboEstadoMembresia)cboEstado.SelectedItem).Valor.ToString()});
                Limpiar();
                //InsertarMembresia();
            }
        }

        private bool ConversionCosto(string costo)
        {
            // Convertir el texto de altura a decimal
            decimal valoraCosto;
            if (decimal.TryParse(costo, out valoraCosto))
            {
                membresiasVistaModelo.Costo = valoraCosto;
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
            cboEstado.Items.Add(new OpComboEstadoMembresia() { Valor = true, Texto = "Activo" });
            cboEstado.Items.Add(new OpComboEstadoMembresia() { Valor = false, Texto = "Inactivo" });

            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;
            OpComboEstadoMembresia seleccionado = (OpComboEstadoMembresia)cboEstado.SelectedItem;
            valorEstado = (bool)seleccionado.Valor;
        }

        private void BusquedaDataGrid()
        {
            foreach (DataGridViewColumn columna in dataGridMembresias.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "costo" && columna.Name != "descripcion" && columna.Name != "id_usuario")
                {
                    cboBusqueda.Items.Add(new OpComboEstadoMembresia() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }

        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtTipo.Text = "";
            txtCosto.Text = "";
            txtDescripcion.Text = "";
            cboEstado.SelectedIndex = 0;
        }

        //public void Listar()
        //{
            //List<Membresias> listaMembresias = (List<Membresias>)membresiasControlador.ListarMembresiasActivas();
            //foreach (Membresias item in listaMembresias)
            //{
               //// dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.tipo,item.costo,item.descripcion,
                //item.estado == true ? "Activo" : "Inactivo","",
                //item.estado == true ? 1:0});
            //}

        //}

        //public void ListarMmebresiasTipo()
        //{
            //dataGridMembresias.Rows.Clear();
           // List<Membresias> listaMembresiasTipo = (List<Membresias>)membresiasControlador.ListarMembresiasTipo(txtBusqueda.Text);
            //foreach (Membresias item in listaMembresiasTipo)
            //{
                //dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.tipo,item.costo,item.descripcion,
                   // item.estado == true ? "Activo" : "Inactivo","",
                   // item.estado == true ? 1:0});
            //}

        //}

        //public void ListarMembresiasEstados()
        //{
            //dataGridMembresias.Rows.Clear();
            //bool busquedaEnGrid = ConversionBooleanaBusqueda();
            //List<Membresias> listaMembresiasEstado = (List<Membresias>)membresiasControlador.ListarMembresiasEstado(busquedaEnGrid);
            //foreach (Membresias item in listaMembresiasEstado)
            //{
                //dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.tipo,item.costo,item.descripcion,
                    //item.estado == true ? "Activo" : "Inactivo","",
                    //item.estado == true ? 1:0});
            //}
        //}

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

        private void FrmMembresias_Load(object sender, EventArgs e)
        {
            BusquedaDataGrid();
            ContenidoCboEstado();
            //Listar();
        }

        private void dataGridMembresias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridMembresias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridMembresias.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGridMembresias.Rows[indice].Cells["idusuario"].Value.ToString();
                    txtTipo.Text = dataGridMembresias.Rows[indice].Cells["tipo"].Value.ToString();
                    txtCosto.Text = dataGridMembresias.Rows[indice].Cells["costo"].Value.ToString();
                    txtDescripcion.Text = dataGridMembresias.Rows[indice].Cells["descripcion"].Value.ToString(); 
                    //Seleciondo el id se cambia el combo box
                    foreach (OpComboEstadoMembresia opcMembresia in cboEstado.Items)
                    {
                        if (Convert.ToBoolean(opcMembresia.Valor) == Convert.ToBoolean(dataGridMembresias.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboEstado.Items.IndexOf(opcMembresia);
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
                //ListarMmebresiasTipo();
            }
            if (cboBusqueda.Text == "Estado")
            {
                //ListarMembresiasEstados();
            }
        }
    }
}
