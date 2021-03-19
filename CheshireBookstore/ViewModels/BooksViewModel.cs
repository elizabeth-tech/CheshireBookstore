using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using MathCore.ViewModels;

namespace CheshireBookstore.ViewModels
{
    class BooksViewModel : ViewModel
    {
        private IRepository<Book> booksRepository;

        public BooksViewModel(IRepository<Book> booksRepository) => this.booksRepository = booksRepository;
    }
}
