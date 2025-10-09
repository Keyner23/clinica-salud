using clinica_salud.Interfaces;
using clinica_salud.models;
namespace clinica_salud.repositories;



public class PetRepository : IPetRepository
{
    private List<Pet> pets = new List<Pet>();

    public void AddPet(Pet pet)
    {
        pets.Add(pet);
    }

    // public List<Pet> GetAllPets()
    // {
    //     return pets;
    // }

    public Pet GetPetByName(string name)
    {
        return pets.FirstOrDefault(p => p.name == name);
    }

    public bool RemovePet(string name)
    {
        var pet = GetPetByName(name);
        if (pet != null)
        {
            pets.Remove(pet);
            return true;
        }
        return false;
    }
}


