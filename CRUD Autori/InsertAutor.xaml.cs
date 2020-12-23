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

namespace CRUD_Autori {
    /// <summary>
    /// Interaction logic for InsertAutor.xaml
    /// </summary>
    public partial class InsertAutor : Window {

        PostoviDataContext PostoviDC = new PostoviDataContext();

        public InsertAutor() {
            InitializeComponent(); 
        }
         
        private void BtnNovi_Click(object sender, RoutedEventArgs e) {
              
             
            if (!String.IsNullOrEmpty(tbIme.Text) && !String.IsNullOrEmpty(tbPrezime.Text) && !String.IsNullOrEmpty(tbUsername.Text) && !String.IsNullOrEmpty(tbEmail.Text) && !String.IsNullOrEmpty(tbPass.Text) && !String.IsNullOrEmpty(cmbRole.Text)) {

            var korisnici = (from k in PostoviDC.Korisniks
                             orderby k.KorisnikID descending
                    select k).SingleOrDefault();

                int lastIndex = int.Parse(korisnici.KorisnikID.ToString() + 1);
                Korisnik noviAutor = new Korisnik {
                    KorisnikID = lastIndex,
                    Role = "2",
                    Username = tbUsername.Text,
                    Email = tbEmail.Text,
                    Pasword = tbPass.Text,
                    Ime = tbIme.Text,
                    Prezime = tbPrezime.Text,
                    Datum = Convert.ToDateTime("2020-11-11")
                };

                PostoviDC.Korisniks.InsertOnSubmit(noviAutor);

                try {
                    PostoviDC.SubmitChanges();
                    MessageBox.Show("Uspešno kreiran novi autor", "Obaveštenje o kreiranju autora", MessageBoxButton.OK, MessageBoxImage.Information); 
                    reset();

                } catch (Exception ex) {
                    MessageBox.Show("Došlo je do greške, molimo vas pokušajte ponovi", "Obavestenje o kreiranju autora", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }

            } else { 
                MessageBox.Show("Došlo je do greške, sva polja su obavezna", "Obaveštenje o kreiranju autora", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void reset() {
            tbIme.Text = tbPrezime.Text = tbUsername.Text = tbEmail.Text = tbPass.Text = "";
            cmbRole.SelectedIndex = -1;
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e) {
            reset();
        }
    }
}
