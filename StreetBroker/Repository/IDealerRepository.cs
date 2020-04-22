using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreetBroker.Models;

namespace StreetBroker.Repository
{
    public interface IDealerRepository
    {
        List<Dealer> GetDealers();
        bool InsertDealer(Dealer dealer);
        Dealer GetDealer(long id);
        bool DeleteDealer(long id);
        bool UpdateDealer(Dealer dealer);
    }
}
