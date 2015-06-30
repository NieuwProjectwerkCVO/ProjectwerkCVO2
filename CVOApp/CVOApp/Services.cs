using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CVOApp.Models;

namespace CVOApp
{
    public static class Services
    {
        public static void Login(string cursistNummer, string wachtwoord)
        {
            int idCursist = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("grp1_SelectCursistByLogin", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add("@cursistNummer", System.Data.SqlDbType.NVarChar).Value = cursistNummer;
                        com.Parameters.Add("@wachtwoord", System.Data.SqlDbType.NVarChar).Value = wachtwoord;
                        con.Open();
                        using (SqlDataReader query = com.ExecuteReader())
                        {
                            if (query.HasRows)
                            {
                                while (query.Read())
                                {
                                    if (query["Wachtwoord"] == wachtwoord)
                                    {
                                        idCursist = Convert.ToInt32(query["Id"]);
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (idCursist != 0)
            {
                CVOApp.Models.LoginClass.LoginSession = idCursist;
            }

        }
    }
}