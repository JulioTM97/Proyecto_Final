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
    public partial class FrmCalificacion2 : Form
    {
        Estudiante estudiante;
        Seccion seccion;
        int auxID;
        DataTable dt;
        Calificacion calificacion;
        public FrmCalificacion2()
        {
            InitializeComponent();
        }

        private void FrmCalificacion2_Load(object sender, EventArgs e)
        {

        }

        internal void ObtenerDatos(Seccion _seccion, Estudiante _estudiante,int _auxID)
        {
            seccion = _seccion;
            estudiante = _estudiante;
            auxID = _auxID;

            txtEstudiante.Text = estudiante.nombre;
            txtMatricula.Text = estudiante.matricula.ToString();
            txtGrado.Text = seccion.grado;
            txtSeccion.Text = seccion.nombre;

            CargarDataGridView();
        }

        private void CargarDataGridView()
        {
            //el programa intenta obtener la lista de todos las secciones.
            try
            {
                DataSet ds = FCalificacion.ObtenerCalificacionesDelEstudiante(seccion, auxID);
                dt = ds.Tables[0];
                dgvCalificacion.DataSource = dt;
                dgvCalificacion.Columns["ID"].Visible = false;
                dgvCalificacion.Columns["ASIGNATURA_ID"].Visible = false;
                dgvCalificacion.Columns["DOCENTE"].Visible = false;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            if (dgvCalificacion.CurrentRow == null) return;
            else
            {
                calificacion = new Calificacion();

                calificacion.id = Convert.ToInt32(dgvCalificacion.CurrentRow.Cells["ID"].Value);

                calificacion.nombreAsignatura = dgvCalificacion.CurrentRow.Cells["ASIGNATURA"].Value.ToString();
                if (dgvCalificacion.CurrentRow.Cells["PRIMER_REPORTE"].Value.ToString() != "")
                    calificacion.primerReporte = Convert.ToInt32(dgvCalificacion.CurrentRow.Cells["PRIMER_REPORTE"].Value);
                else calificacion.primerReporte = 0;

                if (dgvCalificacion.CurrentRow.Cells["SEGUNDO_REPORTE"].Value.ToString() != "")
                    calificacion.segundoReporte = Convert.ToInt32(dgvCalificacion.CurrentRow.Cells["SEGUNDO_REPORTE"].Value);
                else calificacion.segundoReporte = 0;

                if (dgvCalificacion.CurrentRow.Cells["TERCER_REPORTE"].Value.ToString() != "")
                    calificacion.tercerReporte = Convert.ToInt32(dgvCalificacion.CurrentRow.Cells["TERCER_REPORTE"].Value);
                else calificacion.tercerReporte = 0;

                if (dgvCalificacion.CurrentRow.Cells["CUARTO_REPORTE"].Value.ToString() != "")
                    calificacion.cuartoReporte = Convert.ToInt32(dgvCalificacion.CurrentRow.Cells["CUARTO_REPORTE"].Value);
                else calificacion.cuartoReporte = 0;

                if (dgvCalificacion.CurrentRow.Cells["COMPLETIVO"].Value.ToString() != "")
                    calificacion.completivo = Convert.ToInt32(dgvCalificacion.CurrentRow.Cells["COMPLETIVO"].Value);
                else calificacion.completivo = 0;

                if (dgvCalificacion.CurrentRow.Cells["EXTRAORDINARIO"].Value.ToString() != "")
                    calificacion.extraordinario = Convert.ToInt32(dgvCalificacion.CurrentRow.Cells["EXTRAORDINARIO"].Value);
                else calificacion.extraordinario = 0;

                FrmCalificacion3 frmCalificacion3 = new FrmCalificacion3(calificacion, estudiante, seccion);
                frmCalificacion3.Show();
            }
        }

        private void dgvCalificacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEvaluar_Click(null, null);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteCalificaciones reporteCalificaciones = new FrmReporteCalificaciones(auxID,seccion);
            reporteCalificaciones.Show();
        }
    }
}
