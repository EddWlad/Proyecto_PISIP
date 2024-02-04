using Aplicacion.Servicio;
using ClosedXML.Excel;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Windows.Controladores;
using UI.Windows.Formularios.Utilitarios;
using UI.Windows.VistaModelos;


namespace UI.Windows.Formularios
{
    public partial class FrmClientes : Form
    {
        
        ClienteVistaModelo clienteVistaModelo = new ClienteVistaModelo();
        ClienteControlador clienteControlador;
        TipoClienteControlador tipoClienteControlador;
        MembresiasControlador membresiasControlador;
        RegistroAsistenciaControlador asistenciaControlador;
        List<ClienteTipoCliente> listaClientes;
        
        public FrmClientes()
        {
            InitializeComponent();
            clienteControlador = new ClienteControlador();
            tipoClienteControlador = new TipoClienteControlador();
            membresiasControlador = new MembresiasControlador();
            asistenciaControlador = new RegistroAsistenciaControlador();
            this.txtCedula.KeyPress += new KeyPressEventHandler(txtCedula_KeyPress);
            this.txtAltura.KeyPress += new KeyPressEventHandler(txtAltura_KeyPress);
            this.txtPeso.KeyPress += new KeyPressEventHandler(txtPeso_KeyPress);
            this.txtTelefono.KeyPress += new KeyPressEventHandler(txtTelefono_KeyPress);
            //this.txtCedula.Validating += new System.ComponentModel.CancelEventHandler(this.txtCedula_Validating);
        }

