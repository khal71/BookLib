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
    public class BookTests
    {
        private readonly Book _book = new Book() {Id= 1, Title= "khaled is crying", price=10};
        private readonly Book _nullName = new Book() { Id = 2, price = 1100 };
        private readonly Book _shortTittle = new Book() { Id = 3, Title = "Ja", price=1000 };
        private readonly Book _negativePrice = new Book() { Id = 4, Title = "I dont want to do this anymore", price = -10 };
        private readonly Book _overPrice = new Book() { Id = 5, Title = "searching for a sugar daddy", price = 2000 };
       


        [TestMethod()]
        public void ToStringTest()
        {
            Book book = new Book(1,"check",501);
            string expected = "{Id=1, Title=check, price=501}";
            string actual = book.ToString();
            Assert.AreEqual(expected, actual);


        }
        [TestMethod()]
        public void ConstructerWithNoParameters()
        {
            var book= new Book();
            Assert.AreEqual(0,book.Id); 
            Assert.AreEqual(null,book.Title);
            Assert.AreEqual(0,book.price);  
        }
        [TestMethod()]
        public void ConstructerWithParameters()
        {
            var book = new Book(1, "grass is crying", 1000);
            Assert.AreEqual(1,book.Id);
            Assert.AreEqual("grass is crying", book.Title);
            Assert.AreEqual(1000, book.price);

        }

        [TestMethod()]
        public void ValidateTitleTest()
        {
            _book.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException>(() => _nullName.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => _shortTittle.ValidateTitle());

        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            _book.ValidatePrice();
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => _negativePrice.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _overPrice.ValidatePrice());
        }

        [TestMethod()]
        public void ValidationTest()
        {
            _book.Validation();
            Assert.ThrowsException<ArgumentNullException>(() => _nullName.Validation());
            Assert.ThrowsException<ArgumentException>(() => _shortTittle.Validation());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _negativePrice.Validation());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _overPrice.Validation());


        }
    }
}