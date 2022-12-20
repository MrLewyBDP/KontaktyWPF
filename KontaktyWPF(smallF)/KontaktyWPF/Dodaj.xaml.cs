using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>
    public partial class Dodaj : Window
    {
        modelKontakt model;
        public Dodaj(modelKontakt model)
        {
            this.model = model;
            InitializeComponent();
        }
        private void kontakt(object sender, RoutedEventArgs e)
        {
            var plec = "Mezczyzna";
            if(pleck.IsChecked == true)
            {
                plec = "Kobieta";
            }
            var dataConvert = data.DisplayDate;
            KontaktBezId kon = new KontaktBezId(imie.Text, nazwisko.Text, numer.Text, dataConvert.ToShortDateString(), wojewodztwo.Text, plec, opis.Text);
            model.Add(kon);
            this.Close();
            

        }
        private void NumerKlik(object sender, KeyEventArgs e)
        {
            Regex wzor = new Regex(@"^D[0-9]$");
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
