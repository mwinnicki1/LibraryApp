namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LibraryApp.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryApp.DAL.LibraryAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryApp.DAL.LibraryAppContext context)
        {
            var readers = new List<Reader>
            {
                new Reader { Name = "Rafa³", Surname = "Wojtas", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "201", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600700", Email = "r.wojtas@ideo.pl" },
                new Reader { Name = "Tomasz", Surname = "Buka³a", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "108", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600701", Email = "tb@ideo.pl" },
                new Reader { Name = "Grzegorz", Surname = "Kucharski", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "108", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600702", Email = "gk@ideo.pl" },
                new Reader { Name = "Arkadiusz", Surname = "Michno", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "100", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600703", Email = "am@ideo.pl" },
                new Reader { Name = "Ziemowit", Surname = "Michno", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "100", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600704", Email = "zm@ideo.pl" },
                new Reader { Name = "Marcin", Surname = "Wojtoñ", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "101", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600705", Email = "mw@ideo.pl" }

            };
            readers.ForEach(s => context.Readers.AddOrUpdate(p => p.Surname, s));
            context.SaveChanges();
        }
    }
}
