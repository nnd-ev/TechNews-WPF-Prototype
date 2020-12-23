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
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        KorisniciDataContext KorisniciDC = new KorisniciDataContext();

        public Registracija()
        {
            InitializeComponent();
        }

        private void BtnRegistracija_Click(object sender, RoutedEventArgs e) {

            if(!String.IsNullOrEmpty(tbEmail.Text) && !String.IsNullOrEmpty(tbUsername.Text) && !String.IsNullOrEmpty(tbsifra.Text) && !String.IsNullOrEmpty(tbPotvrdaSifre.Text)) {

            var maxIndex = (from k in KorisniciDC.Korisniks
                            orderby k.KorisnikID descending
                            select k).Take(1).SingleOrDefault();

                var proveraDuplikata = (from k in KorisniciDC.Korisniks
                                        where k.Email == tbEmail.Text ||
                                        k.Username == tbUsername.Text
                                        select k).Count();

                if(tbsifra.Text != tbPotvrdaSifre.Text) {
                    MessageBox.Show("Sifra i potvrda sifre moraju biti iste.", "Obaveštenje o registraciji", MessageBoxButton.OK, MessageBoxImage.Error); 
                }else if(proveraDuplikata>0){
                    MessageBox.Show("Korisnik sa istim korisničkim imenom već postoji.", "Obaveštenje o registraciji", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                MessageBox.Show(maxIndex.KorisnikID.ToString());

            Korisnik noviKorisnik = new Korisnik {
                KorisnikID = int.Parse(maxIndex.KorisnikID.ToString()+ 1),
                Role = "1",
                Username = tbUsername.Text,
                Ime = null,
                Prezime = null,
                Email = tbEmail.Text,
                Pasword = tbsifra.Text,
                Datum = Convert.ToDateTime("2020/11/11")
            };

            KorisniciDC.Korisniks.InsertOnSubmit(noviKorisnik);

            try {
                KorisniciDC.SubmitChanges();
                MessageBox.Show("Uspešno ste se registrovali", "Obaveštenje o registraciji", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (Exception) {
                MessageBox.Show("Došlo je do greške prilikom registracije, molimo vas pokušajte ponovo.", "Obaveštenje o registraciji", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            } else {
                MessageBox.Show("Sva polja su obavezna.", "Obaveštenje o registraciji", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnPrijava_Click(object sender, RoutedEventArgs e) {
            Prijava prijava = new Prijava();
            prijava.ShowDialog();
        }
    }
}
