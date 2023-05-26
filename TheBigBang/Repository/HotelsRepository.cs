using Microsoft.EntityFrameworkCore;
using TheBigBang.Models;

namespace TheBigBang.Repository
{
    public class HotelsRepository:IHotelsRepository
    {
        private readonly BookingDbContext _dbContext;

        public HotelsRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Hotels>> GetHotels()
        {
            return await _dbContext.Hotels.ToListAsync();
        }

        public async Task<Hotels?> GetHotelById(int Hid)
        {
            return await _dbContext.Hotels.FindAsync(Hid);
        }

        public async Task<Hotels> CreateHotel(Hotels hotel)
        {
            _dbContext.Hotels.Add(hotel);
            await _dbContext.SaveChangesAsync();
            return hotel;
        }

        public async Task UpdateHotel(Hotels hotel)
        {
            _dbContext.Entry(hotel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteHotel(int Hid)
        {
            var hotel = await _dbContext.Hotels.FindAsync(Hid);
            if (hotel != null)
            {
                _dbContext.Hotels.Remove(hotel);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}