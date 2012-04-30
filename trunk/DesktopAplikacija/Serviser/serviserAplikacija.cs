﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DesktopAplikacija.Serviser.Entiteti;

namespace DesktopAplikacija.Serviser
{
    public partial class serviserAplikacija : Form
    {
        DAL.DAL d = DAL.DAL.Instanca;
        string s;
        int pamti;
        KolekcijaAutobusa a = KolekcijaAutobusa.Instanca;
        List<DAL.Entiteti.Autobus> autobusi;
        public serviserAplikacija()
        {
            InitializeComponent();
            try
            {
                autobusi = new List<DAL.Entiteti.Autobus>();
                autobusi = a.dajPoDatumu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        public serviserAplikacija(string sifra)
        {
            InitializeComponent();
            s = sifra;
            pamti = 0;
            try
            {
                autobusi = new List<DAL.Entiteti.Autobus>();
                autobusi = a.dajPoDatumu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void izađiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        serviserAplikacija: Close();
        }

        private void Izađi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kreirajIzvještajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KreirajIzvjestaj k = new KreirajIzvjestaj(s);
            k.Show();
        }

        private void prikažiIzvještajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrikaziIzvjestaj p = new PrikaziIzvjestaj();
            p.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            KreirajIzvjestaj k = new KreirajIzvjestaj(s);
            k.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PrikaziIzvjestaj p = new PrikaziIzvjestaj();
            p.Show();
        }


        private void serviserAplikacija_Load(object sender, EventArgs e)
        {
            try
            {
                d.kreirajKonekciju();
                foreach (DAL.Entiteti.Autobus au in autobusi)
                    toolStripComboBox1.Items.Add(au.SifraAutobusa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text != "")
            {
                int sifra = Convert.ToInt32(toolStripComboBox1.Text);
                IzmijeniPodatke i = new IzmijeniPodatke(sifra);
                i.Show();
            }
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            try
            {
                DAL.DAL.AutobusDAO ad = new DAL.DAL.AutobusDAO();
                foreach (DAL.Entiteti.Autobus au in autobusi)
                {
                    if (toolStripComboBox1.Text == "")
                    {
                        MessageBox.Show("Niste selektovali autobus!"); break;
                    }
                    else if (Convert.ToInt32(au.SifraAutobusa) == Convert.ToInt32(toolStripComboBox1.Text))
                    {
                        pamti = Convert.ToInt32(toolStripComboBox1.Text);

                        IzmijeniPodatke i = new IzmijeniPodatke(pamti);
                        i.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            try
            {

                DAL.DAL.AutobusDAO ad = new DAL.DAL.AutobusDAO();
                if (comboBox1.Text == "Datum isteka registracije")
                {
                    autobusi = a.dajPoIsteku();
                    foreach (DAL.Entiteti.Autobus au in autobusi)
                    {
                        DateTime novi = au.DatumServisa;
                        dataGridView1.Rows.Add(au.SifraAutobusa, au.RegistracijskeTablice, au.IstekRegistracije, au.BrojSjedista, novi.ToString("yyyy, dd. MMMM"));
                    }
                }
                else if (comboBox1.Text == "Datum servisa")
                {
                    autobusi = a.dajPoDatumu();
                    foreach (DAL.Entiteti.Autobus au in autobusi)
                    {
                        DateTime novi1 = au.DatumServisa;
                        dataGridView1.Rows.Add(au.SifraAutobusa, au.RegistracijskeTablice, au.IstekRegistracije, au.BrojSjedista, novi1.ToString("yyyy, dd. MMMM"));
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }

}