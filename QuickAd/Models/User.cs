using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickAd.Models {
	public class User {
        [Required,MinLength(3)]
		public String FirstName;
        [Required,MinLength(3)]
		public String LastName;
        [Required,MaxLength(255),MinLength(5)]
		public String Email;
        [Required]
		public DateTime DateOfBirth;
		public String City;
		public String Street;
		public int BuildingNumber;
		public int HomeNumber;
		public Sex Sex;
		public String Password;
		public String PhoneNumber;
		public String Hash;
		public int Privillage;
		public int Id;
	    public int IdSex;

        public virtual string VfirstName {get { return this.FirstName; } set { this.FirstName = value; }}
        public virtual string VlastName {get { return this.LastName; } set { this.LastName = value; }}
        public virtual string Vemail {get { return this.Email; } set { this.Email = value; }}
        public virtual DateTime VdateOfBirth {get { return this.DateOfBirth; } set { this.DateOfBirth = value; }}
        public virtual string Vcity {get { return this.City; } set { this.City = value; }}
        public virtual string Vstreet {get { return this.Street; } set { this.Street = value; }}
        public virtual int VbuildingNumber {get { return this.BuildingNumber; } set { this.BuildingNumber = value; }}
        public virtual int VhomeNumber {get { return this.HomeNumber; } set { this.HomeNumber = value; }}
        public virtual int VidSex {get { return this.IdSex; } set { this.IdSex = value; }}
        public virtual string Vpassword {get { return this.Password; } set { this.Password = value; }}
        public virtual string VphoneNumber {get { return this.PhoneNumber; } set { this.PhoneNumber = value; }}
        public virtual int Vprivillage { get { return this.Privillage; } set { this.Privillage = value; } } 

		public String GetFirstName() {
			return this.FirstName;
		}
		public void SetFirstName(String firstName) {
			this.FirstName = firstName;
		}
		public String GetLastName() {
			return this.LastName;
		}
		public void SetLastName(String lastName) {
			this.LastName = lastName;
		}
		public String GetEmail() {
			return this.Email;
		}
		public void SetEmail(String email) {
			this.Email = email;
		}
		public DateTime GetDateOfBirth() {
			return this.DateOfBirth;
		}
		public void SetDateOfBirth(DateTime dateOfBirth) {
			this.DateOfBirth = dateOfBirth;
		}
		public String GetCity() {
			return this.City;
		}
		public void SetCity(String city) {
			this.City = city;
		}
		public String GetStreet() {
			return this.Street;
		}
		public void SetStreet(String street) {
			this.Street = street;
		}
		public int GetBuildingNumber() {
			return this.BuildingNumber;
		}
		public void SetBuildingNumber(int buildingNumber) {
			this.BuildingNumber = buildingNumber;
		}
		public int GetHomeNumber() {
			return this.HomeNumber;
		}
		public void SetHomeNumber(int homeNumber) {
			this.HomeNumber = homeNumber;
		}
		public Sex GetSex() {
			return this.Sex;
		}
		public void SetSex(Sex sex) {
			this.Sex = sex;
		}
		public String GetPassword() {
			return this.Password;
		}
		public void SetPassword(String password) {
			this.Password = password;
		}
		public String GetPhoneNumber() {
			return this.PhoneNumber;
		}
		public void SetPhoneNumber(String phoneNumber) {
			this.PhoneNumber = phoneNumber;
		}
		public String GetHash() {
			return this.Hash;
		}
		public void SetHash(String hash) {
			this.Hash = hash;
		}
		public int GetPrivillage() {
			return this.Privillage;
		}
		public void SetPrivillage(int privillage) {
			this.Privillage = privillage;
		}
		public bool IsAdmin()
		{
		    return (Privillage > 1);
		}
		public bool IsOwner(Advertise adv)
		{
		    return (bool) (adv.IdUser == this.Id);
		}
		public int GetId() {
			return this.Id;
		}
		public void SetId(int id) {
			this.Id = id;
		}
		public Email CreateEmailTo(User user) {
			return new Email(user);
		}

		private List<Email> emails;
		private List<Advertise> advertises;

	}

}
