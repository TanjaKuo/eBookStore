using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eBookStore.Models;
using eBookStore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace eBookStore.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        private readonly IReserveRepository _reserveRepository;

        private readonly UserManager<IdentityUser> _userManager;


        public BookController(IBookRepository bookRepository,
            IReserveRepository reserveRepository,
            UserManager<IdentityUser> userManager)
        {
            _bookRepository = bookRepository;
            _reserveRepository = reserveRepository;
            _userManager = userManager;
        }

      

        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var seachedBook = await _bookRepository.GetSearchBooks(searchString);

                if(!seachedBook.Any())
                {
                    return View();
                }

                else
                {
                    var seachedResult = new BookViewModel
                    {
                        Books = (List<Book>)await _bookRepository.GetSearchBooks(searchString)
                    };

                    return View(seachedResult);
                }
            }
            else
            {
                var noSearch = new BookViewModel
                {
                    Books = (List<Book>)await _bookRepository.GetAllBooks()
            };
            return View(noSearch);
         }
   }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepository.GetSingleBook(id);

            if (book == null)
            {
                return NotFound();
            }            

            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Title,Reserve,ReserveNumber")] Book book)
        {
            var existingUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var specifBook = new Book
            {
                Id = book.Id,
                Title = book.Title,
                Reserve = book.Reserve,
            };

            if(specifBook != null && existingUser != null)
            {
                if(specifBook.Reserve == true)
                {

                    await _reserveRepository.GenerateBookingNumberAsync(book.Id, existingUser);

                    var bookNumber = await _reserveRepository.GetBookingNumberAsync(book.Id);
                    var reservedName = await _reserveRepository.GetReserveNameAsync(book.Id);
                    
                    await _bookRepository.UpdateBooking(book.Id, bookNumber, reservedName);
                }

                await _bookRepository.UpdateReserve(specifBook);

            }

            return RedirectToAction("Index");
        }
    }
}
