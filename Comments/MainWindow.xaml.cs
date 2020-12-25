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

namespace Comments {
    
    public partial class MainWindow : Window {

        CommentsDataContext CommentsDC = new CommentsDataContext();

        public MainWindow() {
            InitializeComponent();
            puniGrid();
        }
         
        private void puniGrid() {

            var postovi = (from k in CommentsDC.Komentars
                           join p in CommentsDC.Posts
                           on k.PostID equals p.PostID   
                           select new {k.KomentarID, k.PostID, k.Sadrzaj, k.Allowed, p.Naslov});

            glavniGrid.ItemsSource = postovi.Where(x=> x.Allowed==false);
        }

        private void BtnObrisi_Click(object sender, RoutedEventArgs e) {

            MessageBoxResult deleteRes = MessageBox.Show("Da li ste sigurni, da zelite da obrisete selektovani komentar?", "Obavestenje o brisanju komentara", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (deleteRes == MessageBoxResult.Yes) {

                dynamic row = glavniGrid.SelectedItem;
                int komentarID = row.KomentarID;

                var deleteUpit = (from p in CommentsDC.Komentars
                                  where p.KomentarID== komentarID
                                  select p).SingleOrDefault();

                CommentsDC.Komentars.DeleteOnSubmit(deleteUpit);
                try {

                    CommentsDC.SubmitChanges();
                     MessageBox.Show("Uspesno obrisan komentar", "Obaveštenje o brisanju komentara", MessageBoxButton.OK, MessageBoxImage.Information);

                } catch (Exception ex) {
                    MessageBox.Show("Došlo je do greške prilikom brisanja komentara", "Obaveštenje o brisanju komentara", MessageBoxButton.OK, MessageBoxImage.Error);
                } finally {
                    puniGrid();
                }
            }
        }

        private void BtnIzmeni_Click(object sender, RoutedEventArgs e) {

            dynamic row = glavniGrid.SelectedItem;
            int komentID = row.KomentarID;

            var komentarUpit = (from k in CommentsDC.Komentars
                                where k.KomentarID == komentID
                                select k).Single();
            komentarUpit.Allowed = true;

            try {

                CommentsDC.SubmitChanges();

                 MessageBox.Show("Uspešno odobren komentar", "Obaveštenje o izmeni statusa komentara", MessageBoxButton.OK, MessageBoxImage.Information);

            } catch (Exception ex) {
                MessageBox.Show("Došlo je do greške prilikom izmene statusa komentara", "Obaveštenje o izmeni statusa komentara", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            } finally {
                puniGrid();
            } 
        }

    }
}
