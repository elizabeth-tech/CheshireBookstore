using Bookstore.Lib.Entities;

namespace CheshireBookstore.Services.Interfaces
{
    internal interface IUserDialog
    {
        bool Edit(Book book);

        bool ConfirmInformation(string Information, string Caption);

        bool ConfirmWarning(string Information, string Caption);

        bool ConfirmError(string Information, string Caption);
    }
}
