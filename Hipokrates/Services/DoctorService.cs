using Hipokrates.DTOs.Doctor;
using Hipokrates.DTOs.Patient;
using Hipokrates.Models;
using Microsoft.EntityFrameworkCore;

namespace Hipokrates.Services.AuthenticationService;

public class DoctorService : IDoctorService
{
    private readonly Repository _repository;

    public DoctorService(Repository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<ConsultationDTO>> GetConsultations()
    {
        return await _repository.Consultations.Select(c => new ConsultationDTO
            {
                Id = c.Id,
                ServiceName = c.Service.Name,
                Room = c.Room.RoomNumber.ToString(),
                Floor = c.Room.FloorNumber.ToString(),
                Status = c.Status.ToString(),
                Date = c.Date,
                Time = c.Time

            })
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }

    public async Task<ConsultationDTO?> GetConsultation(int id)
    {
        return await _repository.Consultations
            .Select(c => new ConsultationDTO
            {
                Id = c.Id,
                ServiceName = c.Service.Name,
                Room = c.Room.RoomNumber.ToString(),
                Floor = c.Room.FloorNumber.ToString(),
                Status = c.Status.ToString(),
                Date = c.Date,
                Time = c.Time
            })
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task CancelConsultation(int id)
    {
        var consultation = await _repository.Consultations.FirstOrDefaultAsync(c => c.Id == id);
        consultation.Status = Status.Canceled;
        await _repository.SaveChangesAsync();
    }

    public async Task AcceptConsultation(int id, int doctorId)
    {
        var consultation = await _repository.Consultations.FirstOrDefaultAsync(c => c.Id == id);
        consultation.Status = Status.Planned;
        consultation.IdDoctor = doctorId;
        await _repository.SaveChangesAsync();
    }

    public async Task RefuseConsultation(int id)
    {
        var consultation = await _repository.Consultations.FirstOrDefaultAsync(c => c.Id == id);
        consultation.Status = Status.Refused;
        await _repository.SaveChangesAsync();
    }

    public async Task<List<RoomsDTO>> GetRooms()
    {
        return await _repository.Rooms.Select(r => new RoomsDTO()
            {
                Id = r.Id,
                FloorNumber = r.FloorNumber,
                RoomNumber = r.RoomNumber
            })
            .ToListAsync();
    }

    public async Task AssignRoom(AssignRoomDTO dto)
    {
        var room = await _repository.Rooms.FirstOrDefaultAsync(r => r.Id == dto.roomId + 1);
        var consultation = await _repository.Consultations.FirstOrDefaultAsync(c => c.Id == dto.consultationId);
        consultation.Room = room;
        await _repository.SaveChangesAsync();
    }
}
