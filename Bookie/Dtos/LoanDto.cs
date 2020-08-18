using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookie.Dtos
{
    public class LoanDto
    {
        public int CustomerId { get; set; }
        public List<int> BookIds { get; set; }
    }
}