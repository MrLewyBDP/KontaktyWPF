using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KontaktyWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Modyfikuj.xaml
    /// </summary>
    public partial class Modyfikuj : Window
    {
        Kontakt kontakt;
        modelKontakt model;
        public Modyfikuj(Kontakt kontakt, modelKontakt model)
        {
            InitializeComponent();
            this.model = model;
            this.kontakt = kontakt;
            imie.Text = kontakt.imie;
            nazwisko.Text = kontakt.nazwisko;
            numer.Text = kontakt.numer_tel;
            data.Text = Convert.ToString(kontakt.data_ur);
            if(kontakt.plec == "Mezczyzna")
            {
                m1.IsChecked = true;
            }
            else if (kontakt.plec == "Kobieta")
            {
                k1.IsChecked = true;
            }
            wojewodztwo.Text = kontakt.wojewodztwo;
            opis.Text = kontakt.opis;
            this.kontakt = kontakt;
        }
        /// <summary>
        ///  zmodyfikowanie kontaktu
        /// </summary>
        private void Zmodyfikuj(object sender, RoutedEventArgs e)
        {
            var plec = "";
            if (m1.IsChecked == true)
            {
                plec = "Mezczyzna";
            }
            else if (k1.IsChecked == true)
            {
                plec = "Kobieta";
            }



            Kontakt kontaktPoEdycji = new Kontakt(imie.Text, nazwisko.Text, numer.Text, data.Text, wojewodztwo.Text, plec, opis.Text, kontakt.id);
            //idKontaktu.imie = imie.Text;
            //idKontaktu.nazwisko = nazwisko.Text;
            //idKontaktu.numer_tel = numer.Text;
            //idKontaktu.data_ur = System.Convert.ToDateTime(data.Text);
            //idKontaktu.plec = plec;
            //idKontaktu.wojewodztwo = wojewodztwo.Text;
            //idKontaktu.opis = opis.Text;
            model.Modify(kontaktPoEdycji);
            this.Close();
        }
        /// <summary>
        /// walidacja numeru telefonu (tylko cyfry)
        /// </summary>
        private void NumerOnly(object sender, KeyEventArgs e)
        {
            Regex wzor = new Regex(@"^D[0-9]+$");
            if (wzor.IsMatch(e.Key.ToString()))
                return;
            e.Handled = true;
        }
        /// <summary>
        /// walidacja numeru telefonu (ilość cyfr)
        /// </summary>
        private void Numerki(object sender, TextChangedEventArgs e)
        {
            if (numer.Text.Length > 9)
            {
                numer.Text = numer.Text.Remove(numer.Text.Length - 1);
                numer.CaretIndex = numer.Text.Length;
            }
        }
        /// <summary>
        /// walidacja daty urodzenia
        /// </summary>
        private void Data(object sender, SelectionChangedEventArgs e)
        {
            if (data.SelectedDate > DateAndTime.Today)
            {
                MessageBox.Show("Proszę podać prawidłową datę.");
                data.SelectedDate = null;
            }
        }
    }
}
