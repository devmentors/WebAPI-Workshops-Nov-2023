using Microsoft.AspNetCore.Mvc;
using MySpot.Application.DTO;
using MySpot.Application.Services;

namespace MySpot.Api.Controllers;

[ApiController]
[Route("api/reservations")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> Get(string licencePlate, int page)
    {
        var reservations = await _reservationService.GetReservationsAsync();
        return Ok(reservations);
    }

    [HttpGet("{id:guid}", Name = "Get reservation by id")]
    public async Task<ActionResult<ReservationDto>> Get(Guid id)
    {
        var reservation = await _reservationService.GetReservationAsync(id);
        return reservation is null ? NotFound() : Ok(reservation);
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ReservationDto dto)
    {
        var id = await _reservationService.ReserveParkingSpotAsync(dto);
        return CreatedAtRoute("Get reservation by id", new {id}, null);
    }
}