using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kulman.WP8.Interfaces;
using Microsoft.Phone.UserData;

namespace Kulman.WP8.Services
{
    /// <summary>
    /// Address book wrapper
    /// Needs address book permissions to work
    /// </summary>
    public class AddressBookService : IAddressBookService
    {
        /// <summary>
        /// Gets a list of contacts in device address book
        /// </summary>
        /// <returns>List of contact</returns>
        public Task<List<Contact>> GetContacts()
        {
            var t = new TaskCompletionSource<List<Contact>>();
            SearchContacts(s => t.TrySetResult(s));
            return t.Task;
        }

        /// <summary>
        /// Gets a list of contacts in device address book filtered by search criteria
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        /// <param name="filter">Filter</param>
        /// <returns>List of contact</returns>
        public Task<List<Contact>> Search(string searchTerm, FilterKind filter)
        {
            var t = new TaskCompletionSource<List<Contact>>();
            SearchContacts(s => t.TrySetResult(s),filter,searchTerm);
            return t.Task;
        }

        /// <summary>
        /// Gets a list of contacts in device address book filtered by search criteria
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        /// <param name="callback">Callback</param>
        /// <param name="filter">Filter</param>
        /// <returns>List of contact</returns>
        private void SearchContacts(Action<List<Contact>> callback, FilterKind filter = FilterKind.None, string searchTerm = null)
        {
            var cons = new Contacts();
            cons.SearchCompleted += (s, e) => callback(e.Results.ToList());
            cons.SearchAsync(String.IsNullOrEmpty(searchTerm) ? string.Empty : searchTerm, filter, null);
        }
    }
}
