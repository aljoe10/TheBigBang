using TheBigBang.Models;
namespace TheBigBang.Repository
{
    public interface IHotelsRepository
    {
        Task<List<Hotels>> GetHotels();
        Task<Hotels?> GetHotelById(int Hid);
        Task<Hotels> CreateHotel(Hotels hotel);
        Task UpdateHotel(Hotels hotel);
        Task DeleteHotel(int Hid);
    }
}
