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

namespace UI.Windows.Formularios
{
    public partial class FrmLogin : Form
    {
        UsuarioControlador usuarioControlador;
        public FrmLogin()
        {
            InitializeComponent();
            usuarioControlador = new UsuarioControlador();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = (List<Usuario>)usuarioControlador.ListarUsuariosActivos();

            Usuario validacion = usuarioControlador.ListarUsuariosActivos().Where(u => u.nombre_usuario == txtDocumento.Text && u.contraseña == txtClave.Text).FirstOrDefault();

            if(validacion != null)
            {
                FrmInicio form = new FrmInicio(validacion);
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se encontro el usuario","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
          
        }
        private void frm_closing(object sender,FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";
            this.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
