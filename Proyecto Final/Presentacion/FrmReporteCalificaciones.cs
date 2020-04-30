using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.Presentacion;
using Proyecto_Final.Datos;
using Proyecto_Final.Entidades;

namespace Proyecto_Final
{
    public partial class FrmReporteCalificaciones : Form
    {
        int estudianteAuxID;
        Seccion seccion;

        public FrmReporteCalificaciones(int _estudianteAuxID, Seccion _seccion)
        {
            InitializeComponent();
            estudianteAuxID = _estudianteAuxID;
            seccion = _seccion;
        }

        private void FrmReporteCalificaciones_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetCalificaciones.usp_Presentacion_ImprimirCalificaciones' Puede moverla o quitarla según sea necesario.
            this.usp_Presentacion_ImprimirCalificacionesTableAdapter.Fill(this.DataSetCalificaciones.usp_Presentacion_ImprimirCalificaciones,seccion.id,estudianteAuxID);
            

            this.reportViewer1.RefreshReport();
        }
    }
}
