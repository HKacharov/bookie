using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookie.Dtos
{
    public class OldLoanDto
    {
        public string CustomerName { get; set; }
        public string BookName { get; set; }
        public string DateLoaned { get; set; }
    }
}