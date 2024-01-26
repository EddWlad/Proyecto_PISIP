using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dominio.Modelo.Entidades;

namespace UI.Windows.Formularios
{
    public partial class FrmInicio : Form
    {

        private static Usuario usuarioActual; 
        public FrmInicio(Usuario objUsuario)
        {
            usuarioActual = objUsuario;
            InitializeComponent();
        }

        private void btnCerar_Click(object sender, EventArgs e)
        {
            FrmLogin form = new FrmLogin();
            form.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void RealeaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            RealeaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormHija(object formhija)
        {
            if(this.panleContenedor.Controls.Count > 0) 
                this.panleContenedor.Controls.RemoveAt(0);
            
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panleContenedor.Controls.Add(fh);
            this.panleContenedor.Tag = fh;
            fh.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            AbrirFormHija(new FrmSubInicio());
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            posicionbtnFrmIncio();
            pictureBox1_Click_1(null, e);
            lblUsuario.Text = usuarioActual.nombre_usuario;
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            pnlSubmenuMembresias.Visible = !pnlSubmenuMembresias.Visible;
            //if (pnlSubmenuMembresias.Visible)
            //{
                // If the sub-menu is visible, move pnlMembresias down to make space for the sub-menu.
                //panlPromocion.Location = new Point(panlPromocion.Location.X, pnlSubmenuMembresias.Location.Y + pnlSubmenuMembresias.Height);
                //btnPromociones.Location = new Point(btnPromociones.Location.X, pnlSubmenuMembresias.Location.Y + pnlSubmenuMembresias.Height);
                

            //}
            //else
            //{
                 //If the sub-menu is not visible, move pnlMembresias back to its original position.
                //panlPromocion.Location = new Point(panlPromocion.Location.X, pnlSubmenuMembresias.Location.Y + 10);
                //btnPromociones.Location = new Point(btnPromociones.Location.X, pnlSubmenuMembresias.Location.Y +10);
               
                
            //}
            
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FrmPromociones());
        }

