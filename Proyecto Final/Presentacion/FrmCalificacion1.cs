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
    public partial class FrmCalificacion1 : Form
    {
        DataTable dt;
        Seccion seccion;
        Estudiante estudiante;
        int auxID;
        string periodo;
        FrmPrincipal frmPrincipal;
        public FrmCalificacion1(FrmPrincipal _frmPrincipal)
        {
            InitializeComponent();
            frmPrincipal = _frmPrincipal;
            btnConsultar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmSeleccionarSeccion frmSeleccionarSeccion = new FrmSeleccionarSeccion(this);
            frmSeleccionarSeccion.Show();
        }

        internal void ObtenerSeccion(Seccion _seccion)
        {
            seccion = _seccion;
            txtGrado.Text = seccion.grado;
            txtSeccion.Text = seccion.nombre;
            CargarDataGridView();
        }

        private void FrmCalificacion1_Load(object sender, EventArgs e)
        {
            periodo = FAño.AñoActual().Tables[0].Rows[0].Field<string>("PERIODO").ToString();
        }

        private void CargarDataGridView()
        {
            //el programa intenta obtener la lista de todos las secciones.
            try
            {
                DataSet ds = FCalificacion.ObtenerEstudiantes(periodo,seccion);
                dt = ds.Tables[0];
                dgvEstudiante.DataSource = dt;
                dgvEstudiante.Columns["ESTUDIANTE_AUX_ID"].Visible = false;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void dgvEstudiante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEstudiante.CurrentRow == null) return;
            FrmCalificacion2 frmCalificacion2 = new FrmCalificacion2(frmPrincipal,this);
            frmCalificacion2.ObtenerDatos(seccion, estudiante, auxID);

            frmPrincipal.AbrirFormEnPanel(frmCalificacion2);
            //frmCalificacion2.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvEstudiante_CellDoubleClick(null, null);
        }

        private void dgvEstudiante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEstudiante.CurrentRow != null)
            {
                btnConsultar.Enabled = true;
                estudiante = new Estudiante();
                estudiante.nombre = dgvEstudiante.CurrentRow.Cells["NOMBRE"].Value.ToString();
                estudiante.matricula = Convert.ToInt32(dgvEstudiante.CurrentRow.Cells["MATRICULA"].Value.ToString());
                auxID = Convert.ToInt32(dgvEstudiante.CurrentRow.Cells["ESTUDIANTE_AUX_ID"].Value.ToString());
            } else btnConsultar.Enabled = false;
        }
        private void btnEnabledChangeEvent(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            if (button.Enabled) button.BackColor = Color.FromArgb(0, 122, 204);
            else button.BackColor = Color.Gray;
        }

        private void btnMateriaPendiente_Click(object sender, EventArgs e)
        {
            frmPrincipal.AbrirFormEnPanel(new FrmMateriaPendiente());
        }
    }
}
