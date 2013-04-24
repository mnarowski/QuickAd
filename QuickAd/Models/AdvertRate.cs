using System;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class AdvertRate {
		private int Id;
		private String Hash;
        private int Rate;
	    private int IdAdvertise;

        public virtual int Vid { get { return this.Id; } set { this.Id = value; } }
        [Required]
        public virtual int Vrate { get { return this.Rate; } set { this.Rate = value; } }
        public virtual int VidAdvertise { get { return this.IdAdvertise; } set { this.IdAdvertise = value; } }

	    public AdvertRate(Advertise advert)
	    {
	        advertise = advert;
	        IdAdvertise = advertise.GetId();
	    }

        public AdvertRate() { }

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
		public virtual int GetRate() {
			return this.Rate;
		}
		public virtual void SetRate(int rate) {
			this.Rate = rate;
		}

		private Advertise advertise;

	}

}
