using System;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class Comment {
        public int Id;
		public String Hash;
		[Required,StringLength(255),MinLength(3)]
        public String Title;
        [Required,MinLength(10)]
		public String Content;
		public DateTime CreatedAt;
	    public int IdAdvert;

        public virtual int Vid { get { return this.Id; } set { this.Id = value; } }
        public virtual string Vtitle {get { return this.Title; } set { this.Title = value; }}
        public virtual string Vcontent {get {return this.Content;} set { this.Content = value; }}
        public virtual DateTime VcreatedDate {get { return this.CreatedAt; } set { this.CreatedAt = value; }}
        public virtual int VidAdvertise {get { return this.IdAdvert; } set { this.IdAdvert = value; }}

		public int GetId() {
			return this.Id;
		}
		public void SetId(int id) {
			this.Id = id;
		}
		public String GetHash() {
			return this.Hash;
		}
		public void SetHash(String hash) {
			this.Hash = hash;
		}
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
		public DateTime GetCreatedAt() {
			return this.CreatedAt;
		}
		public void SetCreatedAt(DateTime createdAt) {
			this.CreatedAt = createdAt;
		}


	}

}
