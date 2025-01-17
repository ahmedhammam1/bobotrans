﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DesktopAplikacija.Entiteti;

namespace DesktopAplikacija.RadnikZaSalterom
{
    public partial class PodaciOAutobusu : Form
    {
        DAL.DAL d = DAL.DAL.Instanca;
        int sifraAutobusa;
        KolekcijaAutobusa ka = KolekcijaAutobusa.Instanca;
        DAL.Entiteti.Autobus odabraniAutobus;
        public PodaciOAutobusu(int sifra)
        {
            InitializeComponent();
            sifraAutobusa = sifra;
            odabraniAutobus = ka.dajPoSifri(sifraAutobusa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PodaciOAutobusu_Load(object sender, EventArgs e)
        {
     
                   d.kreirajKonekciju();
                    textBox1.Text = Convert.ToString(odabraniAutobus.SifraAutobusa);
                    textBox2.Text = odabraniAutobus.RegistracijskeTablice;
                    textBox7.Text = odabraniAutobus.BrojSjedista.ToString();
                    textBox3.Text = (odabraniAutobus.ImaToalet) ? "DA" : "NE";
                    textBox4.Text = (odabraniAutobus.ImaKlimu) ? "DA" : "NE";
                    textBox5.Text = (odabraniAutobus.Slobodan) ? "DA" : "NE";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
