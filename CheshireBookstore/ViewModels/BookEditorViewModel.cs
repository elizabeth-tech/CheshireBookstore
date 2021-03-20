using Bookstore.Lib.Entities;
using MathCore.ViewModels;
using System;

namespace CheshireBookstore.ViewModels
{
    internal class BookEditorViewModel : ViewModel
    {
        public int BookId { get; }

        #region Название книги

        /// <summary>Название книги</summary>
        private string bookName;

        /// <summary>Название книги</summary>
        public string BookName
        {
            get => bookName;
            set => Set(ref bookName, value);
        }

        #endregion

        public BookEditorViewModel()
            :this(new Book { Id = 1, Name = "Хребты безумия"})
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Не предназначено для рантайма");
        }

        public BookEditorViewModel(Book book)
        {
            BookId = book.Id;
            BookName = book.Name;
        }
    }
}
