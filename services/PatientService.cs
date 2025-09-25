using System.Globalization;
using clinica_salud.models;
namespace clinica_salud.services;


public class PatientService
{
    List<Patient> patients = new List<Patient>(); // se crea la lista de pacientes


    // method to add patients to the list
    public void AddPatient()
    {
        Console.WriteLine("Ingrese el ID del paciente:");
        int id = int.Parse(Console.ReadLine());



        Console.WriteLine("Ingrese el nombre del paciente:");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            return;
        }



        Console.WriteLine("Ingrese la edad del paciente:");
        int age = int.Parse(Console.ReadLine());

        try
        {
            if (age <= 0)
            {
                Console.WriteLine("Edad no válida. Debe ser un número positivo.");
                return;
            }
        }
        catch (System.Exception)
        {
            throw new Exception("Error al verificar la edad.");
        }



        Console.WriteLine("Ingrese los síntomas del paciente:");
        string symptoms = Console.ReadLine();



        Patient patient = new Patient(id, name, age, symptoms);

        patients.Add(patient);
        Console.WriteLine("");
        Console.WriteLine("Paciente registrado exitosamente....");
        Console.WriteLine("------------------------------------------");
    }



    // method to show all patients
    public void ShowPatients()
    {
        if (patients.Count == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }

        Console.WriteLine("\nLista de pacientes:");
        foreach (var patient in patients)
        {
            Console.WriteLine(patient.MostrarInformacion());
        }
    }




    // method to search for a patient by name
    public Patient? SearchPatient(string name)
    {
        Console.WriteLine("Ingrese el nombre del paciente a buscar:");
        string buscar = Console.ReadLine();

        var patient1 = patients.FirstOrDefault(e => e.name == buscar);
        if (patient1 != null)
        {
            Console.WriteLine("Paciente encontrado:");
            Console.WriteLine(patient1.MostrarInformacion());
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("PACIENTE NO ENCONTRADOOOO.");
        }
        return patient1;

    }

}
