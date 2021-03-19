using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using MathCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheshireBookstore.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        private IRepository<Book> booksRepository;
        private object buyersRepository;
        private object sellersRepository;

        public StatisticViewModel(IRepository<Book> booksRepository, object buyersRepository, object sellersRepository)
        {
            this.booksRepository = booksRepository;
            this.buyersRepository = buyersRepository;
            this.sellersRepository = sellersRepository;
        }
    }
}
