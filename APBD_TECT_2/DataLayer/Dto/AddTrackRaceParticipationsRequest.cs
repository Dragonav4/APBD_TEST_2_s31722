namespace APBD_TECT_2.DataLayer.Dto;

public class AddTrackRaceParticipationsRequest
{
    public string RaceName { get; set; }
    public string TrackName { get; set; }
    public List<ParticipationInputDto> Participations { get; set; } = new();
}

public class ParticipationInputDto
{
    public int RacerId { get; set; }
    public int Position { get; set; }
    public int FinishTimeInSeconds { get; set; }
}