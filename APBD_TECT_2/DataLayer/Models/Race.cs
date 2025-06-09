using System.ComponentModel.DataAnnotations;

namespace APBD_TECT_2.DataLayer.Models;

public class Race
{
    [Key]
    public int RaceId { get; set; }
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
    [MaxLength(100)]
    [Required]
    public String location { get; set; }
    public DateTime Date { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; } = new List<TrackRace>();

    
}