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
     
    public partial class Postovi : Window {
        PostoviDataContext PostDC = new PostoviDataContext();
        public Postovi() {
            InitializeComponent();
            puniGrid();
        } 

        private void puniGrid() {
            if (String.IsNullOrEmpty(tbSearch.Text)) {

            var postoviUpit = (from p in PostDC.Posts
                               join k in PostDC.Kategorijas
                               on p.KategorijaID equals k.KategorijaID
                               select new { p.PostID, p.KorisnikID, p.Naslov, p.Sadrzaj, k.KategorijaID, k.NazivKategorije });

            glavniGrid.ItemsSource = postoviUpit;
            } else {
              
                glavniGrid.ItemsSource = null;
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e) {
            var prikazi = (from p in PostDC.Posts
                           where p.Naslov.StartsWith(tbSearch.Text)
                           select p);
            puniGrid();
            lbPrikaziSearchData.Visibility = System.Windows.Visibility.Visible;
            if (!String.IsNullOrEmpty(tbSearch.Text)) {
                lbPrikaziSearchData.ItemsSource = prikazi;
                glavniGrid.ItemsSource = prikazi;
            } else if(tbSearch.Text == ""){
                lbPrikaziSearchData.Visibility = System.Windows.Visibility.Hidden;
                lbPrikaziSearchData.ItemsSource = null;
            }
        }
         

        private void LbPrikaziSearchData_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(lbPrikaziSearchData.ItemsSource != null) {
                int postID = ((Post)lbPrikaziSearchData.SelectedItem).PostID;

                //var zaPrikaz = (from p in PostDC.Posts
                //                where p.PostID == postID
                //                select p);
                var zaPrikaz = (from p in PostDC.Posts
                join k in PostDC.Kategorijas
                on p.KategorijaID equals k.KategorijaID
                where p.PostID == postID
                select new { p.PostID, p.KorisnikID, p.Naslov, p.Sadrzaj, k.KategorijaID, k.NazivKategorije });

                
                puniGrid();
                glavniGrid.ItemsSource = zaPrikaz;  
            }
            lbPrikaziSearchData.Visibility = System.Windows.Visibility.Collapsed;
        }
         
        private void BtnOtvori_Click(object sender, RoutedEventArgs e) {
            dynamic row = glavniGrid.SelectedItem;
            int postID = row.PostID;
            JedanPost otvoriPost = new JedanPost(postID);
            otvoriPost.ShowDialog();
        }

        private void BtnProfil_Click(object sender, RoutedEventArgs e) {
            int userID = 1;
            Profil profil = new Profil(userID);
            profil.ShowDialog(); 
        }
    }
}
