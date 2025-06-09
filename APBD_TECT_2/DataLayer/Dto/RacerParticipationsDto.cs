
namespace APBD_TECT_2.DataLayer.Dto
{
    public class RacerParticipationsDto
    {
        public int RacerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ParticipationDto> Participations { get; set; } = new();
    }

    public class ParticipationDto
    {
        public RaceDto Race { get; set; }
        public TrackDto Track { get; set; }
        public int Laps { get; set; }
        public int FinishTimeInSeconds { get; set; }
        public int Position { get; set; }
    }

    public class RaceDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }

    public class TrackDto
    {
        public string Name { get; set; }
        public decimal LengthInKm { get; set; }
    }
}