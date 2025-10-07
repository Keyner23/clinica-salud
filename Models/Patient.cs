namespace clinica_salud.models;

public class Patient
{
    public int id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public int phone { get; set; }

    public List<Pet> pets { get; set; }

    public Patient(int id, string name, string address, int phone)
    {
        this.id = id;
        this.name = name;
        this.address = address;
        this.phone = phone;
        this.pets = new List<Pet>();
    }

    public void AddPet(Pet pet)
    {
        pets.Add(pet);
    }
    public string ShowInformation()
    {
        string petInfo = pets.Count > 0
            ? string.Join("\n", pets.Select(p => $"  - {p.ShowInformation()}"))
            : "  - No tiene mascotas registradas.";

        return $"ID: {id}, Nombre: {name}, Direccion: {address}, Telefono: {phone}\nMascotas:\n{petInfo}";
    }
}