﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.TipoviPodataka;

namespace DAL.Entiteti
{
    public class KupacKarte : Kupac
    {
        protected List<int> sjedista;
        protected List<double> cijene;
        protected Stanica pocetnaStanica;
        protected Stanica krajnjaStanica;
        protected Voznja voznja;

        public Stanica PocetnaStanica
        {
            get { return pocetnaStanica; }
            set { pocetnaStanica = value; }
        }


        public Stanica KrajnjaStanica
        {
            get { return krajnjaStanica; }
            set { krajnjaStanica = value; }
        }


        public Voznja Voznja
        {
            get { return voznja; }
            set { voznja = value; }
        }


        public List<int> Sjedista
        {
            get { return sjedista; }
            set { sjedista = value; }
        }

        public List<double> Cijene
        {
            get { return cijene; }
            set { cijene = value; }
        }


        public KupacKarte(int sK, string i, Stanica pS, Stanica kS, Voznja v, List<int> s, List<double> c)
            : base(sK, i)
        {
            pocetnaStanica = pS;
            krajnjaStanica = kS;
            voznja = v;
            sjedista = s;
            cijene = c;
        }

        public KupacKarte(string i, Stanica pS, Stanica kS, Voznja v, List<int> s, List<double> c)
            : base(i)
        {
            pocetnaStanica = pS;
            krajnjaStanica = kS;
            voznja = v;
            sjedista = s;
            cijene = c;
        }

        public double proracunajCijenu()
        {
            return 1;
        }
    }
}