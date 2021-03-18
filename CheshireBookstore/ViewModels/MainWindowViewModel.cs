using MathCore.ViewModels;

namespace CheshireBookstore.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Свойства

        #region Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string title = "Книжный магазин \"Чешир\"";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        #endregion

        #endregion

    }
}
