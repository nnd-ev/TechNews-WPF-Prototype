using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Insertovanja
{
    /// <summary>
    /// Interaction logic for Prijava.xaml
    /// </summary>
    public partial class Prijava : Window
    {
        KorisniciDataContext KorisniciDC = new KorisniciDataContext();
        public Prijava()
        {
            InitializeComponent();
        }

        private void BtnRegistracija_Click(object sender, RoutedEventArgs e) {
            Registracija prijava = new Registracija();
            prijava.ShowDialog();
        } 
        private void BtnPrijava_Click(object sender, RoutedEventArgs e) {
            if (!String.IsNullOrEmpty(tbEmail.Text) && !String.IsNullOrEmpty(tbSifra.Text)) {
                var proveraUsera = (from k in KorisniciDC.Korisniks
                                    where k.Email == tbEmail.Text &&
                                    k.Pasword == tbSifra.Text
                                    select k).Count();

            if(proveraUsera == 0) {
                MessageBox.Show("Korisnik sa unetim parametrima ne postoji u našoj bazi, molimo kreirajte nalog pre prijave na nalog.", "Obaveštenje o prijavi na nalog", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                MessageBox.Show("Uspesno ste se prijavili", "Obaveštenje o prijavi na nalog", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            } else {
                MessageBox.Show("Sva polja su obavezna.", "Obaveštenje o registraciji", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
