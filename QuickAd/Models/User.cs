using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class User {
        private String FirstName;
        private String LastName;
        private String Email;
        private DateTime DateOfBirth;
		private String City;
		private String Street;
		private int BuildingNumber;
		private int HomeNumber;
		private Sex Sex;
		private String Password;
		private String PhoneNumber;
		private String Hash;
		private int Privillage;
		private int Id;
	    private int IdSex;
        [Display(Name = "id")]
        public virtual int Vid { get { return this.Id; } set { this.Id = value; } }
        [Display(Name = "Imiê")]
        public virtual string VfirstName {get { return this.FirstName; } set { this.FirstName = value; }}
        [Display(Name = "Nazwisko")]
        public virtual string VlastName {get { return this.LastName; } set { this.LastName = value; }}
        [Display(Name = "E-mail"),Required,MinLength(4),MaxLength(32)]
        public virtual string Vemail {get { return this.Email; } set { this.Email = value; }}
        [Display(Name = "Data urodzenia")]
        public virtual DateTime VdateOfBirth { get { return this.DateOfBirth; } set { this.DateOfBirth = value; } }
        [Display(Name = "Miasto")]
        public virtual string Vcity { get { return this.City; } set { this.City = value; } }
        [Display(Name = "Ulica")]
        public virtual string Vstreet { get { return this.Street; } set { this.Street = value; } }
        [Display(Name = "Nr bundyku")]
        public virtual int VbuildingNumber { get { return this.BuildingNumber; } set { this.BuildingNumber = value; } }
        [Display(Name = "Nr lokalu")]
        public virtual int VhomeNumber { get { return this.HomeNumber; } set { this.HomeNumber = value; } }
        [Display(Name = "P³eæ")]
        public virtual int VidSex { get { return this.IdSex; } set { this.IdSex = value; } }
        [Display(Name = "Has³o"),MinLength(5),MaxLength(20),Required]
        public virtual string Vpassword { get { return this.Password; } set { this.Password = value; } }
        [Display(Name = "Numer telefonu")]
        public virtual string VphoneNumber { get { return this.PhoneNumber; } set { this.PhoneNumber = value; } }
        [Display(Name = "Uprawnienia")]
        public virtual int Vprivillage { get { return this.Privillage; } set { this.Privillage = value; } }

        public User() { }

		public virtual String GetFirstName() {
			return this.FirstName;
		}
		public virtual void SetFirstName(String firstName) {
			this.FirstName = firstName;
		}
		public virtual String GetLastName() {
			return this.LastName;
		}
		public virtual void SetLastName(String lastName) {
			this.LastName = lastName;
		}
		public virtual String GetEmail() {
			return this.Email;
		}
		public virtual void SetEmail(String email) {
			this.Email = email;
		}
		public virtual DateTime GetDateOfBirth() {
			return this.DateOfBirth;
		}
		public virtual void SetDateOfBirth(DateTime dateOfBirth) {
			this.DateOfBirth = dateOfBirth;
		}
		public virtual String GetCity() {
			return this.City;
		}
		public virtual void SetCity(String city) {
			this.City = city;
		}
		public virtual String GetStreet() {
			return this.Street;
		}
		public virtual void SetStreet(String street) {
			this.Street = street;
		}
		public virtual int GetBuildingNumber() {
			return this.BuildingNumber;
		}
		public virtual void SetBuildingNumber(int buildingNumber) {
			this.BuildingNumber = buildingNumber;
		}
		public virtual int GetHomeNumber() {
			return this.HomeNumber;
		}
		public virtual void SetHomeNumber(int homeNumber) {
			this.HomeNumber = homeNumber;
		}
		public virtual Sex GetSex() {
			return this.Sex;
		}
		public virtual void SetSex(Sex sex) {
			this.Sex = sex;
		}
		public virtual String GetPassword() {
			return this.Password;
		}
		public virtual void SetPassword(String password) {
			this.Password = password;
		}
		public virtual String GetPhoneNumber() {
			return this.PhoneNumber;
		}
		public virtual void SetPhoneNumber(String phoneNumber) {
			this.PhoneNumber = phoneNumber;
		}
		public virtual String GetHash() {
			return this.Hash;
		}
		public virtual void SetHash(String hash) {
			this.Hash = hash;
		}
		public virtual int GetPrivillage() {
			return this.Privillage;
		}
		public virtual void SetPrivillage(int privillage) {
			this.Privillage = privillage;
		}
		public virtual bool IsAdmin()
		{
		    return (Privillage > 1);
		}
		public virtual bool IsOwner(Advertise adv)
		{
		    return (bool) (adv.VidUser == this.Id);
		}
		public virtual int GetId() {
			return this.Id;
		}
		public virtual void SetId(int id) {
			this.Id = id;
		}
		public virtual Email CreateEmailTo(User user) {
			return new Email(user);
		}
        public virtual string ToString() {
            return String.Format("{0}_", GetId());
        }
		private List<Email> emails;
		private List<Advertise> advertises;

	}

}
