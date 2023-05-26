using Microsoft.EntityFrameworkCore;
using TheBigBang.Models;
namespace TheBigBang.Repository
{
    public class RoomsRepository:IRoomsRepository
    {
        private readonly BookingDbContext _dbContext;

        public RoomsRepository(BookingDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Rooms>> GetRoomsByHotelId(int Hid)
        {
            return await _dbContext.Rooms
                .Where(r => r.Hid == Hid)
                .ToListAsync();
        }

        public async Task<Rooms?> GetRoomById(int Rid)
        {
            return await _dbContext.Rooms.FindAsync(Rid);
        }

        public async Task<Rooms> CreateRoom(Rooms room)
        {
            _dbContext.Rooms.Add(room);
            await _dbContext.SaveChangesAsync();
            return room;
        }

        public async Task UpdateRoom(Rooms room)
        {
            _dbContext.Entry(room).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoom(int Rid)
        {
            var room = await _dbContext.Rooms.FindAsync(Rid);
            if (room != null)
            {
                _dbContext.Rooms.Remove(room);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}