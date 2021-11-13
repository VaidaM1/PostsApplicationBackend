using Microsoft.EntityFrameworkCore;
using PostsApplicationBackEnd.Data;
using PostsApplicationBackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsApplicationBackEnd.Repositories
{
    public class ParcelRepository
    {
        private readonly DataContext _dataContext;

        public ParcelRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Parcel>> GetAllAsync()
        {
            return await _dataContext.Parcels.Include(h => h.Post).ToListAsync();
        }

        public async Task<Parcel> GetById(int id)
        {
            return await _dataContext.Parcels.FirstOrDefaultAsync(b => b.Id == id);

        }

        public async Task<List<Parcel>> GetByPostIdAsync(int postId)
        {
            return await _dataContext.Parcels.Include(r => r.Post).Where(p => p.PostId == postId).ToListAsync();
        }

        public async Task<int> CreateAsync(Parcel parcel)
        {
            _dataContext.Add(parcel);
            await _dataContext.SaveChangesAsync();
            return parcel.Id;
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            _dataContext.Update(parcel);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Parcel parcel)
        {
            _dataContext.Remove(parcel);
            await _dataContext.SaveChangesAsync();
        }
    }
}
