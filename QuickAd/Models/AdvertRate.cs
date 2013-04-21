using System;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class AdvertRate {
		public int Id;
		public String Hash;
        [Required]
		public int Rate;
	    public int IdAdvertise;

        public virtual int Vid { get { return this.Id; } set { this.Id = value; } }
        public virtual int Vrate { get { return this.Rate; } set { this.Rate = value; } }
        public virtual int VidAdvertise { get { return this.IdAdvertise; } set { this.IdAdvertise = value; } }

	    public AdvertRate(Advertise advert)
	    {
	        advertise = advert;
	        IdAdvertise = advertise.GetId();
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
		public int GetRate() {
			return this.Rate;
		}
		public void SetRate(int rate) {
			this.Rate = rate;
		}

		private Advertise advertise;

	}

}
