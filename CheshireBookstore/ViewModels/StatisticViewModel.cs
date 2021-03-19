using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CheshireBookstore.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        private readonly IRepository<Book> booksRepository;
        private readonly IRepository<Buyer> buyersRepository;
        private readonly IRepository<Seller> sellersRepository;

        public StatisticViewModel(IRepository<Book> books, IRepository<Buyer> buyers, IRepository<Seller> sellers)
        {
            booksRepository = books;
            buyersRepository = buyers;
            sellersRepository = sellers;
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
        }

        #endregion

        #endregion

    }
}
