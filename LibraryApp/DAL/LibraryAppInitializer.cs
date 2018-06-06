using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LibraryApp.Models;

namespace LibraryApp.DAL
{
    public class LibraryAppInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryAppContext>
    {

        protected override void Seed(LibraryAppContext context)
        {
            var readers = new List<Reader>
            {
                new Reader {Name="Rafał",Surname="Wojtas",Street="Nad Przyrwą",HouseNumber="13",ApartmentNumber="201",PostalCode="35-234",City="Rzeszów",PhoneNumber="500600700",Email="r.wojtas@ideo.pl"}
            };

            readers.ForEach(s => context.Readers.Add(s));
            context.SaveChanges();
                       

        }
    }
}