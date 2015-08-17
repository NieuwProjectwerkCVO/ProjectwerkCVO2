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
                            while (query.Read())
                            {
                                if (query["Wachtwoord"].ToString() == wachtwoord)
                                {
                                    CVOApp.Models.LoginClass.LoginSession = Convert.ToInt32(query["Id"]);
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

        }

        public static List<Resultaat> ResultatenByCursistId(int cursistId)
        {
            List<Resultaat> lijst = new List<Resultaat>();

            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("grp1_SelectCursistResultaat", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add("@idCursist", System.Data.SqlDbType.Int).Value = cursistId;
                        con.Open();
                        using (SqlDataReader query = com.ExecuteReader())
                        {
                            while (query.Read())
                            {
                                Resultaat r = new Resultaat();
                                r.CursusNummer = query["CursusNummer"].ToString();
                                r.ModuleNaam = query["Naam"].ToString();
                                r.Totaal = Convert.ToDouble(query["PuntenTotaal"]);
                                lijst.Add(r);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return lijst;
        }


        public static List<Module> SelectCursussen()
        {
            List<Module> lijst = new List<Module>();

            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("grp1_SelectCursussen", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        con.Open();
                        using (SqlDataReader query = com.ExecuteReader())
                        {
                            while (query.Read())
                            {
                                Module m = new Module();
                                m.Naam = query["Naam"].ToString();
                                m.CursusNummer = query["CursusNummer"].ToString();
                                m.AantalPlaatsen = Convert.ToInt32(query["MaximumCapaciteit"]);
                                m.BeschikbarePlaatsen = Convert.ToInt32(query["AantalPlaatsenBeschikbaar"]);
                                lijst.Add(m);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return lijst;
        }

<<<<<<< HEAD
            public static List<Lesrooster> SelectLessenByCursist(int cursistId)
            {

                List<Lesrooster> lijst = new List<Lesrooster>();
            }
=======
        //public static List<Lesmoment> SelectLessen()
        //{

        //    List<Lesmoment> lijst = new List<Lesmoment>();
        //}
>>>>>>> origin/master
    }
}