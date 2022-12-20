using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Microsoft.Data.Sqlite;

namespace KontaktyWPF
{
    public class modelKontakt
    {
        public static string tabelkaNazwa = "Osoby";
        SqliteConnection connection = new SqliteConnection($"Data Source=Kontakty.db");
        public int CountOfRows;
        public modelKontakt()
        {
            connection.Open();
        }
        ~modelKontakt()
        {
            connection.Close();
        }
        public void NowaTabela(string NazwaTabelki)
        {
            var command = connection.CreateCommand();
            command.CommandText = $@"CREATE TABLE IF NOT EXISTS {NazwaTabelki} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Imie TEXT, Nazwisko TEXT, NumerTelefonu INTEGER, DataUrodzenia TEXT, Wojewodztwo TEXT, Plec TEXT, Opis TEXT  )";
            tabelkaNazwa = NazwaTabelki;
            command.ExecuteNonQuery();
        }

        public string AktualnaBaza()
        {
            return tabelkaNazwa;
        }

        public void Add(KontaktBezId kon)
        {
            var command = connection.CreateCommand();
            command.CommandText = $@"INSERT INTO {tabelkaNazwa} (Imie, Nazwisko, NumerTelefonu, DataUrodzenia, Wojewodztwo, Plec, Opis) VALUES ('{kon.imie}', '{kon.nazwisko}', '{kon.numer_tel}', '{kon.data_ur}', '{kon.wojewodztwo}', '{kon.plec}', '{kon.opis}');";
            command.ExecuteNonQuery();
        }
        public void Modify(Kontakt kon)
        {
            var command = connection.CreateCommand();
            command.CommandText = $@"UPDATE {tabelkaNazwa} SET Imie = '{kon.Imie}', Nazwisko ='{kon.Nazwisko}' , NumerTelefonu = {kon.NumerTelefonu}, DataUrodzenia = '{kon.DataUrodzenia}', Wojewodztwo = '{kon.Wojewodztwo}',Plec = '{kon.Plec}', Opis = '{kon.Opis}' WHERE Id = {kon.ID}";
            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            var command = connection.CreateCommand();
            command.CommandText = $@"DELETE FROM {tabelkaNazwa} WHERE id='{id}';";
            command.ExecuteNonQuery();
        }

        public void Przeładowanie(string osobaDoWyszukania, int nrStrony)
        {

            MainWindow.listaKontaktow.Clear();
            int offset = 4 * (nrStrony - 1);
            var command = connection.CreateCommand();
            command.CommandText = $@"SELECT * FROM {tabelkaNazwa} WHERE (Imie LIKE '%{osobaDoWyszukania}%' OR Nazwisko LIKE '%{osobaDoWyszukania}%') ORDER BY Id ASC  LIMIT 4 OFFSET {offset}";
            using (var reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    string numer;
                    int id = reader.GetInt32(0);
                    string Imie = reader.GetString(1);
                    string Nazwisko = reader.GetString(2);
                    int NumerTelefonu = reader.GetInt32(3);
                    string DataUrodzenia = reader.GetString(4);
                    string Opis = reader.GetString(7);
                    string Wojewodztwo = reader.GetString(5);
                    string Plec = reader.GetString(6);
                    numer = NumerTelefonu.ToString();

                    MainWindow.listaKontaktow.Add(new Kontakt(Imie, Nazwisko, numer, DataUrodzenia, Wojewodztwo, Plec, Opis, id));
                }
            }
        }
        public double Pasek(string osobaDoWyszukania)
        {
            var command = connection.CreateCommand();
            command.CommandText = $@"SELECT COUNT(*) FROM {tabelkaNazwa} WHERE (Imie LIKE '%{osobaDoWyszukania}%' OR Nazwisko LIKE '%{osobaDoWyszukania}%')";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Count = System.Convert.ToInt32(reader.GetString(0));
                    CountOfRows = Count;

                }

            }
            return CountOfRows;
        }
    }
}
