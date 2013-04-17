using System;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class Territory {
		public int Id;
		public String Hash;
        [Required,MaxLength(255),MinLength(3)]
		public String Name;

        public virtual int Vid { get { return this.Id; } set { this.Id = value; } }
        public virtual string Vname { get { return this.Name; } set { this.Name = value; } }

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
		public String GetName() {
			return this.Name;
		}
		public void SetName(String name) {
			this.Name = name;
		}


	}

}
