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

namespace Delete
{
    /// <summary>
    /// Interaction logic for UpdatePost.xaml
    /// </summary>
    public partial class UpdatePost : Window
    {
        PostoviDataContext PostoviDC = new PostoviDataContext();

        public UpdatePost(int idPosta) {
            InitializeComponent();
            puniCombo();
            tbPostID.Text = idPosta.ToString();
            fillAllData(idPosta);
        }
         
        private void fillAllData(int PostID) {
            TextRange rtbText = new TextRange(tbSadrzaj.Document.ContentStart, tbSadrzaj.Document.ContentEnd);
            var selektuj = (from p in PostoviDC.Posts
                            where p.PostID == PostID
                            select p).SingleOrDefault();
            tbNaslov.Text = selektuj.Naslov;
            cmbKategorija.SelectedIndex = int.Parse(selektuj.KategorijaID.ToString());
            rtbText.Text = selektuj.Sadrzaj;
        }
        private void puniCombo() {
            var kategorije = (from k in PostoviDC.Kategorijas
                              select k);

            cmbKategorija.ItemsSource = kategorije;
        }

        private void reset() {
            TextRange rtbText = new TextRange(tbSadrzaj.Document.ContentStart, tbSadrzaj.Document.ContentEnd);
            tbNaslov.Text = rtbText.Text = "";
            cmbKategorija.SelectedIndex = -1;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {
            TextRange rtbText = new TextRange(tbSadrzaj.Document.ContentStart, tbSadrzaj.Document.ContentEnd);
            if (!String.IsNullOrEmpty(tbNaslov.Text) && !String.IsNullOrEmpty(tbNaslov.Text) && !String.IsNullOrEmpty(rtbText.ToString())) {

                var updatePost = (from p in PostoviDC.Posts
                                  where p.PostID.Equals(tbPostID.Text)
                                  select p).SingleOrDefault();

                updatePost.Naslov = updatePost.Naslov;   
                updatePost.KategorijaID =  ((Kategorija)cmbKategorija.SelectedItem).KategorijaID;
                updatePost.Sadrzaj = rtbText.Text;


                try {
                    PostoviDC.SubmitChanges();
                    MessageBox.Show("Uspesno izmenjen post", "Obavestenje o izemni podataka", MessageBoxButton.OK, MessageBoxImage.Information);

                    reset();

                } catch (Exception ex) { 
                    MessageBox.Show("Doslo je do greske prilikom izmene posta, molimo vas pokusajte ponovi", "Obavestenje o izemni podataka", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }  
            } else {
                MessageBox.Show("Sva polja su obavezna");
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e) {
            reset();
        }

        private void BtnNovaKat_Click(object sender, RoutedEventArgs e) {
            UpravljanjeKategorijamaxaml novaKat = new UpravljanjeKategorijamaxaml();
            novaKat.ShowDialog();
        }
    }
}
