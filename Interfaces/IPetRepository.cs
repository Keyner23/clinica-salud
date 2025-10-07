using clinica_salud.models;

namespace clinica_salud.Interfaces;

public interface IPetRepository
{
    void AddPet(Pet pet);
    List<Pet> GetAllPets();
    Pet GetPetByName(string name);
    bool RemovePet(string name);
}

