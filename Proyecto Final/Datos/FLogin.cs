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
    class FLogin
    {
        public static DataSet ValidarLogin(Usuario usuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
    {
                FDBHelper.MakeParam("@Username", SqlDbType.VarChar, 0, usuario.username),
                FDBHelper.MakeParam("@Password", SqlDbType.VarChar, 0, usuario.password)
};
        return FDBHelper.ExecuteDataSet("usp_Data_FLogin_ValidarLogin", dbParams);
        }
    }
}