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
    /// Logika interakcji dla klasy BazaDodaj.xaml
    /// </summary>
    public partial class BazaDodaj : Window
    {
        modelKontakt model;
        public MainWindow w1 = new MainWindow();
        public BazaDodaj(MainWindow w1, modelKontakt model)
        {
            this.model = model;
            this.w1 = w1;
            InitializeComponent();
            
        }
        private void Baza(object sender, RoutedEventArgs e)
        {
                model.NowaTabela(nazwa.Text);
                this.Close();
                w1.Wyczysc();
                w1.Window_Activated(null, null);
        }
    }
}
