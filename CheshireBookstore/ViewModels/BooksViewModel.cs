using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using CheshireBookstore.Infrastructure.DebugServices;
using MathCore.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace CheshireBookstore.ViewModels
{
    class BooksViewModel : ViewModel
    {
        private readonly IRepository<Book> booksRepository;

        private CollectionViewSource booksViewSource;

        public IEnumerable<Book> Books => booksRepository.Items;

        public ICollectionView BooksView  => booksViewSource.View;

        #region Искомое слово для поиска книг

        /// <summary>Искомое слово</summary>
        private string booksFilter;

        /// <summary>Искомое слово</summary>
        public string BooksFilter
        {
            get => booksFilter;
            set
            {
                if (Set(ref booksFilter, value))
                    booksViewSource.View.Refresh();
            }
        }

        #endregion



        //Конструкторы

        public BooksViewModel(IRepository<Book> books)
        {
            booksRepository = books;

            booksViewSource = new CollectionViewSource
            {
                Source = booksRepository.Items.ToArray(),
                SortDescriptions =
                {
                    new SortDescription(nameof(Book.Name), ListSortDirection.Ascending)
                }
            };

            booksViewSource.Filter += OnBooksFilter;
        }

        public BooksViewModel()
            :this(new DebugBooksRepository()) // отладочный репозиторий
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Используется конструктор для тестирования");
        }

        // Событие вызывается для каждого отображаемого элемента книги
        private void OnBooksFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Book book) || string.IsNullOrEmpty(BooksFilter)) return; // Если это не книга или фильтр не задан, то ничего не делаем

            if (!book.Name.Contains(BooksFilter))
                e.Accepted = false;
        }
    }
}
