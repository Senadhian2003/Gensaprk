using LinqApp.Model;

namespace LinqApp
{
    internal class Program
    {
        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t.Pub, (pid, title) => new { Key = pid, TitleCount = title.Count() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
            }
        }
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }

        void PrintNumberOfBooksFromEachType()
        {
            pubsContext context = new pubsContext();
            var groupedTitles = context.Titles.GroupBy(t => t.PubId)
                                 .Select(g => new { PubId = g.Key, Count = g.Count() })
                                 .ToList();

            foreach (var item in groupedTitles)
            {
                Console.WriteLine($"PubId: {item.PubId}, Count: {item.Count}");
            }


        }

        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            //program.PrintTheBooksPulisherwise();

            program.PrintNumberOfBooksFromEachType();

        }
    }
}
