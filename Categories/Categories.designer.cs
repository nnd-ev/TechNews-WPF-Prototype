﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Categories
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TechNews")]
	public partial class CategoriesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertKomentar(Komentar instance);
    partial void UpdateKomentar(Komentar instance);
    partial void DeleteKomentar(Komentar instance);
    partial void InsertKorisnik(Korisnik instance);
    partial void UpdateKorisnik(Korisnik instance);
    partial void DeleteKorisnik(Korisnik instance);
    partial void InsertPost(Post instance);
    partial void UpdatePost(Post instance);
    partial void DeletePost(Post instance);
    partial void InsertKategorija(Kategorija instance);
    partial void UpdateKategorija(Kategorija instance);
    partial void DeleteKategorija(Kategorija instance);
    partial void InsertBookmark(Bookmark instance);
    partial void UpdateBookmark(Bookmark instance);
    partial void DeleteBookmark(Bookmark instance);
    #endregion
		
		public CategoriesDataContext() : 
				base(global::Categories.Properties.Settings.Default.TechNewsConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CategoriesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CategoriesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CategoriesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CategoriesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Komentar> Komentars
		{
			get
			{
				return this.GetTable<Komentar>();
			}
		}
		
		public System.Data.Linq.Table<Korisnik> Korisniks
		{
			get
			{
				return this.GetTable<Korisnik>();
			}
		}
		
		public System.Data.Linq.Table<Post> Posts
		{
			get
			{
				return this.GetTable<Post>();
			}
		}
		
		public System.Data.Linq.Table<Kategorija> Kategorijas
		{
			get
			{
				return this.GetTable<Kategorija>();
			}
		}
		
		public System.Data.Linq.Table<Bookmark> Bookmarks
		{
			get
			{
				return this.GetTable<Bookmark>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Komentar")]
	public partial class Komentar : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _KomentarID;
		
		private int _PostID;
		
		private int _KorisnikID;
		
		private string _Sadrzaj;
		
		private bool _Allowed;
		
		private System.DateTime _Datum;
		
		private EntityRef<Korisnik> _Korisnik;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnKomentarIDChanging(int value);
    partial void OnKomentarIDChanged();
    partial void OnPostIDChanging(int value);
    partial void OnPostIDChanged();
    partial void OnKorisnikIDChanging(int value);
    partial void OnKorisnikIDChanged();
    partial void OnSadrzajChanging(string value);
    partial void OnSadrzajChanged();
    partial void OnAllowedChanging(bool value);
    partial void OnAllowedChanged();
    partial void OnDatumChanging(System.DateTime value);
    partial void OnDatumChanged();
    #endregion
		
		public Komentar()
		{
			this._Korisnik = default(EntityRef<Korisnik>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KomentarID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int KomentarID
		{
			get
			{
				return this._KomentarID;
			}
			set
			{
				if ((this._KomentarID != value))
				{
					this.OnKomentarIDChanging(value);
					this.SendPropertyChanging();
					this._KomentarID = value;
					this.SendPropertyChanged("KomentarID");
					this.OnKomentarIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int PostID
		{
			get
			{
				return this._PostID;
			}
			set
			{
				if ((this._PostID != value))
				{
					this.OnPostIDChanging(value);
					this.SendPropertyChanging();
					this._PostID = value;
					this.SendPropertyChanged("PostID");
					this.OnPostIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KorisnikID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int KorisnikID
		{
			get
			{
				return this._KorisnikID;
			}
			set
			{
				if ((this._KorisnikID != value))
				{
					if (this._Korisnik.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKorisnikIDChanging(value);
					this.SendPropertyChanging();
					this._KorisnikID = value;
					this.SendPropertyChanged("KorisnikID");
					this.OnKorisnikIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sadrzaj", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Sadrzaj
		{
			get
			{
				return this._Sadrzaj;
			}
			set
			{
				if ((this._Sadrzaj != value))
				{
					this.OnSadrzajChanging(value);
					this.SendPropertyChanging();
					this._Sadrzaj = value;
					this.SendPropertyChanged("Sadrzaj");
					this.OnSadrzajChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Allowed", DbType="Bit NOT NULL")]
		public bool Allowed
		{
			get
			{
				return this._Allowed;
			}
			set
			{
				if ((this._Allowed != value))
				{
					this.OnAllowedChanging(value);
					this.SendPropertyChanging();
					this._Allowed = value;
					this.SendPropertyChanged("Allowed");
					this.OnAllowedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Datum", DbType="Date NOT NULL")]
		public System.DateTime Datum
		{
			get
			{
				return this._Datum;
			}
			set
			{
				if ((this._Datum != value))
				{
					this.OnDatumChanging(value);
					this.SendPropertyChanging();
					this._Datum = value;
					this.SendPropertyChanged("Datum");
					this.OnDatumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Korisnik_Komentar", Storage="_Korisnik", ThisKey="KorisnikID", OtherKey="KorisnikID", IsForeignKey=true)]
		public Korisnik Korisnik
		{
			get
			{
				return this._Korisnik.Entity;
			}
			set
			{
				Korisnik previousValue = this._Korisnik.Entity;
				if (((previousValue != value) 
							|| (this._Korisnik.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Korisnik.Entity = null;
						previousValue.Komentars.Remove(this);
					}
					this._Korisnik.Entity = value;
					if ((value != null))
					{
						value.Komentars.Add(this);
						this._KorisnikID = value.KorisnikID;
					}
					else
					{
						this._KorisnikID = default(int);
					}
					this.SendPropertyChanged("Korisnik");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Korisnik")]
	public partial class Korisnik : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _KorisnikID;
		
		private string _Role;
		
		private string _Username;
		
		private string _Email;
		
		private string _Pasword;
		
		private string _Ime;
		
		private string _Prezime;
		
		private System.DateTime _Datum;
		
		private EntitySet<Komentar> _Komentars;
		
		private EntitySet<Post> _Posts;
		
		private EntitySet<Bookmark> _Bookmarks;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnKorisnikIDChanging(int value);
    partial void OnKorisnikIDChanged();
    partial void OnRoleChanging(string value);
    partial void OnRoleChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPaswordChanging(string value);
    partial void OnPaswordChanged();
    partial void OnImeChanging(string value);
    partial void OnImeChanged();
    partial void OnPrezimeChanging(string value);
    partial void OnPrezimeChanged();
    partial void OnDatumChanging(System.DateTime value);
    partial void OnDatumChanged();
    #endregion
		
		public Korisnik()
		{
			this._Komentars = new EntitySet<Komentar>(new Action<Komentar>(this.attach_Komentars), new Action<Komentar>(this.detach_Komentars));
			this._Posts = new EntitySet<Post>(new Action<Post>(this.attach_Posts), new Action<Post>(this.detach_Posts));
			this._Bookmarks = new EntitySet<Bookmark>(new Action<Bookmark>(this.attach_Bookmarks), new Action<Bookmark>(this.detach_Bookmarks));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KorisnikID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int KorisnikID
		{
			get
			{
				return this._KorisnikID;
			}
			set
			{
				if ((this._KorisnikID != value))
				{
					this.OnKorisnikIDChanging(value);
					this.SendPropertyChanging();
					this._KorisnikID = value;
					this.SendPropertyChanged("KorisnikID");
					this.OnKorisnikIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Role", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Role
		{
			get
			{
				return this._Role;
			}
			set
			{
				if ((this._Role != value))
				{
					this.OnRoleChanging(value);
					this.SendPropertyChanging();
					this._Role = value;
					this.SendPropertyChanged("Role");
					this.OnRoleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pasword", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Pasword
		{
			get
			{
				return this._Pasword;
			}
			set
			{
				if ((this._Pasword != value))
				{
					this.OnPaswordChanging(value);
					this.SendPropertyChanging();
					this._Pasword = value;
					this.SendPropertyChanged("Pasword");
					this.OnPaswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ime", DbType="NVarChar(50)")]
		public string Ime
		{
			get
			{
				return this._Ime;
			}
			set
			{
				if ((this._Ime != value))
				{
					this.OnImeChanging(value);
					this.SendPropertyChanging();
					this._Ime = value;
					this.SendPropertyChanged("Ime");
					this.OnImeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prezime", DbType="NVarChar(50)")]
		public string Prezime
		{
			get
			{
				return this._Prezime;
			}
			set
			{
				if ((this._Prezime != value))
				{
					this.OnPrezimeChanging(value);
					this.SendPropertyChanging();
					this._Prezime = value;
					this.SendPropertyChanged("Prezime");
					this.OnPrezimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Datum", DbType="Date NOT NULL")]
		public System.DateTime Datum
		{
			get
			{
				return this._Datum;
			}
			set
			{
				if ((this._Datum != value))
				{
					this.OnDatumChanging(value);
					this.SendPropertyChanging();
					this._Datum = value;
					this.SendPropertyChanged("Datum");
					this.OnDatumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Korisnik_Komentar", Storage="_Komentars", ThisKey="KorisnikID", OtherKey="KorisnikID")]
		public EntitySet<Komentar> Komentars
		{
			get
			{
				return this._Komentars;
			}
			set
			{
				this._Komentars.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Korisnik_Post", Storage="_Posts", ThisKey="KorisnikID", OtherKey="KorisnikID")]
		public EntitySet<Post> Posts
		{
			get
			{
				return this._Posts;
			}
			set
			{
				this._Posts.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Korisnik_Bookmark", Storage="_Bookmarks", ThisKey="KorisnikID", OtherKey="KorisnikID")]
		public EntitySet<Bookmark> Bookmarks
		{
			get
			{
				return this._Bookmarks;
			}
			set
			{
				this._Bookmarks.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Komentars(Komentar entity)
		{
			this.SendPropertyChanging();
			entity.Korisnik = this;
		}
		
		private void detach_Komentars(Komentar entity)
		{
			this.SendPropertyChanging();
			entity.Korisnik = null;
		}
		
		private void attach_Posts(Post entity)
		{
			this.SendPropertyChanging();
			entity.Korisnik = this;
		}
		
		private void detach_Posts(Post entity)
		{
			this.SendPropertyChanging();
			entity.Korisnik = null;
		}
		
		private void attach_Bookmarks(Bookmark entity)
		{
			this.SendPropertyChanging();
			entity.Korisnik = this;
		}
		
		private void detach_Bookmarks(Bookmark entity)
		{
			this.SendPropertyChanging();
			entity.Korisnik = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Post")]
	public partial class Post : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PostID;
		
		private int _KorisnikID;
		
		private int _KategorijaID;
		
		private string _Naslov;
		
		private string _Sadrzaj;
		
		private int _Like_;
		
		private int _Dislike_;
		
		private System.DateTime _Datum;
		
		private EntityRef<Korisnik> _Korisnik;
		
		private EntityRef<Kategorija> _Kategorija;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPostIDChanging(int value);
    partial void OnPostIDChanged();
    partial void OnKorisnikIDChanging(int value);
    partial void OnKorisnikIDChanged();
    partial void OnKategorijaIDChanging(int value);
    partial void OnKategorijaIDChanged();
    partial void OnNaslovChanging(string value);
    partial void OnNaslovChanged();
    partial void OnSadrzajChanging(string value);
    partial void OnSadrzajChanged();
    partial void OnLike_Changing(int value);
    partial void OnLike_Changed();
    partial void OnDislike_Changing(int value);
    partial void OnDislike_Changed();
    partial void OnDatumChanging(System.DateTime value);
    partial void OnDatumChanged();
    #endregion
		
		public Post()
		{
			this._Korisnik = default(EntityRef<Korisnik>);
			this._Kategorija = default(EntityRef<Kategorija>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int PostID
		{
			get
			{
				return this._PostID;
			}
			set
			{
				if ((this._PostID != value))
				{
					this.OnPostIDChanging(value);
					this.SendPropertyChanging();
					this._PostID = value;
					this.SendPropertyChanged("PostID");
					this.OnPostIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KorisnikID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int KorisnikID
		{
			get
			{
				return this._KorisnikID;
			}
			set
			{
				if ((this._KorisnikID != value))
				{
					if (this._Korisnik.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKorisnikIDChanging(value);
					this.SendPropertyChanging();
					this._KorisnikID = value;
					this.SendPropertyChanged("KorisnikID");
					this.OnKorisnikIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KategorijaID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int KategorijaID
		{
			get
			{
				return this._KategorijaID;
			}
			set
			{
				if ((this._KategorijaID != value))
				{
					if (this._Kategorija.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKategorijaIDChanging(value);
					this.SendPropertyChanging();
					this._KategorijaID = value;
					this.SendPropertyChanged("KategorijaID");
					this.OnKategorijaIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Naslov", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Naslov
		{
			get
			{
				return this._Naslov;
			}
			set
			{
				if ((this._Naslov != value))
				{
					this.OnNaslovChanging(value);
					this.SendPropertyChanging();
					this._Naslov = value;
					this.SendPropertyChanged("Naslov");
					this.OnNaslovChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sadrzaj", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Sadrzaj
		{
			get
			{
				return this._Sadrzaj;
			}
			set
			{
				if ((this._Sadrzaj != value))
				{
					this.OnSadrzajChanging(value);
					this.SendPropertyChanging();
					this._Sadrzaj = value;
					this.SendPropertyChanged("Sadrzaj");
					this.OnSadrzajChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Like_", DbType="Int NOT NULL")]
		public int Like_
		{
			get
			{
				return this._Like_;
			}
			set
			{
				if ((this._Like_ != value))
				{
					this.OnLike_Changing(value);
					this.SendPropertyChanging();
					this._Like_ = value;
					this.SendPropertyChanged("Like_");
					this.OnLike_Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dislike_", DbType="Int NOT NULL")]
		public int Dislike_
		{
			get
			{
				return this._Dislike_;
			}
			set
			{
				if ((this._Dislike_ != value))
				{
					this.OnDislike_Changing(value);
					this.SendPropertyChanging();
					this._Dislike_ = value;
					this.SendPropertyChanged("Dislike_");
					this.OnDislike_Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Datum", DbType="Date NOT NULL")]
		public System.DateTime Datum
		{
			get
			{
				return this._Datum;
			}
			set
			{
				if ((this._Datum != value))
				{
					this.OnDatumChanging(value);
					this.SendPropertyChanging();
					this._Datum = value;
					this.SendPropertyChanged("Datum");
					this.OnDatumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Korisnik_Post", Storage="_Korisnik", ThisKey="KorisnikID", OtherKey="KorisnikID", IsForeignKey=true)]
		public Korisnik Korisnik
		{
			get
			{
				return this._Korisnik.Entity;
			}
			set
			{
				Korisnik previousValue = this._Korisnik.Entity;
				if (((previousValue != value) 
							|| (this._Korisnik.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Korisnik.Entity = null;
						previousValue.Posts.Remove(this);
					}
					this._Korisnik.Entity = value;
					if ((value != null))
					{
						value.Posts.Add(this);
						this._KorisnikID = value.KorisnikID;
					}
					else
					{
						this._KorisnikID = default(int);
					}
					this.SendPropertyChanged("Korisnik");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kategorija_Post", Storage="_Kategorija", ThisKey="KategorijaID", OtherKey="KategorijaID", IsForeignKey=true)]
		public Kategorija Kategorija
		{
			get
			{
				return this._Kategorija.Entity;
			}
			set
			{
				Kategorija previousValue = this._Kategorija.Entity;
				if (((previousValue != value) 
							|| (this._Kategorija.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Kategorija.Entity = null;
						previousValue.Posts.Remove(this);
					}
					this._Kategorija.Entity = value;
					if ((value != null))
					{
						value.Posts.Add(this);
						this._KategorijaID = value.KategorijaID;
					}
					else
					{
						this._KategorijaID = default(int);
					}
					this.SendPropertyChanged("Kategorija");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Kategorija")]
	public partial class Kategorija : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _KategorijaID;
		
		private string _NazivKategorije;
		
		private EntitySet<Post> _Posts;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnKategorijaIDChanging(int value);
    partial void OnKategorijaIDChanged();
    partial void OnNazivKategorijeChanging(string value);
    partial void OnNazivKategorijeChanged();
    #endregion
		
		public Kategorija()
		{
			this._Posts = new EntitySet<Post>(new Action<Post>(this.attach_Posts), new Action<Post>(this.detach_Posts));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KategorijaID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int KategorijaID
		{
			get
			{
				return this._KategorijaID;
			}
			set
			{
				if ((this._KategorijaID != value))
				{
					this.OnKategorijaIDChanging(value);
					this.SendPropertyChanging();
					this._KategorijaID = value;
					this.SendPropertyChanged("KategorijaID");
					this.OnKategorijaIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NazivKategorije", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string NazivKategorije
		{
			get
			{
				return this._NazivKategorije;
			}
			set
			{
				if ((this._NazivKategorije != value))
				{
					this.OnNazivKategorijeChanging(value);
					this.SendPropertyChanging();
					this._NazivKategorije = value;
					this.SendPropertyChanged("NazivKategorije");
					this.OnNazivKategorijeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kategorija_Post", Storage="_Posts", ThisKey="KategorijaID", OtherKey="KategorijaID")]
		public EntitySet<Post> Posts
		{
			get
			{
				return this._Posts;
			}
			set
			{
				this._Posts.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Posts(Post entity)
		{
			this.SendPropertyChanging();
			entity.Kategorija = this;
		}
		
		private void detach_Posts(Post entity)
		{
			this.SendPropertyChanging();
			entity.Kategorija = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Bookmark")]
	public partial class Bookmark : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BookmarkID;
		
		private int _PostID;
		
		private int _KorisnikID;
		
		private EntityRef<Korisnik> _Korisnik;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBookmarkIDChanging(int value);
    partial void OnBookmarkIDChanged();
    partial void OnPostIDChanging(int value);
    partial void OnPostIDChanged();
    partial void OnKorisnikIDChanging(int value);
    partial void OnKorisnikIDChanged();
    #endregion
		
		public Bookmark()
		{
			this._Korisnik = default(EntityRef<Korisnik>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookmarkID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int BookmarkID
		{
			get
			{
				return this._BookmarkID;
			}
			set
			{
				if ((this._BookmarkID != value))
				{
					this.OnBookmarkIDChanging(value);
					this.SendPropertyChanging();
					this._BookmarkID = value;
					this.SendPropertyChanged("BookmarkID");
					this.OnBookmarkIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int PostID
		{
			get
			{
				return this._PostID;
			}
			set
			{
				if ((this._PostID != value))
				{
					this.OnPostIDChanging(value);
					this.SendPropertyChanging();
					this._PostID = value;
					this.SendPropertyChanged("PostID");
					this.OnPostIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KorisnikID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int KorisnikID
		{
			get
			{
				return this._KorisnikID;
			}
			set
			{
				if ((this._KorisnikID != value))
				{
					if (this._Korisnik.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKorisnikIDChanging(value);
					this.SendPropertyChanging();
					this._KorisnikID = value;
					this.SendPropertyChanged("KorisnikID");
					this.OnKorisnikIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Korisnik_Bookmark", Storage="_Korisnik", ThisKey="KorisnikID", OtherKey="KorisnikID", IsForeignKey=true)]
		public Korisnik Korisnik
		{
			get
			{
				return this._Korisnik.Entity;
			}
			set
			{
				Korisnik previousValue = this._Korisnik.Entity;
				if (((previousValue != value) 
							|| (this._Korisnik.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Korisnik.Entity = null;
						previousValue.Bookmarks.Remove(this);
					}
					this._Korisnik.Entity = value;
					if ((value != null))
					{
						value.Bookmarks.Add(this);
						this._KorisnikID = value.KorisnikID;
					}
					else
					{
						this._KorisnikID = default(int);
					}
					this.SendPropertyChanged("Korisnik");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
