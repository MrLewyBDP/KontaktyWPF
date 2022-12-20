using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktyWPF
{
    public class Kontakt
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NumerTelefonu { get; set; }
        public string DataUrodzenia { get; set; }
        public string Wojewodztwo { get; set; }
        public string Plec { get; set; }
        public string Opis { get; set; }
        public Kontakt(string _imie, string _nazwisko, string _numer_tel, string _data_ur, string _wojewodztwo, string _plec, string _opis, int id)
        {
            this.Imie = _imie;
            this.Nazwisko = _nazwisko;
            this.NumerTelefonu = _numer_tel;
            this.DataUrodzenia = _data_ur;
            this.Wojewodztwo = _wojewodztwo;
            this.Plec = _plec;
            this.Opis = _opis;
            this.ID = id;
        }
    }

    public class KontaktBezId
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string numer_tel { get; set; }
        public string data_ur { get; set; }
        public string wojewodztwo { get; set; }
        public string plec { get; set; }
        public string opis { get; set; }
        public KontaktBezId(string _imie, string _nazwisko, string _numer_tel, string _data_ur, string _wojewodztwo, string _plec, string _opis)
        {
            this.imie = _imie;
            this.nazwisko = _nazwisko;
            this.numer_tel = _numer_tel;
            this.data_ur = _data_ur;
            this.wojewodztwo = _wojewodztwo;
            this.plec = _plec;
            this.opis = _opis;
        }
    }
}
