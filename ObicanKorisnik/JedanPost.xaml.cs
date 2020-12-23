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
    /// Interaction logic for JedanPost.xaml
    /// </summary>
    public partial class JedanPost : Window {
        PostoviDataContext PostDC = new PostoviDataContext();


        public JedanPost(int idPosta) {
            InitializeComponent();
            tbPostID.Text = idPosta.ToString();
            fillAllData(idPosta);
            prikaziLikeDislike();
            promenaBookmarkBtn();
        }

        private void promenaBookmarkBtn() {
            var proveraBook = (from b in PostDC.Bookmarks
                               where b.PostID == int.Parse(tbPostID.Text)
                               select b).SingleOrDefault();
            if(proveraBook == null) {
                btnBookmark.Content = "Dodaj u bookmark";
            } else {
                btnBookmark.Content = "Izbaci iz bookmarka";
            }
        }

        private void fillAllData(int PostID) {
            TextRange rtbText = new TextRange(rtbPrikaz.Document.ContentStart, rtbPrikaz.Document.ContentEnd);
            var selektuj = (from p in PostDC.Posts
                            where p.PostID == PostID
                            select p).SingleOrDefault();

            StringBuilder sb = new StringBuilder();
            sb.Append(selektuj.Naslov);
            sb.Append("\n");
            sb.Append(selektuj.Sadrzaj);

            rtbText.Text = sb.ToString();
        }
        private void prikaziLikeDislike() {
            var ocene = (from o in PostDC.Ocenas
                         where o.PostID.Equals(tbPostID.Text)
                         select o);
            tbBrLike.Text = ocene.Where(x => x.Ocena1 == true).Count().ToString();
            tbBrDislike.Text = ocene.Where(x => x.Ocena1 == false).Count().ToString();

            //var postovi = (from p in PostDC.Posts
            //               where p.PostID == int.Parse(tbPostID.Text)
            //               select p).SingleOrDefault();
            //tbBrLike.Text = postovi.Like_.ToString();
            //tbBrDislike.Text = postovi.Dislike_.ToString(); 
        }
         
        private void BtnBookmark_Click(object sender, RoutedEventArgs e) {

            var checkBook = (from b in PostDC.Bookmarks
                             where b.PostID == int.Parse(tbPostID.Text) && b.KorisnikID == 1
                             select b).SingleOrDefault();

            var MaxBookId = (from b in PostDC.Bookmarks
                             orderby b.BookmarkID descending
                             select b).Take(1).Single();

            if (checkBook == null) { 
                //insert
                Bookmark noviBook = new Bookmark {
                    BookmarkID = int.Parse(MaxBookId.BookmarkID.ToString() + 1),
                    //BookmarkID = 1,
                    PostID = int.Parse(tbPostID.Text),
                    KorisnikID = 1
                };

                PostDC.Bookmarks.InsertOnSubmit(noviBook);
                promenaBookmarkBtn();
                try {
                    PostDC.SubmitChanges();
                    MessageBox.Show("Uspešno dodat postu u bookmark.", "Obaveštenje o bookmarku", MessageBoxButton.OK, MessageBoxImage.Information);
                } catch (Exception ex) {
                    MessageBox.Show("Došlo je do greške prilikom dodavanja posta u bookmark, pokušajte ponovo.", "Obaveštenje o bookmarku", MessageBoxButton.OK, MessageBoxImage.Error);
                } finally {
                    promenaBookmarkBtn();
                } 
            } else {
                PostDC.Bookmarks.DeleteOnSubmit(checkBook);
                try {
                    PostDC.SubmitChanges();
                    MessageBox.Show("Uspešno izbače postu iz bookmarka.", "Obaveštenje o bookmarku", MessageBoxButton.OK, MessageBoxImage.Information);
                } catch (Exception ex) {
                    MessageBox.Show("Došlo je do greške prilikom brisanja posta iz bookmarka, pokušajte ponovo.", "Obaveštenje o bookmarku", MessageBoxButton.OK, MessageBoxImage.Error);
                } finally {
                    promenaBookmarkBtn();
                }

            } 
        }


        private void BtnDodajKom_Click(object sender, RoutedEventArgs e) { 
            InsertKomentar novKom = new InsertKomentar(int.Parse(tbPostID.Text));
            novKom.ShowDialog(); 
        }

        //kreiraj triger za ocene

        private void BtnOcena_Click(object sender, RoutedEventArgs e) {


            int postID = int.Parse(tbPostID.Text);
            var proveraOcene = (from o in PostDC.Ocenas
                        where o.PostID == postID
                        && o.KorisnikID == 1
                        select o).SingleOrDefault();

            var maxOcenaID = (from o in PostDC.Ocenas
                              orderby o.OcenaID descending
                              select o).Take(1).SingleOrDefault();
             
            //int ocena;
            bool ocenaSada;
             
            var senderBtn = sender as Button;
            if (senderBtn.Content.ToString() == "Like") {
                ocenaSada = true;
                //ocena = 1;
            } else {
                ocenaSada = false;
                //ocena = 0;
            }
            
            //ako je ocenjen proveri da li je ocena like ili dislike
            //ako je like i sada o5 like onda obrisi ocenu
            //ako je like a sada dislike onda update ocenu
            //i obrnuto

            if (proveraOcene != null) {
                MessageBox.Show("nije null");
                bool ocenaPre = Convert.ToBoolean(proveraOcene.Ocena1);

                if (ocenaPre == true) {
                    if (ocenaSada == true) {
                        PostDC.Ocenas.DeleteOnSubmit(proveraOcene);
                        try { 
                            PostDC.SubmitChanges();
                            MessageBox.Show("obrisana ocena");
                        } catch (Exception ex) {
                            MessageBox.Show("Došlo je do greške prilikom ocenjivanja posta. Pokušajte ponovo", "Obaveštenje o ocenjivanju posta", MessageBoxButton.OK, MessageBoxImage.Error);
                            throw;
                        } finally {
                            prikaziLikeDislike();
                        }
                    } else {
                        proveraOcene.Ocena1 = false; 
                        try {
                            PostDC.SubmitChanges();
                        MessageBox.Show("dodat dislike");

                        } catch (Exception ex) {
                            MessageBox.Show("Došlo je do greške prilikom ocenjivanja posta. Pokušajte ponovo", "Obaveštenje o ocenjivanju posta", MessageBoxButton.OK, MessageBoxImage.Error);
                        } finally {
                            prikaziLikeDislike();
                        }
                    }
                } else if (ocenaPre == false) {
                    if (ocenaSada == false) {
                        PostDC.Ocenas.DeleteOnSubmit(proveraOcene);
                        try {
                            PostDC.SubmitChanges(); 
                            MessageBox.Show("obrisana ocena");
                        } catch (Exception ex) {
                            MessageBox.Show("Došlo je do greške prilikom ocenjivanja posta. Pokušajte ponovo", "Obaveštenje o ocenjivanju posta", MessageBoxButton.OK, MessageBoxImage.Error);
                        } finally {
                            prikaziLikeDislike();
                        }
                    } else {
                 
                        proveraOcene.Ocena1 = true;
                        //PostDC.Ocenas.InsertOnSubmit(novaOcena);
                        try {
                            PostDC.SubmitChanges();
                        MessageBox.Show("dodat like");

                        } catch (Exception ex) {
                            MessageBox.Show("Došlo je do greške prilikom ocenjivanja posta. Pokušajte ponovo", "Obaveštenje o ocenjivanju posta", MessageBoxButton.OK, MessageBoxImage.Error);
                        } finally {
                            prikaziLikeDislike();
                        }
                    }
                }
            } else {
                MessageBox.Show("null je");
                if (ocenaSada == true) {
                    Ocena novaOcena = new Ocena {
                        OcenaID = int.Parse(maxOcenaID.OcenaID.ToString()) + 1,
                        //OcenaID = 1,
                        PostID = postID,
                        KorisnikID = 1,
                        Ocena1 = true
                    };

                    PostDC.Ocenas.InsertOnSubmit(novaOcena);
                   
                    try {
                        PostDC.SubmitChanges();
                        MessageBox.Show("dodat like");
                    } catch (Exception ex) {
                        MessageBox.Show("Došlo je do greške prilikom ocenjivanja posta. Pokušajte ponovo", "Obaveštenje o ocenjivanju posta", MessageBoxButton.OK, MessageBoxImage.Error);
                    } finally {
                        prikaziLikeDislike();
                    }
                } else {
                    Ocena novaOcena = new Ocena {
                        OcenaID = int.Parse(maxOcenaID.OcenaID.ToString()) + 1,
                        //OcenaID = 1,
                        PostID = postID,
                        KorisnikID = 1,
                        Ocena1 = false
                    };

                    PostDC.Ocenas.InsertOnSubmit(novaOcena);
                    MessageBox.Show("dodat dislike");
                    try {
                        PostDC.SubmitChanges();

                    } catch (Exception ex) {
                        MessageBox.Show("Došlo je do greške prilikom ocenjivanja posta. Pokušajte ponovo", "Obaveštenje o ocenjivanju posta", MessageBoxButton.OK, MessageBoxImage.Error);
                    } finally {
                        prikaziLikeDislike();
                    }
                }
            }

        } 
    }
}
