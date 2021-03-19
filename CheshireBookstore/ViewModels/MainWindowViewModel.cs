using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using CheshireBookstore.Services.Interfaces;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using System.Linq;
using System.Windows.Input;

namespace CheshireBookstore.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Свойства

        private readonly IRepository<Book> booksRepository;
        private readonly IRepository<Buyer> buyersRepository;
        private readonly IRepository<Seller> sellersRepository;
        private readonly IRepository<Deal> dealsRepository;
        private readonly ISalesService salesService;

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

        #region Текущая дочерняя ViewModel

        private ViewModel currentVM;

        /// <summary>Основная ViewModel может изменять значение дочерней</summary>
        public ViewModel CurrentVM
        {
            get => currentVM;
            private set => Set(ref currentVM, value);
        }

        #endregion

        #endregion

        #region Команды

        #region Отобразить представление с книгами

        private ICommand showBooksViewCommand;

        public ICommand ShowBooksViewCommand => showBooksViewCommand ??= new LambdaCommand(OnShowBooksViewCommandExecuted, CanShowBooksViewCommandExecute);

        private bool CanShowBooksViewCommandExecute(object p) => true;

        private void OnShowBooksViewCommandExecuted(object p) => CurrentVM = new BooksViewModel(booksRepository);

        #endregion

        #region Отобразить представление с покупателями

        private ICommand showBuyersViewCommand;

        public ICommand ShowBuyersViewCommand => showBuyersViewCommand ??= new LambdaCommand(OnShowBuyersViewCommandExecuted, CanShowBuyersViewCommandExecute);

        private bool CanShowBuyersViewCommandExecute(object p) => true;

        private void OnShowBuyersViewCommandExecuted(object p) => CurrentVM = new BuyersViewModel(buyersRepository);

        #endregion

        #region Отобразить представление со статистикой

        private ICommand showStatisticViewCommand;

        public ICommand ShowStatisticViewCommand => showStatisticViewCommand ??= new LambdaCommand(OnShowStatisticViewCommandExecuted, CanShowStatisticViewCommandExecute);

        private bool CanShowStatisticViewCommandExecute(object p) => true;

        private void OnShowStatisticViewCommandExecuted(object p) => CurrentVM = new StatisticViewModel(
            booksRepository,
            buyersRepository,
            sellersRepository);

        #endregion

        #endregion

        public MainWindowViewModel(IRepository<Book> booksRep,
            IRepository<Seller> sellers,
            IRepository<Buyer> buyers,
            IRepository<Deal> deals,
            ISalesService salesService)
        {
            booksRepository = booksRep;
            //sellersRepository = sellers;
            //buyersRepository = buyers;
            //dealsRepository = deals;
            //this.salesService = salesService;

            //this.booksRepository = booksRepository;
            //var _books = booksRepository.items.Take(10).ToArray();

            //var deals_count = salesService.Deals.Count();
            //var book = booksRepository.Get(5);
            //var buyer = buyers.Get(3);
            //var seller = sellers.Get(7);

            //var deal = salesService.MakeDeal(book.Name, seller, buyer, 100m);
            //var deals_count2 = salesService.Deals.Count();
        }
    }
}
