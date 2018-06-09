using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApp.Models
{
    public class BorrowBook
    {
        [Key]
        public int Id { get; set; }
        public int BorrowId { get; set; }
        public int BookId { get; set; }

    }
}