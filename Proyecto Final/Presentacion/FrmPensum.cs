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
    public partial class FrmPensum : Form
    {
        Seccion seccion;
        Asignatura asignatura;
        DataTable dt;
        public FrmPensum()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmSeleccionarSeccion frmSeleccionarSeccion = new FrmSeleccionarSeccion(this);
            frmSeleccionarSeccion.Show();
        }

        internal void ObtenerSeccion (Seccion _seccion)
        {
            seccion = _seccion;
            txtGrado.Text = seccion.grado;
            txtSeccion.Text = seccion.nombre;
            CargarDataGridView();
        }

        internal void ObtenerAsignatura (Asignatura _asignatura)
        {
            for (int i = 0; i<dgvPensum.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvPensum.Rows[i].Cells["ASIGNATURA_AUX_ID"].Value) == _asignatura.id)
                {
                    MessageBox.Show("Esta asignatura ya está en este pensum");
                    return;
                }
            }

            asignatura = _asignatura;

            try
            {
                if (FPensum.AgregarAsignatura(seccion,asignatura) > 0) MessageBox.Show("Asignatura agregada con exito!");
                else MessageBox.Show("La asignatura no se pudo agregar.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            CargarDataGridView();
            //MessageBox.Show(asignatura.id.ToString());
        }

        private void CargarDataGridView()
        {
            {
                //el programa intenta obtener la lista de todos las secciones.
                try
                {
                    DataSet ds = FPensum.GetAll(seccion);
                    dt = ds.Tables[0];
                    dgvPensum.DataSource = dt;
                    dgvPensum.Columns["ASIGNATURA_AUX_ID"].Visible = false;
                    dgvPensum.Columns["ID"].Visible = false;


                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + exception.StackTrace);
                }
            }
        }

        private void btnAgregarAsignatura_Click(object sender, EventArgs e)
        {
            if (txtSeccion.Text == "") {
                MessageBox.Show("Seleccione una seccion primero");
                return;
            }
            FrmSeleccionarAsignatura frmSeleccionarAsignatura = new FrmSeleccionarAsignatura(this);
            frmSeleccionarAsignatura.Show();
        }

        private void bntQuitarAsignatura_Click(object sender, EventArgs e)
        {
            if (dgvPensum.CurrentRow == null) return;
            DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar la asignatura de este pensum?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.No) return;
            try
            {
                if (FPensum.QuitarAsignatura(Convert.ToInt32(dgvPensum.CurrentRow.Cells["ID"].Value)) > 0) MessageBox.Show("Eliminada con exito!");
                else MessageBox.Show("La asignatura no se pudo quitar.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            CargarDataGridView();
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
