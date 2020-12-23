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

namespace ObicanKorisnik {
    /// <summary>
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Window {
        PostoviDataContext PostDC = new PostoviDataContext();
        public Profil(int profilID) {
            InitializeComponent();
            tbProfilID.Text = profilID.ToString();
            PopuniSve();
        }

        private void PopuniSve() {
            var User = (from k in PostDC.Korisniks
                        where k.KorisnikID == 3
                        select k).Single();
            tbEmail.Text = User.Email;
            tbUsername.Text = User.Username;
            tbPassword.Text = User.Pasword; 
        }

        private void resetuj() {
            tbEmail.Text = tbUsername.Text = tbPassword.Text = tbPasswordConfirm.Text = "";
        }
        private void enableFields(bool value) {
            tbEmail.IsEnabled = tbUsername.IsEnabled = tbPassword.IsEnabled = tbPasswordConfirm.IsEnabled = value;
        }

        private void BtnIzmeni_Click(object sender, RoutedEventArgs e) {

            if(!String.IsNullOrEmpty(tbEmail.Text) && !String.IsNullOrEmpty(tbUsername.Text) && !String.IsNullOrEmpty(tbPassword.Text) && !String.IsNullOrEmpty(tbPasswordConfirm.Text)) {

            

            var User = (from k in PostDC.Korisniks
                        where k.KorisnikID == int.Parse(tbProfilID.Text)
                        select k).Single();

            User.Email = tbEmail.Text;
            User.Username = tbUsername.Text;
            User.Pasword = tbPassword.Text;

            try {
                PostDC.SubmitChanges();
                MessageBox.Show("Podaci su uspešno izmenjeni", "Obaveštenje o izmeni profila", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (Exception ex) {
                MessageBox.Show("Došlo je do greške prilikom izmene profila, molimo vas pokušajte ponovo.", "Obaveštenje o izmeni profila", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            } else {
                MessageBox.Show("Svi podaci su obavezni.", "Obaveštenje o izmeni profila", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BtnOdustani_Click(object sender, RoutedEventArgs e) {
            resetuj();
            enableFields(false);
        }

        private void BtnEnableIzmenu_Click(object sender, RoutedEventArgs e) {
            enableFields(true);
        }

        private void BtnOdjava_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Došlo je do greške prilikom odjavljivanja, molimo vas pokušajte ponovo.", "Obaveštenje o odjavi sa profila", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
