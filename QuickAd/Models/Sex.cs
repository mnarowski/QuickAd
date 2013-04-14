﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickAd.Models
{
    public class Sex
    {
        public int Id;
        public String Hash;
        public String Name;

        public virtual int Vid { get { return this.Id; } set { this.Id = value; } }
        public virtual string Vname { get { return this.Name; } set { this.Name = value; } }

        public int GetId()
        {
            return this.Id;
        }
        public void SetId(int id)
        {
            this.Id = id;
        }
        public String GetHash()
        {
            return this.Hash;
        }
        public void SetHash(String hash)
        {
            this.Hash = hash;
        }
        public String GetName()
        {
            return this.Name;
        }
        public void SetName(String name)
        {
            this.Name = name;
        }
    }
}