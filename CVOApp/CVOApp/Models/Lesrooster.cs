using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVOApp.Models
{
    public class Lesrooster
    {
        private string _cursusNummer;
        private string _module;
        private DateTime _datum;
        private string _lokaal;
        private DateTime _van;
        private DateTime _tot;
        private string _campus;
        private string _docent;

        public string CursusNummer
        {
            get { return _cursusNummer; }
            set { _cursusNummer = value; }
        }

        public string Module
        {
            get { return _module; }
            set { _module = value; }
        }

        public string Lokaal
        {
            get { return _lokaal; }
            set { _lokaal = value;}
        }

        public DateTime Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }

        public DateTime Van
        {
            get { return _van; }
            set { _van = value; }
        }

        public DateTime Tot
        {
            get { return _tot; }
            set { _tot = value; }
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

        public Lesrooster(string module, string cursusNummer, DateTime datum, DateTime van, DateTime tot, string docent, string campus, string lokaal)
        {
            Module = module;
            CursusNummer = cursusNummer;
            Datum = datum;
            Docent = docent;
            Van = van;
            Tot = tot;
            Campus = campus;
            Lokaal = lokaal;
        }
    }
}