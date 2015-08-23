using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVOApp.Models
{
    public class Lesrooster
    {
        private string _cursusNummer;
        private string _moduleNaam;
        private DateTime _lesDatum;
        private string _lokaal;
        private DateTime _startTijd;
        private DateTime _eindTijd;
        private string _campus;
        private string _docent;

        public string CursusNummer
        {
            get { return _cursusNummer; }
            set { _cursusNummer = value; }
        }

        public string ModuleNaam
        {
            get { return _moduleNaam; }
            set { _moduleNaam = value; }
        }

        public string Lokaal
        {
            get { return _lokaal; }
            set { _lokaal = value;}
        }

        public DateTime LesDatum
        {
            get { return _lesDatum; }
            set { _lesDatum = value; }
        }

        public DateTime StartTijd
        {
            get { return _startTijd; }
            set { _startTijd = value; }
        }

        public DateTime EindTijd
        {
            get { return _eindTijd; }
            set { _eindTijd = value; }
        }

        public string Campus
        {
            get { return _campus; }
            set { _campus = value; }
        }

        public string Docent
        {
            get { return _docent; }
            set { _docent = value; }
        }


        public Lesrooster()
        {

        }

        public Lesrooster(string moduleNaam, string cursusNummer, DateTime lesDatum, DateTime startTijd, DateTime eindTijd, string docent, string campus, string lokaal)
        {
            ModuleNaam = moduleNaam;
            CursusNummer = cursusNummer;
            LesDatum = lesDatum;
            Docent = docent;
            StartTijd = startTijd;
            EindTijd = eindTijd;
            Campus = campus;
            Lokaal = lokaal;
        }
    }
}