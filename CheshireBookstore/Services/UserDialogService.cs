using Bookstore.Lib.Entities;
using CheshireBookstore.Services.Interfaces;
using CheshireBookstore.ViewModels;
using CheshireBookstore.Views.Windows;

namespace CheshireBookstore.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool Edit(Book book)
        {
            var book_editor_model = new BookEditorViewModel(book);
            var book_editor_window = new BookEditorWindow
            {
                DataContext = book_editor_model
            };

            // Если пользователь в диалоговом окне отказался от изменений, то ничего не делаем
            if (book_editor_window.ShowDialog() != true) return false;

            book.Name = book_editor_model.BookName; // Если не отказался, то копируем данные из модели-представления в модель книги

            return true;
        }
    }
}
