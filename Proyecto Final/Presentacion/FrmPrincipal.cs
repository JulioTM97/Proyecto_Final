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
using System.Runtime.InteropServices;


namespace Proyecto_Final.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        FrmLogin frmLogin;
        Usuario usuario;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public FrmPrincipal(FrmLogin _frmLogin, Usuario _usuario)
        {
            InitializeComponent();
            frmLogin = _frmLogin;
            usuario = _usuario;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 250;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        } 
        
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        // Para mostrar los datos del Usuario           
        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {
             /* txtNombre.Text = usuario.nombre;
              txtCedula.Text = usuario.cedula;
              txtTelefono.Text = usuario.telefono;
              txtCorreo.Text = usuario.correo;
              txtTipo.Text = usuario.rol;
              txtUsername.Text = usuario.username;  */    
        }

        private void Mostrar_Formulario_Inicio_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmInicio());
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Mostrar_Formulario_Inicio_Click(null, e);
        }

        private void btncp_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmUsuario());
        }

        private void btncg_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmGrado());
        }

        private void btncs_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmSeccion());
        }

        private void btncd_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmInstitucion());
        }

        private void btnca_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmAsignatura());
        }

        private void lblogo_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmInicio());
        }

        private void MenuVertical_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
