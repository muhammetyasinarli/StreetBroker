using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StreetBroker.Common;
using StreetBroker.Models;

namespace StreetBroker.Repository
{
    public class RepoRepository : IRepoRepository
    {
        private readonly ApplicationDbContext _context;

        public RepoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<RepoOrder> GetRepoOrders()
        {
            return _context.RepoOrders.
                    Where(r => r.RecordStatus == RecordStatus.Active).ToList<RepoOrder>();
        }
        public RepoOrder GetRepoOrder(long id)
        {
            return _context.RepoOrders.
                    Where(r => r.Id == id).SingleOrDefault<RepoOrder>();
        }
        public bool InsertRepoOrder(RepoOrder repoOrder)
        {
            _context.Add(repoOrder);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteRepoOrder(long id)
        {
            RepoOrder repoOrder = GetRepoOrder(id);
            _context.Remove(repoOrder);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateRepoOrder(RepoOrder repoOrder)
        {
            //Will update all properties of the Customer
            _context.RepoOrders.Attach(repoOrder);
            _context.Entry(repoOrder).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
