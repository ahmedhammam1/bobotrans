# Baza podataka za aplikaciju #

## Tabele: ##

  1. Linije
  1. Voznje
  1. LinijeVoznje
  1. Stanice
  1. Autobusi
  1. Poruke
  1. Izvjestaji
  1. RasporedVoznji
  1. LinijeRasporedVoznji
  1. Korisnici
  1. TipoviKorisnika
  1. Karte
  1. ZakupiAutobusa
  1. KupciKarti
  1. TipoviKupacaKarte
  1. LinijeCijene
  1. StaniceULiniji
  1. RasporedVoznjeAutobus
  1. InternetRezervacije


### Linije: ###

- id (primary, int, autoincrement)

- naziv (varchar):unique

### Voznje: ###

- id (primary, int ,autoincrement)

- idAutobusa(int) - Foreign Key na Autobusi.id: on update: cascade, on delete - RESTRICT

- vrijemePolaska (date)

- sati(int)

- minute(int)

### LinijeVoznje: ###

- id (primary, int, autoincrement)

- idLinije (int) - Foreign Key na Linije.id: update: cascade, on delete - RESTRICT

- idVoznje (int) - Foreign Key na Voznje.id: on update i delete - cascade, unique

### Stanice: ###

- id (primary,int, autoincrement)

- naziv (varchar)

- mjesto (varchar)


### Autobusi: ###

- id (primary,int, autoincrement)

- registracijskeTablice (varchar): unique

- istekRegistracije (Date)

- brojSjedista(integer)

- datumServisa (Date)

- toalet (Boolean)

- slobodan (Boolean)

- klima (boolean)


### Poruke: ###

- id (primary, int, autoincrement)

- idPosiljaoca (int) - foreign key na korisnici.id: on update i delete - cascade

- idPrimaoca (int) - foreign key na korisnici.id: on update i delete - cascade

- vrijemeSlanja (DateTime)



### Izvjestaji: ###

- id (primary, int, autoincrement)

- datum (Date)

- tekst (Text)

- idKreatora (int) - foreign key na korisnici.id: on update i delete - cascade
- idAutobusa (int) - foreign key na autobusi.id: on update i delete - cascade


### RasporedVoznji: ###

- id (primary, int, autoincrement)

- danUSedmici (int)

- sati(int)

- minute(int)

- potrebanBrojSjedista (int)

### LinijeRasporedVoznji ###

- id (primary, int, autoincrement)

- idLinije (int): Foreign Key na Linije.id: update: cascade, on delete - RESTRICT

- idRasporedaVoznje : Foreign Key na Linije.id: update: cascade, on delete - CASCADE, unique


### Korisnici: ###

- id (primary, int, autoincrement)    (to je ujedno sifra korisnika)

- imeIPrezime (varchar)

- tip (int): foreign key na TipoviKorisnika.id: on UPDATE NO ACTION, DELETE NO ACTION

- username (varchar) - unique

- lozinka (varchar)


### TipoviKorisnika: ###

- id (primary, int, autoincrement)

- tip (varchar):unique


### Karte: ###

- id (primary, int, autoincrement)

- idVoznje (int): foreign key na Voznje.id: on UPDATE - CASCADE, on DELETE - RESTRICT

- idPocetneStanice (int) : foreignKey na Stanice.id: on update: CASCADE, on DELETE: RESTRICT

- idKrajnjeStanice (int) : foreignKey na Stanice.id: on update: CASCADE, on DELETE: RESTRICT

- idSjedista (int)

- cijena (decimal)

- idKupca (int): foreignKey na KupciKarti.id: on update:CASCADE, on DELETE: RESTRICT

- vrijemeIDatumKupovine (DateTime)

### ZakupiAutobusa: ###

- id (primary, int, autoincrement)

- imeZakupca (varchar)

- idAutobusa (int) - Foreign Key na Autobusi.id: on update: cascade, on delete - RESTRICT

- cijena (decimal)

- pocetakZakupa (Date)

- krajZakupa (Date)


### KupciKarti: ###

- id (primary, int, autoincrement)

- imeIPrezime (varchar)

- tipKupca (int): foreign key na TipoviKupcaKarte.id: on UPDATE NO ACTION, DELETE NO ACTION


### TipoviKupacaKarte: ###

- id (primary, int, autoincrement)

- naziv (varchar): unique

- popust (decimal)


### LinijeCijene: ###

- id (primary, int, autoincrement)

- idLinije (int) - foreign key na Linije.id: ON UPDATE i DELETE - CASCADE

- idPrveStanice (int)- foreign key na Stanice.id: ON UPDATE - CASCADE i DELETE - RESTRICT

- idDrugeStanice (int)- foreign key na Stanice.id: ON UPDATE - CASCADE i DELETE - RESTRICT

- cijena (decimal)


### StaniceULiniji ###

- id (primary, int, autoincrement)

- idLinije (int) - foreign key na Linije.id: ON UPDATE i DELETE - CASCADE

- idStanice (int) - foreign key na Stanice.id: ON UPDATE - CASCADE i DELETE - RESTRICT

- trajanjeDoDolaska (int)

- trajanjeDoPolaska (int)

### RasporedVoznjeAutobus ###

- id (primary, int, autoincrement)

- idRasporedaVoznje - foreign key na RasporedVoznji.id: on UPDATE i DELETE - restrict

- idAutobusa - foreign key na Autobusi.id: on UPDATE i DELETE - restrict

### InternetRezervacije ###

- id (primary, int, autoincrement)

- idKupca (int)

- sifra (varchar)