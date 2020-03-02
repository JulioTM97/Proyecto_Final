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
    public partial class FrmAsignatura : Form
    {
        DataTable asignaturas, docentes;
        bool asignaturaNueva;
        string estado;
        public FrmAsignatura()
        {
            InitializeComponent();
        }

        private void FrmAsignatura_Load(object sender, EventArgs e)
        {
            try
            {
                asignaturas = FAsignatura.CargarNombresAsignaturas().Tables[0];
                docentes = FAsignatura.CargarDocentes().Tables[0];
                CargarComboBoxes();

                DataSet dataSet = FAsignatura.GetAll();
                dgvAsignatura.DataSource = dataSet.Tables[0];
                Cambios("reinicio");
                dgvAsignatura_CellClick(null, null);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void CargarComboBoxes()
        {
            txtNombreExistente.DataSource = asignaturas;
            txtNombreExistente.DisplayMember = "NOMBRE";
            txtDocente.DataSource = docentes;
            txtDocente.DisplayMember = "NOMBRE";
        }

        private void dgvAsignatura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAsignatura.CurrentRow != null)
            {
                txtID.Text = dgvAsignatura.CurrentRow.Cells["ID"].Value.ToString();
                txtDocente.Text = dgvAsignatura.CurrentRow.Cells["DOCENTE"].Value.ToString();
                txtNombreExistente.Text = dgvAsignatura.CurrentRow.Cells["ASIGNATURA"].Value.ToString();
            }
        }

        private void rbNuevaAsignatura_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNuevaAsignatura.Checked) { 
                asignaturaNueva = true;
                txtNombreNuevo.Visible = true;
                txtNombreNuevo.Enabled = true;
                txtNombreExistente.Visible = false;
                txtNombreExistente.Enabled = false;
            }
            else 
            {
                asignaturaNueva = false;
                txtNombreNuevo.Visible = false;
                txtNombreNuevo.Enabled = false;
                txtNombreExistente.Visible = true;
                txtNombreExistente.Enabled = true;
            }
        }

        private void btnAgregarAsignatura_Click(object sender, EventArgs e)
        {
            Cambios("agregar");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cambios("reinicio");
        }

        private void btnModificarAsignatura_Click(object sender, EventArgs e)
        {
            if (dgvAsignatura.CurrentRow == null) return;
            Cambios("modificar");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Si hay algun campo vacio o las contraseñas no coinciden el procedimiento se cancela
            if (asignaturaNueva && txtNombreNuevo.Text=="")
            {
                MessageBox.Show("Elija el nombre de la asignatura");
                return;
            }

            Asignatura asignatura = new Asignatura();

            //cuando se está agregando una nueva seccion el ID se borra
            //cuando se está modificando una seccion el ID se mantiene
            //la siguiente condicion es para evitar un error tratando de convertir un valor nulo a entero.
            if (txtID.Text != "") asignatura.id = Convert.ToInt32(txtID.Text);
            else asignatura.id = 0;
            if (asignaturaNueva) asignatura.nombre = txtNombreNuevo.Text;
            else asignatura.nombre = txtNombreExistente.Text;
            asignatura.docente = txtDocente.Text;
            try
            {
                if (estado == "agregando" && asignaturaNueva)
                {
                    if (FAsignatura.InsertarNueva(asignatura) > 0) MessageBox.Show("Asignatura registrada con exito!");
                    else MessageBox.Show("La asignatura no se pudo registrar");
                }
                else if (estado == "agregando" && !asignaturaNueva)
                {
                    if (FAsignatura.InsertarExistente(asignatura) > 0) MessageBox.Show("Asignatura registrada con exito!");
                    else MessageBox.Show("La asignatura no se pudo registrar");
                }
                else if (estado == "modificando")
                {
                    if (FAsignatura.Actualizar(asignatura) > 0) MessageBox.Show("Modificada con exito!");
                    else MessageBox.Show("La asignatura no se pudo modificar");
                }
                Cambios("reinicio");
                FrmAsignatura_Load(null, null);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void btnEliminarAsignatura_Click(object sender, EventArgs e)
        {
            if (dgvAsignatura.CurrentRow == null) return;
            Asignatura asignatura = new Asignatura();
            asignatura.id = Convert.ToInt32(txtID.Text);

            DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar la asignatura?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.No) return;
            try
            {
                if (FAsignatura.Eliminar(asignatura) > 0) MessageBox.Show("Eliminada con exito!");
                else MessageBox.Show("La asignatura no se pudo eliminar.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            FrmAsignatura_Load(null, null);
        }

        private void Cambios(string opcion)
        {
            switch (opcion)
            {
                //cuando presiono agregar seccion se realiza la siguiente configuracion en la ventana
                case "agregar":
                    btnAgregarAsignatura.Enabled = false;
                    btnModificarAsignatura.Enabled = false;
                    btnEliminarAsignatura.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    txtDocente.Enabled = true;

                    txtID.Clear();

                    rbNuevaAsignatura.Checked = true;
                    rbNuevaAsignatura_CheckedChanged(null,null);

                    rbNuevaAsignatura.Enabled = true;
                    rbAsignaturaExistente.Enabled = true;

                    dgvAsignatura.Enabled = false;

                    estado = "agregando";
                    CargarComboBoxes();
                    break;

                //cuando presiono modificar seccion se realiza la siguiente configuracion en la ventana
                case "modificar":
                    btnAgregarAsignatura.Enabled = false;
                    btnModificarAsignatura.Enabled = false;
                    btnEliminarAsignatura.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    txtDocente.Enabled = true;

                    dgvAsignatura.Enabled = false;

                    estado = "modificando";
                    break;

                //cuando presiono cancelar se realiza la siguiente configuracion en la ventana
                case "reinicio":
                    btnAgregarAsignatura.Enabled = true;
                    btnModificarAsignatura.Enabled = true;
                    btnEliminarAsignatura.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;

                    rbAsignaturaExistente.Checked = true;
                    rbNuevaAsignatura_CheckedChanged(null, null);

                    txtNombreNuevo.Clear();

                    txtID.Enabled = false;
                    txtDocente.Enabled = false;
                    txtNombreExistente.Enabled = false;
                    txtNombreNuevo.Enabled = false;

                    rbNuevaAsignatura.Enabled = false;
                    rbAsignaturaExistente.Enabled = false;

                    dgvAsignatura.Enabled = true;
                    dgvAsignatura_CellClick(null, null);
                    estado = "";
                    break;
            }
        }
    }
}
