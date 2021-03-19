using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using CheshireBookstore.Services.Interfaces;
using MathCore.ViewModels;
using System.Linq;

namespace CheshireBookstore.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Свойства

        private readonly IRepository<Book> booksRepository;

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