        private void btnPagoDiario_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FmrPagoDiario());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            pnlSubMenuCliente.Visible = !pnlSubMenuCliente.Visible;
            if (pnlSubMenuCliente.Visible)
            {
                panlPromocion.Location = new Point(panlPromocion.Location.X, pnlSubMenuCliente.Location.Y + pnlSubMenuCliente.Height);
                btnPromociones.Location = new Point(btnPromociones.Location.X, pnlSubMenuCliente.Location.Y + pnlSubMenuCliente.Height);
                pnlPagoDiario.Location = new Point(pnlPagoDiario.Location.X, btnPromociones.Location.Y + btnPromociones.Height + 10);
                btnPagoDiario.Location = new Point(btnMembresias.Location.X, btnPromociones.Location.Y + btnPromociones.Height + 10);
                // If the sub-menu is visible, move pnlMembresias down to make space for the sub-menu.
                pnlMembresias.Location = new Point(pnlMembresias.Location.X, btnPagoDiario.Location.Y + btnMembresias.Height +10);
                btnMembresias.Location = new Point(btnMembresias.Location.X, btnPagoDiario.Location.Y + btnPagoDiario.Height+10);
                pnlSubmenuMembresias.Location = new Point(pnlSubmenuMembresias.Location.X, btnMembresias.Location.Y + btnMembresias.Height);
                //pnlSubmenuMembresias.Location = new Point(pnlSubMenuCliente.Location.X, btnMembresias.Location.Y + btnMembresias.Height);


            }
            else
            {
                // If the sub-menu is not visible, move pnlMembresias back to its original position.
                //pnlMembresias.Location = new Point(pnlMembresias.Location.X, pnlSubMenuCliente.Location.Y);
                //btnMembresias.Location = new Point(btnMembresias.Location.X, pnlSubMenuCliente.Location.Y);
                //pnlSubmenuMembresias.Location = new Point(pnlSubMenuCliente.Location.X, btnMembresias.Location.Y + btnMembresias.Height);
                panlPromocion.Location = new Point(panlPromocion.Location.X, btnClientes.Location.Y + btnClientes.Height + 10);
                btnPromociones.Location = new Point(btnPromociones.Location.X, btnClientes.Location.Y + btnClientes.Height + 10);
                pnlPagoDiario.Location = new Point(pnlPagoDiario.Location.X, btnPromociones.Location.Y + btnPromociones.Height + 10);
                btnPagoDiario.Location = new Point(btnMembresias.Location.X, btnPromociones.Location.Y + btnPromociones.Height + 10);
                pnlMembresias.Location = new Point(pnlMembresias.Location.X, btnPagoDiario.Location.Y + btnMembresias.Height + 10);
                btnMembresias.Location = new Point(btnMembresias.Location.X, btnPagoDiario.Location.Y + btnPagoDiario.Height + 10);
                pnlSubmenuMembresias.Location = new Point(pnlSubmenuMembresias.Location.X, btnMembresias.Location.Y + btnMembresias.Height);
                //posicionbtnFrmIncio();

            }
            
        }

        private void posicionbtnFrmIncio()
        {
            if(pnlSubMenuCliente.Visible == false)
            {
                // If the sub-menu is not visible, move pnlMembresias back to its original position.
                   //pnlMembresias.Location = new Point(pnlMembresias.Location.X, pnlSubMenuCliente.Location.Y + 10);
                   //btnMembresias.Location = new Point(btnMembresias.Location.X, pnlSubMenuCliente.Location.Y + 10);
                   //pnlSubmenuMembresias.Location = new Point(pnlSubMenuCliente.Location.X, btnMembresias.Location.Y + btnMembresias.Height+10);
                   panlPromocion.Location = new Point(panlPromocion.Location.X, btnClientes.Location.Y + btnClientes.Height +10 );
                   btnPromociones.Location = new Point(btnPromociones.Location.X, btnClientes.Location.Y + btnClientes.Height + 10);
                   pnlPagoDiario.Location = new Point(pnlPagoDiario.Location.X, btnPromociones.Location.Y + btnPromociones.Height + 10);
                   btnPagoDiario.Location = new Point(btnPagoDiario.Location.X, btnPromociones.Location.Y + btnPromociones.Height + 10);
                   pnlMembresias.Location = new Point(pnlMembresias.Location.X, btnPagoDiario.Location.Y + btnMembresias.Height + 10);
                   btnMembresias.Location = new Point(btnMembresias.Location.X, btnPagoDiario.Location.Y + btnPagoDiario.Height + 10);
                   pnlSubmenuMembresias.Location = new Point(pnlSubmenuMembresias.Location.X, btnMembresias.Location.Y + btnMembresias.Height);
            }

            //if (pnlMembresias.Visible == false)
            //{
               // panlPromocion.Location = new Point(panlPromocion.Location.X, pnlSubmenuMembresias.Location.Y );
               // btnPromociones.Location = new Point(btnPromociones.Location.X, pnlSubmenuMembresias.Location.Y );
                
                //pnlSubmenuMembresias.Location = new Point(btnMembresias.Location.X, pnlSubMenuCliente.Location.Y + btnMembresias.Height);

                //pnlSubmenuMembresias.Location = new Point(pnlSubmenuMembresias.Location.X, pnlSubMenuCliente.Location.Y + btnMembresias.Height);
            //}
                         
        }

        private void controlPosicionClienteMembresia()
        {
            if(pnlSubMenuCliente.Visible == true && pnlMembresias.Visible == true)
            {
                panlPromocion.Location = new Point(panlPromocion.Location.X, pnlSubmenuMembresias.Location.Y);
                btnPromociones.Location = new Point(btnPromociones.Location.X, pnlSubmenuMembresias.Location.Y);
            }
            
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            pnlSubMenuCliente.Visible = false;
            AbrirFormHija(new FrmClientes());
            posicionbtnFrmIncio();
        }

        private void btnTipoCliente_Click(object sender, EventArgs e)
        {
            pnlSubMenuCliente.Visible = false;
            AbrirFormHija(new FrmTipoCliente());
            posicionbtnFrmIncio();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            pnlSubMenuCliente.Visible = false;
            AbrirFormHija(new FrmAsistencia());
            posicionbtnFrmIncio();
        }

        private void btnNuevaMembresia_Click(object sender, EventArgs e)
        {
            pnlSubmenuMembresias.Visible = false;
            AbrirFormHija(new FrmMembresias());
        }

        private void btnTiposMembresia_Click(object sender, EventArgs e)
        {
            pnlSubmenuMembresias.Visible = false;
            AbrirFormHija(new FrmTipoMembresia());
        }

        private void btnCostosMembresia_Click(object sender, EventArgs e)
        {
            pnlSubmenuMembresias.Visible = false;
            AbrirFormHija(new FrmCostoMembresias());
        }
    }
}
