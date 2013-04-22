using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class Advertise {
        [Required,MinLength(3),MaxLength(255)]
		public String Title;
        [Required,MinLength(10)]
		public String Content;
		public DateTime Validity;
		public int Visits;
		public double Price;
		public String AddinationalInfo;
		public bool VisibleToOthers;
		public String Hash;
		public int Id;
	    public int IdUser;
	    public int IdAdvertCategory;
	    public int IdTerritory;

        public virtual int Vid {get { return this.Id; } set { this.Id = value; }}
        public virtual string Vtitle {get { return this.Title; } set { this.Title = value; }}
        public virtual int VidUser {get { return this.IdUser; } set { this.IdUser = value; }}
        public virtual string Vcontent {get { return this.Content; } set { this.Content = value; }}
        public virtual DateTime Vvalidity {get { return this.Validity; } set { this.Validity = value; }}
        public virtual int Vvisits {get { return this.Visits; } set { this.Visits = value; }}
        public virtual double Vprice {get { return this.Price; } set { this.Price = value; }}
        public virtual string VadditionalInfo {get { return this.AddinationalInfo; } set { this.AddinationalInfo = value; }}
        public virtual bool VvisibleToOthers {get { return this.VisibleToOthers; } set { this.VisibleToOthers = value; }}
        public virtual int VidAdvertCategry {get { return this.IdAdvertCategory; } set { this.IdAdvertCategory = value; }}
        public virtual int VidIdTerritory {get { return this.IdTerritory; } set { this.IdTerritory = value; }}

		public String GetTitle() {
			return this.Title;
		}
		public void SetTitle(String title) {
			this.Title = title;
		}
		public String GetContent() {
			return this.Content;
		}
		public void SetContent(String content) {
			this.Content = content;
		}
		public DateTime GetValidity() {
			return this.Validity;
		}
		public void SetValidity(DateTime validity) {
			this.Validity = validity;
		}
		public int GetVisits() {
			return this.Visits;
		}
		public void SetVisits(int visits) {
			this.Visits = visits;
		}
		public double GetPrice() {
			return this.Price;
		}
		public void SetPrice(double price) {
			this.Price = price;
		}
		public String GetAddinationalInfo() {
			return this.AddinationalInfo;
		}
		public void SetAddinationalInfo(String addinationalInfo) {
			this.AddinationalInfo = addinationalInfo;
		}
		public bool GetVisibleToOthers() {
			return this.VisibleToOthers;
		}
		public void SetVisibleToOthers(bool visibleToOthers) {
			this.VisibleToOthers = visibleToOthers;
		}
		public String GetHash() {
			return this.Hash;
		}
		public void SetHash(String hash) {
			this.Hash = hash;
		}
		public int GetId() {
			return this.Id;
		}
		public void SetId(int id) {
			this.Id = id;
		}
		public AdvertCategory GetCategory()
		{
		    return DBHelper.FindOne<AdvertCategory>(this.IdAdvertCategory);
		}
		public void SetAdvertCategory(AdvertCategory advertCat)
		{
		    advertCategory = advertCat;
		}
		public Image[] GetGalleryImages() {
			Image[] imgs = new Image[images.Count];
		    int i = 0;
		    foreach (Image image1 in images)
		    {
		        imgs[i] = image1;
		        i++;
		    }
		    return imgs;
		}
		public void SetGalleryImages(Image[] galleryImages) {
			images.AddRange(galleryImages);
		}
		public void AddGalleryImage(Image img) {
			images.Add(img);
		}
		public void DeleteAllGalleryImages() {
		    foreach (Image image1 in images)
		    {
		        DBHelper.Delete(image1);
		    }
		}
		public void IncrementVisitsCount()
		{
		    this.Visits++;
		}

		private AdvertCategory advertCategory;
		private Territory teritory;
		private List<Comment> comments;
		private List<Image> images;
		private Image image;


	}

}
