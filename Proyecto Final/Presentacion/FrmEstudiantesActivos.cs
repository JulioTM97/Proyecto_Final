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
    public partial class FrmEstudiantesActivos : Form
    {
        DataTable dt = new DataTable();
        Seccion seccion = new Seccion();
        Estudiante estudiante = new Estudiante();
        string estado;
        int aux_id;
        public FrmEstudiantesActivos()
        {
            InitializeComponent();

            DataSet _dataSet = FGrado.GetAll();
            DataTable _dataTable = _dataSet.Tables[0];

            cbGrado.DataSource = _dataTable;
            cbGrado.DisplayMember = "NOMBRE";
            cbGrado.SelectedIndex = 0;
            txtPeriodo.Text = FAño.AñoActual().Tables[0].Rows[0].Field<string>("PERIODO").ToString();
            cambios("reinicio");
            
        }

        private void FrmEstudiantesActivos_Load(object sender, EventArgs e)
        {
            {
                //el programa intenta obtener la lista de todos los alumnos activos en este periodo.
                try
                {
                    DataSet ds = FEstudiantesActivos.GetAll(txtPeriodo.Text);
                    dt = ds.Tables[0];
                    dgvEstudiante.DataSource = dt;
                    dgvEstudiante.Columns["SECCION_ID"].Visible = false;
                    dgvEstudiante.Columns["ESTUDIANTE_AUX_ID"].Visible = false;
                    dgvEstudiante.Columns["ID"].Visible = false;


                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + exception.StackTrace);
                }
                dgvEstudiante_CellClick(null, null);
            }
        }

        private void cbGrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cambios(string opcion)
        {
            switch (opcion)
            {
                case "agregar":
                    btnAgregarEstudiante.Enabled = false;
                    btnModificarEstudiante.Enabled = false;
                    btnEliminarEstudiante.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnBuscarEstudiante.Enabled = true;
                    btnBuscarSeccion.Enabled = true;

                    btnFiltrar.Enabled = false;
                    btnLimpiarBusqueda.Enabled = false;
                    cbGrado.Enabled = false;
                    txtEstudianteB.Enabled = false;

                    txtNombre.Enabled = false;
                    txtGrado.Enabled = false;
                    txtSeccion.Enabled = false;
                    txtMatricula.Enabled = true;

                    txtNombre.Clear();
                    txtID.Clear();
                    txtGrado.Clear();
                    txtSeccion.Clear();
                    txtMatricula.Clear();

                    rbNuevoIngreso.Enabled = true;
                    rbReinscripcion.Enabled = true;

                    dgvEstudiante.Enabled = false;
                    estado = "agregando";
                    cambioRadioButton(null, null);
                    break;

                case "modificar":
                    btnAgregarEstudiante.Enabled = false;
                    btnModificarEstudiante.Enabled = false;
                    btnEliminarEstudiante.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnBuscarSeccion.Enabled = true;

                    btnFiltrar.Enabled = false;
                    btnLimpiarBusqueda.Enabled = false;
                    cbGrado.Enabled = false;
                    txtEstudianteB.Enabled = false;

                    txtNombre.Enabled = true;
                    txtGrado.Enabled = false;
                    txtSeccion.Enabled = false;
                    txtMatricula.Enabled = true;

                    dgvEstudiante.Enabled = false;
                    estado = "modificando";
                    break;
                case "reinicio":
                    rbNuevoIngreso.Checked = true;
                    rbNuevoIngreso.Enabled = false;
                    rbReinscripcion.Enabled = false;

                    btnAgregarEstudiante.Enabled = true;
                    btnModificarEstudiante.Enabled = true;
                    btnEliminarEstudiante.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnBuscarEstudiante.Enabled = false;
                    btnBuscarSeccion.Enabled = false;

                    btnFiltrar.Enabled = true;
                    btnLimpiarBusqueda.Enabled = true;
                    cbGrado.Enabled = true;
                    txtEstudianteB.Enabled = true;

                    txtNombre.Enabled = false;
                    txtGrado.Enabled = false;
                    txtSeccion.Enabled = false;
                    txtMatricula.Enabled = false;

                    estado = "";
                    dgvEstudiante.Enabled = true;
                    dgvEstudiante_CellClick(null,null);
                    break;
            }
        }

        private void dgvEstudiante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEstudiante.CurrentRow != null)
            {
                txtID.Text = dgvEstudiante.CurrentRow.Cells["ID"].Value.ToString();
                txtNombre.Text = dgvEstudiante.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtGrado.Text = dgvEstudiante.CurrentRow.Cells["GRADO"].Value.ToString();
                txtSeccion.Text = dgvEstudiante.CurrentRow.Cells["SECCION"].Value.ToString();
                txtMatricula.Text = dgvEstudiante.CurrentRow.Cells["MATRICULA"].Value.ToString();
                seccion.id = Convert.ToInt32(dgvEstudiante.CurrentRow.Cells["SECCION_ID"].Value);
                aux_id= Convert.ToInt32(dgvEstudiante.CurrentRow.Cells["ESTUDIANTE_AUX_ID"].Value);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtSeccion.Text == "" || txtMatricula.Text == "")
            {
                MessageBox.Show("Asegurece de completar los campos requeridos para continuar");
                return;
            }

            estudiante.matricula = Convert.ToInt32(txtMatricula.Text);

            for (int i = 0; i < dgvEstudiante.RowCount; i++)
            {
                if (Convert.ToInt32(dgvEstudiante.Rows[i].Cells["MATRICULA"].Value) == estudiante.matricula &&
                    seccion.id == Convert.ToInt32(dgvEstudiante.Rows[i].Cells["SECCION_ID"].Value) &&
                      Convert.ToInt32(dgvEstudiante.Rows[i].Cells["ID"].Value) != Convert.ToInt32(txtID.Text))
                {
                    MessageBox.Show("Ya existe un estudiante con esta matricula en esta sección."+
                        Environment.NewLine+"Por favor cambie la matricula.");
                    return;
                }
            }
            try
            {
                if (estado == "agregando" && rbNuevoIngreso.Checked)
                {
                    estudiante.nombre = txtNombre.Text;
                    int registrosCreados = FEstudiantesActivos.NuevoIngreso(estudiante,seccion,txtPeriodo.Text);
                    if (registrosCreados > 0) MessageBox.Show("Estudiante registrado con exito!");
                    else MessageBox.Show("El estudiante no se pudo registrar");
                }
                else if (estado == "agregando" && rbReinscripcion.Checked)
                {
                    int registrosCreados = FEstudiantesActivos.Reinscripcion(estudiante, seccion, txtPeriodo.Text);
                    if (registrosCreados > 0) MessageBox.Show("Estudiante registrado con exito!");
                    else MessageBox.Show("El estudiante no se pudo registrar");
                }
                else if (estado == "modificando")
                {
                    estudiante.id = Convert.ToInt32(txtID.Text);
                    estudiante.nombre = txtNombre.Text;
                    //MessageBox.Show(seccion.id.ToString());
                    int registrosModificados = FEstudiantesActivos.Modificar(estudiante, seccion, txtPeriodo.Text);
                    if (registrosModificados > 0) MessageBox.Show("Estudiante modificado con exito!");
                    else MessageBox.Show("El estudiante no se pudo modificar");
                }
                cambios("reinicio");
                FrmEstudiantesActivos_Load(null, null);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cambios("reinicio");
        }

        private void btnAgregarEstudiante_Click(object sender, EventArgs e)
        {
            cambios("agregar");
        }
        private void cambioRadioButton(object sender, EventArgs e)
        {
            if (estado != "agregando") return;
            if (rbNuevoIngreso.Checked)
            {
                btnBuscarEstudiante.Enabled = false;
                txtNombre.Enabled = true;
                txtNombre.Clear();
                txtID.Clear();
            }
            else if (rbReinscripcion.Checked)
            {
                btnBuscarEstudiante.Enabled = true;
                txtNombre.Enabled = false;
                txtNombre.Clear();
                txtID.Clear();
            }
        }

        private void btnBuscarSeccion_Click(object sender, EventArgs e)
        {
            FrmSeleccionarSeccion frmSeleccionarSeccion = new FrmSeleccionarSeccion(this);
            frmSeleccionarSeccion.Show();
        }

        internal void ObtenerSeccion(Seccion _seccion) {
            txtGrado.Text = _seccion.grado;
            txtSeccion.Text = _seccion.nombre;
            seccion = _seccion;
        }

        internal void ObtenerEstudiante(Estudiante _estudiante)
        {
            for (int i=0; i<dgvEstudiante.RowCount; i++)
            {
                if (dgvEstudiante.Rows[i].Cells["NOMBRE"].Value.ToString() == _estudiante.nombre)
                {
                    MessageBox.Show("Este estudiante ya está registrado en el periodo actual");
                    return;
                }
            }
            txtNombre.Text = _estudiante.nombre;
            txtID.Text = _estudiante.id.ToString();
            estudiante = _estudiante;
        }

        private void btnBuscarEstudiante_Click(object sender, EventArgs e)
        {
            FrmEstudiante frmEstudiante = new FrmEstudiante(this);
            frmEstudiante.Show();
        }

        private void btnEliminarEstudiante_Click(object sender, EventArgs e)
        {
            {
                if (dgvEstudiante.CurrentRow == null) return;
                estudiante.id = Convert.ToInt32(txtID.Text);
                
                DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar al estudiante?"+Environment.NewLine+"Esto eliminará todas las calificaciones de este estudiante.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.No) return;
                try
                {
                    if (FEstudiantesActivos.Eliminar(estudiante,txtPeriodo.Text, aux_id) > 0) MessageBox.Show("Eliminado con exito!");
                    else MessageBox.Show("El estudiante no se pudo eliminar.");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + exception.StackTrace);
                }
                FrmEstudiantesActivos_Load(null, null);
            }
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void btnModificarEstudiante_Click(object sender, EventArgs e)
        {
            cambios("modificar");
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
