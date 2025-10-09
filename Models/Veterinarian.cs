namespace clinica_salud.Models;

public class Veterinarian : Person
{
    public int id { get; set; }
    public string specialty { get; set; }

    public Veterinarian(int id, string name, string address, int phone, string specialty)
    {
        this.id = id;
        this.name = name;
        this.address = address;
        this.phone = phone;
        this.specialty = specialty;
    }


    public override string ShowInformation()
    {
        return $"ID: {id}, Nombre: {name}, Direccion: {address}, Telefono: {phone}, Especialidad: {specialty}";
    }

}