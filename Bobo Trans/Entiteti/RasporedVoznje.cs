﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entiteti
{
    public class RasporedVoznje
    {
        private long sifraRasporedaVoznji;
        private int danUSedmici;
        private DateTime vrijeme;
        private long potrebanBrojSjedista;


        #region GetteriSetteri
        public int DanUSedmici
        {
            get { return danUSedmici; }
            set { danUSedmici = value; }
        }
        public long SifraRasporedaVoznji
        {
            get { return sifraRasporedaVoznji; }
            set { sifraRasporedaVoznji = value; }
        }
        public DateTime Vrijeme
        {
            get { return vrijeme; }
            set { vrijeme = value; }
        }

        public long PotrebanBrojSjedista
        {
            get { return potrebanBrojSjedista; }
            set { potrebanBrojSjedista = value; }
        } 
        #endregion

        public RasporedVoznje(int dUS,DateTime v, long pBS)
        {
            danUSedmici = dUS;
            vrijeme = v;
            potrebanBrojSjedista = pBS;
        }

        public RasporedVoznje(long sRV,int dUS, DateTime v, long pBS)
        {
            danUSedmici = dUS;
            sifraRasporedaVoznji = sRV;
            vrijeme = v;
            potrebanBrojSjedista = pBS;
        }

    }
}
