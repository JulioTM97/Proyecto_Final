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
    public partial class FrmSeccion : Form
    {
        DataTable dt = new DataTable();
        DataTable grados, docentes;
        private string estado;
        public FrmSeccion()
        {
            InitializeComponent();
            cambios("reinicio");

            DataSet _dataSet = FSeccion.CargarGrados();
            grados = _dataSet.Tables[0];

            CargarComboBoxGrados();
        }

        private void CargarComboBoxGrados()
        {
            txtGrado.DataSource = grados;
            txtGrado.DisplayMember = "NOMBRE";
            DataRow[] row = grados.Select();
            txtGrado.Text = row[0].Field<string>("NOMBRE");
        }

        private void dgvSeccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSeccion.CurrentRow != null)
            {
                txtID.Text = dgvSeccion.CurrentRow.Cells["ID"].Value.ToString();
                txtGrado.Text = dgvSeccion.CurrentRow.Cells["GRADO"].Value.ToString();
                txtSeccion.Text = dgvSeccion.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtDocente.Text = dgvSeccion.CurrentRow.Cells["DOCENTE"].Value.ToString();
            }
        }
        private void cambios(string opcion)
        {
            switch (opcion)
            {
                //cuando presiono agregar seccion se realiza la siguiente configuracion en la ventana
                case "agregar":
                    btnAgregarSeccion.Enabled = false;
                    btnModificarSeccion.Enabled = false;
                    btnEliminarSeccion.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    txtDocente.Enabled = true;
                    txtSeccion.Enabled = true;

                    txtGrado.Enabled = true;
                    txtSeccion.Enabled = true;

                    txtID.Clear();
                    txtSeccion.Clear();

                    dgvSeccion.Enabled = false;

                    estado = "agregando";
                    CargarComboBoxGrados();
                    CargarComboBoxDocentes();
                    break;

                //cuando presiono modificar seccion se realiza la siguiente configuracion en la ventana
                case "modificar":
                    btnAgregarSeccion.Enabled = false;
                    btnModificarSeccion.Enabled = false;
                    btnEliminarSeccion.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    txtDocente.Enabled = true;

                    txtGrado.Enabled = true;
                    txtSeccion.Enabled = true;

                    dgvSeccion.Enabled = false;

                    estado = "modificando";
                    CargarComboBoxDocentes();
                    break;

                //cuando presiono cancelar se realiza la siguiente configuracion en la ventana
                case "reinicio":
                    btnAgregarSeccion.Enabled = true;
                    btnModificarSeccion.Enabled = true;
                    btnEliminarSeccion.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;

                    txtID.Enabled = false;
                    txtGrado.Enabled = false;
                    txtSeccion.Enabled = false;

                    txtDocente.Enabled = false;

                    dgvSeccion.Enabled = true;
                    dgvSeccion_CellClick(null, null);
                    estado = "";
                    break;
            }
        }

        private void btnAgregarSeccion_Click(object sender, EventArgs e)
        {
            cambios("agregar");
        }

        private void btnModificarSeccion_Click(object sender, EventArgs e)
        {
            cambios("modificar");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cambios("reinicio");
        }

        private void btnEliminarSeccion_Click(object sender, EventArgs e)
        {
            if (dgvSeccion.CurrentRow == null) return;
            Seccion seccion = new Seccion();
            seccion.id = Convert.ToInt32(txtID.Text);
            DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar la sección?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.No) return;
            try
            {
                if (FSeccion.Eliminar(seccion) > 0) MessageBox.Show("Eliminado con exito!");
                else MessageBox.Show("La sección no se pudo eliminar.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            FrmSeccion_Load(null, null);
        }

        private void FrmSeccion_Load(object sender, EventArgs e)
        {
            //el programa intenta obtener la lista de todos las secciones.
            try
            {
                DataSet ds = FSeccion.GetAll();
                docentes = FAsignatura.CargarDocentes().Tables[0];
                CargarComboBoxDocentes();
                dt = ds.Tables[0];
                dgvSeccion.DataSource = dt;
                dgvSeccion.Columns["ID"].Visible = false;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            dgvSeccion_CellClick(null, null);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Si hay algun campo vacio o las contraseñas no coinciden el procedimiento se cancela
            if (txtSeccion.Text == "")
            {
                MessageBox.Show("Elija el nombre de la sección");
                return;
            }
            else if (txtGrado.Text == "")
            {
                MessageBox.Show("Debe agregar un grado primero");
                return;
            }
            else if (txtDocente.Text == "")
            {
                MessageBox.Show("Seleccione un maestro encargado");
                return;
            }

                Seccion seccion = new Seccion();

            //cuando se está agregando una nueva seccion el ID se borra
            //cuando se está modificando una seccion el ID se mantiene
            //la siguiente condicion es para evitar un error tratando de convertir un valor nulo a entero.
            if (txtID.Text != "") seccion.id = Convert.ToInt32(txtID.Text);
            else seccion.id = 0;
            seccion.grado = txtGrado.Text;
            seccion.nombre = txtSeccion.Text;
            seccion.docente = txtDocente.Text;
            try
            {
                if (estado == "agregando")
                {
                    int seccionID = FSeccion.Insertar(seccion);
                    if (seccionID > 0) MessageBox.Show("Sección registrada con exito!");
                    else MessageBox.Show("La sección no se pudo registrar");
                }
                else if (estado == "modificando")
                {
                    if (FSeccion.Actualizar(seccion) > 0) MessageBox.Show("Modificada con exito!");
                    else MessageBox.Show("La sección no se pudo modificar");
                }
                cambios("reinicio");
                FrmSeccion_Load(null, null);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void txtGrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnEnabledChangeEvent(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            if (button.Enabled) button.BackColor = Color.FromArgb(0, 122, 204);
            else button.BackColor = Color.Gray;
        }

        private void CargarComboBoxDocentes()
        {
            txtDocente.DataSource = docentes;
            txtDocente.DisplayMember = "NOMBRE";
        }
    }
}
