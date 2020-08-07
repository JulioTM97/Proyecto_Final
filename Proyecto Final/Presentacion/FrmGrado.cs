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

namespace Proyecto_Final.Presentacion
{
    public partial class FrmGrado : Form
    {
        private string estado;
        private DataTable dt = new DataTable();
        public FrmGrado()
        {
            InitializeComponent();
            cambios("reinicio");
        }

        private void FrmGrado_Load(object sender, EventArgs e)
        {
            //el programa intenta obtener la lista de todos los grados.
            try
            {
                DataSet ds = FGrado.GetAll();
                dt = ds.Tables[0];
                dgvGrado.DataSource = dt;
                dgvGrado.Columns["ID"].Visible = false;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            dgvGrado_CellClick(null, null);
        }

        private void btnAgregarGrado_Click(object sender, EventArgs e)
        {
            cambios("agregar");
        }
        private void btnModificarGrado_Click(object sender, EventArgs e)
        {
            if (dgvGrado.CurrentRow == null) return;
            cambios("modificar");
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cambios("reinicio");
        }

        private void btnEliminarGrado_Click(object sender, EventArgs e)
        {
            if (dgvGrado.CurrentRow == null) return;
            Grado grado = new Grado();
            grado.id = Convert.ToInt32(txtID.Text);
            DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar el grado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.No) return;
            try
            {
                if (FGrado.Eliminar(grado) > 0) MessageBox.Show("Eliminado con exito!");
                else MessageBox.Show("El grado no se pudo eliminar.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            FrmGrado_Load(null, null);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Si el campo de texto esta vacio se cancela el procedimiento
            if (txtGrado.Text == "")
            {
                MessageBox.Show("Escriba el nombre del grado.");
                return;
            }
                

            Grado grado = new Grado();

            //cuando se está agregando un nuevo grado el ID se borra
            //cuando se está modificando a un grado el ID se mantiene
            //la siguiente condicion es para evitar un error tratando de convertir un valor nulo a entero.
            if (txtID.Text != "") grado.id = Convert.ToInt32(txtID.Text);
            else grado.id = 0;
            grado.nombre = txtGrado.Text;
            try
            {
                if (estado == "agregando")
                {
                    int GradoID = FGrado.Insertar(grado);
                    if (GradoID > 0) MessageBox.Show("Grado registrado con exito!");
                    else MessageBox.Show("El Grado no se pudo registrar");
                }
                else if (estado == "modificando")
                {
                    if (FGrado.Actualizar(grado) > 0) MessageBox.Show("Modificado con exito!");
                    else MessageBox.Show("El Grado no se pudo modificar");
                }
                cambios("reinicio");
                FrmGrado_Load(null, null);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void cambios(string opcion)
        {
            switch (opcion)
            {
                //cuando presiono agregar grado se realiza la siguiente configuracion en la ventana
                case "agregar":
                    btnAgregarGrado.Enabled = false;
                    btnModificarGrado.Enabled = false;
                    btnEliminarGrado.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    txtGrado.Enabled = true;

                    txtID.Clear();
                    txtGrado.Clear();

                    dgvGrado.Enabled = false;

                    estado = "agregando";
                    break;

                //cuando presiono modificar grado se realiza la siguiente configuracion en la ventana
                case "modificar":
                    btnAgregarGrado.Enabled = false;
                    btnModificarGrado.Enabled = false;
                    btnEliminarGrado.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    txtGrado.Enabled = true;

                    dgvGrado.Enabled = false;

                    estado = "modificando";
                    break;

                //cuando presiono cancelar se realiza la siguiente configuracion en la ventana
                case "reinicio":
                    btnAgregarGrado.Enabled = true;
                    btnModificarGrado.Enabled = true;
                    btnEliminarGrado.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;

                    txtID.Enabled = false;
                    txtGrado.Enabled = false;

                    dgvGrado.Enabled = true;
                    dgvGrado_CellClick(null, null);
                    estado = "";
                    break;
            }
        }

        private void dgvGrado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrado.CurrentRow != null)
            {
                txtID.Text = dgvGrado.CurrentRow.Cells["ID"].Value.ToString();
                txtGrado.Text = dgvGrado.CurrentRow.Cells["NOMBRE"].Value.ToString();
            }
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
