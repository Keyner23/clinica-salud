using clinica_salud.Interfaces;
using clinica_salud.Models;

namespace clinica_salud.Repositories;

public class VeterinarianRepository: IVeterinarianRepository
{
    private List<Veterinarian> veterinarians = new List<Veterinarian>();

    public void AddVeterinarian(Veterinarian veterinarian)
    {
        veterinarians.Add(veterinarian);
    }

    public List<Veterinarian> GetAllVeterinarians()
    {
        return veterinarians;
    }  
}
