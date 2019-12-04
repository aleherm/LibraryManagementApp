using DomainModel;
using NUnit.Framework;

namespace TestDomainModel
{
    [TestFixture]
    public class BookTest
    {
        [TestCase]
        public void BookTitleShouldHaveAtLeast2Characters()
        {
            Book book = new Book();
            string title = "Zelda";
            book.Title = title;
            Assert.IsTrue(book.Title.Length >= 2);
        }

        [TestCase]
        public void BookTitleShouldNotHaveLessThan2Characters()
        {
            Book book = new Book();
            book.Title = "Z";
            Assert.IsFalse(book.Title.Length >= 2);
        }

        [TestCase]
        public void BookShouldHaveAtLeast1Edition()
        {
            Book book = new Book();
            book.Editions.Add(new Edition());
            Assert.NotNull(book.Editions);
        }

        [TestCase]
        public void BookShouldHaveAtLeast1Author()
        {
            Book book = new Book();
            book.Authors.Add(new Author());
            Assert.NotNull(book.Authors);
        }
    }
}
