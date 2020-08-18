using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookie.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [Required]
        [MaxLength(55)]
        public string Name { get; set; }
    }
}