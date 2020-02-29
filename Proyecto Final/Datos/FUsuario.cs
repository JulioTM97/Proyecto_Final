using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Proyecto_Final.Datos;
using Proyecto_Final.Entidades;
using System.Data.SqlClient;

namespace Proyecto_Final.Datos
{
    class FUsuario
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FUsuario_GetAll", dbParams);
        }

        public static DataSet CargarRoles()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FUsuario_CargarRoles", dbParams);
        }

        public static int Insertar(Usuario usuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@NOMBRE", SqlDbType.VarChar, 0, usuario.nombre),
                    FDBHelper.MakeParam("@CEDULA", SqlDbType.VarChar, 0, usuario.cedula),
                    FDBHelper.MakeParam("@TELEFONO", SqlDbType.VarChar, 0, usuario.telefono),
                    FDBHelper.MakeParam("@CORREO", SqlDbType.VarChar, 0, usuario.correo),
                    FDBHelper.MakeParam("@USERNAME", SqlDbType.VarChar, 0, usuario.username),
                    FDBHelper.MakeParam("@PASSWORD", SqlDbType.VarChar, 0, usuario.password),
                    FDBHelper.MakeParam("@ROL", SqlDbType.VarChar, 0, usuario.rol),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FUsuario_Insertar", dbParams));
        }

        public static int Actualizar(Usuario usuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID", SqlDbType.Int, 0, usuario.id),
                    FDBHelper.MakeParam("@NOMBRE", SqlDbType.VarChar, 0, usuario.nombre),
                    FDBHelper.MakeParam("@CEDULA", SqlDbType.VarChar, 0, usuario.cedula),
                    FDBHelper.MakeParam("@TELEFONO", SqlDbType.VarChar, 0, usuario.telefono),
                    FDBHelper.MakeParam("@CORREO", SqlDbType.VarChar, 0, usuario.correo),
                    FDBHelper.MakeParam("@USERNAME", SqlDbType.VarChar, 0, usuario.username),
                    FDBHelper.MakeParam("@PASSWORD", SqlDbType.VarChar, 0, usuario.password),
                    FDBHelper.MakeParam("@ROL", SqlDbType.VarChar, 0, usuario.rol),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FUsuario_Actualizar", dbParams));
        }

        public static int Eliminar(Usuario usuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID", SqlDbType.Int, 0, usuario.id),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FUsuario_Eliminar", dbParams));
        }
    }
}
