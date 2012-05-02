﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BoboTransporter.Grafika.Vozila
{
    class Auto:Slicica
    {
        static private string teksturaIme = "Auto\\auto{0}Tekstura";
        int pozicijaCelijeX;

        public int PozicijaCelijeX
        {
            get { return pozicijaCelijeX; }
            set { pozicijaCelijeX = value; }
        }
        int pozicijaCelijeY;

        public int PozicijaCelijeY
        {
            get { return pozicijaCelijeY; }
            set { pozicijaCelijeY = value; }
        }

        int vrijemeOdbrojano;
        int kretanje;
        int rotacijaX;
        int brojTeksture;
        bool cekam;
        bool pomjerljiv;

        public bool Pomjerljiv
        {
            get { return pomjerljiv; }
            set { pomjerljiv = value; }
        }

        public bool Cekam
        {
            get { return cekam; }
            set { cekam = value; }
        }

        public Auto(int pX,int pY, int RotacijaX, int brTek) : base()
        {
            pozicijaCelijeX = pX;
            pozicijaCelijeY = pY;
            Pozicija = new Vector2(pX*37.5f+618.75f, pY*37.5f+618.75f);
            Rotacija = 0f;
            VertikalnaPozicija = 0.37f;
            Velicina = .10f;
            kretanje = 0;
            cekam = false;
            vrijemeOdbrojano = 0;
            rotacijaX = RotacijaX;
            Okvir = new Rectangle(0, 0, 300, 300);
            Sredina = new Vector2(150, 150);
            pomjerljiv = true;
            brojTeksture = brTek;
        }

        /*
         * Kretanja:
         * 0 - ravno
         * 1 - desno
         * -1 - lijevo
         * 
         * RotacijaX:
         * 0 - gore
         * 3 - lijevo
         * 2 - dole
         * 1 - desno
        */

        public void postaviKretanje(int kret_)
        {
            if (cekam && pomjerljiv)
            {
                vrijemeOdbrojano = 0;
                kretanje = kret_;
                cekam = false;
            }
        }

        public override void LoadContent(ContentManager theContentManager)
        {
            LoadContent(theContentManager, String.Format(teksturaIme,brojTeksture));
        }

        public void Update(GameTime gameTime)
        {
            if (!cekam)
            {
                vrijemeOdbrojano += 4*gameTime.ElapsedGameTime.Milliseconds;
                if (vrijemeOdbrojano > 1000) vrijemeOdbrojano = 1000;
                if (kretanje == 0)
                {
                    Rotacija = rotacijaX * (float)Math.PI / 2;
                    Pozicija = new Vector2(
                        pozicijaCelijeX * 37.5f + 618.75f - ((float)Math.Sin(Rotacija) * (500 - vrijemeOdbrojano) * 37.5f / 1000)
                        ,
                        pozicijaCelijeY * 37.5f + 618.75f + ((float)Math.Cos(Rotacija) * (500 - vrijemeOdbrojano) * 37.5f / 1000)
                        );
                }
                else if (kretanje == 1)
                {
                    float Rotacija2 = rotacijaX * (float)Math.PI / 2;
                    Rotacija = Rotacija2 + (float)Math.PI * vrijemeOdbrojano / 2000;
                    Pozicija = new Vector2(pozicijaCelijeX * 37.5f + 618.75f - ((float)Math.Cos(Rotacija) * 18.75f)
                        ,
                        pozicijaCelijeY * 37.5f + 618.75f - ((float)Math.Sin(Rotacija) * 18.75f)
                        );
                    switch (rotacijaX)
                    {
                        case 0:
                            Pozicija += new Vector2(18.75f, 18.75f);
                            break;
                        case 1:
                            Pozicija += new Vector2(-18.75f, 18.75f);
                            break;
                        case 2:
                            Pozicija += new Vector2(-18.75f, -18.75f);
                            break;
                        case 3:
                            Pozicija += new Vector2(18.75f, -18.75f);
                            break;
                    }
                }

                else if (kretanje == -1)
                {
                    float Rotacija2 = rotacijaX * (float)Math.PI / 2;
                    Rotacija = Rotacija2 - (float)Math.PI * vrijemeOdbrojano / 2000;
                    Pozicija = new Vector2(pozicijaCelijeX * 37.5f + 618.75f + ((float)Math.Cos(Rotacija) * 18.75f)
                        ,
                        pozicijaCelijeY * 37.5f + 618.75f + ((float)Math.Sin(Rotacija) * 18.75f)
                        );
                    switch (rotacijaX)
                    {
                        case 0:
                            Pozicija += new Vector2(-18.75f, 18.75f);
                            break;
                        case 1:
                            Pozicija += new Vector2(-18.75f, -18.75f);
                            break;
                        case 2:
                            Pozicija += new Vector2(18.75f, -18.75f);
                            break;
                        case 3:
                            Pozicija += new Vector2(18.75f, 18.75f);
                            break;
                    }
                }

                if (vrijemeOdbrojano == 1000)
                {
                    //odrediti relativnu poziciju
                    int pX=0, pY=0;
                    #region Odredjivanje pX i pY
                    switch (kretanje)
                    {
                        case 0:
                            switch (rotacijaX)
                            {
                                case 0:
                                    pX = 0; pY = -1;
                                    break;
                                case 1:
                                    pX = 1; pY = 0;
                                    break;
                                case 2:
                                    pX = 0; pY = 1;
                                    break;
                                case 3:
                                    pX = -1; pY = 0;
                                    break;
                            }

                            break;
                        case 1:
                            switch (rotacijaX)
                            {
                                case 0:
                                    pX = 1; pY = 0;
                                    break;
                                case 1:
                                    pX = 0; pY = 1;
                                    break;
                                case 2:
                                    pX = -1; pY = 0;
                                    break;
                                case 3:
                                    pX = 0; pY = -1;
                                    break;
                            }

                            break;
                        case -1:
                            switch (rotacijaX)
                            {
                                case 0:
                                    pX = -1; pY = 0;
                                    break;
                                case 1:
                                    pX = 0; pY = -1;
                                    break;
                                case 2:
                                    pX = 1; pY = 0;
                                    break;
                                case 3:
                                    pX = 0; pY = 1;
                                    break;
                            }

                            break;
                    } 
                    #endregion
                    cekam = true;
                    rotacijaX += kretanje;
                    while (rotacijaX > 3) rotacijaX -= 4;
                    while (rotacijaX < 0) rotacijaX += 4;
                    pozicijaCelijeX += pX;
                    pozicijaCelijeY += pY;
                }
            }
        }
    }
}