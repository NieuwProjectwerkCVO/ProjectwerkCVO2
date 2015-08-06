using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVOApp.Models
{
    public class Lesmoment
    {
        private string _cursusNummer;
        private string _moduleNaam;
        private bool _ingeschreven;
        private DateTime _lestijd;

        public string CursusNummer
        {
            get { return _cursusNummer; }
            set { _cursusNummer = value; }
        }

        public string ModuleNaam
        {
            get { return _moduleNaam; }
            set { _moduleNaam= value; }
        }

        public bool Ingeschreven
        {
            get { return _ingeschreven; }
            set { _ingeschreven = value; }
        }

        public DateTime Lestijd
        {
            get { return _lestijd; }
            set { _lestijd = value; }
        }


        public Lesmoment()
        {

        }

        public Lesmoment(string moduleNaam, string cursusNummer, bool ingeschreven, DateTime lestijd)
        {
            ModuleNaam = moduleNaam;
            CursusNummer = cursusNummer;
            Ingeschreven = ingeschreven;
            Lestijd = lestijd;
        }
    }
}