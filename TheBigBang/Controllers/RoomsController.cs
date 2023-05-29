using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBigBang.Models;
using TheBigBang.Repository;

namespace TheBigBang.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsRepository _roomRepository;

        public RoomsController(IRoomsRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        // GET api/hotels/{hotelId}/rooms
        [HttpGet]
        public async Task<IActionResult> GetRoomsByHotel(int Hid)
        {
            var rooms = await _roomRepository.GetRoomsByHotelId(Hid);
            return Ok(rooms);
        }

        // GET api/hotels/{hotelId}/rooms/{id}
        [HttpGet("{Rid}")]
        public async Task<IActionResult> GetRoom(int Rid)
        {
            var room = await _roomRepository.GetRoomById(Rid);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        // POST api/hotels/{hotelId}/rooms
        [HttpPost]
        public async Task<IActionResult> CreateRoom(int Hid, Rooms room)
        {
            room.Hid = Hid;

            var createdRoom = await _roomRepository.CreateRoom(room);
            return CreatedAtAction(nameof(GetRoom), new { Hid, Rid = createdRoom.Rid }, createdRoom);
        }

        // PUT api/hotels/{hotelId}/rooms/{id}
        [HttpPut("{Rid}")]
        public async Task<IActionResult> UpdateRoom(int Hid, int Rid, Rooms room)
        {
            if (Rid != room.Hid || Hid != room.Hid)
                return BadRequest();

            await _roomRepository.UpdateRoom(room);
            return NoContent();
        }

        // DELETE api/hotels/{hotelId}/rooms/{id}
        [HttpDelete("{Rid}")]
        public async Task<IActionResult> DeleteRoom(int Rid)
        {
            await _roomRepository.DeleteRoom(Rid);
            return NoContent();
        }
    }
}
