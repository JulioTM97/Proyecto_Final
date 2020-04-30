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
    class FEstudiantesActivos
    {
        public static DataSet GetAll(String _periodo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@PERIODO", SqlDbType.VarChar, 0, _periodo),

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FEstudiantesActivos_GetAll", dbParams);
        }

        public static int NuevoIngreso(Estudiante estudiante, Seccion seccion,string periodo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@PERIODO", SqlDbType.VarChar, 0, periodo),
                    FDBHelper.MakeParam("@SECCION_ID", SqlDbType.Int, 0, seccion.id),
                    FDBHelper.MakeParam("@ESTUDIANTE_NOMBRE", SqlDbType.VarChar, 0, estudiante.nombre),
                    FDBHelper.MakeParam("@MATRICULA", SqlDbType.Int, 0, estudiante.matricula)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FEstudiantesActivos_NuevoIngreso", dbParams));
        }

        public static int Reinscripcion(Estudiante estudiante, Seccion seccion, string periodo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@PERIODO", SqlDbType.VarChar, 0, periodo),
                    FDBHelper.MakeParam("@SECCION_ID", SqlDbType.Int, 0, seccion.id),
                    FDBHelper.MakeParam("@ESTUDIANTE_ID", SqlDbType.Int, 0, estudiante.id),
                    FDBHelper.MakeParam("@MATRICULA", SqlDbType.Int, 0, estudiante.matricula)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FEstudiantesActivos_Reinscripcion", dbParams));
        }

        public static int Modificar(Estudiante estudiante, Seccion seccion, string periodo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID", SqlDbType.Int, 0, estudiante.id),
                    FDBHelper.MakeParam("@NOMBRE", SqlDbType.VarChar, 0, estudiante.nombre),
                    FDBHelper.MakeParam("@SECCION", SqlDbType.Int, 0, seccion.id),
                    FDBHelper.MakeParam("@MATRICULA", SqlDbType.Int, 0, estudiante.matricula),
                    FDBHelper.MakeParam("@PERIODO", SqlDbType.VarChar, 0, periodo)
                };

            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FEstudiantesActivos_Modificar", dbParams));
        }

        public static int Eliminar(Estudiante estudiante, string periodo, int _aux_id)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@PERIODO", SqlDbType.VarChar, 0, periodo),
                    FDBHelper.MakeParam("@ESTUDIANTE_ID", SqlDbType.Int, 0, estudiante.id),
                    FDBHelper.MakeParam("@AUX_ID", SqlDbType.Int, 0, _aux_id)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FEstudiantesActivos_Eliminar", dbParams));
        }

        //usp_Data_FEstudiantesActivos_Eliminar

    }
}
