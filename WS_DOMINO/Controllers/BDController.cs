using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WS_DOMINO.Controllers
{
    public class BDController : Controller
    {
        OracleConnection connection = null;
        OracleCommand command = null;

        private string oradb = "Data Source=localhost:1521/xe; User Id=domino_restaurant; Password=domino_restaurant";

        public DataTable SPRefcursor(string SP, params object[] parametros)
        {
            try
            {
                DataTable dt = new DataTable();
                connection = new OracleConnection(oradb);
                command = new OracleCommand(SP, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                OracleCommandBuilder.DeriveParameters(command);
                int cuenta = 0;

                foreach (OracleParameter pr in command.Parameters)
                {
                    switch (pr.ParameterName)
                    {
                        case "P_REFCURSOR":
                            pr.Direction = ParameterDirection.Output;
                            OracleDataAdapter oda = new OracleDataAdapter(command);
                            command.ExecuteNonQuery();
                            oda.Fill(dt);
                            break;


                        default:
                            pr.Value = parametros[cuenta];
                            cuenta++;
                            break;
                    }

                }

                connection.Close();
                command.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
    }
}