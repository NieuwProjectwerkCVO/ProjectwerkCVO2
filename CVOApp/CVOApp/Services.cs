﻿using CVOApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        public static void ModulePerOpleidingSelect(string Opleiding)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("grp1_SelectOpleidingByNaam", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add("@OpleidingNaam", System.Data.SqlDbType.NVarChar).Value = Opleiding;
                        con.Open();
                        using (SqlDataReader query = com.ExecuteReader())
                        {
                            while (query.Read())
                            {
                                CVOApp.Models.Opleiding.OpleidingSession = Convert.ToInt32(query["Id"]);

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


        public static List<Modules> SelectCursussenPerOpleiding(int id)
        {
            List<Modules> lijst = new List<Modules>();

            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("grp1_SelectCursussenPerOpleiding", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                        con.Open();
                        using (SqlDataReader query = com.ExecuteReader())
                        {
                            while (query.Read())
                            {
                                Modules m = new Modules();
                                m.Naam = query["Naam"].ToString();
                                m.CursusNummer = query["CursusNummer"].ToString();
                                m.AantalPlaatsen = Convert.ToInt32(query["MaximumCapaciteit"]);
                                m.BeschikbarePlaatsen = Convert.ToInt32(query["AantalPlaatsenBeschikbaar"]);
                                m.Id= Convert.ToInt32(query["Id"]);
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



        public static void ReserveerPlaats(int CursistId, int CursusId, DateTime date)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("grp1_ReservatieModule", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@CursistId", System.Data.SqlDbType.Int)).Value = CursistId;
                        com.Parameters.Add(new SqlParameter("@CursusId", System.Data.SqlDbType.Int)).Value = CursusId;
                        com.Parameters.Add(new SqlParameter("@Date", System.Data.SqlDbType.Int)).Value = date;

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public static List<Lesrooster> SelectLessenByCursist()
        {
            List<Lesrooster> lijst = new List<Lesrooster>();

            try
            {
                using(SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    using(SqlCommand com = new SqlCommand("grp1_SelectAlleLessenByCursistNummer"))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;

                        con.Open();
                        using (SqlDataReader query = com.ExecuteReader())
                        {
                            while(query.Read())
                            {
                                Lesrooster l = new Lesrooster();
                                l.CursusNummer = query["Cursusnummer"].ToString();
                                l.LesDatum = Convert.ToDateTime(query["Datum"]);
                                l.Campus = query["Campus"].ToString();
                                l.Docent = query["Docent"].ToString();
                                l.Lokaal = query["Lokaal"].ToString();
                                l.ModuleNaam = query["Modulenaam"].ToString();
                                l.StartTijd = Convert.ToDateTime(query["Starttijd"]);
                                l.EindTijd = Convert.ToDateTime(query["Eindtijd"]);
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


        
        


        public static List<Lesrooster> SelectLessenByCursist(int cursistId)
        {

            List<Lesrooster> lijst = new List<Lesrooster>();
            return lijst;
        }
        //public static List<Lesmoment> SelectLessen()
        //{

        //    List<Lesmoment> lijst = new List<Lesmoment>();
        //}


        public static List<Evenement> SelectEvents()
        {
            List<Evenement> lijst = new List<Evenement>();

            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("grp1_SelectEvents", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;

                        con.Open();
                        using (SqlDataReader query = com.ExecuteReader())
                        {
                            while (query.Read())
                            {
                                Evenement e = new Evenement();
                                e.Id = Convert.ToInt32(query["Id"]);
                                e.Naam = query["Naam"].ToString();
                                e.Datum = Convert.ToDateTime(query["Datum"]);
                                e.Locatie = query["Locatie"].ToString();
                                if (query["StartUur"] != DBNull.Value && query["EindUur"] != DBNull.Value)
                                {
                                    e.StartUur = Convert.ToDateTime(query["StartUur"]);
                                    e.EindUur = Convert.ToDateTime(query["EindUur"]);
                                }
                                lijst.Add(e);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
                System.Diagnostics.Debug.Write("hierboven");
            }

            return lijst;
        }

    }
}
