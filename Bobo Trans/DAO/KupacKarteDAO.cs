﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;

using DAL.Entiteti;
using DAL.Interfejsi;

namespace DAL
{
    partial class DAL
    {
        public class KupacKarteDAO : IDaoCrud<KupacKarte>
        {
            protected MySqlCommand c;

            public long create(KupacKarte entity)
            {
                c = new MySqlCommand("START TRANSACTION;", con);
                long idKupca;
                try
                {
                    c = new MySqlCommand(String.Format("INSERT INTO kupcikarti VALUES ('','{0}','{1}');"
                         , entity.Ime, (int)(TipoviPodataka.TipoviKupaca.BEZ_POPUSTA))
                         , con);
                    c.ExecuteNonQuery();
                    idKupca = c.LastInsertedId;

                    for (int i = 0; i < entity.Sjedista.Count; i++)
                    {
                        c = new MySqlCommand(String.Format("INSERT INTO karte VALUES ('','{0}','{1}','{2}','{3}','{4}','{5}','{6}');"
                         , entity.Voznja.SifraVoznje, entity.PocetnaStanica.SifraStanice, entity.KrajnjaStanica.SifraStanice, entity.Sjedista[i], entity.Cijene[i].ToString().Replace(',', '.'), idKupca, entity.DatumIVrijemeKupovine.ToString("yyyy-MM-dd HH:mm"))
                         , con);
                        c.ExecuteNonQuery();
                    }

                    return idKupca;
                }
                catch (Exception e)
                {
                    c = new MySqlCommand("ROLLBACK;", con);
                    c.ExecuteNonQuery();
                    throw e;
                }
            }

            public KupacKarte read(KupacKarte entity)
            {
                int id;
                c = new MySqlCommand(string.Format("SELECT * FROM kupcikarti WHERE imeIPrezime='{0}' AND tipKupca='{1}'",entity.Ime,(int)(TipoviPodataka.TipoviKupaca.BEZ_POPUSTA)),con);
                MySqlDataReader r = c.ExecuteReader();
                if (r.Read())
                {
                    id = r.GetInt32("id");
                    r.Close();
                }
                else
                {
                    r.Close();
                    throw new Exception("nije nadjen nijedan element");
                }
                return getById(id);
            }

            public KupacKarte update(KupacKarte entity)
            {
                delete(entity);
                entity.SifraKupca = create(entity);
                return entity;
            }

            public void delete(KupacKarte entity)
            {
                try
                {
                    c = new MySqlCommand("START TRANSACTION;", con);
                    c.ExecuteNonQuery();

                    c = new MySqlCommand(string.Format("DELETE FROM karte WHERE idKupca='{0}'", entity.SifraKupca), con);
                    c.ExecuteNonQuery();

                    c = new MySqlCommand(string.Format("DELETE FROM kupcikarti WHERE id='{0}'", entity.SifraKupca), con);
                    c.ExecuteNonQuery();

                    c = new MySqlCommand("COMMIT;", con);
                    c.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    c = new MySqlCommand("ROLLBACK;", con);
                    c.ExecuteNonQuery();
                    throw e;
                }
            }

            public KupacKarte getById(long id)
            {
                long sifra = id;
                string ime;
                Stanica pocetnaStanica;
                Stanica krajnjaStanica;
                int pocetnaStanicaId = 0;
                int krajnjaStanicaId = 0;
                Voznja voznja;
                int voznjaId = 0;
                List<int> sjedista = new List<int>();
                List<double> cijene = new List<double>();
                DateTime datumIVrijemeKupovine;

                try
                {
                    c = new MySqlCommand("START TRANSACTION;", con);
                    c.ExecuteNonQuery();
                    ime = ocitajIme(id);
                    ocitajKarte(id, ref pocetnaStanicaId, ref krajnjaStanicaId, ref voznjaId, sjedista, cijene, out datumIVrijemeKupovine);
                    pocetnaStanica = DAL.Instanca.getDAO.getStaniceDAO().getById(pocetnaStanicaId);
                    krajnjaStanica = DAL.Instanca.getDAO.getStaniceDAO().getById(krajnjaStanicaId);
                    voznja = DAL.Instanca.getDAO.getVoznjaDAO().getById(voznjaId);

                    c = new MySqlCommand("COMMIT;", con);
                    c.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    c = new MySqlCommand("ROLLBACK;", con);
                    c.ExecuteNonQuery();
                    throw e;
                }

                return new KupacKarte((int)id, ime, pocetnaStanica, krajnjaStanica, voznja, sjedista, cijene, datumIVrijemeKupovine);
            }

            private void ocitajKarte(long id, ref int pocetnaStanicaId, ref int krajnjaStanicaId, ref int voznjaId, List<int> sjedista, List<double> cijene, out DateTime datumIVrijemeKupovine)
            {
                pocetnaStanicaId = 0;
                krajnjaStanicaId = 0;
                voznjaId = 0;
                datumIVrijemeKupovine = new DateTime(2000, 1, 1, 12, 0, 0);
                c = new MySqlCommand(string.Format("SELECT * FROM karte WHERE idKupca='{0}';", id), con);
                MySqlDataReader r = c.ExecuteReader();
                try
                {
                    while (r.Read())
                    {
                        pocetnaStanicaId = r.GetInt32("idPocetneStanice");
                        krajnjaStanicaId = r.GetInt32("idKrajnjeStanice");
                        voznjaId = r.GetInt32("idVoznje");
                        sjedista.Add(r.GetInt32("idSjedista"));
                        cijene.Add(r.GetDouble("cijena"));
                        datumIVrijemeKupovine = r.GetDateTime("vrijemeIDatumKupovine");
                    }
                    r.Close();
                }
                catch (Exception ex)
                {
                    r.Close();
                    throw ex;
                }
            }

            private string ocitajIme(long id)
            {
                string ime;
                c = new MySqlCommand(string.Format("SELECT * FROM kupcikarti WHERE id='{0}' AND tipKupca='{1}';", id, (int)(TipoviPodataka.TipoviKupaca.BEZ_POPUSTA)), con);
                MySqlDataReader r = c.ExecuteReader();
                if (r.Read())
                {
                    ime = r.GetString("imeIPrezime");
                    r.Close();
                }
                else
                {
                    r.Close();
                    throw new Exception("nije nadjen nijedan element");
                }
                return ime;
            }

            public List<KupacKarte> GetAll()
            {
                List<KupacKarte> kupci = new List<KupacKarte>();
                c = new MySqlCommand(string.Format("SELECT id FROM kupcikarti WHERE tipKupca='{0}'", (int)(TipoviPodataka.TipoviKupaca.BEZ_POPUSTA)), con);
                MySqlDataReader r = c.ExecuteReader();
                List<long> sifre = new List<long>();
                try
                {
                    while (r.Read())
                        sifre.Add(r.GetInt32("id"));
                    r.Close();
                }
                catch (Exception ex)
                {
                    r.Close();
                    throw ex;
                }

                foreach (long sifra in sifre)
                    kupci.Add(getById(sifra));
                return kupci;
            }

            public List<KupacKarte> getByExample(string name, string values)
            {
                throw new Exception("get by Example se ne moze implementirati za kupce karti");
            }
        }
    }
}
