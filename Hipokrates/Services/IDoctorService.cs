using Hipokrates.DTOs.Doctor;
using Hipokrates.DTOs.Patient;

namespace Hipokrates.Services.AuthenticationService;

public interface IDoctorService
{
    public Task<List<ConsultationDTO>> GetConsultations();

    public Task<ConsultationDTO> GetConsultation(int id);
    
    public Task CancelConsultation(int id);

    public Task AcceptConsultation(int id, int doctorId);

    public Task RefuseConsultation(int id);

    public Task<List<RoomsDTO>> GetRooms();

    public Task AssignRoom(AssignRoomDTO dto);


}