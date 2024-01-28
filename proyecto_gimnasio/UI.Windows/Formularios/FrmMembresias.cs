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
        TipoMembresiaControlador tipoMembresiaControlador;
        CostoMembresiasControlador costoMembresiasControlador;
        PromocionesControlador promocionesControlador;
        public FrmMembresias()
        {
            InitializeComponent();
            membresiasControlador = new MembresiasControlador();
            tipoMembresiaControlador = new TipoMembresiaControlador();
            costoMembresiasControlador = new CostoMembresiasControlador();
            promocionesControlador = new PromocionesControlador();

        }
        public void InsertarMembresia()
        {
            if (membresiasControlador.InsertarMembresia(membresiasVistaModelo))
            {
                MessageBox.Show("Pago insertado correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al ingresar pago");
            }
        }
        private void contenidoTipoMembresia()
        {
            cboTipoMembresia.DataSource = tipoMembresiaControlador.ListarTipoMembresiasActivas();
            cboTipoMembresia.DisplayMember = "descripcion";
            cboTipoMembresia.ValueMember = "id_tipo_membresia";

        }
        private void contenidoCostoMembresia()
        {
            cboCostoMembresia.DataSource = costoMembresiasControlador.ListarCostoMembresiasActivas();
            cboCostoMembresia.DisplayMember = "valor";
            cboCostoMembresia.ValueMember = "id_costo_membresia";

        }
        private void contenidoPromociones()
        {
            cboPromocion.DataSource = promocionesControlador.ListarPromocionesActivas();
            cboPromocion.DisplayMember = "descripcion";
            cboPromocion.ValueMember = "id_promocion";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            membresiasVistaModelo.Fecha_Registro = DateTime.Now;
           
                //bool estadoMembresias = Convert.ToBoolean(cboEstado.SelectedValue.ToString());
                
                membresiasVistaModelo.Descripcion = txtDescripcion.Text;
                membresiasVistaModelo.Fecha_Inicio = ConvertirFechaInicio();
                membresiasVistaModelo.Fecha_Fin = ConvertirFechaFin();
                membresiasVistaModelo.Estado = true;
                membresiasVistaModelo.Id_Tipo_Membresia = (int)cboTipoMembresia.SelectedValue;
                membresiasVistaModelo.Id_Costo_Membresia = (int)cboCostoMembresia.SelectedValue;
                membresiasVistaModelo.Id_Promocion = (int)cboPromocion.SelectedValue;
                dataGridMembresias.Rows.Add(new object[] {"",membresiasVistaModelo.Id_Membresia, membresiasVistaModelo.Fecha_Registro,membresiasVistaModelo.Descripcion,membresiasVistaModelo.Fecha_Inicio,
                membresiasVistaModelo.Fecha_Fin,cboTipoMembresia.Text,cboCostoMembresia.Text,cboPromocion.Text});
                Limpiar();
                InsertarMembresia();
            
        }

        public DateTime ConvertirFechaInicio()
        {
            DateTime fechaInicio;
            if (DateTime.TryParse(textFechaInicio.Text, out fechaInicio))
            {
                return fechaInicio;
            }
            else
            {
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
                return DateTime.Now;
            }
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
            txtFechaRegistro.Text = "";
            txtDescripcion.Text = "";
            txtFechaFin.Text = "";
            textFechaInicio.Text = "";
        }

        public void Listar()
        {
            List<MembresiaTipoCostoPromocion> listaMembresias = (List<MembresiaTipoCostoPromocion>)membresiasControlador.ListarMembresiasActivas();
            foreach (MembresiaTipoCostoPromocion item in listaMembresias)
            {
                dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.fecha_registro,item.descripcion,item.fecha_inicio,item.fecha_fin,item.tipoMembresia,
                item.costo,item.promocion});
            }

        }

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
            contenidoTipoMembresia();
            contenidoCostoMembresia();
            contenidoPromociones();
            txtFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //ContenidoCboEstado();
            Listar();
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
                    txtId.Text = dataGridMembresias.Rows[indice].Cells["idmembresias"].Value.ToString();
                    txtFechaRegistro.Text = dataGridMembresias.Rows[indice].Cells["fecha_registro"].Value.ToString();
                    txtDescripcion.Text = dataGridMembresias.Rows[indice].Cells["descripcion"].Value.ToString();
                    textFechaInicio.Text = dataGridMembresias.Rows[indice].Cells["fecha_inicio"].Value.ToString();
                    txtFechaFin.Text = dataGridMembresias.Rows[indice].Cells["fecha_fin"].Value.ToString();
                    //Seleciondo el id se cambia el combo box
                    //foreach (OpComboEstadoMembresia opcMembresia in cboEstado.Items)
                    //{
                    //if (Convert.ToBoolean(opcMembresia.Valor) == Convert.ToBoolean(dataGridMembresias.Rows[indice].Cells["EstadoValor"].Value))
                    //{
                    //int indice_combo = cboEstado.Items.IndexOf(opcMembresia);
                    //cboEstado.SelectedIndex = indice_combo;
                    //break;
                    //}

                    //}

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
