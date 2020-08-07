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
    public partial class FrmCalificacion3 : Form
    {
        Calificacion calificacion;
        Estudiante estudiante;
        Seccion seccion;
        FrmCalificacion2 frmCalificacion2;
        public FrmCalificacion3(FrmCalificacion2 _frmCalificacion2,Calificacion _calificacion, Estudiante _estudiante,Seccion _seccion)
        {
            InitializeComponent();
            calificacion = _calificacion;
            estudiante = _estudiante;
            seccion = _seccion;
            frmCalificacion2 = _frmCalificacion2;
        }

        private void FrmCalificacion3_Load(object sender, EventArgs e)
        {
            txtAsignatura.Text = calificacion.nombreAsignatura;

            txtPrimer.Value = calificacion.primerReporte;
            txtSegundo.Value = calificacion.segundoReporte;
            txtTercer.Value = calificacion.tercerReporte;
            txtCuarto.Value = calificacion.cuartoReporte;
            txtCompletivo.Value = calificacion.completivo;
            txtExtraordinario.Value = calificacion.extraordinario;

            txtEstudiante.Text = estudiante.nombre;
            txtMatricula.Text = estudiante.matricula.ToString();
            txtGrado.Text = seccion.grado;
            txtSeccion.Text = seccion.nombre;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Las calificaciones del estudiante en esta asignatura se actualizarán en la base de datos."+Environment.NewLine+"¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.No) return;
            try
            {
                calificacion.primerReporte = Convert.ToInt32(txtPrimer.Value);
                calificacion.segundoReporte = Convert.ToInt32(txtSegundo.Value);
                calificacion.tercerReporte = Convert.ToInt32(txtTercer.Value);
                calificacion.cuartoReporte = Convert.ToInt32(txtCuarto.Value);
                calificacion.completivo = Convert.ToInt32(txtCompletivo.Value);
                calificacion.extraordinario = Convert.ToInt32(txtExtraordinario.Value);

                if (FCalificacion.EvaluarEstudiante(calificacion) > 0)
                {
                    MessageBox.Show("Estudiante evaluado con exito!");
                    this.Close();
                }
                else MessageBox.Show("El estudiante no se pudo ser evaluado.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCalificacion3_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCalificacion2.CargarDataGridView();
        }
    }
}
