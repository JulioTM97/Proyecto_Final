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
    public partial class FrmEstudiante : Form
    {
        DataTable dt = new DataTable();
        FrmEstudiantesActivos frmEstudiantesActivos;

        public FrmEstudiante(FrmEstudiantesActivos _frmEstudiantesActivos)
        {
            InitializeComponent();
            frmEstudiantesActivos = _frmEstudiantesActivos;
        }

        private void FrmEstudiante_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = FEstudiante.GetAll();
                dt = ds.Tables[0];
                dgvEstudiante.DataSource = dt;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            //dgvUsuario_CellClick(null, null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            StringComparison comp = StringComparison.OrdinalIgnoreCase;
            try
            {
                for (int i = 0; i < dgvEstudiante.Rows.Count; i++)
                {
                    if (dgvEstudiante.Rows[i].Cells["NOMBRE"].Value.ToString().IndexOf(txtNombre.Text,comp) < 0)
                    {
                        dgvEstudiante.CurrentCell = null;
                        dgvEstudiante.Rows[i].Visible = false;
                    }
                    else dgvEstudiante.Rows[i].Visible = true;
                }
                dgvEstudiante.CurrentCell = dgvEstudiante.FirstDisplayedCell;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            //dgvUsuario_CellClick(null, null);
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            {
                for (int i = 0; i < dgvEstudiante.Rows.Count; i++) dgvEstudiante.Rows[i].Visible = true;
                dgvEstudiante.CurrentCell = dgvEstudiante.FirstDisplayedCell;
                //dgvUsuario_CellClick(null, null);
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnBuscar_Click(null, null);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvEstudiante.CurrentRow != null) {
                Estudiante estudiante = new Estudiante();
                estudiante.id = Convert.ToInt32(dgvEstudiante.CurrentRow.Cells["ID"].Value);
                estudiante.nombre = dgvEstudiante.CurrentRow.Cells["NOMBRE"].Value.ToString();
                frmEstudiantesActivos.ObtenerEstudiante(estudiante);
                this.Close();
            }
        }

        private void dgvEstudiante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSeleccionar_Click(null, null);
        }
    }
}

//culture.CompareInfo.IndexOf(paragraph, word, CompareOptions.IgnoreCase) >= 0
//string title = "STRING";
//bool contains = title.Contains("string", StringComparison.OrdinalIgnoreCase);
