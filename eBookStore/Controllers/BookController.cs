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

namespace eBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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
        // Guid id, [Bind("Id,Title,Reserve")] Book book
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Reserve,ReserveNumber")] Book book)
        {
            var specifBook = new Book
            {
                Id = book.Id,
                Title = book.Title,
                Reserve = book.Reserve
            };

            if(specifBook != null)
            {
                if(specifBook.Reserve == true)
                {
                    var number = Guid.NewGuid();
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
