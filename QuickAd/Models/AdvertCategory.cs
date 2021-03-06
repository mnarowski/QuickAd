using System;
using System.ComponentModel.DataAnnotations;
using QuickAd.Models.DBO;

namespace QuickAd.Models {
	public class AdvertCategory : IEntity {
		private int Id;
		private String Hash;
        private String Name;

        public AdvertCategory() { }

        public virtual int Vid { get { return this.Id; } set { this.Id = value; } }
        [Required,Display(Name="Nazwa")]
        public virtual string Vname { get { return this.Name; } set { this.Name = value; } }

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
		public virtual String GetName() {
			return this.Name;
		}
		public virtual void SetName(String name) {
			this.Name = name;
		}


	}

}
