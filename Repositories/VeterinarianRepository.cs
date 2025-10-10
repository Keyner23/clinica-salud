using clinica_salud.Db;
using clinica_salud.Interfaces;
using clinica_salud.Models;

namespace clinica_salud.Repositories;

public class VeterinarianRepository : IVeterinarianRepository
{
    public void AddVeterinarian(Veterinarian veterinarian)
    {
        Database.veterinarians.Add(veterinarian);
    }
    public List<Veterinarian> GetAllVeterinarians()
    {
        return Database.veterinarians;
    }
}
