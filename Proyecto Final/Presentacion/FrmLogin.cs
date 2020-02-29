using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.Presentacion;
using Proyecto_Final.Entidades;
using Proyecto_Final.Datos;

namespace Proyecto_Final
{
    public partial class FrmLogin : Form
    {
        Usuario usuario;
        public FrmLogin()
        {
            InitializeComponent();
            usuario = new Usuario();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            usuario.username = txtUsuario.Text;
            usuario.password = txtContraseña.Text;

            DataSet ds = FLogin.ValidarLogin(usuario);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dt.Rows[0]["ELIMINADO"]))
                {
                    MessageBox.Show("Este usuario ha sido eliminado contacte con un administrador");
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                    return;

                }
                usuario.id = Convert.ToInt32(dt.Rows[0]["ID"]);
                usuario.nombre = dt.Rows[0]["NOMBRE"].ToString();
                usuario.cedula = dt.Rows[0]["CEDULA"].ToString();
                usuario.telefono = dt.Rows[0]["TELEFONO"].ToString();
                usuario.correo = dt.Rows[0]["CORREO"].ToString();
                usuario.rol = dt.Rows[0]["ROL"].ToString();
                usuario.eliminado = Convert.ToBoolean(dt.Rows[0]["ELIMINADO"]);
                FrmPrincipal principal = new FrmPrincipal(this, usuario);
                principal.Show();
                this.Enabled = false;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos");
                txtUsuario.Clear();
                txtContraseña.Clear();
            }

        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnEntrar_Click(null,null);
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }
    }
}
