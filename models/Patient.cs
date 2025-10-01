namespace clinica_salud.models;

public class Patient
{
    public int id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public int phone { get; set; }

    public Patient(int id, string name, string address, int phone)
    {
        this.id = id;
        this.name = name;
        this.address = address;
        this.phone = phone;
    }

    public string ShowInformation()
    {
        return $"ID: {id}, Nombre: {name}, Direccion: {address}, Telefono: {phone}";
    }
}