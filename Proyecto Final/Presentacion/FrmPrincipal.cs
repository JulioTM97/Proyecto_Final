using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.Entidades;
using Proyecto_Final.Datos;
using Proyecto_Final.Presentacion;

namespace Proyecto_Final.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        FrmLogin frmLogin;
        Usuario usuario;
        public FrmPrincipal() {
            InitializeComponent();
        }
        public FrmPrincipal(FrmLogin _frmLogin, Usuario _usuario)
        {
            InitializeComponent();
            frmLogin = _frmLogin;
            usuario = _usuario;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            MessageBox.Show(
                usuario.id + Environment.NewLine +
                usuario.cedula + Environment.NewLine + 
                usuario.correo + Environment.NewLine +
                usuario.nombre + Environment.NewLine +
                usuario.password + Environment.NewLine +
                usuario.username + Environment.NewLine +
                usuario.rol + Environment.NewLine +
                usuario.telefono + Environment.NewLine 
                ) ;
            txtNombre.Text = usuario.nombre;
            txtCedula.Text = usuario.cedula;
            txtTelefono.Text = usuario.telefono;
            txtCorreo.Text = usuario.correo;
            txtTipo.Text = usuario.rol;
            txtUsername.Text = usuario.username;
        }

        private void personalDelCentroEducativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.Show();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Close();
        }

        private void gradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrado frmGrado = new FrmGrado();
            frmGrado.Show();
        }

        private void consultarSeccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeccion frmSeccion = new FrmSeccion();
            frmSeccion.Show();
        }

        private void consultarDatosDeInstitucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstitucion frmInstitucion = new FrmInstitucion();
            frmInstitucion.Show();
        }

        private void consultarAsignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAsignatura frmAsignatura = new FrmAsignatura();
            frmAsignatura.Show();
        }
    }
}
