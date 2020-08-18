using AutoMapper;
using Bookie.Dtos;
using Bookie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookie.Controllers.Api
{
    public class LoansController : ApiController
    {
        private ApplicationDbContext _context;

        public LoansController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetLoans()
        {
            var loans = _context.Loans.Include(l=>l.Customer).Include(l=>l.Book).Where(l => l.DateReturned == null).ToList();

            var loanDtos = new List<OldLoanDto>();

            foreach (var l in loans)
            {
                var newLoan = new OldLoanDto
                {
                    CustomerName = l.Customer.Name,
                    BookName = l.Book.Name,
                    DateLoaned = l.DateLoaned.ToShortDateString()
                };
                loanDtos.Add(newLoan);

            }

            return Ok(loanDtos);
        }

        [HttpPost]
        public IHttpActionResult CreateLoan(LoanDto newLoan)
        {
            if (newLoan.BookIds.Count == 0)
                return BadRequest("No Book Ids found.");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newLoan.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is invalid.");

            var books = _context.Books.Where(b => newLoan.BookIds.Contains(b.Id)).ToList();

            if (books.Count != newLoan.BookIds.Count)
                return BadRequest("One or more Book Ids are invalid.");

            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                book.NumberAvailable--;

                var rental = new Loan
                {
                    Customer = customer,
                    Book = book,
                    DateLoaned = DateTime.Now
                };
                _context.Loans.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
