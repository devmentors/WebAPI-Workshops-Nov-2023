using MySpot.Application.DTO;
using MySpot.Core.Entities;
using MySpot.Core.Exceptions;
using MySpot.Core.Repositories;

namespace MySpot.Application.Services;

public sealed class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    public async Task<ReservationDto?> GetReservationAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetAsync(id);
        return reservation is null ? null : Map(reservation);
    }

    public async Task<IEnumerable<ReservationDto>> GetReservationsAsync()
    {
        var reservations = await _reservationRepository.GetAllAsync();
        return reservations.Select(Map);
    }

    private static ReservationDto Map(Reservation reservation)
        => new(reservation.Id, reservation.ParkingSpotId,
            reservation.UserId, reservation.Date, reservation.LicencePlate);
    
    public async Task<Guid> ReserveParkingSpotAsync(ReservationDto dto)
    {
        var (_, parkingSpotId, userId, date, licencePlate) = dto;

        var reservation = new Reservation(Guid.NewGuid(), date, 
            parkingSpotId, userId, licencePlate);
        
        await _reservationRepository.AddAsync(reservation);
        
        return reservation.Id;


        // DB save
        // send email
    }

    public async Task UpdateReservation(ReservationDto dto)
    {
        await Task.CompletedTask;
        Reservation reservation = default; //DB GET

        try
        {
            reservation.ChangeLicencePate(dto.LicencePlate);
        }
        catch (MySpotException ex)
        {
            // HTTP 400
        }
        catch (Exception ex)
        {
            // HTTP 500
        }
    }
}