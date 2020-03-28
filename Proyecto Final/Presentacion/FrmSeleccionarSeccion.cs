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
    public partial class FrmSeleccionarSeccion : Form
    {
        DataTable dt = new DataTable();
        Seccion seccion = new Seccion();
        FrmEstudiantesActivos frmEstudiantesActivos;
        FrmPensum frmPensum;
        public FrmSeleccionarSeccion(FrmEstudiantesActivos _frmEstudiantesActivos)
        {
            InitializeComponent();
            frmEstudiantesActivos = _frmEstudiantesActivos;
        }

        public FrmSeleccionarSeccion(FrmPensum _frmPensum)
        {
            InitializeComponent();
            frmPensum = _frmPensum;
        }
        private void FrmSeleccionarSeccion_Load(object sender, EventArgs e)
        {
            {
                //el programa intenta obtener la lista de todos las secciones.
                try
                {
                    DataSet ds = FSeccion.GetAll();
                    dt = ds.Tables[0];
                    dgvSeccion.DataSource = dt;

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + exception.StackTrace);
                }
                dgvSeccion_CellClick(null, null);
            }
        }

        private void dgvSeccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSeccion.CurrentRow != null)
            {
                seccion.id = Convert.ToInt32(dgvSeccion.CurrentRow.Cells["ID"].Value.ToString());
                seccion.grado = dgvSeccion.CurrentRow.Cells["GRADO"].Value.ToString();
                seccion.nombre = dgvSeccion.CurrentRow.Cells["NOMBRE"].Value.ToString();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (frmPensum != null)
            {
                dgvSeccion_CellClick(null, null);
                frmPensum.ObtenerSeccion(seccion);
            }
            else
            {
                dgvSeccion_CellClick(null, null);
                frmEstudiantesActivos.ObtenerSeccion(seccion);
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSeccion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSeleccionar_Click(null, null);
        }
    }
}
