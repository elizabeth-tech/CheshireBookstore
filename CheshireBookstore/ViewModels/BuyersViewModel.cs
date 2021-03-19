using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using MathCore.ViewModels;

namespace CheshireBookstore.ViewModels
{
    class BuyersViewModel : ViewModel
    {
        private readonly IRepository<Buyer> buyersRepository;

        public BuyersViewModel(IRepository<Buyer> buyers) => buyersRepository = buyers;
    }
}
