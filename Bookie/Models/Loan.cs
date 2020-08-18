using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookie.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime DateLoaned { get; set; }
        public DateTime? DateReturned { get; set; }

        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Book Book { get; set; }
    }
}