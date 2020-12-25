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
     
    public partial class UpdateAutor : Window {
        PostoviDataContext PostoviDC = new PostoviDataContext();
        public UpdateAutor(int idKorisnika) {
            InitializeComponent();
            tbKorisnikID.Text = idKorisnika.ToString();
            fillAllData(idKorisnika);
        }

        private void fillAllData(int idKorisnika) {
            
            var selektuj = (from p in PostoviDC.Korisniks
                            where p.KorisnikID == idKorisnika
                            select p).SingleOrDefault();

            tbIme.Text = selektuj.Ime;
            tbPrezime.Text = selektuj.Prezime;
            tbUsername.Text = selektuj.Username;
            tbEmail.Text = selektuj.Email;
            tbPass.Text = selektuj.Pasword;
            if(selektuj.Role == "2") {
                cmbRole.SelectedIndex = 0;
            } else {
                cmbRole.SelectedIndex = 1;

            } 
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e) {
            if (!String.IsNullOrEmpty(tbIme.Text) && !String.IsNullOrEmpty(tbPrezime.Text) && !String.IsNullOrEmpty(tbUsername.Text) && !String.IsNullOrEmpty(tbEmail.Text) && !String.IsNullOrEmpty(tbPass.Text) && !String.IsNullOrEmpty(cmbRole.Text)) {
                 

                var updateAutora = (from p in PostoviDC.Korisniks
                                  where p.KorisnikID.Equals(tbKorisnikID.Text)
                                  select p).SingleOrDefault();

                int RoleID = 0;
                if (cmbRole.SelectedIndex == 0) {
                    RoleID = 2;
                } else {
                    RoleID = 3;
                }
                 
                updateAutora.Role = RoleID.ToString();
                updateAutora.Ime = tbIme.Text;
                updateAutora.Prezime = tbPrezime.Text;
                updateAutora.Email = tbEmail.Text;
                updateAutora.Username = tbUsername.Text;
                updateAutora.Pasword = tbPass.Text;
                 
                try {
                    PostoviDC.SubmitChanges();
                    MessageBox.Show("Uspešno izmenjen autor", "Obaveštenje o izmeni autora", MessageBoxButton.OK, MessageBoxImage.Information); 
                    reset();

                } catch (Exception ex) {
                    MessageBox.Show("Došlo je do greske prilikom izmene autora, molimo vas pokusajte ponovi", "Obaveštenje o izmeni autora", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                } 
            } else {
                MessageBox.Show("Sva polja su obavezna", "Obaveštenje o izmeni autora", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnReset_Click(object sender, RoutedEventArgs e) {
            reset();
            }

        private void reset() {
            tbIme.Text = tbPrezime.Text = tbUsername.Text = tbEmail.Text = tbPass.Text = "";
            cmbRole.SelectedIndex = -1;
        }
    }
}
