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
            imie.Text = kontakt.Imie;
            nazwisko.Text = kontakt.Nazwisko;
            numer.Text = kontakt.NumerTelefonu;
            data.Text = Convert.ToString(kontakt.DataUrodzenia);
            if(kontakt.Plec == "Mezczyzna")
            {
                m1.IsChecked = true;
            }
            else if (kontakt.Plec == "Kobieta")
            {
                k1.IsChecked = true;
            }
            wojewodztwo.Text = kontakt.Wojewodztwo;
            opis.Text = kontakt.Opis;
            this.kontakt = kontakt;
        }
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
            Kontakt kontaktPoEdycji = new Kontakt(imie.Text, nazwisko.Text, numer.Text, data.Text, wojewodztwo.Text, plec, opis.Text, kontakt.ID);
            model.Modify(kontaktPoEdycji);
            this.Close();
        }
        private void NumerOnly(object sender, KeyEventArgs e)
        {
            Regex wzor = new Regex(@"^D[0-9]+$");
            if (wzor.IsMatch(e.Key.ToString()))
                return;
            e.Handled = true;
        }
        private void Numerki(object sender, TextChangedEventArgs e)
        {
            if (numer.Text.Length > 9)
            {
                numer.Text = numer.Text.Remove(numer.Text.Length - 1);
                numer.CaretIndex = numer.Text.Length;
            }
        }
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
