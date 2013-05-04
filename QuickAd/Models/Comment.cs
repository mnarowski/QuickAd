using System;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class Comment {
        private int Id;
		private String Hash;
		private String Title;
        private String Content;
		private DateTime CreatedAt;
	    private int IdAdvert;
        private int IdUser;

        public virtual int Vid { get { return this.Id; } set { this.Id = value; } }
        [Required, MaxLength(255), MinLength(3),Display(Name="Nazwa komentarza")]
        public virtual string Vtitle {get { return this.Title; } set { this.Title = value; }}
        [Required, MinLength(10),Display(Name="Zawartoœæ"),DataType(DataType.MultilineText)]
		public virtual string Vcontent {get {return this.Content;} set { this.Content = value; }}
        [Display(Name="Data dodania")]
        public virtual DateTime VcreatedDate {get { return this.CreatedAt; } set { this.CreatedAt = value; }}
        public virtual int VidAdvertise {get { return this.IdAdvert; } set { this.IdAdvert = value; }}
        public virtual int VidUser { get { return this.IdUser; } set { this.IdUser = value; } }
        public Comment() { }

        public Comment(Advertise adv) {
            CreatedAt = DateTime.Now;
            IdAdvert = adv.GetId();
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
		public virtual DateTime GetCreatedAt() {
			return this.CreatedAt;
		}
		public virtual void SetCreatedAt(DateTime createdAt) {
			this.CreatedAt = createdAt;
		}

        public virtual int getIdUser() {
            return this.IdUser;
        }

        public virtual void setIdUser(User u) {
            this.IdUser = u.GetId();
        }

        public virtual void setIdUser(int id) {
            this.IdUser = id;
        }

	}

}
