using Bookstore.Lib.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheshireBookstore.Services.Interfaces
{
    internal interface ISalesService
    {
        IEnumerable<Deal> Deals { get; } // Свойство, которое отображает все продажи

        // Метод создания новой сделки
        Task<Deal> MakeDeal(string bookName, Seller seller, Buyer buyer, decimal price);
    }
}
