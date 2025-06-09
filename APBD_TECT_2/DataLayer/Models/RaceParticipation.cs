using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TECT_2.DataLayer.Models
{
    [Table("RaceParticipation")]
    public class RaceParticipation
    {
        public int RacerId { get; set; }
        
        [ForeignKey(nameof(RacerId))]
        public Racer Racer { get; set; }
        public int TrackRaceId { get; set; }
        
        [ForeignKey(nameof(TrackRaceId))]
        public TrackRace TrackRace { get; set; }

        public int FinishTimeInSeconds { get; set; }
        public int Position { get; set; }
    }
}