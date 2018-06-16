using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryApp.Models;

namespace LibraryApp.ViewModel
{
    public class BorrowIndex
    {
        public Reader reader { get; set; }
        public Book book { get; set; }
    }
}