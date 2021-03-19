using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using CheshireBookstore.Models;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
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

        public ObservableCollection<BestsellersInfo> Bestsellers { get; } = new ObservableCollection<BestsellersInfo>();

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
            await ComputeDealsStatisticAsync();

            //BooksCount = await booksRepository.items.CountAsync();
        }

        private async Task ComputeDealsStatisticAsync()
        {
            var bestsellers_query = dealsRepository.items
               .GroupBy(b => b.Book.Id)
               .Select(deals => new { BookId = deals.Key, Count = deals.Count(), Sum = deals.Sum(d => d.Price) })
               .OrderByDescending(deals => deals.Count)
               .Take(5)
               .Join(booksRepository.items,
                    deals => deals.BookId,
                    book => book.Id,
                    (deals, book) => new BestsellersInfo
                    {
                        Book = book,
                        SellCount = deals.Count,
                        SumCost = deals.Sum
                    });

            //Bestsellers.Clear();
            //foreach (var bestseller in await bestsellers_query.ToArrayAsync())
                //Bestsellers.Add(bestseller);

            Bestsellers.AddClear(await bestsellers_query.ToArrayAsync());
        }

        #endregion

        #endregion

    }
}
