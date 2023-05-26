using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBigBang.Models;
using TheBigBang.Repository;

namespace TheBigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsRepository _hotelRepository;
        private readonly IRoomsRepository _roomRepository;

        public HotelsController(IHotelsRepository hotelRepository, IRoomsRepository roomRepository)
        {
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
        }

        // GET api/hotels
        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _hotelRepository.GetHotels();
            return Ok(hotels);
        }

        // GET api/hotels/{id}
        [HttpGet("{Hid}")]
        public async Task<IActionResult> GetHotel(int Hid)
        {
            var hotel = await _hotelRepository.GetHotelById(Hid);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        // POST api/hotels
        [HttpPost]
        public async Task<IActionResult> CreateHotel(Hotels hotel)
        {
            var createdHotel = await _hotelRepository.CreateHotel(hotel);
            return CreatedAtAction(nameof(GetHotel), new { Hid = createdHotel.Hid }, createdHotel);
        }

        // PUT api/hotels/{id}
        [HttpPut("{Hid}")]
        public async Task<IActionResult> UpdateHotel(int id, Hotels hotel)
        {
            if (id != hotel.Hid)
                return BadRequest();

            await _hotelRepository.UpdateHotel(hotel);
            return NoContent();
        }

        // DELETE api/hotels/{id}
        [HttpDelete("{Hid}")]
        public async Task<IActionResult> DeleteHotel(int Hid)
        {
            // First, delete associated rooms
            var rooms = await _roomRepository.GetRoomsByHotelId(Hid);
            foreach (var room in rooms)
            {
                await _roomRepository.DeleteRoom(room.Hid);
            }

            // Then, delete the hotel
            await _hotelRepository.DeleteHotel(Hid);
            return NoContent();
        }
    }
}
