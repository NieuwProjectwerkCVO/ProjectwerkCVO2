using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVOApp.Models
{
    public class Resultaat
    {
        private string _cursusNummer;
        private string _moduleNaam;
        private double _totaal;

        public double Totaal
        {
            get { return _totaal; }
            set { _totaal = value; }
        }
        

        public string ModuleNaam
        {
            get { return _moduleNaam; }
            set { _moduleNaam = value; }
        }
        

        public string CursusNummer
        {
            get { return _cursusNummer; }
            set { _cursusNummer = value; }
        }

        public Boolean Geslaagd
        {
            get
            {
                if (Totaal < 50)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Resultaat(string cursusNummer, double totaal, string moduleNaam)
        {
            CursusNummer = cursusNummer;
            Totaal = totaal;
            ModuleNaam = moduleNaam;
        }

        public Resultaat()
        {

        }
        
        
    }
}