using System;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class Image {
        
		private String ImagePath;
		private int Id;
		private String Hash;
		private String Extension = "jpg";
	    private bool IsPrivate;
	    private int IdAdvert;

        public virtual int Vid {get { return this.Id; } set { this.Id = value; }}
        [Required]
        public virtual string Vpath {get { return this.ImagePath; } set { this.ImagePath = value; }}
        public virtual string Vextension {get { return this.Extension; } set { this.Extension = value; }}
        public virtual bool VisPrivate {get { return this.IsPrivate; } set { this.IsPrivate = value; }}
        public virtual int VidAdvertise {get { return this.IdAdvert; } set { this.IdAdvert = value; }}

        public Image() { }

		public virtual string GetImagePath() {
			return this.ImagePath;
		}
		public virtual void SetImagePath(string imagePath) {
			this.ImagePath = imagePath;
		}
		public virtual int GetId() {
			return this.Id;
		}
		public virtual void SetId(int id) {
			this.Id = id;
		}
		public virtual String GetHash() {
			return this.Hash;
		}
		public virtual void SetHash(String hash) {
			this.Hash = hash;
		}
		public virtual String GetExtension() {
			return this.Extension;
		}
		public virtual void SetExtension(String extension) {
			this.Extension = extension;
		}


	}

}
