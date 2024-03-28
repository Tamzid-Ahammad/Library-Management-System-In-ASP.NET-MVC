using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LibraryMangementSystem
    {
        [Key]
        public Guid LibraryId { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(100)]
        public string StudentName { get; set; }
        [StringLength(150)]
        [Required]
        [EmailAddress]
        public string StudentEmail { get; set; }
        [StringLength(150)]
        [DataType(DataType.MultilineText)]
        public string StudentAddress { get; set; }
        [Range(1, 10)]
        [Required]
        public int DaysforBookBorrowed { get; set; }
        public List<BookInfo> BookInformation { get; set; } = new List<BookInfo>();

    }



    public class BookInfo
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        
        public string BookExistingArea { get; set; }
        
        public decimal BookBorrowingPrice { get; set; }
        
    }
}