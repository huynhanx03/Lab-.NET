using ODataBookStore.Models;

namespace ODataBookStore.Data
{
    public static class DataSource
    {
        private static IList<Book> listBooks { get; set; }
        public static IList<Book> GetBooks()
        {
            if(listBooks != null)
            {
                return listBooks;
            }
            listBooks = new List<Book>();
            Book book = new Book
            {
                Id = 1,
                ISBN="978-0-321-87758-1",
                Title= "Essential C#6.0",
                Author="Quoc An",
                Price=59.99m,
                Location = new Address
                {
                    City="HCM City",
                    Street="D2, Thu Duc District"
                },
                Press = new Press
                {
                    Id= 1,
                    Name="Kawasaki",
                    Category= Category.Book,
                }
            };
            listBooks.Add(book);
            book = new Book
            {
                Id = 2,
                ISBN = "978-0-321-87758-1",
                Title = "Lam Nguoi",
                Author = "Con Da Lap",
                Price = 59.99m,
                Location = new Address
                {
                    City = "Hau Giang",
                    Street = "D2, Thu Duc District"
                },
                Press = new Press
                {
                    Id = 2,
                    Name = "Honda",
                    Category = Category.Book,
                }
            };
            listBooks.Add(book);
            book = new Book
            {
                Id = 3,
                ISBN = "978-0-321-87758-1",
                Title = "Essential C#4.0",
                Author = "Phu Cho",
                Price = 59.99m,
                Location = new Address
                {
                    City = "Soc Trang",
                    Street = "Tra Quyt"
                },
                Press = new Press
                {
                    Id = 3,
                    Name = "Suzuki",
                    Category = Category.Book,
                }
            };
            listBooks.Add(book);
            return listBooks;
        }
    }
}
