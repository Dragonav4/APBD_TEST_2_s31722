using APBD_TECT_2.DataLayer.Dto;

namespace APBD_TECT_2.Interfaces;

public interface ITrackRacesService
{
    Task AddNewTrackRacesAsync(AddTrackRaceParticipationsRequest request);
}