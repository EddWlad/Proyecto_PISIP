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
using UI.Windows.VistaModelos;

namespace UI.Windows.Formularios
{
    public partial class FrmAsistencia : Form
    {
        RegistroAsistenciaVistaModelo registroAsistenciaVistaModelo = new RegistroAsistenciaVistaModelo();
        RegistroAsistenciaControlador registroAsistenciaControlador;
        public FrmAsistencia()
        {
            InitializeComponent();
            registroAsistenciaControlador = new RegistroAsistenciaControlador();
        }

        public void InsertarAsistencia()
        {
            if (registroAsistenciaControlador.InsertarAsistencia(registroAsistenciaVistaModelo))
            {
                MessageBox.Show("Asistencia registrada correctamente");
            }
            else
            {
                MessageBox.Show("Error: Al registrar asistencia");
            }
        }

        private void FrmAsistencia_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            registroAsistenciaVistaModelo.Fecha = DateTime.Now;
            registroAsistenciaVistaModelo.Estado = true;
            InsertarAsistencia();
        }
    }
}
