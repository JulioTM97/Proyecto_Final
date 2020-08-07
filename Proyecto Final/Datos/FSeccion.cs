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
    class FSeccion
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FSeccion_GetAll", dbParams);
        }

        public static DataSet CargarGrados()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FSeccion_CargarGrados", dbParams);
        }

        public static int Insertar(Seccion seccion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@GRADO", SqlDbType.VarChar, 0, seccion.grado),
                    FDBHelper.MakeParam("@DOCENTE", SqlDbType.VarChar, 0, seccion.docente),
                    FDBHelper.MakeParam("@NOMBRE", SqlDbType.VarChar, 0, seccion.nombre)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FSeccion_Insertar", dbParams));
        }

        public static int Actualizar(Seccion seccion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID", SqlDbType.Int, 0, seccion.id),
                    FDBHelper.MakeParam("@GRADO", SqlDbType.VarChar, 0, seccion.grado),
                    FDBHelper.MakeParam("@DOCENTE", SqlDbType.VarChar, 0, seccion.docente),
                    FDBHelper.MakeParam("@NOMBRE", SqlDbType.VarChar, 0, seccion.nombre),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FSeccion_Actualizar", dbParams));
        }
        public static int Eliminar(Seccion seccion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID", SqlDbType.Int, 0, seccion.id),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FSeccion_Eliminar", dbParams));
        }
    }
}
