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
    class FGrado
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FGrado_GetAll", dbParams);
        }

        public static int Insertar(Grado grado)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@NOMBRE", SqlDbType.VarChar, 0, grado.nombre)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FGrado_Insertar", dbParams));
        }

        public static int Actualizar(Grado grado)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID", SqlDbType.Int, 0, grado.id),
                    FDBHelper.MakeParam("@NOMBRE", SqlDbType.VarChar, 0, grado.nombre),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FGrado_Actualizar", dbParams));
        }
        public static int Eliminar(Grado grado)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID", SqlDbType.Int, 0, grado.id),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FGrado_Eliminar", dbParams));
        }
    }
}
