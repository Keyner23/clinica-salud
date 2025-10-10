using clinica_salud.Models;

namespace clinica_salud.Interfaces;

public interface IAppoimentRepository
{
    void AddAppoiment(Appointment appoiment);
    List<Appointment> GetAllAppoiments();

    List<Appointment> GetAppointmentsByPetName(string petName);

    // Appointment? GetAppoimentById(int id);
}
