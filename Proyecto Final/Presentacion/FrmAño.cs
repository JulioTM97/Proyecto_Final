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
    public partial class FrmAño : Form
    {

        private static DataTable dt = new DataTable();
        public FrmAño()
        {
            InitializeComponent();
        }

        private void FrmAño_Load(object sender, EventArgs e)
        {
            //el programa intenta obtener la lista de todos los Periodos.
            try
            {
                DataSet ds = FAño.GetAll();
                dt = ds.Tables[0];
                dgvAño.DataSource = dt;
                txtPeriodo.Text = FAño.AñoActual().Tables[0].Rows[0].Field<string>("PERIODO").ToString();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("¿Seguro que desea finalizar el periodo actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.No) return;
            
            try
            {
                string[] actual = txtPeriodo.Text.Split('-');
                int numero1 = Convert.ToInt32(actual[1]);
                int numero2 = numero1 + 1;
                string siguientePeriodo = numero1.ToString() + "-" + numero2.ToString();
                Año año = new Año();
                año.periodo = siguientePeriodo;

                if (FAño.FinalizarAño(año) > 0) MessageBox.Show("Finalizado con exito!");
                else MessageBox.Show("El periodo no se pudo finalizar.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            FrmAño_Load(null, null);
            
        }
    }
}
