using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVOApp.Models
{
    public class Modules
    {
        private string _cursusNummer;
        private string _naam;
        private int _aantalPlaatsen;
        private int _beschikbarePlaatsen;
        private DateTime _date;     

        public string CursusNummer
        {
            get { return _cursusNummer; }
            set { _cursusNummer = value; }
        }

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        public int AantalPlaatsen
        {
            get { return _aantalPlaatsen; }
            set { _aantalPlaatsen = value; }
        }

        public int BeschikbarePlaatsen
        {
            get { return _beschikbarePlaatsen; }
            set { _beschikbarePlaatsen = value; }
        }

        public int CursistId { get; set; }
        public int CursusId { get; set; }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = DateTime.Now;
            }
        }
        public Modules()
        {

        }

        public Modules(string naam, string cursusNummer, int aantalPlaatsen, int beschikbarePlaatsen, string lestijden)
        {
            Naam = naam;
            CursusNummer = cursusNummer;
            AantalPlaatsen = aantalPlaatsen;
            BeschikbarePlaatsen = beschikbarePlaatsen;           
        }

        public Modules(int cursistId, int cursusId, DateTime date)
        {
            CursistId = cursistId;
            CursusId = cursistId;
            Date = date;
        }

        public static void Registreer()
        {
            
        }

        

        public static int ModuleSession
        {
            get
            {
                object value = HttpContext.Current.Session["ModuleSession"];
                if (value != null)
                {
                    return Convert.ToInt32(value);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["ModuleSession"] = value;
            }

        }


    }
}