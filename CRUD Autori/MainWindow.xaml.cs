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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD_Autori {
   
    public partial class MainWindow : Window {

        PostoviDataContext PostoviDC = new PostoviDataContext();

        public MainWindow() {
            InitializeComponent();
            puniGrid();
        }
          

        private void puniGrid() { 
           
            var korisnici = (from k in PostoviDC.Korisniks
                           select k); 

            foreach(var k in korisnici) {
                if(k.Role == "2") {
                    k.Role = "Autor";
                } else {
                    k.Role = "Urednik";
                }
            }
            glavniGrid.ItemsSource = korisnici.Where(x => x.Role == "2" || x.Role == "3");
            //glavniGrid.ItemsSource = korisnici; 
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e) {
            InsertAutor noviAutor = new InsertAutor();  
            noviAutor.ShowDialog();

            puniGrid();
        }

        private void BtnObrisi_Click(object sender, RoutedEventArgs e) {

            MessageBoxResult deleteRes = MessageBox.Show("Da li ste sigurni, da želite da obrišete selektovani post?", "Obaveštenje o brisanju autora", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (deleteRes == MessageBoxResult.Yes) {

                dynamic row = glavniGrid.SelectedItem;
                int korisnikID = row.KorisnikID;
                  
                var deleteUpit = (from k in PostoviDC.Korisniks
                                  where k.KorisnikID == korisnikID
                                  select k);

                PostoviDC.Korisniks.DeleteOnSubmit(deleteUpit.Single());

                try {

                    PostoviDC.SubmitChanges();
                    MessageBox.Show("Uspešno obrisan autor", "Obaveštenje o brisanju autora", MessageBoxButton.OK, MessageBoxImage.Information);

                } catch (Exception ex) {
                    MessageBox.Show("Došlo je do greske prilikom brisanja"+ex.Message, "Obaveštenje o brisanju autora" , MessageBoxButton.OK, MessageBoxImage.Error);
                } finally {
                    puniGrid();
                }
            }
        }

        private void BtnIzmeni_Click(object sender, RoutedEventArgs e) {

            dynamic row = glavniGrid.SelectedItem;
            int KorisnikID = row.KorisnikID;

            UpdateAutor izmeniAutora = new UpdateAutor(KorisnikID);
            izmeniAutora.ShowDialog();
        }
    }
}
