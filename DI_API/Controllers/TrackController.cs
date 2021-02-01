using Base.BusinessModels;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace DI_API.Controllers
{
    [Route("/track")]
    public class TrackController : Controller
    {
        private readonly ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        // GET: api/Track
        [HttpGet]
        public IActionResult GetAllTracks()
        {
            return Ok(_trackService.GetAll());
        }

        // GET: api/Track/5
        [HttpGet("{id}")]
        public IActionResult GetTrackByID([FromRoute] int ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var track = _trackService.GetByID(ID);

            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        // POST: api/Track
        [HttpPost]
        public IActionResult PostTrack([FromBody] TrackEntity newTrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(_trackService.Add(newTrack));
        }

        // PUT: api/Track/track
        [HttpPut("{id}")]
        public IActionResult PutTrack([FromRoute] int id, [FromBody] TrackEntity editTrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != editTrack.ID)
            {
                return BadRequest();
            }

            _trackService.Update(editTrack);

            return NoContent();
        }

        // DELETE: api/Track/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeDetail([FromRoute] int ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _trackService.Delete(ID);

            return NoContent();
        }
    }
}
