﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApp.Models
{
    public class Reader
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}