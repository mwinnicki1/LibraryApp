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
        [DataType(DataType.Date)]
        [Display(Name = "Publishing date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishingDate { get; set; }

        [Required]
        [StringLength(13)]
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Borrow date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BorrowDate { get; set; }

        [Display(Name = "Reader")]
        public int? ReaderId { get; set; }

        public virtual Reader Reader { get; set; }
    }
}