using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.Datos;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Presentacion
{
    public partial class FrmUsuario : Form
    {
        //"estado" me indica si estoy agregando o modificando un usuario para cuando pulse aceptar.
        string estado;

        //"contraseñaOriginal" es la variable que me ayuda a verificar si la contraseña se ha modificado al
        //modificar un usuario.
        string contraseñaOriginal;
        private static DataTable dt = new DataTable();
        public FrmUsuario()
        {
            InitializeComponent();

            #region rellena los comboBox con los roles

            DataSet _dataSet = FUsuario.CargarRoles();
            DataTable _dataTable = _dataSet.Tables[0];

            txtTipo.DataSource = _dataTable;
            txtTipo.DisplayMember = "NOMBRE";
            txtTipo.SelectedIndex = 0;

            txtMostrar.DataSource = _dataTable;
            txtMostrar.DisplayMember = "NOMBRE";
            txtMostrar.SelectedIndex = 0;

            #endregion

            //Le indico como quiero que aparezcan los elementos en la ventana.
            cambios("reinicio");
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            //el programa intenta obtener la lista de todos los usuarios.
            try
            {
                DataSet ds = FUsuario.GetAll();
                dt = ds.Tables[0];
                dgvUsuario.DataSource = dt;

                dgvUsuario.Columns["ID"].Visible = false;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            dgvUsuario_CellClick(null, null);
        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si selecciono una fila del datagridview se llenan los campos te texto de la ventana
            if (dgvUsuario.CurrentRow != null)
            {
                txtID.Text = dgvUsuario.CurrentRow.Cells["ID"].Value.ToString();
                txtNombre.Text = dgvUsuario.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtCedula.Text = dgvUsuario.CurrentRow.Cells["CEDULA"].Value.ToString();
                txtTelefono.Text = dgvUsuario.CurrentRow.Cells["TELEFONO"].Value.ToString();
                txtCorreo.Text = dgvUsuario.CurrentRow.Cells["CORREO"].Value.ToString();
                txtUsuario.Text = dgvUsuario.CurrentRow.Cells["USERNAME"].Value.ToString();
                txtContraseña.Text = dgvUsuario.CurrentRow.Cells["PASSWORD"].Value.ToString();
                txtConfirmarContraseña.Text = dgvUsuario.CurrentRow.Cells["PASSWORD"].Value.ToString();
                txtTipo.Text = dgvUsuario.CurrentRow.Cells["ROL"].Value.ToString();

                

            }
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            //se configura la ventana para poder agregar un usuario
            cambios("agregar");
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            //Si no se ha seleccionado ningun usuario o no hay ninguno que seleccionar
            //El procedimiento se cancela.
            if (dgvUsuario.CurrentRow == null) return;
            //se configura la ventana para poder modificar un usuario
            contraseñaOriginal = txtContraseña.Text;
            cambios("modificar");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //se configura la ventana para volver a su estado original
            cambios("reinicio");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Si hay algun campo vacio o las contraseñas no coinciden el procedimiento se cancela
            if (!comprobarCampos())
            return;

            Usuario usuario = new Usuario();

            //cuando se está agregando un nuevo usuario el ID se borra
            //cuando se está modificando a un usuario el ID se mantiene
            //la siguiente condicion es para evitar un error tratando de convertir un valor nulo a entero.
            if (txtID.Text != "") usuario.id = Convert.ToInt32(txtID.Text);
            else usuario.id = 0;
            usuario.nombre = txtNombre.Text;
            usuario.cedula = txtCedula.Text;
            usuario.telefono = txtTelefono.Text;
            usuario.correo = txtCorreo.Text;
            usuario.username = txtUsuario.Text;
            //usuario.password = Encriptar.GetSHA256(txtContraseña.Text);
            usuario.rol = txtTipo.Text;
            try
            {
                if (estado == "agregando")
                {
                    usuario.password = Encriptar.GetSHA256(txtContraseña.Text);
                    int usuarioID = FUsuario.Insertar(usuario);
                    if (usuarioID > 0) MessageBox.Show("Usuario registrado con exito!");
                    else MessageBox.Show("El usuario no se pudo registrar");
                }
                else if (estado == "modificando")
                {
                    if (contraseñaOriginal == txtContraseña.Text) usuario.password = txtContraseña.Text;
                    else usuario.password = Encriptar.GetSHA256(txtContraseña.Text);
                    if (FUsuario.Actualizar(usuario) > 0) MessageBox.Show("Modificado con exito!");
                    else MessageBox.Show("El producto no se pudo modificar");
                }
                cambios("reinicio");
                FrmUsuario_Load(null, null);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        //este metodo configura los elementos de la ventana dependiendo de los botones que se pulsen
        private void cambios (string opcion)
        {
            switch (opcion)
            {
                //cuando presiono agregar usuario se realiza la siguiente configuracion en la ventana
                case "agregar":
                    btnAgregarUsuario.Enabled = false;
                    btnModificarUsuario.Enabled = false;
                    btnEliminarUsuario.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    txtNombre.Enabled = true;
                    txtCedula.Enabled = true;
                    txtTelefono.Enabled = true;
                    txtCorreo.Enabled = true;
                    txtUsuario.Enabled = true;
                    txtContraseña.Enabled = true;
                    txtConfirmarContraseña.Enabled = true;
                    txtTipo.Enabled = true;

                    txtID.Clear();
                    txtNombre.Clear();
                    txtCedula.Clear();
                    txtTelefono.Clear();
                    txtCorreo.Clear();
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                    txtConfirmarContraseña.Clear();

                    dgvUsuario.Enabled = false;

                    estado = "agregando";
                    break;

                //cuando presiono modificar usuario se realiza la siguiente configuracion en la ventana
                case "modificar":
                    btnAgregarUsuario.Enabled = false;
                    btnModificarUsuario.Enabled = false;
                    btnEliminarUsuario.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    txtNombre.Enabled = true;
                    txtCedula.Enabled = true;
                    txtTelefono.Enabled = true;
                    txtCorreo.Enabled = true;
                    txtUsuario.Enabled = true;
                    txtContraseña.Enabled = true;
                    txtConfirmarContraseña.Enabled = true;
                    txtTipo.Enabled = true;

                    dgvUsuario.Enabled = false;

                    estado = "modificando";
                    break;

                //cuando presiono cancelar se realiza la siguiente configuracion en la ventana
                case "reinicio":
                    btnAgregarUsuario.Enabled = true;
                    btnModificarUsuario.Enabled = true;
                    btnEliminarUsuario.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;

                    txtNombre.Enabled = false;
                    txtCedula.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtCorreo.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtContraseña.Enabled = false;
                    txtConfirmarContraseña.Enabled = false;
                    txtTipo.Enabled = false;

                    dgvUsuario.Enabled = true;
                    dgvUsuario_CellClick(null, null);
                    estado = "";
                    break;
            }
        }

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.CurrentRow == null) return; 
            Usuario usuario = new Usuario();
            usuario.id = Convert.ToInt32(txtID.Text);
            DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar el usuario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.No) return;
            try
            {
                if (FUsuario.Eliminar(usuario) > 0) MessageBox.Show("Eliminado con exito!");
                else MessageBox.Show("El usuario no se pudo eliminar.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            FrmUsuario_Load(null, null);
        }

        private bool comprobarCampos()
        {
            string aux ="";
            if (txtNombre.Text == "" || txtCedula.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtUsuario.Text == "" || txtContraseña.Text == "")
            {

                if (txtNombre.Text == "") aux += "Nombre" + Environment.NewLine;
                if (txtCedula.Text == "") aux += "Cédula" + Environment.NewLine;
                if (txtTelefono.Text == "") aux += "Teléfono" + Environment.NewLine;
                if (txtCorreo.Text == "") aux += "Correo" + Environment.NewLine;
                if (txtUsuario.Text == "") aux += "Usuario" + Environment.NewLine;
                if (txtContraseña.Text == "") aux += "Contraseña" + Environment.NewLine;
                MessageBox.Show("Debe completar los siguientes campos:" + Environment.NewLine + aux);
                return false;
            }
            else if (!(txtContraseña.Text == txtConfirmarContraseña.Text))
            {
                MessageBox.Show("Las contraseñas no coinciden, por favor reviselas");
                return false;
            }
            else return true;
            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvUsuario.Rows.Count; i++)
                {
                    if (dgvUsuario.Rows[i].Cells["ROL"].Value.ToString() != txtMostrar.Text)
                    {
                        dgvUsuario.CurrentCell = null;
                        dgvUsuario.Rows[i].Visible = false;
                    }
                    else dgvUsuario.Rows[i].Visible = true;
                }
                dgvUsuario.CurrentCell = dgvUsuario.FirstDisplayedCell;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            dgvUsuario_CellClick(null, null);
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvUsuario.Rows.Count; i++) dgvUsuario.Rows[i].Visible = true;
            dgvUsuario.CurrentCell = dgvUsuario.FirstDisplayedCell;
            dgvUsuario_CellClick(null, null);
        }

        private void btnEnabledChangeEvent(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            if (button.Enabled) button.BackColor = Color.FromArgb(0, 122, 204);
            else button.BackColor = Color.Gray;
        }
    }
}
