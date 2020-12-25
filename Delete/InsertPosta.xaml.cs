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
    /// Interaction logic for InsertPosta.xaml
    /// </summary>
    public partial class InsertPosta : Window
    {

        PostoviDataContext PostoviDC = new PostoviDataContext();

        public InsertPosta()
        {
            InitializeComponent();
            puniCombo();
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

        private void BtnInsert_Click(object sender, RoutedEventArgs e) {
            TextRange rtbText = new TextRange(tbSadrzaj.Document.ContentStart, tbSadrzaj.Document.ContentEnd);
            if (!String.IsNullOrEmpty(tbNaslov.Text) && !String.IsNullOrEmpty(tbNaslov.Text) && !String.IsNullOrEmpty(rtbText.ToString())) {

                Post noviPost = new Post {
                    PostID = 5,
                    KorisnikID = 3,
                    KategorijaID = ((Kategorija)cmbKategorija.SelectedItem).KategorijaID,
                    Naslov = tbNaslov.Text,
                    Sadrzaj = rtbText.ToString(),
                    Like_ = 0,
                    Dislike_ = 0,
                    Datum = Convert.ToDateTime("2020-11-11")
                };
                    PostoviDC.Posts.InsertOnSubmit(noviPost);

                try {
                    PostoviDC.SubmitChanges();
                    MessageBox.Show("Uspesno kreiran novi post", "Uspesan unos", MessageBoxButton.OK, MessageBoxImage.Information);

                    reset();
                    
                } catch (Exception ex) {
                    MessageBox.Show("Doslo je do greske, molimo vas pokusajte ponovi", "Obavestenje o upisu u bazu", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                } 

            } else {
                MessageBox.Show("Sva polja su obavezna");
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e) {
            reset();
        }

        private void TbSadrzaj_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void BtnNovaKat_Click(object sender, RoutedEventArgs e) {
            UpravljanjeKategorijamaxaml novaKat = new UpravljanjeKategorijamaxaml();
            novaKat.ShowDialog();
        }
    }
}
