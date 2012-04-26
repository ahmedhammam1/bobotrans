﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DAL;

namespace DesktopAplikacija
{
    public partial class Login : Form
    {
        DAL.DAL d = DAL.DAL.Instanca;
        public Login()
        {
            
           
                InitializeComponent();
                
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
               
                DAL.DAL.KorisnikDAO kd = d.getDAO.getKorisnikDAO();
                
                try
                {
                    //dok se naprave forme koje ce se otvarati stavila sam da mi ispisuje na toolStrioStatusLabel//
                    
                    DAL.Entiteti.Korisnik k = kd.getByUsernameAndPassword(t_nazivKorisnika.Text, t_sifraKorisnika.Text);
                    LoginPodaci lg = new LoginPodaci(k.ImeIPrezime, k.Password);
                    
                    if(k.Tip==DAL.TipoviPodataka.TipoviKorisnika.MENAGER)
                        toolStripStatusLabel1.Text = "logovani ste kao menager";
                    if(k.Tip==DAL.TipoviPodataka.TipoviKorisnika.RADNIK_ZA_SALTEROM)
                        toolStripStatusLabel1.Text = "logovani ste kao radnik";
                    if(k.Tip==DAL.TipoviPodataka.TipoviKorisnika.SERVISER)
                        toolStripStatusLabel1.Text = "logovani ste kao serviser";

                }
                catch (Exception e1)
                {toolStripStatusLabel1.Text=e1.Message;}  
                       
            }    
            else
                toolStripStatusLabel1.Text="Unesite podatke";

            }

        

            
        

        private void t_nazivKorisnika_Validating(object sender, CancelEventArgs e)
        {
            if (t_nazivKorisnika.Text.Length < 3)
                errorProvider1.SetError(t_nazivKorisnika, "Unesite naziv");
            else
                errorProvider1.SetError(t_nazivKorisnika, "");
        }

        private void t_sifraKorisnika_Validating(object sender, CancelEventArgs e)
        {
            if (t_sifraKorisnika.Text.Length< 3)
                errorProvider1.SetError(t_sifraKorisnika, "Unestite šifru");
            else errorProvider1.SetError(t_sifraKorisnika, "");
        }

        private bool Validiraj()
        {
             if((errorProvider1.GetError(t_nazivKorisnika)=="")&&(errorProvider1.GetError(t_sifraKorisnika)==""))
                 return true;
             return false;
        
        }

        private void Login_Load(object sender, EventArgs e)
        {
            d.kreirajKonekciju();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            d.terminirajKonekciju();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    
    
    
    
    
    }


    }
