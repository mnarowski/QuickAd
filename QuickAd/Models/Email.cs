using System;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class Email {
		private User SenderUser;
        private String Content;
        private String Title;
		private DateTime DateSend;
		private bool IsSend;
		private int Id;
		private String Hash;
		private DateTime DateCreated;
	    private int IdSender;
	    private int IdRecipent;

        public virtual int Vid {get { return this.Id; } set { this.Id = value; }}
        public virtual int VidSenderUser {get { return this.IdSender; } set { this.IdSender = value; }}
        public virtual int VidRecipent {get { return this.IdRecipent; } set { this.IdRecipent = value; }}
        [Required, MinLength(3), MaxLength(1000),Display(Name="Treœæ wiadomoœci")]
        public virtual string Vcontent {get { return this.Content; } set { this.Content = value; }}
        [Required, MinLength(3), MaxLength(255),Display(Name="Tytu³ wiadomoœci")]
        public virtual string Vtitle {get { return this.Title; } set { this.Title = value; }}
        public virtual DateTime VsendDate {get { return this.DateSend; } set { this.DateSend = value; }}
        public virtual bool VisSend {get { return this.IsSend; } set {this.IsSend = value;}}
        public virtual DateTime VcreatedDate {get { return this.DateCreated; } set { this.DateCreated = value; }}

        public Email(User user)
        {
            this.IdRecipent = user.Vid;
            
        }

        public Email() { }

		public virtual User GetSenderUser() {
			return this.SenderUser;
		}
		public virtual void SetSenderUser(User senderUser) {
			this.SenderUser = senderUser;
            this.VidSenderUser = senderUser.GetId();
        }
		public virtual String GetContent() {
			return this.Content;
		}
		public virtual void SetContent(String content) {
			this.Content = content;
		}
		public virtual String GetTitle() {
			return this.Title;
		}
		public virtual void SetTitle(String title) {
			this.Title = title;
		}
		public virtual DateTime GetDateSend() {
			return this.DateSend;
		}
		public virtual void SetDateSend(DateTime dateSend) {
			this.DateSend = dateSend;
		}
		public virtual bool GetIsSend() {
			return this.IsSend;
		}
		public virtual void SetIsSend(bool isSend) {
			this.IsSend = isSend;
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
		public virtual DateTime GetDateCreated() {
			return this.DateCreated;
		}
		public virtual void SetDateCreated(DateTime dateCreated) {
			this.DateCreated = dateCreated;
		}


	}

}
