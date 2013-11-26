using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Phone.UserData;

namespace Kulman.WP8.Interfaces
{
    public interface IAddressBookService
    {
        /// <summary>
        /// Gets a list of contacts in device address book
        /// </summary>
        /// <returns>List of contact</returns>
        Task<List<Contact>> GetContacts();

        /// <summary>
        /// Gets a list of contacts in device address book filtered by search criteria
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        /// <param name="filter">Filter</param>
        /// <returns>List of contact</returns>
        Task<List<Contact>> Search(string searchTerm, FilterKind filter);
    }
}
