using TheBigBang.Models;
namespace TheBigBang.Repository
{
    public interface IRoomsRepository
    {
        Task<List<Rooms>> GetRoomsByHotelId (int Hid);
        Task<Rooms?> GetRoomById (int Rid);
        Task<Rooms> CreateRoom(Rooms room);
        Task UpdateRoom(Rooms room);
        Task DeleteRoom(int Rid);
    }
}
