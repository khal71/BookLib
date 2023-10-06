using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {
     private IBookRepo _bookRepo;
        private readonly Book _badBook = new Book() { Id = 13, Title = "Row", price = 10000 };

        [TestInitialize]
            public void Init()
        {
            _bookRepo = new BooksRepository();
        }
        [TestMethod()]
        public void getByIdTest()
        {
            Assert.IsNotNull(_bookRepo.getById(2)); 
            Assert.IsNull(_bookRepo.getById(14));
        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Book> book= _bookRepo.Get();
            Assert.AreEqual(5, book.Count());
            IEnumerable<Book> sortbooks = _bookRepo.Get(sortby: "title-asc");
            Assert.AreEqual("Batman",sortbooks.First().Title);
            IEnumerable<Book> sortsbooks = _bookRepo.Get(sortby: "price-asc");
            Assert.AreEqual(900, sortsbooks.First().price);
            IEnumerable<Book> defaultCase = _bookRepo.Get(sortby: "InvalidOrder"); 
            Assert.IsNotNull(defaultCase); 
        }

        [TestMethod()]
        public void AddTest()
        {
            Book book = new Book() { Id = 15, Title = "The light", price=1000};
            Assert.AreEqual(15,_bookRepo.Add(book).Id);
            Assert.AreEqual(6,_bookRepo.Get().Count());
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>_bookRepo.Add(_badBook));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.IsNull(_bookRepo.Delete(99));
            Assert.AreEqual(1, _bookRepo.Delete(1).Id);
            Assert.AreEqual(4, _bookRepo.Get().Count()); 
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Book book = new Book() { Id = 16, Title = "Green", price = 1000 };
            Assert.IsNull(_bookRepo.Update(88, book));
            Assert.AreEqual(2,_bookRepo.Update(2,book).Id);
            Assert.AreEqual(5, _bookRepo.Get().Count());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _bookRepo.Update(1,_badBook));

        }
        [TestMethod()]
        public void GetFilteredTest()
        {
            IEnumerable<Book> booksAbovePrice = _bookRepo.Get(overPrice: 1002);
            Assert.AreEqual(3, booksAbovePrice.Count());

            IEnumerable<Book> booksBelowPrice = _bookRepo.Get(underPrice: 1003);
            Assert.AreEqual(2, booksBelowPrice.Count());
        }

        [TestMethod()]
        public void GetSortedTest()
        {
            IEnumerable<Book> sortedByTitle = _bookRepo.Get(sortby: "title-asc");
            Assert.IsTrue(sortedByTitle.SequenceEqual(sortedByTitle.OrderBy(book => book.Title)));

            IEnumerable<Book> sortedByTitleDesc = _bookRepo.Get(sortby: "title-desc");
            Assert.IsTrue(sortedByTitleDesc.SequenceEqual(sortedByTitleDesc.OrderByDescending(book => book.Title)));

            IEnumerable<Book> sortedByPrice = _bookRepo.Get(sortby: "price-asc");
            Assert.IsTrue(sortedByPrice.SequenceEqual(sortedByPrice.OrderBy(book => book.price)));

            IEnumerable<Book> sortedByPriceDesc = _bookRepo.Get(sortby: "price-desc");
            Assert.IsTrue(sortedByPriceDesc.SequenceEqual(sortedByPriceDesc.OrderByDescending(book => book.price)));
        }
    }
}