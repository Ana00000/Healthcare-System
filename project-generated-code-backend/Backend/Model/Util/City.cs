// File:    City.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class City

using Backend.Model.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.Util
{
    public class City : Entity
    {
        public List<Address> Address { get; set; }
        public string Name { get; set; }

        public string PostalCode { get; set; }

        public City() : base()
        {
        }

        public City(string name, string postalCode) : base()
        {
            Name = name;
            PostalCode = postalCode;
        }

        [JsonConstructor]
        public City(String serialNumber, string name, string postalCode) : base(serialNumber)
        {
            Name = name;
            PostalCode = postalCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is City other))
            {
                return false;
            }

            return Name.Equals(other.Name) && PostalCode.Equals(other.PostalCode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Name + " " + PostalCode;
        }
    }
}