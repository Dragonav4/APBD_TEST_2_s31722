using System.ComponentModel.DataAnnotations;

namespace APBD_TECT_2.DataLayer.Models;

public class Racer
{
    [Key]
    public int RacerId { get; set; }
    [MaxLength(50)]
    public String FirstName { get; set; }
    [MaxLength(100)]
    public String LastName { get; set; }
    
    public ICollection<RaceParticipation> RaceParticipations { get; set; } = new List<RaceParticipation>();
    
}