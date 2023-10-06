using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public interface IBookRepo
    {
        public Book getById(int id);
        public IEnumerable<Book> Get(int? overPrice = null, int? underPrice = null, string? sortby = null);
        public Book Add(Book book);
        public Book Delete(int id);
        public Book Update(int id, Book book);





    }
}
