using System;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class Email {
		public User SenderUser;
        [Required,MinLength(3),MaxLength(1000)]
		public String Content;
        [Required,MinLength(3),MaxLength(255)]
		public String Title;
		public DateTime DateSend;
		public bool IsSend;
		public int Id;
		public String Hash;
		public DateTime DateCreated;
	    public int IdSender;
	    public int IdRecipent;

        public virtual int Vid {get { return this.Id; } set { this.Id = value; }}
        public virtual int VidSenderUser {get { return this.IdSender; } set { this.IdSender = value; }}
        public virtual int VidRecipent {get { return this.IdRecipent; } set { this.IdRecipent = value; }}
        public virtual string Vcontent {get { return this.Content; } set { this.Content = value; }}
        public virtual string Vtitle {get { return this.Title; } set { this.Title = value; }}
        public virtual DateTime VsendDate {get { return this.DateSend; } set { this.DateSend = value; }}
        public virtual bool VisSend {get { return this.IsSend; } set {this.IsSend = value;}}
        public virtual DateTime VcreatedDate {get { return this.DateCreated; } set { this.DateCreated = value; }}

        public Email(User user)
        {
            this.IdRecipent = user.Id;
        }

		public User GetSenderUser() {
			return this.SenderUser;
		}
		public void SetSenderUser(User senderUser) {
			this.SenderUser = senderUser;
		}
		public String GetContent() {
			return this.Content;
		}
		public void SetContent(String content) {
			this.Content = content;
		}
		public String GetTitle() {
			return this.Title;
		}
		public void SetTitle(String title) {
			this.Title = title;
		}
		public DateTime GetDateSend() {
			return this.DateSend;
		}
		public void SetDateSend(DateTime dateSend) {
			this.DateSend = dateSend;
		}
		public bool GetIsSend() {
			return this.IsSend;
		}
		public void SetIsSend(bool isSend) {
			this.IsSend = isSend;
		}
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
		public DateTime GetDateCreated() {
			return this.DateCreated;
		}
		public void SetDateCreated(DateTime dateCreated) {
			this.DateCreated = dateCreated;
		}


	}

}
