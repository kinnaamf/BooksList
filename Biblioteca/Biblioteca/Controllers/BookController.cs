using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Composition.Convention;
using System.Net;

namespace Biblioteca.Controllers
{
    public class BookController : Controller
    {
        static IList<Models.Book> booksList = new List<Models.Book> {
            new Models.Book() { ID = 1, Denumire = "Mândrie și prejudecată", Autor = "Jane Austen", NrPagini = 432, AnEditare = 1813 },
            new Models.Book() { ID = 2, Denumire = "1984", Autor = "George Orwell", NrPagini = 328, AnEditare = 1949 },
            new Models.Book() { ID = 3, Denumire = "Cronicile din Narnia", Autor = "C.S. Lewis", NrPagini = 768, AnEditare = 1950 },
            new Models.Book() { ID = 4, Denumire = "Sapiens: Scurtă istorie a omenirii", Autor = "Yuval Noah Harari", NrPagini = 464, AnEditare = 2011 },
            new Models.Book() { ID = 5, Denumire = "Harry Potter și piatra filozofală", Autor = "J.K. Rowling", NrPagini = 352, AnEditare = 1997 },
            new Models.Book() { ID = 6, Denumire = "Crimă și pedeapsă", Autor = "Fiodor Dostoievski", NrPagini = 430, AnEditare = 1866 },
            new Models.Book() { ID = 7, Denumire = "Război și pace", Autor = "Lev Tolstoi", NrPagini = 1225, AnEditare = 1869 },
            new Models.Book() { ID = 8, Denumire = "Marea Gatsby", Autor = "F. Scott Fitzgerald", NrPagini = 180, AnEditare = 1925 },
            new Models.Book() { ID = 9, Denumire = "To Kill a Mockingbird", Autor = "Harper Lee", NrPagini = 281, AnEditare = 1960 },
            new Models.Book() { ID = 10, Denumire = "Fahrenheit 451", Autor = "Ray Bradbury", NrPagini = 158, AnEditare = 1953 },
            new Models.Book() { ID = 11, Denumire = "Pe aripile vântului", Autor = "Margaret Mitchell", NrPagini = 1037, AnEditare = 1936 },
            new Models.Book() { ID = 12, Denumire = "Catcher in the Rye", Autor = "J.D. Salinger", NrPagini = 277, AnEditare = 1951 },
            new Models.Book() { ID = 13, Denumire = "Lord of the Flies", Autor = "William Golding", NrPagini = 224, AnEditare = 1954 },
            new Models.Book() { ID = 14, Denumire = "Un veac de singurătate", Autor = "Gabriel García Márquez", NrPagini = 417, AnEditare = 1967 },
            new Models.Book() { ID = 15, Denumire = "Micul Prinț", Autor = "Antoine de Saint-Exupéry", NrPagini = 96, AnEditare = 1943 }
        };
        public ActionResult Index()
        {
            return View(booksList.OrderBy(book => book.ID).ToList());
        }
        public ActionResult Create(Models.Book book)
        {
            if(ModelState.IsValid)
            {
                book.ID = booksList.Count + 1;
                booksList.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public ActionResult Edit(int Id) { 
            var book = booksList.Where(b => b.ID == Id).FirstOrDefault();
            return View(book); 
        }
        [HttpPost]
        public ActionResult Edit(Models.Book books)
        {
            var book = booksList.Where(b => b.ID == books.ID).FirstOrDefault();
            booksList.Remove(book);
            booksList.Add(books);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            if(Id == null) { return StatusCode(404); } 

            var book = booksList.FirstOrDefault(b => b.ID == Id);

            if(book == null)
            {
                return StatusCode(505);
            }
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var book = booksList.FirstOrDefault(b => b.ID == id);
            if(book != null)
            {
                booksList.Remove(book);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? Id)
        {
            var book =  booksList.FirstOrDefault(b => b.ID == Id);
            if (book == null)
            {
                return StatusCode(404);
            }
            return View(book);
        }
    }
}
