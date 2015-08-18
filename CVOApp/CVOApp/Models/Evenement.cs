using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVOApp.Models
{
    public class Evenement
    {
        private int _id;
        private string _naam;
        private DateTime _datum;
        private string _locatie;
        private DateTime _startUur;
        private DateTime _eindUur;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        public DateTime Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }

        public string Locatie
        {
            get { return _locatie; }
            set { _locatie = value; }
        }

        public DateTime StartUur
        {
            get { return _startUur; }
            set { _startUur = value; }
        }

        public DateTime EindUur
        {
            get { return _eindUur; }
            set { _eindUur = value; }
        }

        public Evenement()
        {
            //this.StartUur = DateTime.Now;
            //this.EindUur = DateTime.Now;
        }
    }
}