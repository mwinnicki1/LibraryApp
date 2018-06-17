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
                new Reader { Name = "Rafa³ Wojtas", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "201", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600700", Email = "r.wojtas@ideo.pl" },
                new Reader { Name = "Tomasz Buka³a", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "108", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600701", Email = "tb@ideo.pl" },
                new Reader { Name = "Grzegorz Kucharski", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "108", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600702", Email = "gk@ideo.pl" },
                new Reader { Name = "Arkadiusz Michno", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "100", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600703", Email = "am@ideo.pl" },
                new Reader { Name = "Ziemowit Michno", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "100", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600704", Email = "zm@ideo.pl" },
                new Reader { Name = "Marcin Wojtoñ", Street = "Nad Przyrw¹", HouseNumber = "13", ApartmentNumber = "101", PostalCode = "35-234", City = "Rzeszów", PhoneNumber = "500600705", Email = "mw@ideo.pl" }

            };
            readers.ForEach(s => context.Readers.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book {Author = "Witold Gombrowicz", Title = "Ferdydurke", Publisher = "Wydawnictwo Literackie", PublishingDate = DateTime.Parse("2016-03-16"), Isbn = "9788308049112" },
                new Book {Author = "Andrzej Pilipuk", Title = "Kroniki Jakuba Wêdrowycza", Publisher = "Fabryka S³ów", PublishingDate = DateTime.Parse("2011-01-01"), Isbn = "9788375745092" },
                new Book {Author = "Henryk Sienkiewicz", Title = "Krzy¿acy", Publisher = "Wydawnictwo Literackie", PublishingDate = DateTime.Parse("2012-01-12"), Isbn = "9788308060254" },
                new Book {Author = "J.K. Rowling", Title = "Harry Potter i Kamieñ Filozoficzny", Publisher = "Media Rodzina", PublishingDate = DateTime.Parse("2016-01-01"), Isbn = "9788380082113" },
                new Book {Author = "Olga Tokarczuk ", Title = "Bieguni ", Publisher = "Wydawnictwo Literackie", PublishingDate = DateTime.Parse("2018-06-07"), Isbn = "9788308055946" }
                
            };
            books.ForEach(s => context.Books.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();
        }
    }
}
