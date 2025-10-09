using clinica_salud.Models;

namespace clinica_salud.Interfaces;

public interface IVeterinarianRepository
{
    void AddVeterinarian(Veterinarian veterinarian);
    List<Veterinarian> GetAllVeterinarians();
}
