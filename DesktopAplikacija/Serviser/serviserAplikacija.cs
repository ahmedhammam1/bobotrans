﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DesktopAplikacija.Poruke;
using DesktopAplikacija.Entiteti;

namespace DesktopAplikacija.Serviser
{
    public partial class ServiserAplikacija : Form
    {
        DAL.DAL d = DAL.DAL.Instanca;
        DAL.Entiteti.Korisnik logovaniKorisnik;
        KolekcijaAutobusa a = KolekcijaAutobusa.Instanca;
        List<DAL.Entiteti.Autobus> autobusi;
        Login login;

        public ServiserAplikacija()
        {
            InitializeComponent();
            try
            {
                autobusi = a.dajPoDatumu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        public ServiserAplikacija(DAL.Entiteti.Korisnik k, Login l)
        {
            login = l;
            l.Visible = false;
            InitializeComponent();
            logovaniKorisnik = k;
            try
            {
                autobusi = a.dajPoDatumu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void Izađi_Click(object sender, EventArgs e)
        {
            this.Close();
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
                DAL.DAL.AutobusDAO ad = d.getDAO.getAutobusDAO();
                foreach (DAL.Entiteti.Autobus au in autobusi)
                {
                    if (toolStripComboBox1.Text == "")
                    {
                        MessageBox.Show("Niste selektovali autobus!"); break;
                    }
                    else if (Convert.ToInt32(au.SifraAutobusa) == Convert.ToInt32(toolStripComboBox1.Text))
                    {
                        long pamti;
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

        private void serviserAplikacija_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Visible = true;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            aplikacijaPoruke ap = new aplikacijaPoruke(logovaniKorisnik);
            ap.Show();
       }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            aplikacijaPoruke a = new aplikacijaPoruke(logovaniKorisnik);
            a.Show();
        }

        private void tsbPoruke_Click(object sender, EventArgs e)
        {
            DesktopAplikacija.Poruke.aplikacijaPoruke ap = new DesktopAplikacija.Poruke.aplikacijaPoruke(logovaniKorisnik);
            ap.Show();
        }

        private void izađiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kreirajIzvještajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            KreirajIzvjestaj k = new KreirajIzvjestaj(logovaniKorisnik);
            k.Show();
        }

        private void prikažiIzvještajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrikaziIzvjestaj p = new PrikaziIzvjestaj();
            p.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            KreirajIzvjestaj k = new KreirajIzvjestaj(logovaniKorisnik);
            k.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            PrikaziIzvjestaj p = new PrikaziIzvjestaj();
            p.Show();
        }

        private void informisanjeOLinijamaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Informisanje.InformisanjeLinije il = new Informisanje.InformisanjeLinije();
            il.Show();
        }

        private void izvOdIzRedaVožnjeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Informisanje.IzvodIzRedaVoznje irv = new Informisanje.IzvodIzRedaVoznje();
            irv.Show();
        }

        private void najjeftinijiPutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Informisanje.NajjeftinijiPut np = new Informisanje.NajjeftinijiPut();
            np.Show();
        }

    }

}