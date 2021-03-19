using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CheshireBookstore.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        private readonly IRepository<Book> booksRepository;
        private readonly IRepository<Buyer> buyersRepository;
        private readonly IRepository<Seller> sellersRepository;
        private readonly IRepository<Deal> dealsRepository;

        public StatisticViewModel(IRepository<Book> books,
            IRepository<Buyer> buyers,
            IRepository<Seller> sellers,
            IRepository<Deal> deals)
        {
            booksRepository = books;
            buyersRepository = buyers;
            sellersRepository = sellers;
            dealsRepository = deals;
        }

        #region Свойства

        #region Количество книг

        /// <summary>Количество книг</summary>
        private int booksCount;

        /// <summary>Количество книг</summary>
        public int BooksCount
        {
            get => booksCount;
            set => Set(ref booksCount, value);
        }

        #endregion

        #endregion

        #region Команды

        #region Вычислить статистические данные

        private ICommand computeStatisticCommand;

        public ICommand ComputeStatisticCommand => computeStatisticCommand ??= new LambdaCommandAsync(OnComputeStatisticCommandExecuted, CanComputeStatisticCommandExecute);

        private bool CanComputeStatisticCommandExecute() => true;

        private async Task OnComputeStatisticCommandExecuted()
        {
            BooksCount = await booksRepository.items.CountAsync();

            var deals = dealsRepository.items;
            var bestsellers = deals.GroupBy(deal => deal.Book)
                .Select(book_deals => new { Book = book_deals.Key, Count = book_deals.Count() })
                .OrderByDescending(book => book.Count)
                .Take(5)
                .ToArrayAsync();
        }

        #endregion

        #endregion

    }
}
