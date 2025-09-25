namespace clinica_salud.models;

public class Patient
{
    public int id { get; set; }
    public string name { get; set; }
    public int age { get; set; }
    public string symptoms { get; set; }


    public Patient(int id, string name, int age, string symptoms)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.symptoms = symptoms;
    }

    public string MostrarInformacion()
    {
        return $"ID: {id}, Name: {name}, Age: {age}, Symptoms: {symptoms}";
    }
}
