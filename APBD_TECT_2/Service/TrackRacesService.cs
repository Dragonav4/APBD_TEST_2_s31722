using APBD_TECT_2.Data;
using APBD_TECT_2.DataLayer.Dto;
using APBD_TECT_2.DataLayer.Models;
using APBD_TECT_2.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;
using APBD_TECT_2.Exceptions;
namespace APBD_TECT_2.Service;
public class TrackRacesService : ITrackRacesService
{
    private readonly DatabaseContext _context;

    public TrackRacesService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddNewTrackRacesAsync(AddTrackRaceParticipationsRequest request)
    {
        if (request == null) throw new BadRequestException("Request cannot be null", HttpStatusCode.BadRequest);
        if (request.RaceName == null || request.TrackName == null || request.Participations.Count == 0)
            throw new BadRequestException("RaceName/TrackName is invalid", HttpStatusCode.BadRequest);
        if (request.Participations.Count == 0)
            throw new BadRequestException("Participations list is empty", HttpStatusCode.BadRequest);
        var race = await _context.Races.FirstOrDefaultAsync(r => r.Name == request.RaceName);
        if (race == null)
            throw new BadRequestException("Race not found", HttpStatusCode.NotFound);
        var track = await _context.Tracks.FirstOrDefaultAsync(t => t.Name == request.TrackName);
        if (track == null)
            throw new BadRequestException("Track not found", HttpStatusCode.NotFound);

        var trackRace =
            await _context.TrackRacers.FirstOrDefaultAsync(
                tr => tr.RaceId == race.RaceId && tr.TrackId == track.TrackId);
        if (trackRace is null)
        {
            trackRace = new TrackRace
            {
                RaceId = race.RaceId,
                TrackId = track.TrackId,
                Laps = 0,
                BestTimeInSeconds = int.MaxValue
            };
            _context.TrackRacers.Add(trackRace);
            await _context.SaveChangesAsync();
        }

        foreach (var p in request.Participations)
        {
            var racer = await _context.Racers.FindAsync(p.RacerId);
            if (racer is null)
                throw new BadRequestException("Unfortunately racer not found", HttpStatusCode.NotFound);

            bool exists = await _context.RaceParticipations.AnyAsync(rp =>
                rp.RacerId == p.RacerId && rp.TrackRaceId == trackRace.TrackRaceId);
            if (exists) throw new BadRequestException("Duplicate participation for racer in this track race",
                    HttpStatusCode.Conflict);

            var participation = new RaceParticipation
            {
                RacerId = p.RacerId,
                TrackRaceId = trackRace.TrackRaceId,
                Position = p.Position,
                FinishTimeInSeconds = p.FinishTimeInSeconds
                
            };
            _context.RaceParticipations.Add(participation);
            if (p.FinishTimeInSeconds < trackRace.BestTimeInSeconds) trackRace.BestTimeInSeconds = p.FinishTimeInSeconds;
            await _context.SaveChangesAsync();
        }
    }
}