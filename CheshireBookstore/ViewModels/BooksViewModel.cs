using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using CheshireBookstore.Infrastructure.DebugServices;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CheshireBookstore.ViewModels
{
    class BooksViewModel : ViewModel
    {
        #region Свойства

        private readonly IRepository<Book> booksRepository;

        private CollectionViewSource booksViewSource;

        //public IEnumerable<Book> Books => booksRepository.Items;

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
                if (Set(ref booksFilter, value)) // Если свойство изменилось
                    booksViewSource.View.Refresh(); // При каждом изменении обновляем CollectionViewSource
            }
        }

        #endregion

        #region Коллекция книг

        private ObservableCollection<Book> booksCollection;

        /// <summary>Коллекция книг</summary>
        public ObservableCollection<Book> BooksCollection
        {
            get => booksCollection;
            set
            {
                if (Set(ref booksCollection, value))
                {
                    booksViewSource.Source = value; // Меняем источник данных у представления
                    OnPropertyChanged(nameof(BooksView));
                }
            }
        }

        #endregion

        #endregion

        #region Команды

        #region Загрузить данные из репозитория

        private ICommand loadDataCommand;

        public ICommand LoadDataCommand => loadDataCommand
            ??= new LambdaCommandAsync(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute() => true;

        private async Task OnLoadDataCommandExecuted() => BooksCollection = new ObservableCollection<Book>(await booksRepository.Items.ToArrayAsync());

        #endregion

        #endregion

        #region Конструкторы

        public BooksViewModel(IRepository<Book> books)
        {
            booksRepository = books;

            booksViewSource = new CollectionViewSource
            {
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

            _ = OnLoadDataCommandExecuted();
        }

        #endregion

        // Событие вызывается для каждого отображаемого элемента книги
        private void OnBooksFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Book book) || string.IsNullOrEmpty(BooksFilter)) return; // Если это не книга или фильтр не задан, то ничего не делаем

            if (book.Name.Contains(BooksFilter))
                e.Accepted = false;
        }
    }
}
