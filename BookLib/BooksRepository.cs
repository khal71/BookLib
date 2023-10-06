using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class BooksRepository :IBookRepo
    {
        //hardcore
        private readonly List<Book> books = new List<Book>
        {
        new Book(1,"the power",1000),
        new Book(2,"hero",1200),
        new Book(3,"The killer",900),
        new Book(4,"the power",1100),
        new Book(5,"Batman",1089)
        }; 
        public Book getById(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Book> Get(int? overPrice = null, int? underPrice = null, string? sortby = null )
        {
            IEnumerable<Book> list = new List<Book>(books); 
            if (overPrice != null)
            {
                list = list.Where(x => x.price> overPrice);

            }
            if (underPrice != null)
            {
                list = list.Where(x => x.price < underPrice); 
            }
            if (sortby != null)
            {
                sortby = sortby.ToLower();
                switch(sortby)
                {
                    case "title":
                    case "title-asc":
                        list = list.OrderBy(x => x.Title);
                        break;
                    case "title-desc":
                        list = list.OrderByDescending(x => x.Title);
                        break;
                    case "price":
                    case "price-asc":
                        list = list.OrderBy(x => x.price); 
                        break;
                    case "price-desc": 
                        list=list.OrderByDescending(x => x.price);
                        break;
                    default:
                        break; 
                            
                }
            }
            return list;


        }
        public Book Add(Book book)
        {
            book.Validation();
            books.Add(book);
            return book; 
        }
        public Book Delete(int id)
        {
            Book book= getById(id);
            if (book==null)
            {
                return null; 
            }
            books.Remove(book);
            return book; 
        }
        public Book Update(int id, Book book)
        {
            book.Validation(); 
            Book existingBook= getById(id); 
            if(existingBook==null)
            {
                return null;
            }
            existingBook.price = book.price;
            existingBook.Title=book.Title;
            return existingBook;

        }

       


    }
}
