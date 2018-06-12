using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        [Display(Name = "Publishing date")]
        public DateTime PublishingDate { get; set; }

        [Required]
        [StringLength(13)]
        public string Isbn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Borrow date")]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BorrowDate { get; set; }

        public virtual Reader Reader { get; set; }
    }
}