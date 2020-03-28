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
    public partial class FrmSeleccionarAsignatura : Form
    {
        FrmPensum frmPensum;
        Asignatura asignatura = new Asignatura();
        public FrmSeleccionarAsignatura(FrmPensum _frmPensum)
        {
            InitializeComponent();
            frmPensum = _frmPensum;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSeleccionarAsignatura_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet dataSet = FAsignatura.GetAll();
                dgvAsignatura.DataSource = dataSet.Tables[0];
                dgvAsignatura_CellClick(null, null);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void dgvAsignatura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAsignatura.CurrentRow != null)
            {
                asignatura.id = Convert.ToInt32(dgvAsignatura.CurrentRow.Cells["ID"].Value.ToString());
                asignatura.docente = dgvAsignatura.CurrentRow.Cells["DOCENTE"].Value.ToString();
                asignatura.nombre = dgvAsignatura.CurrentRow.Cells["ASIGNATURA"].Value.ToString();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            frmPensum.ObtenerAsignatura(asignatura);
            this.Close();
        }

        private void dgvAsignatura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSeleccionar_Click(null, null);
        }
    }
}
