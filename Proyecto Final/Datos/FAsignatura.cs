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
    class FAsignatura
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FAsignatura_GetAll", dbParams);
        }

        public static DataSet CargarDocentes()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FAsignatura_CargarDocentes", dbParams);
        }
        public static DataSet CargarNombresAsignaturas()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FAsignatura_CargarNombresAsignaturas", dbParams);
        }
        public static int InsertarNueva(Asignatura asignatura)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ASIGNATURA", SqlDbType.VarChar, 0, asignatura.nombre),
                    FDBHelper.MakeParam("@DOCENTE", SqlDbType.VarChar, 0, asignatura.docente)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FAsignatura_InsertarNueva", dbParams));
        }
        public static int InsertarExistente(Asignatura asignatura)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ASIGNATURA", SqlDbType.VarChar, 0, asignatura.nombre),
                    FDBHelper.MakeParam("@DOCENTE", SqlDbType.VarChar, 0, asignatura.docente)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FAsignatura_InsertarExistente", dbParams));
        }

        public static int Actualizar(Asignatura asignatura)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID", SqlDbType.VarChar, 0, asignatura.id),
                    FDBHelper.MakeParam("@ASIGNATURA", SqlDbType.VarChar, 0, asignatura.nombre),
                    FDBHelper.MakeParam("@DOCENTE", SqlDbType.VarChar, 0, asignatura.docente)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FAsignatura_Modificar", dbParams));
        }

            public static int Eliminar(Asignatura asignatura)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID", SqlDbType.Int, 0, asignatura.id),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FAsignatura_Eliminar", dbParams));
        }
    }
}
