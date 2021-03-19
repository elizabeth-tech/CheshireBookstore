using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using MathCore.ViewModels;

namespace CheshireBookstore.ViewModels
{
    class BooksViewModel : ViewModel
    {
        private readonly IRepository<Book> booksRepository;

        public BooksViewModel(IRepository<Book> books) => booksRepository = books;
    }
}
