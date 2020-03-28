using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Final.Datos
{
    class FPensum
    {
        public static DataSet GetAll(Seccion seccion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@SECCION", SqlDbType.Int, 0, seccion.id)
                };
            return FDBHelper.ExecuteDataSet("usp_Data_FPensum_GetAll", dbParams);
        }

        public static int AgregarAsignatura(Seccion seccion, Asignatura asignatura)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@SECCION", SqlDbType.Int, 0, seccion.id),
                    FDBHelper.MakeParam("@ASIGNATURA", SqlDbType.Int, 0, asignatura.id)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FPensum_AgregarAsignatura", dbParams));
        }

        public static int QuitarAsignatura(int id)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@PENSUM_ID", SqlDbType.Int, 0, id),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FPensum_QuitarAsignatura", dbParams));
        }
    }
}
