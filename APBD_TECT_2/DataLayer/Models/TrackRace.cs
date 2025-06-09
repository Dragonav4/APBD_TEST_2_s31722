using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TECT_2.DataLayer.Models
{
    [Table("TrackRace")]
    public class TrackRace
    {
        [Key]
        public int TrackRaceId { get; set; }

        public int TrackId { get; set; }
        
        [ForeignKey(nameof(TrackId))]
        public Track Track { get; set; }

        public int RaceId { get; set; }
        
        [ForeignKey(nameof(RaceId))]
        public Race Race { get; set; }
        
        public int Laps { get; set; }
        public int BestTimeInSeconds { get; set; }

        public ICollection<RaceParticipation> RaceParticipations { get; set; }
            = new List<RaceParticipation>();
    }
}