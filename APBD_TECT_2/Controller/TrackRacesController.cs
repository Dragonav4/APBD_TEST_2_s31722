using APBD_TECT_2.DataLayer.Dto;
using APBD_TECT_2.Exceptions;
using APBD_TECT_2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBD_TECT_2.Controller;

[ApiController]
[Route("api/track-races")]
public class TrackRacesController : ControllerBase
{
    private readonly ITrackRacesService _trackRacesService;

    public TrackRacesController(ITrackRacesService trackRacesService)
    {
        _trackRacesService = trackRacesService;
    }

    [HttpPost("participants")]
    public async Task<IActionResult> AddRacerAsync(AddTrackRaceParticipationsRequest racerParticipations)
    {
        if (racerParticipations == null) throw new BadRequestException("Participations cannot be null");
        await _trackRacesService.AddNewTrackRacesAsync(racerParticipations);
        return Created();
    }
}