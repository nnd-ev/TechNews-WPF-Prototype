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

namespace Categories {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        CategoriesDataContext CategorisDC = new CategoriesDataContext();

        public MainWindow() {
            InitializeComponent();
            puniComboKat();
        }
        private void puniComboKat() {

            var cat = (from k in CategorisDC.Kategorijas
                       select k);
            cmbKategorije.ItemsSource = cat;
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e) {
            string novaKat = tbKategorija.Text;

            var kategorijeUpit = (from k in CategorisDC.Kategorijas
                                  select k);

            int KatID = kategorijeUpit.Count() + 1;

            int proveraPostojanja = kategorijeUpit.Where(x => x.NazivKategorije == novaKat).Count();

            if (proveraPostojanja == 0) {
                Kategorija nova = new Kategorija {
                    KategorijaID = KatID,
                    NazivKategorije = novaKat
                };

                CategorisDC.Kategorijas.InsertOnSubmit(nova);
                try {
                    CategorisDC.SubmitChanges();
                    MessageBox.Show("Uspesno dodata kategorija " + novaKat);
                    reset();
                } catch (Exception) {
                    MessageBox.Show("Doslo je do greske prilikom unosa nove kategorije, pokusajte ponovo ", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                } finally {
                    puniComboKat();
                }
            } else {
                    MessageBox.Show("Kategorija sa istim imenom vec postoji u bazi. Pokusajte sa drugim nazivom kategorije", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnObrisi_Click(object sender, RoutedEventArgs e) {
            int katID = ((Kategorija)cmbKategorije.SelectedItem).KategorijaID;
            var deleteUpit = (from k in CategorisDC.Kategorijas
                              where k.KategorijaID == katID
                              select k).SingleOrDefault();

             
            MessageBoxResult deleteRes = MessageBox.Show("Da li ste sigurni, da zelite da obrisete selektovani post?", "Brisanje", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(deleteRes == MessageBoxResult.Yes) {

                CategorisDC.Kategorijas.DeleteOnSubmit(deleteUpit);
                try {

                    CategorisDC.SubmitChanges();
                    MessageBox.Show("Uspesno obrisana kategorija");
                } catch (Exception ex) {
                    MessageBox.Show("Greska prilikom brisanje, molimo vas pokusajte ponovo", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                } finally {
                    reset();
                    puniComboKat();
                }
            }
        }

        private void BtnIzmeni_Click(object sender, RoutedEventArgs e) {
            if (!String.IsNullOrEmpty(tbKategorija.Text)) {

            int katID = ((Kategorija)cmbKategorije.SelectedItem).KategorijaID;
            var updateKat = (from k in CategorisDC.Kategorijas
                              where k.KategorijaID==katID
                              select k).SingleOrDefault();

            updateKat.NazivKategorije = tbKategorija.Text;

            try {
                CategorisDC.SubmitChanges();
                MessageBox.Show("Usesno izmenenja kategorija", "Izmena", MessageBoxButton.OK, MessageBoxImage.Information);
                } catch (Exception ex) {
                MessageBox.Show("Greska prilikom izmene kategorije, molimo vas pokusajte ponovo", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            } finally {
                    reset();
                puniComboKat();
            }
            } else {
                MessageBox.Show("Obavezan je novi naziv kategorije", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void CmbKategorije_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cmbKategorije.SelectedIndex != -1) {
            tbKategorija.Text = ((Kategorija)cmbKategorije.SelectedItem).NazivKategorije;
            }
        }
     
        private void reset() {
            tbKategorija.Text = cmbKategorije.Text="";
            cmbKategorije.SelectedIndex = -1;
        }
    }
}
