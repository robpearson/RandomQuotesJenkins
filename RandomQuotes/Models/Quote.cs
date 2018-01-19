using System;

namespace RandomQuotes.Models
{
    public class Quote
    {
        public static string[] Quotes;

        public static string[] Authors;

        private Quote(string text, string author)
        {
            QuoteText = text;
            Author = author;
        }

        public static Quote GetRandomQuote()
        {
            var random = new Random();
            var index = random.Next(Quotes.Length);
            var randomQuote = Quotes[index];
            var randomAuthor = Authors[index];
            return BuildQuote(randomQuote, randomAuthor);
        }

        public static Quote BuildQuote(string quote, string author)
        {
            return new Quote(quote, author);
        }

        public string QuoteText { get; set; }
        public string Author { get; set; }
    }
}
