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
    public partial class FrmInstitucion : Form
    {
        private string estado;
        DataTable dataTable;
        DataRow[] dataRow;
        public FrmInstitucion()
        {
            InitializeComponent();
        }

        private void FrmInstitucion_Load(object sender, EventArgs e)
        {
            DataSet dataSet = FInstitucion.GetAll();
            dataTable = dataSet.Tables[0];
            dataRow = dataTable.Select();

            if (dataRow.Length > 0)
            {
                cambios("existe registro");
                txtNombreCentro.Text = dataRow[0].Field<string>("NOMBRE_CENTRO");
                txtNombreDirector.Text = dataRow[0].Field<string>("NOMBRE_DIRECTOR");
                txtDireccion.Text = dataRow[0].Field<string>("DIRECCION");
                txtRegional.Text = dataRow[0].Field<string>("CODIGO_REGIONAL");
                txtCoordinadorPedagogico.Text = dataRow[0].Field<string>("COORDINADOR_PEDAGOGICO");
                txtCoordinadorTecnico.Text = dataRow[0].Field<string>("COORDINADOR_TECNICO");
            }
            else
            {
                cambios("no existe registro");
            }
            cambios("reinicio");
        }

        private void cambios(string opcion)
        {
            switch (opcion){
                case "existe registro":
                    btnAgregarDatos.Visible = false;
                    btnAgregarDatos.Enabled = false;
                    btnActualizarDatos.Visible = true;
                    break;
                case "no existe registro":
                    btnAgregarDatos.Visible = true;
                    btnActualizarDatos.Visible = false;
                    btnActualizarDatos.Enabled = false;
                    break;
                case "agregar":
                case "modificar":
                    btnAgregarDatos.Enabled = false;
                    btnActualizarDatos.Enabled = false;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    txtCoordinadorPedagogico.Enabled = true;
                    txtCoordinadorTecnico.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtNombreCentro.Enabled = true;
                    txtNombreDirector.Enabled = true;
                    txtRegional.Enabled = true;
                    break;
                case "reinicio":
                    btnAgregarDatos.Enabled = true;
                    btnActualizarDatos.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;

                    txtCoordinadorPedagogico.Enabled = false;
                    txtCoordinadorTecnico.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtNombreCentro.Enabled = false;
                    txtNombreDirector.Enabled = false;
                    txtRegional.Enabled = false;

                    estado = "";
                    break;
            }
            if (opcion == "agregar") estado = "agregando";
            else if (opcion == "modificar") estado = "modificando";
        }

        private void btnAgregarDatos_Click(object sender, EventArgs e)
        {
            cambios("agregar");
        }

        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            cambios("modificar");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cambios("reinicio");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Institucion institucion = new Institucion();
            institucion.nombreCentro = txtNombreCentro.Text;
            institucion.nombreDirector = txtNombreDirector.Text;
            institucion.direccion = txtDireccion.Text;
            institucion.codigoRegional = txtRegional.Text;
            institucion.coordinadorPedagogico = txtCoordinadorPedagogico.Text;
            institucion.coordinadorTecnico = txtCoordinadorTecnico.Text;

            try
            {
                if (estado == "agregando")
                {
                    if (FInstitucion.Insertar(institucion) > 0) MessageBox.Show("Datos agregados con exito!");
                    else MessageBox.Show("Los datos no pudieron ser agregados");
                }
                if (estado == "modificando")
                {
                    if (FInstitucion.Actualizar(institucion) > 0) MessageBox.Show("Los datos se actualizaron con exito!");
                    else MessageBox.Show("Los datos no se pudieron actualizar");
                }
                
                FrmInstitucion_Load(null,null);
                cambios("reinicio");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }
    }
}
