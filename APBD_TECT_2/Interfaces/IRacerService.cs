using APBD_TECT_2.DataLayer.Dto;

namespace APBD_TECT_2.Interfaces;

public interface IRacerService
{
    Task<RacerParticipationsDto?> GetAllRacesAsync(int racerId);
}