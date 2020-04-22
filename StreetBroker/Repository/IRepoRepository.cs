using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreetBroker.Models;

namespace StreetBroker.Repository
{
    public interface IRepoRepository
    {
        List<RepoOrder> GetRepoOrders();
        bool InsertRepoOrder(RepoOrder repoOrder);
        RepoOrder GetRepoOrder(long id);
        bool DeleteRepoOrder(long id);
        bool UpdateRepoOrder(RepoOrder repoOrder);
    }
}
