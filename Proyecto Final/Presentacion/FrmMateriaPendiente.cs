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
    public partial class FrmMateriaPendiente : Form
    {
        DataTable dt;
        public FrmMateriaPendiente()
        {
            InitializeComponent();
        }

        private void btnEnabledChangeEvent(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            if (button.Enabled) button.BackColor = Color.FromArgb(0, 122, 204);
            else button.BackColor = Color.Gray;
        }

        private void FrmMateriaPendiente_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = FMateriaPendiente.GetAll();
                dt = ds.Tables[0];
                dgvEstudiantesAsignaturasPendientes.DataSource = dt;
                dgvEstudiantesAsignaturasPendientes.Columns["ID_ESTUDIANTE"].Visible = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteMateriasPendiente frmReporteMateriasPendiente = new FrmReporteMateriasPendiente();
            frmReporteMateriasPendiente.Show();
        }
    }
}
