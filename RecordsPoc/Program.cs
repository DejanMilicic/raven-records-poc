using Raven.Client.Documents;

namespace RecordsPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new DocumentStore
            {                
                Urls = new[] { "http://localhost:8080" },
                Database = "test-records",
            };

            store.Initialize();

            using (var session = store.OpenSession())
            {
                var person = new Person("John", "Doe");

                session.Store(person);
                session.SaveChanges();
            }
        }        
    }

    public record Person(string FirstName, string LastName);
}