        public void InsertarCliente()
        {
            if(clienteControlador.InsertarCliente(clienteVistaModelo))
            {
                MessageBox.Show("Cliente insertado correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al insertar cliente");
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            Limpiar();
            BusquedaDataGrid();
            contenidoTipoCliente();
            contenidoMembresia();
            //ContenidoCboEstado();
            ptbFoto.Image = Properties.Resources.sin_foto;
            Listar();
        }
        private void contenidoMembresia()
        {
            cboTipoMembresia.DataSource = membresiasControlador.ListarMembresiasActivas();
            cboTipoMembresia.DisplayMember = "descripcion";
            cboTipoMembresia.ValueMember = "id_membresia";

        }
        private void BusquedaDataGrid()
        {
            foreach(DataGridViewColumn columna in dataGridClientes.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "foto" && columna.Name != "apellido" && columna.Name != "telefono" && columna.Name != "email" && columna.Name != "peso" && columna.Name != "altura")
                {
                    cboBusqueda.Items.Add(new OpComboEstadoCliente() { Valor = columna.Name, Texto = columna.HeaderText });
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
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtCedula.Text = "";
            txtPeso.Text = "";
            txtAltura.Text = "";
            ptbFoto.Image = null;
            ptbFoto.Image = Properties.Resources.sin_foto;

        }

        private void contenidoTipoCliente()
        {
            cboTipoCliente.DataSource = tipoClienteControlador.ListarTipoClientesActivos();
            cboTipoCliente.DisplayMember = "descripcion";
            cboTipoCliente.ValueMember = "id_tipo_cliente";

        }
        private bool ConversionAltura(string txtAltura)
        {
            // Convertir el texto de altura a decimal
            decimal valoraltura;
            if (decimal.TryParse(txtAltura, out  valoraltura))
            {
                clienteVistaModelo.Altura = valoraltura;
                return true;
            }
            else
            {
                // Manejar el caso en el que el valor no es un número válido
                MessageBox.Show("Por favor, ingresa un valor válido para la altura.");
                return false;
            }
        }

        private bool ConversionPeso(string txtPeso)
        {
            // Convertir el texto de altura a decimal
            decimal valoraPeso;
            if (decimal.TryParse(txtPeso, out valoraPeso))
            {
                clienteVistaModelo.Peso = valoraPeso;
                return true;
            }
            else
            {
                // Manejar el caso en el que el valor no es un número válido
                MessageBox.Show("Por favor, ingresa un valor válido para el peso.");
                return false;
            }
        }

        

        public void Listar()
        {  
            listaClientes = (List<ClienteTipoCliente>)clienteControlador.ListarClientesActivos();
            foreach (ClienteTipoCliente item in listaClientes)
            {
                Image foto = ConvertirBytesAImagen(item.foto);
                foto = RedimensionarImagen(foto, dataGridClientes.Columns["foto"].Width, dataGridClientes.RowTemplate.Height);
                dataGridClientes.Rows.Add(new object[] {"",item.id_cliente,item.tipoCliente,item.cedula,item.nombre,item.apellido,item.direccion, item.telefono,item.email,
                item.peso,item.altura,item.membresia,foto});
            }
                
        }

        private void dataGridClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex <0)
            {
                return;
            }
            if(e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var imgWidth = Properties.Resources.check_circle_solid_24.Width;
                var imgHeight = Properties.Resources.check_circle_solid_24.Height;
                var imgX = e.CellBounds.Left + (e.CellBounds.Width - imgWidth) / 2;
                var imgY = e.CellBounds.Top + (e.CellBounds.Height - imgHeight) / 2;

                e.Graphics.DrawImage(Properties.Resources.check_circle_solid_24,new Rectangle(imgX,imgY,imgWidth,imgHeight));
                e.Handled = true;
            }
        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridClientes.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if(indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGridClientes.Rows[indice].Cells["id_cliente"].Value.ToString();
                    if (int.TryParse(dataGridClientes.Rows[indice].Cells["tipoCliente"].Value?.ToString(), out int tipoClienteId))
                    {
                        cboTipoCliente.SelectedValue = tipoClienteId;
                    }
                    else
                    {
                        // Manejar el caso de valor no válido o nulo
                    }
                    txtCedula.Text = dataGridClientes.Rows[indice].Cells["cedula"].Value.ToString();
                    txtNombre.Text = dataGridClientes.Rows[indice].Cells["nombre"].Value.ToString();
                    txtApellido.Text = dataGridClientes.Rows[indice].Cells["apellido"].Value.ToString();
                    txtDireccion.Text = dataGridClientes.Rows[indice].Cells["direccion"].Value.ToString();
                    txtTelefono.Text = dataGridClientes.Rows[indice].Cells["telefono"].Value.ToString();
                    txtEmail.Text = dataGridClientes.Rows[indice].Cells["email"].Value.ToString();
                    txtPeso.Text = dataGridClientes.Rows[indice].Cells["peso"].Value.ToString();
                    txtAltura.Text = dataGridClientes.Rows[indice].Cells["altura"].Value.ToString();
                    if (int.TryParse(dataGridClientes.Rows[indice].Cells["tipoMembresia"].Value?.ToString(), out int tipoMembresiaId))

                    {
                        cboTipoMembresia.SelectedValue = tipoMembresiaId;
                    }
                    else
                    {
                        // Manejar el caso de valor no válido o nulo
                    }
                    Image img = (Image)dataGridClientes.Rows[indice].Cells["foto"].Value;

                    if (img != null) // Verifica si la imagen no es null
                    {
                        ptbFoto.Image = img; // Asigna la imagen al PictureBox si existe.
                    }
                    else
                    {
                        // Aquí puedes decidir qué hacer si no hay imagen.
                        // Por ejemplo, puedes establecer el PictureBox a una imagen predeterminada o dejarlo vacío.
                        ptbFoto.Image = Properties.Resources.sin_foto; // Asume que tienes una imagen predeterminada en los recursos de tu proyecto.
                                                                                    // O simplemente dejarlo vacío
                                                                                    // ptbFoto.Image = null;
                    }
                }
            }
        }
        public void ListarClientesNombre()
        {
            dataGridClientes.Rows.Clear();
            List<ClienteTipoCliente> listaClientesNombre = (List<ClienteTipoCliente>)clienteControlador.ListarClientesNombres(txtBusqueda.Text);
                foreach (ClienteTipoCliente item in listaClientesNombre)
                {
                dataGridClientes.Rows.Add(new object[] {"",item.id_cliente,item.tipoCliente,item.cedula,item.nombre,item.apellido,item.direccion, item.telefono,item.email,
                item.peso,item.altura,item.membresia,"",});
            }
            
        }
        public void ListarClientesTipo()
        {
            dataGridClientes.Rows.Clear();
            List<ClienteTipoCliente> listaClientesTipo = (List<ClienteTipoCliente>)clienteControlador.ListarClientesTipo(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesTipo)
            {
                dataGridClientes.Rows.Add(new object[] {"",item.id_cliente,item.tipoCliente,item.cedula,item.nombre,item.apellido,item.direccion, item.telefono,item.email,
                item.peso,item.altura,item.membresia,"",});
            }

        }
        public void ListarClientesCedula()
        {
            dataGridClientes.Rows.Clear();
            List<ClienteTipoCliente> listaClientesTipo = (List<ClienteTipoCliente>)clienteControlador.ListarClientesCedula(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesTipo)
            {
                dataGridClientes.Rows.Add(new object[] {"",item.id_cliente,item.tipoCliente,item.cedula,item.nombre,item.apellido,item.direccion, item.telefono,item.email,
                item.peso,item.altura,item.membresia,"",});
            }

        }
        public void ListarClientesMembresia()
        {
            dataGridClientes.Rows.Clear();
            List<ClienteTipoCliente> listaClientesTipo = (List<ClienteTipoCliente>)clienteControlador.ListarClientesMembresia(txtBusqueda.Text);
            foreach (ClienteTipoCliente item in listaClientesTipo)
            {
                dataGridClientes.Rows.Add(new object[] {"",item.id_cliente,item.tipoCliente,item.cedula,item.nombre,item.apellido,item.direccion, item.telefono,item.email,
                item.peso,item.altura,item.membresia,"",});
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
            if (cboBusqueda.Text == "Nombre")
            {
                ListarClientesNombre();
            }
        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ptbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            if (txtCedula.Text.Length != 10)
            {
                MessageBox.Show("La cédula debe tener 10 caracteres.");
                return; // Salir del método si la condición no se cumple
            }
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El cliente ya existe");
                Limpiar();
                return;
            }
            var cedulaEncontrada = listaClientes.Where(x=>x.cedula.Equals(txtCedula.Text)).ToList();
            if (cedulaEncontrada.Count > 0)
            {
                MessageBox.Show("La cedula existe");
                Limpiar();
                return;
            }
            bool isValid = true;

            // Verificar si el campo Nombre está vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo 'Nombre' es obligatorio.");
                isValid = false;
            }
            // Verificar si el campo Apellido está vacío
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El campo 'Apellido' es obligatorio.");
                isValid = false;
            }
            // Verificar si el campo Teléfono está vacío
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El campo 'Teléfono' es obligatorio.");
                isValid = false;
            }
            if (isValid)
            {
                clienteVistaModelo.Foto = ms.GetBuffer();
                clienteVistaModelo.Id_Tipo_Cliente = (int)cboTipoCliente.SelectedValue;
                // Mostrar un mensaje de error
                clienteVistaModelo.Cedula = txtCedula.Text;
                clienteVistaModelo.Nombre = txtNombre.Text;
                clienteVistaModelo.Apellido = txtApellido.Text;
                clienteVistaModelo.Direccion = txtDireccion.Text;
                clienteVistaModelo.Telefono = txtTelefono.Text;
                clienteVistaModelo.Email = txtEmail.Text;
                clienteVistaModelo.Id_Membresia = (int)cboTipoMembresia.SelectedValue;
                // Validacion de valores de peso y altura correctos
                if (ConversionAltura(txtAltura.Text) && ConversionPeso(txtPeso.Text))
                {
                   clienteVistaModelo.Estado = true;
                   dataGridClientes.Rows.Add(new object[] {"",clienteVistaModelo.Id_Cliente,cboTipoCliente.Text,clienteVistaModelo.Cedula, clienteVistaModelo.Nombre,clienteVistaModelo.Apellido,clienteVistaModelo.Direccion, clienteVistaModelo.Telefono,clienteVistaModelo.Email,
                   clienteVistaModelo.Peso,clienteVistaModelo.Altura,cboTipoMembresia.Text,clienteVistaModelo.Foto});
                   Limpiar();
                   InsertarCliente();
                }
                else
                {
                   // Manejar el caso en el que el valor no es un número válido
                   MessageBox.Show("Por favor,ingrese el valor correcto");
                }
                dataGridClientes.Rows.Clear();
                Listar();
            }
        }

        //private void ObtenerCliente(int id)
        //{
            //var cliente = clienteControlador.ObtenerCliente(id);
        //}

        private void modificarCliente()
        {
            if (clienteControlador.ModificarCliente(clienteVistaModelo))
            {
                MessageBox.Show("Cliente modficado correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al modificar cliente");
            }
        }
        private void btnReporte_Click(object sender, EventArgs e)
        {
            if(dataGridClientes.Rows.Count <1 )
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach(DataGridViewColumn columna in dataGridClientes.Columns)
                {
                    if(columna.HeaderText != "" && columna.Visible && columna.HeaderText != "Foto")
                        dt.Columns.Add(columna.HeaderText,typeof(string));
                }
                foreach(DataGridViewRow fila in dataGridClientes.Rows)
                {
                    if (fila.Visible)
                        dt.Rows.Add(new object[] {
                           fila.Cells[2].Value.ToString(),
                           fila.Cells[3].Value.ToString(),
                           fila.Cells[4].Value.ToString(),
                           fila.Cells[5].Value.ToString(),
                           fila.Cells[6].Value.ToString(),
                           fila.Cells[7].Value.ToString(),
                           fila.Cells[8].Value.ToString(),
                           fila.Cells[9].Value.ToString(),
                           fila.Cells[10].Value.ToString(),
                        });
                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteClientes_{0}.xlsx", DateTime.Now.ToString("dd-MM-yyyy"));
                savefile.Filter = "Excel Files | *.xlsx";

                if(savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte de clientes generado");
                    }
                    catch 
                    {
                        MessageBox.Show("Error al generar reporte");
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ptbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El Id del cliente no fue encontrado");
                return;
            }
            clienteVistaModelo.Foto = ms.GetBuffer();
            clienteVistaModelo.Id_Cliente = int.Parse(txtId.Text); 
            clienteVistaModelo.Id_Tipo_Cliente = (int)cboTipoCliente.SelectedValue;
            clienteVistaModelo.Cedula = txtCedula.Text;
            clienteVistaModelo.Nombre = txtNombre.Text;
            clienteVistaModelo.Apellido = txtApellido.Text;
            clienteVistaModelo.Direccion = txtDireccion.Text;
            clienteVistaModelo.Telefono = txtTelefono.Text;
            clienteVistaModelo.Email = txtEmail.Text;
            clienteVistaModelo.Id_Membresia = (int)cboTipoMembresia.SelectedValue;
            // Validacion de valores de peso y altura correctos
            if (ConversionAltura(txtAltura.Text) && ConversionPeso(txtPeso.Text))
            {
                clienteVistaModelo.Estado = true;
                Limpiar();
                modificarCliente();
            }
            else
            {
                // Manejar el caso en el que el valor no es un número válido
                MessageBox.Show("Por favor,ingrese el valor correcto");
            }
            dataGridClientes.Rows.Clear();
            Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El Id del cliente no fue encontrado");
                return;
            }
           
            var eliminacionCliente = clienteControlador.EliminarCliente(int.Parse(txtId.Text));
            if (eliminacionCliente)
            {
                MessageBox.Show("Cliente eliminado correctamente");

            }
            else
            {
                MessageBox.Show("Error: Al elimnar cliente");
            }
            dataGridClientes.Rows.Clear();
            Limpiar();
            Listar();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridClientes.Rows.Clear();
            Listar();
            Limpiar();
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            DialogResult rs = fo.ShowDialog();
            if(rs == DialogResult.OK)
            {
                ptbFoto.Image = Image.FromFile(fo.FileName);
            }
        }
        private Image ConvertirBytesAImagen(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image img = Image.FromStream(ms);
                int anchoCelda = dataGridClientes.Columns["foto"].Width;
                int altoCelda = dataGridClientes.RowTemplate.Height;
                return RedimensionarImagen(img, anchoCelda, altoCelda);
            }
        }
        private Image RedimensionarImagen(Image img, int ancho, int alto)
        {
            Bitmap bm = new Bitmap(ancho, alto);
            Graphics grp = Graphics.FromImage(bm);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            Rectangle rect = new Rectangle(0, 0, ancho, alto);
            grp.DrawImage(img, rect);
            return bm;
        }
    }
}
