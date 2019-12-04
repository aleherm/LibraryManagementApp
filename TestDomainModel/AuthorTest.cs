using DomainModel;
using NUnit.Framework;

namespace TestDomainModel
{
    [TestFixture]
    public class AuthorTest
    {
        [TestCase]
        public void AuthorFirstNameShouldHaveAtLeast5Characters()
        {
            Author author = new Author();
            author.FirstName = "Alexandra";
            Assert.IsTrue(author.FirstName.Length >= 5);
        }

        [TestCase]
        public void AuthorLastNameShouldHaveAtLeast5Characters()
        {
            Author author = new Author();
            author.LastName = "Hermeneanu";
            Assert.IsTrue(author.LastName.Length >= 5);
        }

        [TestCase]
        public void AuthorLanguageShouldHaveAtLeast5Characters()
        {
            Author author = new Author();
            author.Language = "Romanian";
            Assert.IsTrue(author.Language.Length >= 5);
        }
    }
}
