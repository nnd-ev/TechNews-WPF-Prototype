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

namespace Delete {
     
    public partial class MainWindow : Window {

        PostoviDataContext PostoviDC = new PostoviDataContext();
 

        public MainWindow() {
            InitializeComponent();
            puniGrid();
        } 

        private void puniGrid() {

            var postovi = (from p in PostoviDC.Posts
                           join k in PostoviDC.Kategorijas
                           on p.KategorijaID equals k.KategorijaID
                           select new {p.PostID, p.KorisnikID, p.Naslov, p.Sadrzaj, k.KategorijaID, k.NazivKategorije });

            glavniGrid.ItemsSource = postovi;
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e) {
            InsertPosta noviPost = new InsertPosta();

            noviPost.ShowDialog();
        }

        private void BtnObrisi_Click(object sender, RoutedEventArgs e) {
             
            MessageBoxResult deleteRes = MessageBox.Show("Da li ste sigurni, da zelite da obrisete selektovani post?", "Brisanje", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(deleteRes == MessageBoxResult.Yes) {

                dynamic row = glavniGrid.SelectedItem;
                int PostID = row.PostID;

                var deleteUpit = (from p in PostoviDC.Posts
                                  where p.PostID == PostID
                                  select p).SingleOrDefault();

                PostoviDC.Posts.DeleteOnSubmit(deleteUpit);
                try {

                    PostoviDC.SubmitChanges();
                    MessageBox.Show("Uspesno obrisan post", "Obavestenje o brisanju", MessageBoxButton.OK, MessageBoxImage.Information);
                } catch (Exception ex) {
                    MessageBox.Show("Doslo je do greske prilikom brisanja posta", "Obavestenje o brisanju", MessageBoxButton.OK, MessageBoxImage.Error);
                } finally {
                    puniGrid();
                }
            }
        }

        private void BtnIzmeni_Click(object sender, RoutedEventArgs e) {
            
            dynamic row = glavniGrid.SelectedItem;
            int postID =  row.PostID ;

            UpdatePost izmeniPost = new UpdatePost(postID); 
            izmeniPost.ShowDialog(); 
        }
    }
}
