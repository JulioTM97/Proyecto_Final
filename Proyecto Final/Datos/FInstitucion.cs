using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Datos
{
    class FInstitucion
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FInstitucion_GetAll", dbParams);
        }
        public static int Insertar(Institucion institucion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@NOMBRE_CENTRO ", SqlDbType.VarChar, 0, institucion.nombreCentro),
                    FDBHelper.MakeParam("@NOMBRE_DIRECTOR", SqlDbType.VarChar, 0, institucion.nombreDirector),
                    FDBHelper.MakeParam("@DIRECCION", SqlDbType.VarChar, 0, institucion.direccion),
                    FDBHelper.MakeParam("@CODIGO_REGIONAL", SqlDbType.VarChar, 0, institucion.codigoRegional),
                    FDBHelper.MakeParam("@COORDINADOR_TECNICO", SqlDbType.VarChar, 0, institucion.coordinadorTecnico),
                    FDBHelper.MakeParam("@COORDINADOR_PEDAGOGICO", SqlDbType.VarChar, 0, institucion.coordinadorPedagogico),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FInstitucion_Insertar", dbParams));
        }

        public static int Actualizar(Institucion institucion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@NOMBRE_CENTRO ", SqlDbType.VarChar, 0, institucion.nombreCentro),
                    FDBHelper.MakeParam("@NOMBRE_DIRECTOR", SqlDbType.VarChar, 0, institucion.nombreDirector),
                    FDBHelper.MakeParam("@DIRECCION", SqlDbType.VarChar, 0, institucion.direccion),
                    FDBHelper.MakeParam("@CODIGO_REGIONAL", SqlDbType.VarChar, 0, institucion.codigoRegional),
                    FDBHelper.MakeParam("@COORDINADOR_TECNICO", SqlDbType.VarChar, 0, institucion.coordinadorTecnico),
                    FDBHelper.MakeParam("@COORDINADOR_PEDAGOGICO", SqlDbType.VarChar, 0, institucion.coordinadorPedagogico),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FInstitucion_Actualizar", dbParams));
        }
    }
}
