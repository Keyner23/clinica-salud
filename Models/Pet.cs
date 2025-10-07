namespace clinica_salud.models;

public class Pet
{
    public string name { get; set; }
    public string species { get; set; }
    public string race { get; set; }
    public int age { get; set; }

    public Pet(string name, string species, string race, int age)
    {
        this.name = name;
        this.species = species;
        this.race = race;
        this.age = age;
    }
    public string ShowInformation()
    {
        return $"Nombre: {name}, Especie: {species}, Raza: {race}, Edad: {age}";
    }
}