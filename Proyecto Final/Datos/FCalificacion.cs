using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Datos
{
    class FCalificacion
    {
        public static DataSet ObtenerEstudiantes(String _periodo, Seccion _seccion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@PERIODO", SqlDbType.VarChar, 0, _periodo),
                    FDBHelper.MakeParam("@SECCION_ID", SqlDbType.Int, 0, _seccion.id)

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FCalificacion1_BuscarEstudiantes", dbParams);
        }

        public static DataSet ObtenerCalificacionesDelEstudiante(Seccion _seccion,int _auxID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@SECCION", SqlDbType.Int, 0, _seccion.id),
                    FDBHelper.MakeParam("@ESTUDIANTE_AUX_ID", SqlDbType.Int, 0, _auxID)
                };
            return FDBHelper.ExecuteDataSet("usp_Data_FCalificacion2_MostrarCalificaciones", dbParams);
        }

        public static int EvaluarEstudiante(Calificacion calificacion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID", SqlDbType.Int, 0, calificacion.id),
                    FDBHelper.MakeParam("@PRIMER_REPORTE", SqlDbType.Int, 0, calificacion.primerReporte),
                    FDBHelper.MakeParam("@SEGUNDO_REPORTE", SqlDbType.Int, 0, calificacion.segundoReporte),
                    FDBHelper.MakeParam("@TERCER_REPORTE", SqlDbType.Int, 0, calificacion.tercerReporte),
                    FDBHelper.MakeParam("@CUARTO_REPORTE", SqlDbType.Int, 0, calificacion.cuartoReporte),
                    FDBHelper.MakeParam("@COMPLETIVO", SqlDbType.Int, 0, calificacion.completivo),
                    FDBHelper.MakeParam("@EXTRAORDINARIO", SqlDbType.Int, 0, calificacion.extraordinario)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FCalificacion3_EvaluarEstudiante", dbParams));
        }
    }
}
