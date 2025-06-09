using System.Net;
using APBD_TECT_2.Data;
using APBD_TECT_2.DataLayer.Dto;
using APBD_TECT_2.Exceptions;
using APBD_TECT_2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APBD_TECT_2.Service;
public class RacerService : IRacerService
{
    private readonly DatabaseContext _context;

    public RacerService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<RacerParticipationsDto?> GetAllRacesAsync(int racerId)
    {
        if (racerId == 0 || racerId < 0) throw new BadRequestException("Racer id is invalid", HttpStatusCode.BadRequest); 
        var participations = _context
            .Racers
            .Where(r => r.RacerId == racerId)
            .Select(r => new RacerParticipationsDto
            {
                FirstName = r.FirstName,
                LastName = r.LastName,
                RacerId = r.RacerId,
                Participations = r.RaceParticipations
                    .OrderBy(rp => rp.TrackRace.Race.Date)
                    .Select(rp => new ParticipationDto
                    {
                        Laps = rp.TrackRace.Laps,
                        FinishTimeInSeconds = rp.FinishTimeInSeconds,
                        Position = rp.Position,
                        Race = new RaceDto
                        {
                            Name = rp.TrackRace.Race.Name,
                            Location = rp.TrackRace.Race.location,
                            Date = rp.TrackRace.Race.Date
                        },
                        Track = new TrackDto
                        {
                            Name = rp.TrackRace.Track.Name,
                            LengthInKm = rp.TrackRace.Track.LengthinKm
                        }
                    }).ToList()
            }).FirstOrDefaultAsync();
        return await participations;
    }
}