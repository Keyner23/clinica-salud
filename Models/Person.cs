namespace clinica_salud.Models;

public abstract class Person
{
    public string name { get; set; }
    public string address { get; set; }
    public int phone { get; set; }


    public virtual string ShowInformation()
    {
        return $"Nombre: {name}, Direccion: {address}, Telefono: {phone}";
    }

}
