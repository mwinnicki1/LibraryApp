﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApp.Models
{
    public class Borrow
    {
        [Key]
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public int ReaderId { get; set; }
        public virtual Reader Reader { get; set; }
    }
}