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
    
    public partial class InsertKomentar : Window {
        PostoviDataContext PostDC = new PostoviDataContext();

        public InsertKomentar(int idPosta) {
            InitializeComponent();
            tbPostID.Text = idPosta.ToString();
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e) {
            TextRange rtbText = new TextRange(tbSadrzaj.Document.ContentStart, tbSadrzaj.Document.ContentEnd);

            var maxIndeks = (from k in PostDC.Komentars
                             orderby k.KomentarID descending
                             select k).Take(1).Single();
             
            Komentar noviKom = new Komentar {
                KomentarID = int.Parse(maxIndeks.KomentarID.ToString()) + 1,
                PostID = int.Parse(tbPostID.Text),
                KorisnikID = 1,
                Sadrzaj = rtbText.Text,
                Allowed = false,
                Datum = Convert.ToDateTime("2020-11-11")
            };

            PostDC.Komentars.InsertOnSubmit(noviKom);
            try {
                PostDC.SubmitChanges();
                MessageBox.Show("Uspešno postavljen komentar", "Obaveštenje o ostavljanju komentara", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (Exception ex) {
                MessageBox.Show("Greška prilikom postavljanja komentara", "Obaveštenje o ostavljanju komentara", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }
    }
}
