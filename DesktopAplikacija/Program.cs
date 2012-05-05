﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopAplikacija.Serviser;
using DesktopAplikacija.Poruke;
using DesktopAplikacija.RadnikZaSalterom;

namespace DesktopAplikacija
{
    static class Program
    {
   
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
            try
            {
                DAL.DAL.Instanca.kreirajKonekciju();
                Application.Run(new aplikacijaPoruke(DAL.DAL.Instanca.getDAO.getKorisnikDAO().getById(5)));
                DAL.DAL.Instanca.terminirajKonekciju();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}