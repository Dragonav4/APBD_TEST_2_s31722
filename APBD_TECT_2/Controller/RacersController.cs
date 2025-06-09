using APBD_TECT_2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBD_TECT_2.Controller;

[ApiController]
[Route("api/[controller]")]
public class RacersController : ControllerBase
{
    private readonly IRacerService _racerService;

    public RacersController(IRacerService racerService)
    {
        _racerService = racerService;
    }

    [HttpGet("{Id:int}/participations")]
    public async Task<IActionResult?> GetRacers(int Id)
    {
        var result = await _racerService.GetAllRacesAsync(Id);
        return Ok(result);
    }
    
}