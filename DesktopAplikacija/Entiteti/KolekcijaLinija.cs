﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopAplikacija.Entiteti
{
    class KolekcijaLinija
    {
        private List<DAL.Entiteti.Linija> linije;
        private static KolekcijaLinija instanca = null;

        public static KolekcijaLinija Instanca
        {
            get { return (KolekcijaLinija.instanca==null)? new KolekcijaLinija(): instanca; }
        }

        public List<DAL.Entiteti.Linija> Linije
        {
            get { return linije; }
            set { linije = value; }
        }


        public bool linijeSadrzeStanicu(DAL.Entiteti.Stanica s)
        {
            foreach (DAL.Entiteti.Linija l in linije)
            {
                foreach (DAL.Entiteti.Stanica sl in l.Stanice)
                {
                    if (sl.SifraStanice == s.SifraStanice)
                        return true;
                }
            }

            return false;
        }

        private KolekcijaLinija()
        {
                DAL.DAL d = DAL.DAL.Instanca;
                d.kreirajKonekciju();
                DAL.DAL.LinijaDAO ld = d.getDAO.getLinijaDAO();
                linije = ld.GetAll();
        }

        public long dodajLiniju(DAL.Entiteti.Linija l)
        {
             DAL.DAL d = DAL.DAL.Instanca;
             DAL.DAL.LinijaDAO ld = d.getDAO.getLinijaDAO();

             l.SifraLinije = ld.create(l);
             linije.Add(l);

             return l.SifraLinije;
        }


        public void updateujLiniju(DAL.Entiteti.Linija l)
        {
            DAL.DAL d = DAL.DAL.Instanca;
            DAL.DAL.LinijaDAO ld = d.getDAO.getLinijaDAO();
            for(int i=0;i<linije.Count;i++)
            {
                if(linije[i].SifraLinije==l.SifraLinije)
                {
                    linije[i] = ld.update(l);
                    return;
                }
            }
        }

        public void izbrisiLiniju(DAL.Entiteti.Linija l)
        {
            DAL.DAL d = DAL.DAL.Instanca;
            DAL.DAL.LinijaDAO ld = d.getDAO.getLinijaDAO();

            for (int i = 0; i < linije.Count; i++)
            {
                if (linije[i].SifraLinije == l.SifraLinije)
                {
                    ld.delete(linije[i]);
                    linije.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
