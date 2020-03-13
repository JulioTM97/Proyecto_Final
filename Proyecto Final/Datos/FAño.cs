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
    class FAño
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FAño_GetAll", dbParams);
        }

        public static DataSet AñoActual()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FAño_AñoActual", dbParams);
        }

        public static int FinalizarAño(Año año)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@PERIODO", SqlDbType.VarChar, 0, año.periodo),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FAño_FinalizarAño", dbParams));
        }

    }
}
