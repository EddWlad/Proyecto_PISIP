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

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FrmClientes());
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
            pictureBox1_Click_1(null, e);
            lblUsuario.Text = usuarioActual.nombre_usuario;
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FrmMembresias());
        }
    }
}
