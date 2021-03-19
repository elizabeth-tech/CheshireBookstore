using Bookstore.Lib.Entities;

namespace CheshireBookstore.Models
{
    internal class BestsellersInfo
    {
        public Book Book { get; set; }

        public int SellCount { get; set; }

        public decimal SumCost { get; set; }
    }
}
