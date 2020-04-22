using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StreetBroker.Common;
using StreetBroker.Models;

namespace StreetBroker.Repository
{
    public class DealerRepository:IDealerRepository
    {
        private readonly ApplicationDbContext _context;

        public DealerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool DeleteDealer(long id)
        {
            Dealer dealer = GetDealer(id);
            _context.Remove(dealer);
            return _context.SaveChanges() > 0;
        }

        public Dealer GetDealer(long id)
        {
            return _context.Dealers.
                    Where(r => r.Id == id).SingleOrDefault<Dealer>();
        }

        public List<Dealer> GetDealers()
        {
            return _context.Dealers.
                    Where(r => r.RecordStatus == RecordStatus.Active).ToList<Dealer>();
        }

        public bool InsertDealer(Dealer dealer)
        {
            _context.Add(dealer);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateDealer(Dealer dealer)
        {
            _context.Dealers.Attach(dealer);
            _context.Entry(dealer).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
