using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APBD_TECT_2.DataLayer.Models;

public class Track
{
    [Key]
    public int TrackId { get; set; }
    [MaxLength(100)]
    [Required]
    public String Name { get; set; }
    [Precision(5,2)]
    [Required]
    public decimal LengthinKm { get; set; }
    public ICollection<TrackRace> TrackRaces { get; set; } = new List<TrackRace>();
    
}