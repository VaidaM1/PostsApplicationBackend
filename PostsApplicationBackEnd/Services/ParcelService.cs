using PostsApplicationBackEnd.Entities;
using PostsApplicationBackEnd.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsApplicationBackEnd.Services
{
    public class ParcelService
    {
        private readonly ParcelRepository _parcelRepository;

        public ParcelService(ParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public async Task<List<Parcel>> GetAllAsync()
        {
            return await _parcelRepository.GetAllAsync();
        }

        public async Task<Parcel> GetByIdAsync(int id)
        {
            var parcel = await _parcelRepository.GetById(id);
            if (parcel == null)
            {
                throw new ArgumentException("Parcel not found");
            }
            return parcel;
        }

        public async Task<List<Parcel>> GetByPostIdAsync(int parcelId)
        {
            return await _parcelRepository.GetByPostIdAsync(parcelId);
        }

        public async Task<int> CreateAsync(Parcel parcel)
        {
            return await _parcelRepository.CreateAsync(parcel);
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            await _parcelRepository.UpdateAsync(parcel);
        }

        public async Task DeleteAsync(int id)
        {
            var parcel = await GetByIdAsync(id);
            await _parcelRepository.DeleteAsync(parcel);
        }
    }
}
