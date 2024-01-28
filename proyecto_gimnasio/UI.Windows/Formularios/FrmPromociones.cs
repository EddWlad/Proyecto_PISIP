﻿using Dominio.Modelo.Entidades;
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
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
                promocionesVistaModelo.Fecha_registro = DateTime.Now;
                promocionesVistaModelo.Descripcion = txtDescripcion.Text;
                promocionesVistaModelo.Fecha_inicio = ConvertirFechaInicio();
                promocionesVistaModelo.Fecha_fin = ConvertirFechaFin();
                promocionesVistaModelo.Estado = true;
                dataGridPromociones.Rows.Add(new object[] {"",promocionesVistaModelo.Id_promocion, promocionesVistaModelo.Fecha_registro,promocionesVistaModelo.Descripcion,promocionesVistaModelo.Fecha_inicio,
                promocionesVistaModelo.Fecha_fin,});
                InsertarPromocion();
                Limpiar();

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

        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtDescripcion.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
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
                dataGridPromociones.Rows.Add(new object[] {"",item.id_promocion,item.fecha_registro,item.descripcion,item.fecha_inicio,
                item.fecha_fin,});
            }

        }
        public void ListarPromocionesTipo()
        {
            dataGridPromociones.Rows.Clear();
            List<Promociones> listaPromocionesTipo = (List<Promociones>)promocionesControlador.ListarPromocionesTipo(txtBusqueda.Text);
            foreach (Promociones item in listaPromocionesTipo)
            {
                dataGridPromociones.Rows.Add(new object[] {"",item.id_promocion,item.fecha_registro,item.descripcion,item.descripcion,
                item.fecha_inicio, item.fecha_fin,});
            }

        }
        //public void ListarPromocionesEstados()
        //{
            //dataGridPromociones.Rows.Clear();
            //bool busquedaEnGrid = ConversionBooleanaBusqueda();
           // List<Promociones> listaPromocionesEstado = (List<Promociones>)promocionesControlador.ListarPromocionesEstado(busquedaEnGrid);
           //foreach (Promociones item in listaPromocionesEstado)
            //{
               // dataGridPromociones.Rows.Add(new object[] {"",item.id_promocion,item.tipo,item.costo,item.descripcion,
                    //item.estado == true ? "Activo" : "Inactivo","",
                    //item.estado == true ? 1:0});
            //}
        //}
        

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
                    txtFecha.Text = dataGridPromociones.Rows[indice].Cells["fecha"].Value.ToString();
                    txtDescripcion.Text = dataGridPromociones.Rows[indice].Cells["descripcion"].Value.ToString();
                    txtFechaInicio.Text = dataGridPromociones.Rows[indice].Cells["fecha_inicio"].Value.ToString();
                    txtFechaFin.Text = dataGridPromociones.Rows[indice].Cells["fecha_fin"].Value.ToString();
   
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "Tipo")
            {
                ListarPromocionesTipo();
            }

        }
    }
}
