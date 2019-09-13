using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Refit;
using RequestPractice.Models;

namespace RequestPractice.Services
{
    [Headers("Authorization: Token aa8e953cdf3b5817bbb79c018c0b155b0ef86ad0")]
    public interface IPersonalRelations
    {
        [Get("/contacts/")]
        Task<ObservableCollection<Contact>> GetContacts();

    }
}
