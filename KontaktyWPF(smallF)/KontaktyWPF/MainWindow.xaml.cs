using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KontaktyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// instancja klasy modelKontakt, która obsługuje operacje na bazie danych
        /// </summary>
        public static modelKontakt model = new modelKontakt();
        /// <summary>
        /// lista z danymi całego kontaktu
        /// </summary>

        public static List<Kontakt> listaKontaktow = new List<Kontakt>
        {
           
        };
        /// <summary>
        /// lista z imieniem, nazwiskiem i numerem telefonu kontaktu (używana w datagridzie)
        /// </summary>

        public static int id = -1;
        public static Kontakt kontakt1;
        public MainWindow()
        {
            InitializeComponent();
            DataGridList.IsReadOnly = true;
            var newid = DataGridList.SelectedIndex;
            id = newid;
        }
        /// <summary>
        /// otwarcie okna dodawania kontaktu
        /// </summary>
        private void DodajKontakt(object sender, RoutedEventArgs e)
        {
            Window dodaj = new Dodaj(model);
            dodaj.ShowDialog();
        }
        /// <summary>
        /// otwarcie okna modyfikacji kontaktu
        /// </summary>
        private void EdytujKontakt(object sender, RoutedEventArgs e)
        {
            //var newid = DataGridList.SelectedIndex;
            if (DataGridList.SelectedItem != null)
            {
                var kontaktDoModyfikacji = (Kontakt)DataGridList.SelectedItem;
                var newid = kontaktDoModyfikacji.id;
                var imieM = Convert.ToString(kontaktDoModyfikacji.imie);
                var nazwiskoM = Convert.ToString(kontaktDoModyfikacji.nazwisko);
                var numerM = kontaktDoModyfikacji.numer_tel;
                var plecM = "Mezczyzna";
                if (kontaktDoModyfikacji.plec == "Mezczyzna")
                {
                    plecM = "Mezczyzna";
                }
                if (kontaktDoModyfikacji.plec == "Kobieta")
                {
                    plecM = "Kobieta";
                }
                var wojewodztwoM = kontaktDoModyfikacji.wojewodztwo;
                var opisM = Convert.ToString(kontaktDoModyfikacji.opis);
                Kontakt kontakt = new Kontakt(imieM, nazwiskoM, numerM, kontaktDoModyfikacji.data_ur, wojewodztwoM, plecM, opisM, newid);

                Window modyfikuj = new Modyfikuj(kontakt, model);
                modyfikuj.ShowDialog();
            }

        }
        /// <summary>
        /// odświeżanie listy kontaktów (po raz pierwszy)
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            Window_Activated(null, null);

        }
        /// <summary>
        /// odświeżenie listy kontaktów oraz wyczyszczenie tekstu wyszukiwarki
        /// </summary>
        public void Window_Activated(object sender, EventArgs e)
        {
            string imie = wysz.Text;
            int NrStrony = System.Convert.ToInt32(NumerStrony.Content);
            ProgressBar.Value = Pages();
            DataGridList.ItemsSource = null;
            if (imie == null)
            {
                imie = "";
            }
            AkBaz.Content = model.AktualnaBaza();
            model.Przeładowanie(imie, NrStrony);
            DataGridList.ItemsSource = listaKontaktow;
            
        }
        /// <summary>
        /// usunięcie zaznaczonego kontaktu
        /// </summary>
        private void UsunKontakt(object sender, RoutedEventArgs e)
        {
            
            if (DataGridList.SelectedItem == null) return;
            var kontakt = (Kontakt)DataGridList.SelectedItem;
            model.Delete(kontakt.id);
            Window_Activated(null, null);
            Wyczysc();
        }
        /// <summary>
        /// wyszukiwarka
        /// </summary>
        private void Wyszukiwarka(object sender, TextChangedEventArgs e)
        {
            string fraza = wysz.Text;
            int NrStrony = Convert.ToInt32(NumerStrony.Content);


            model.Przeładowanie(fraza, NrStrony);
            Window_Activated(null, null);
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void NowaBaza(object sender, RoutedEventArgs e)
        {
            BazaDodaj bazaDodaj = new BazaDodaj(this, model);
            bazaDodaj.ShowDialog();
        }
        public double Pages()
        {
            double i = 0;
            double NumerStrony2 = Convert.ToDouble(NumerStrony.Content);
            double IloscStronListy = Math.Ceiling((model.Pasek(wysz.Text)) / 4);
            if (IloscStronListy > 0)
            {
                i = 100 / (IloscStronListy / NumerStrony2);
            }
            return i;
        }
        public void Wyczysc()
        {
            NumerStrony.Content = "1";
            AkBaz.Content = model.AktualnaBaza();
            model.Przeładowanie("", 1);
            DataGridList.ItemsSource = null;
            DataGridList.ItemsSource = listaKontaktow;
        }
        private void Lewo(object sender, RoutedEventArgs e)
        {
            if (System.Convert.ToInt32(NumerStrony.Content) >= 2)
            {

                NumerStrony.Content = (System.Convert.ToInt32(NumerStrony.Content) - 1).ToString();

            }
            Window_Activated(null, null);

        }
        private void Prawo(object sender, RoutedEventArgs e)
        {

            if (System.Convert.ToInt32(NumerStrony.Content) >= 1)
            {
                NumerStrony.Content = (System.Convert.ToInt32(NumerStrony.Content) + 1).ToString();
                Window_Activated(null, null);
                if (DataGridList.Items.Count == 0)
                {
                    NumerStrony.Content = (System.Convert.ToInt32(NumerStrony.Content) - 1).ToString();
                    Window_Activated(null, null);
                }
                Window_Activated(null, null);
            }

        }
    }
}
