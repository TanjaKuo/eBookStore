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

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly UserManager<IdentityUser> _userManager;


        public BookController(IBookRepository bookRepository,
            IReserveRepository reserveRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _bookRepository = bookRepository;
            _reserveRepository = reserveRepository;
            _signInManager = signInManager;
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


        //// GET: Book/Edit/5
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
            //var user2 = await _userManager.FindByEmailAsync(User.Identity.Name);
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

                    //await _reserveRepository.GenerateBookingNumberAsync(book.Id, user);
                    await _reserveRepository.GenerateBookingNumberAsync(book.Id, existingUser);

                    var bookNumber = await _reserveRepository.GetBookingNumberAsync(book.Id);
                    var reservedName = await _reserveRepository.GetReserveNameAsync(book.Id);
                    //await _bookRepository.UpdateBookingNumber(book.Id, abc, user);
                    //await _bookRepository.UpdateBookingNumber(book.Id, bookNumber);
                    //await _bookRepository.UpdateReserveName(book.Id, reservedName);
                    await _bookRepository.UpdateBooking(book.Id, bookNumber, reservedName);
                }
                await _bookRepository.UpdateReserve(specifBook);

            }

            return RedirectToAction("Index");
        }

        // GET: Book/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null || _context.Book == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = await _context.Book
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(book);
        //}

        //// GET: Book/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Book/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Reserve")] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        book.Id = Guid.NewGuid();
        //        _context.Add(book);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(book);
        //}



        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //if (id != book.Id)
        //{
        //    return NotFound();
        //}

        //if (ModelState.IsValid)
        //{
        //    try
        //    {
        //        _bookRepository.Update(book);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookExists(book.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
        //  return View(book);
        //  }


    }
}
