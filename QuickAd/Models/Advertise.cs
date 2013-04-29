using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class Advertise {
		private String Title;
        private String Content;
		private DateTime Validity;
		private int Visits;
		private double Price;
		private String AddinationalInfo;
		private bool VisibleToOthers;
		private String Hash;
		private int Id;
	    private int IdUser;
	    private int IdAdvertCategory;
	    private int IdTerritory;

        [Display(Name="id")]
        public virtual int Vid {get { return this.Id; } set { this.Id = value; }}
        [Display(Name = "Tytu³"), Required, MinLength(3), MaxLength(255)]
        public virtual string Vtitle {get { return this.Title; } set { this.Title = value; }}
        [Display(Name="Autor")]
        public virtual int VidUser {get { return this.IdUser; } set { this.IdUser = value; }}
        [Display(Name = "Treœæ"), Required, MinLength(10)]
        public virtual string Vcontent {get { return this.Content; } set { this.Content = value; }}
        [Display(Name = "Data wa¿noœci")]
        public virtual DateTime Vvalidity {get { return this.Validity; } set { this.Validity = value; }}
        [Display(Name = "Iloœæ wizyt")]
        public virtual int Vvisits {get { return this.Visits; } set { this.Visits = value; }}
        [Display(Name = "Cena")]
        public virtual double Vprice {get { return this.Price; } set { this.Price = value; }}
        [Display(Name = "Informacje dodatkowe")]
        public virtual string VadditionalInfo {get { return this.AddinationalInfo; } set { this.AddinationalInfo = value; }}
        public virtual bool VvisibleToOthers {get { return this.VisibleToOthers; } set { this.VisibleToOthers = value; }}
        [Display(Name = "Kategoria")]
        public virtual int VidAdvertCategory { get { return this.IdAdvertCategory; } set { this.IdAdvertCategory = value; } }
        [Display(Name = "Region")]
        public virtual int VidTerritory {get { return this.IdTerritory; } set { this.IdTerritory = value; }}

        public Advertise() { }

		public virtual String GetTitle() {
			return this.Title;
		}
		public virtual void SetTitle(String title) {
			this.Title = title;
		}
		public virtual String GetContent() {
			return this.Content;
		}
		public virtual void SetContent(String content) {
			this.Content = content;
		}
		public virtual DateTime GetValidity() {
			return this.Validity;
		}
		public virtual void SetValidity(DateTime validity) {
			this.Validity = validity;
		}
		public virtual int GetVisits() {
			return this.Visits;
		}
		public virtual void SetVisits(int visits) {
			this.Visits = visits;
		}
		public virtual double GetPrice() {
			return this.Price;
		}
		public virtual void SetPrice(double price) {
			this.Price = price;
		}
		public virtual String GetAddinationalInfo() {
			return this.AddinationalInfo;
		}
		public virtual void SetAddinationalInfo(String addinationalInfo) {
			this.AddinationalInfo = addinationalInfo;
		}
		public virtual bool GetVisibleToOthers() {
			return this.VisibleToOthers;
		}
		public virtual void SetVisibleToOthers(bool visibleToOthers) {
			this.VisibleToOthers = visibleToOthers;
		}
		public virtual String GetHash() {
			return this.Hash;
		}
		public virtual void SetHash(String hash) {
			this.Hash = hash;
		}
		public virtual int GetId() {
			return this.Id;
		}
		public virtual void SetId(int id) {
			this.Id = id;
		}
		public virtual AdvertCategory GetCategory()
		{
		    return DBHelper.FindOne<AdvertCategory>(this.IdAdvertCategory);
		}
		public virtual void SetAdvertCategory(AdvertCategory advertCat)
		{
		    advertCategory = advertCat;
		}
		public virtual Image[] GetGalleryImages() {
			Image[] imgs = new Image[images.Count];
		    int i = 0;
		    foreach (Image image1 in images)
		    {
		        imgs[i] = image1;
		        i++;
		    }
		    return imgs;
		}
		public virtual void SetGalleryImages(Image[] galleryImages) {
			images.AddRange(galleryImages);
		}
		public virtual void AddGalleryImage(Image img) {
			images.Add(img);
		}
		public virtual void DeleteAllGalleryImages() {
		    foreach (Image image1 in images)
		    {
		        DBHelper.Delete(image1);
		    }
		}
		public virtual void IncrementVisitsCount()
		{
		    this.Visits++;
		}

        public virtual int GetIdUser() {
            return IdUser;
        }

        public virtual void setIdUser(int _idUser) {
            this.IdUser = _idUser;
        }

		private AdvertCategory advertCategory;
		private Territory teritory;
		private List<Comment> comments;
		private List<Image> images;
		private Image image;


	}

}
