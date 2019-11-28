using NUnit.Framework;
using RandomQuotes.Models;

namespace RandomQuotes.Test
{
    public class QuoteFixture
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_Create_Quote()
        {
            var testQuote = "Test quote";
            var testAuthor = "test author";
            var quote = Quote.BuildQuote(testQuote, testAuthor);
            
            Assert.That(quote.QuoteText, Is.EqualTo(testQuote));
            Assert.That(quote.Author, Is.EqualTo(testAuthor));
        }
    }
}