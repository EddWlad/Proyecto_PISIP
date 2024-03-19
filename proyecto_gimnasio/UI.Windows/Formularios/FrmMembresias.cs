using DocumentFormat.OpenXml.Wordprocessing;
using Dominio.Modelo.Entidades;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Windows.Controladores;
using UI.Windows.Formularios.Utilitarios;
using UI.Windows.VistaModelos;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using PageSize = iTextSharp.text.PageSize;
using iText.Kernel.Pdf;
using iTextSharp.text.pdf;
using PdfWriter = iTextSharp.text.pdf.PdfWriter;
using Irony;
using System.IO;
using System.Drawing;
using Image = System.Drawing.Image;
using iTextSharp.tool.xml;

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
        List<MembresiaTipoCostoPromocion> listaMembresias;
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
                MessageBox.Show("Membresia insertada correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al ingresar Membresia");
            }
        }
        public void ModificarMembresia()
        {
            if (membresiasControlador.ModificarMembresia(membresiasVistaModelo))
            {
                MessageBox.Show("Membresia modificada correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al modificar Membresia");
            }
        }
        private void contenidoTipoMembresia()
        {
            cboTipoMembresia.DataSource = tipoMembresiaControlador.ListarTipoMembresiasActivas();
            cboTipoMembresia.DisplayMember = "descripcion";
            cboTipoMembresia.ValueMember = "id_tipo_membresia";

        }
        private void contenidoCostoMembresia(string tipo)
        {
            cboCostoMembresia.DataSource = costoMembresiasControlador.ListarCostoMembresiasDescripcion(tipo);
            cboCostoMembresia.DisplayMember = "costo";
            cboCostoMembresia.ValueMember = "id_costo_membresia";

        }
        private void contenidoPromociones()
        {
            cboPromocion.DataSource = promocionesControlador.ListarPromocionesVigentes(DateTime.Now.Date);
            cboPromocion.DisplayMember = "descripcion";
            cboPromocion.ValueMember = "id_promocion";

        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("La membresia ya existe");
                Limpiar();
                return;
            }
            var membresiaEncontrada = listaMembresias.Where(x => x.descripcion.Equals(txtDescripcion.Text)).ToList();
            if (membresiaEncontrada.Count > 0)
            {
                MessageBox.Show("La membresia existe");
                Limpiar();
                return;
            }
            bool isValid = true;

            // Verificar si el campo Nombre está vacío
            if (string.IsNullOrWhiteSpace(txtFechaRegistro.Text))
            {
                MessageBox.Show("El campo 'Fehcha' es obligatorio.");
                isValid = false;
            }
            // Verificar si el campo Apellido está vacío
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo 'Descripcion' es obligatorio.");
                isValid = false;
            }
            // Verificar si el campo Teléfono está vacío
            if (string.IsNullOrWhiteSpace(ConvertirFechaInicio().ToString()))
            {
                MessageBox.Show("El campo 'Fecha Inicio' es obligatorio.");
                isValid = false;
            }
            else
            {
                DateTime inicio = DateTime.Parse(ConvertirFechaInicio().ToString());
                if (inicio < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha de inicio debe ser mayor a la fecha actual");
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(ConvertirFechaFin().ToString()))
            {
                MessageBox.Show("El campo 'Fecha Fin' es obligatorio.");
                isValid = false;
            }
            else
            {
                DateTime inicio = DateTime.Parse(ConvertirFechaInicio().ToString());
                DateTime fin = DateTime.Parse(ConvertirFechaFin().ToString());
                if (fin < inicio)
                {
                    MessageBox.Show("La fecha de fin debe ser mayor a la fecha de inicio");
                    return;
                }
            }
            if (isValid)
            {
                membresiasVistaModelo.Fecha_Registro = DateTime.Now;
                membresiasVistaModelo.Descripcion = txtDescripcion.Text;
                membresiasVistaModelo.Fecha_Inicio = ConvertirFechaInicio();
                membresiasVistaModelo.Fecha_Fin = ConvertirFechaFin();
                membresiasVistaModelo.Estado = true;
                membresiasVistaModelo.Id_Tipo_Membresia = (int)cboTipoMembresia.SelectedValue;
                membresiasVistaModelo.Id_Costo_Membresia = (int)cboCostoMembresia.SelectedValue;
                membresiasVistaModelo.Id_Promocion = (int)cboPromocion.SelectedValue;
                dataGridMembresias.Rows.Add(new object[] {"",membresiasVistaModelo.Id_Membresia, membresiasVistaModelo.Fecha_Registro,membresiasVistaModelo.Descripcion,membresiasVistaModelo.Fecha_Inicio,
                membresiasVistaModelo.Fecha_Fin,cboTipoMembresia.Text,cboCostoMembresia.Text,cboPromocion.Text});
                InsertarMembresia();
                Limpiar();
                dataGridMembresias.Rows.Clear();
                Listar();
            }
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
            txtId.Text = "";
            txtFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDescripcion.Text = "";
            txtFechaFin.Text = "";
            textFechaInicio.Text = "";
            txtBusqueda.Text = "";
        }

        public void Listar()
        {
            listaMembresias = (List<MembresiaTipoCostoPromocion>)membresiasControlador.ListarMembresiasActivas();
            foreach (MembresiaTipoCostoPromocion item in listaMembresias)
            {
                dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.fecha_registro.ToString("dd/MM/yyyy"),item.descripcion,item.fecha_inicio.ToString("dd/MM/yyyy"),item.fecha_fin.ToString("dd/MM/yyy"),item.tipoMembresia,
                item.costo,item.promocion});
            }

        }
        public void MembresiasCosto()
        {
            dataGridMembresias.Rows.Clear();
            listaMembresias = (List<MembresiaTipoCostoPromocion>)membresiasControlador.ListarMembresiasCosto(decimal.Parse(txtBusqueda.Text));
            foreach (MembresiaTipoCostoPromocion item in listaMembresias)
            {
                dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.fecha_registro.ToString("dd/MM/yyyy"),item.descripcion,item.fecha_inicio.ToString("dd/MM/yyyy"),item.fecha_fin.ToString("dd/MM/yyy"),item.tipoMembresia,
                item.costo,item.promocion});
            }

        }
        public void MembresiasTipo()
        {
            dataGridMembresias.Rows.Clear();
            listaMembresias = (List<MembresiaTipoCostoPromocion>)membresiasControlador.ListarMembresiasTipo(txtBusqueda.Text);
            foreach (MembresiaTipoCostoPromocion item in listaMembresias)
            {
                dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.fecha_registro.ToString("dd/MM/yyyy"),item.descripcion,item.fecha_inicio.ToString("dd/MM/yyyy"),item.fecha_fin.ToString("dd/MM/yyy"),item.tipoMembresia,
                item.costo,item.promocion});
            }
        }
        public void MembresiasPromocion()
        {
            dataGridMembresias.Rows.Clear();
            listaMembresias = (List<MembresiaTipoCostoPromocion>)membresiasControlador.ListarMembresiasPromocion(txtBusqueda.Text);
            foreach (MembresiaTipoCostoPromocion item in listaMembresias)
            {
                dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.fecha_registro.ToString("dd/MM/yyyy"),item.descripcion,item.fecha_inicio.ToString("dd/MM/yyyy"),item.fecha_fin.ToString("dd/MM/yyy"),item.tipoMembresia,
                item.costo,item.promocion});
            }
        }

        public void MembresiasFechaRegistro()
        {
            dataGridMembresias.Rows.Clear();
            listaMembresias = (List<MembresiaTipoCostoPromocion>)membresiasControlador.ListarMembresiasFechaRegistro(DateTime.Parse(txtBusqueda.Text));
            foreach (MembresiaTipoCostoPromocion item in listaMembresias)
            {
                dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.fecha_registro.ToString("dd/MM/yyyy"),item.descripcion,item.fecha_inicio.ToString("dd/MM/yyyy"),item.fecha_fin.ToString("dd/MM/yyy"),item.tipoMembresia,
                item.costo,item.promocion});
            }
        }
        public void MembresiasFechaInicio()
        {
            dataGridMembresias.Rows.Clear();
            listaMembresias = (List<MembresiaTipoCostoPromocion>)membresiasControlador.ListarMembresiasFechaInicio(DateTime.Parse(txtBusqueda.Text));
            foreach (MembresiaTipoCostoPromocion item in listaMembresias)
            {
                dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.fecha_registro.ToString("dd/MM/yyyy"),item.descripcion,item.fecha_inicio.ToString("dd/MM/yyyy"),item.fecha_fin.ToString("dd/MM/yyy"),item.tipoMembresia,
                item.costo,item.promocion});
            }
        }
        public void MembresiasFechaFin()
        {
            dataGridMembresias.Rows.Clear();
            listaMembresias = (List<MembresiaTipoCostoPromocion>)membresiasControlador.ListarMembresiasFechafin(DateTime.Parse(txtBusqueda.Text));
            foreach (MembresiaTipoCostoPromocion item in listaMembresias)
            {
                dataGridMembresias.Rows.Add(new object[] {"",item.id_membresia,item.fecha_registro.ToString("dd/MM/yyyy"),item.descripcion,item.fecha_inicio.ToString("dd/MM/yyyy"),item.fecha_fin.ToString("dd/MM/yyy"),item.tipoMembresia,
                item.costo,item.promocion});
            }
        }

        private void FrmMembresias_Load(object sender, EventArgs e)
        {
            BusquedaDataGrid();
            contenidoTipoMembresia();
            //contenidoCostoMembresia(cboTipoMembresia.Text);
            contenidoPromociones();
            txtFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //ContenidoCboEstado();
            Limpiar();
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

                e.Graphics.DrawImage(Properties.Resources.check_circle_solid_24, new System.Drawing.Rectangle(imgX, imgY, imgWidth, imgHeight));
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
                    txtFechaRegistro.Text = DateTime.Parse(dataGridMembresias.Rows[indice].Cells["fecha_registro"].Value.ToString()).ToString("dd/MM/yyyy");
                    txtDescripcion.Text = dataGridMembresias.Rows[indice].Cells["descripcion"].Value.ToString();
                    textFechaInicio.Text = dataGridMembresias.Rows[indice].Cells["fecha_inicio"].Value.ToString();
                    txtFechaFin.Text = dataGridMembresias.Rows[indice].Cells["fecha_fin"].Value.ToString();
                    cboTipoMembresia.Text = dataGridMembresias.Rows[indice].Cells["tipo_membresia"].Value.ToString();
                    cboCostoMembresia.Text = dataGridMembresias.Rows[indice].Cells["costo_membresia"].Value.ToString();
                    cboPromocion.Text = dataGridMembresias.Rows[indice].Cells["promocion"].Value.ToString();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "Fecha registro")
            {
                MembresiasFechaRegistro();
            }
            if (cboBusqueda.Text == "Fecha Inicio")
            {
                MembresiasFechaInicio();
            }
            if (cboBusqueda.Text == "Fecha Fin")
            {
                MembresiasFechaFin();
            }
            if (cboBusqueda.Text == "Tipo Membresia")
            {
                MembresiasTipo();
            }
            if (cboBusqueda.Text == "Costo")
            {
                MembresiasCosto();
            }
            if (cboBusqueda.Text == "Promocion")
            {
                MembresiasPromocion();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El Id del cliente no fue encontrado");
                return;
            }
            var membresiaEncontrada = listaMembresias.Where(x => x.descripcion.Equals(txtDescripcion.Text)).ToList();
            if (membresiaEncontrada.Count > 0)
            {
                MessageBox.Show("La membresia existe");
                Limpiar();
                return;
            }
            bool isValid = true;

            // Verificar si el campo Nombre está vacío
            if (string.IsNullOrWhiteSpace(txtFechaRegistro.Text))
            {
                MessageBox.Show("El campo 'Fehcha' es obligatorio.");
                isValid = false;
            }
            // Verificar si el campo Apellido está vacío
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo 'Descripcion' es obligatorio.");
                isValid = false;
            }
            // Verificar si el campo Teléfono está vacío
            if (string.IsNullOrWhiteSpace(ConvertirFechaInicio().ToString()))
            {
                MessageBox.Show("El campo 'Fecha Inicio' es obligatorio.");
                isValid = false;
            }
            else
            {
                DateTime inicio = DateTime.Parse(ConvertirFechaInicio().ToString());
                if (inicio < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha de inicio debe ser mayor a la fecha actual");
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(ConvertirFechaFin().ToString()))
            {
                MessageBox.Show("El campo 'Fecha Fin' es obligatorio.");
                isValid = false;
            }
            else
            {
                DateTime inicio = DateTime.Parse(ConvertirFechaInicio().ToString());
                DateTime fin = DateTime.Parse(ConvertirFechaFin().ToString());
                if (fin < inicio)
                {
                    MessageBox.Show("La fecha de fin debe ser mayor a la fecha de inicio");
                    return;
                }
            }
            if(isValid)
            {
                membresiasVistaModelo.Id_Membresia = int.Parse(txtId.Text);
                membresiasVistaModelo.Fecha_Registro = DateTime.Now;
                membresiasVistaModelo.Descripcion = txtDescripcion.Text;
                membresiasVistaModelo.Fecha_Inicio = ConvertirFechaInicio();
                membresiasVistaModelo.Fecha_Fin = ConvertirFechaFin();
                membresiasVistaModelo.Estado = true;
                membresiasVistaModelo.Id_Tipo_Membresia = (int)cboTipoMembresia.SelectedValue;
                membresiasVistaModelo.Id_Costo_Membresia = (int)cboCostoMembresia.SelectedValue;
                membresiasVistaModelo.Id_Promocion = (int)cboPromocion.SelectedValue;
                dataGridMembresias.Rows.Add(new object[] {"",membresiasVistaModelo.Id_Membresia, membresiasVistaModelo.Fecha_Registro,membresiasVistaModelo.Descripcion,membresiasVistaModelo.Fecha_Inicio,
                membresiasVistaModelo.Fecha_Fin,cboTipoMembresia.Text,cboCostoMembresia.Text,cboPromocion.Text});
                ModificarMembresia();
                Limpiar();
                dataGridMembresias.Rows.Clear();
                Listar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El Id de membresia no fue encontrado");
                return;
            }

            var eliminacionMembresia = membresiasControlador.EliminarMembresia(int.Parse(txtId.Text));
            if (eliminacionMembresia)
            {
                MessageBox.Show("Membresia eliminada correctamente");

            }
            else
            {
                MessageBox.Show("Error: Al elimnar membresia");
            }
            dataGridMembresias.Rows.Clear();
            Limpiar();
            Listar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridMembresias.Rows.Clear();
            Limpiar();
            Listar();
        }

        private void cboTipoMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoMembresia.SelectedItem != null)
            {
                string tipoSeleccionado = cboTipoMembresia.Text;
                contenidoCostoMembresia(tipoSeleccionado);
            }
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            if(txtDescripcion.Text == "")
            {
                MessageBox.Show("No se encontro tarjeta de miembro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string textoHtml = Properties.Resources.PlantillaMembresia.ToString();

            textoHtml = textoHtml.Replace("@nombrenegocio", "WORKOUTCENTER");
            textoHtml = textoHtml.Replace("@docnegocio", "1726517103001");
            textoHtml = textoHtml.Replace("@direcnegocio", "PICHINCHA I QUITO I GUAYLLABAMBA / AV SIMON BOLIVAR SN Y PASAJE SN");

            textoHtml = textoHtml.Replace("@tipodocumento", cboTipoMembresia.Text);
            textoHtml = textoHtml.Replace("@numerodocumento", txtFechaRegistro.Text);

            textoHtml = textoHtml.Replace("@docproveedor", txtDescripcion.Text);
            textoHtml = textoHtml.Replace("@nombreproveedor", textFechaInicio.Text);
            textoHtml = textoHtml.Replace("@fecharegistro", txtFechaFin.Text);
            textoHtml = textoHtml.Replace("@usuarioregistro", cboPromocion.Text);
            textoHtml = textoHtml.Replace("@montototal", cboCostoMembresia.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Tarjeta_{0}.pdf", DateTime.Now.ToString("dd-MM-yyyy"));
            savefile.Filter = "Pdf Files|*.pdf";

            if(savefile.ShowDialog() == DialogResult.OK)
            {
                using(FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A5,25,25,25,25);
                    PdfWriter write = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();


                    // Asumiendo que tienes una imagen llamada Logo en tus recursos
                    Image image = Properties.Resources.Logo;

                    byte[] byteImage;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Guardar la imagen en el MemoryStream
                        image.Save(ms, image.RawFormat);

                        // Convertir el MemoryStream a byte array
                        byteImage = ms.ToArray();
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }
                    using(StringReader sr = new StringReader(textoHtml))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(write,pdfDoc,sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
