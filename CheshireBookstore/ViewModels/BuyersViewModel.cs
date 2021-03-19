using MathCore.ViewModels;

namespace CheshireBookstore.ViewModels
{
    class BuyersViewModel : ViewModel
    {
        private object buyersRepository;

        public BuyersViewModel(object buyersRepository) => this.buyersRepository = buyersRepository;
    }
}
