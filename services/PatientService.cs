using clinica_salud.models;
namespace clinica_salud.services;



public class PatientService
{
    List<Patient> patients = new List<Patient>(); // se crea la lista de pacientes
    private PetService petService;


    // method to add patients to the list
    public void AddPatient()
    {
        try
        {
            Console.WriteLine("Ingrese el ID del paciente:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Error: El ID debe ser un número entero.");
                return;
            }
            if (patients.Any(p => p.id == id))
            {
                Console.WriteLine("Error: Ya existe un paciente con ese ID.");
                return;
            }


            Console.WriteLine("Ingrese el nombre del paciente:");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Error: El nombre no puede estar vacío.");
                return;
            }


            Console.WriteLine("Ingrese el numero de telefono");
            if (!int.TryParse(Console.ReadLine(), out int phone))
            {
                Console.WriteLine("Error: La edad debe ser un número entero.");
                return;
            }


            Console.WriteLine("Ingrese la direccion:");
            string? address = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Advertencia: No se ingresaro la direccion.");
            }


            Patient patient = new Patient(id, name, address, phone);
            patients.Add(patient);

            Console.WriteLine();
            Console.WriteLine("PACIENTE REGISTRADO CORRECTAMENTE....");
            Console.WriteLine("------------------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error inesperado:  " + ex.Message);
        }
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
            Console.WriteLine(patient.ShowInformation());
        }
    }



    // method to search for a patient by name
    public Patient? SearchPatient(string name)
    {
        Console.WriteLine("Ingrese el nombre del paciente a buscar:");
        string? buscar = Console.ReadLine();

        var patient1 = patients.FirstOrDefault(e => e.name == buscar);
        if (patient1 != null)
        {
            Console.WriteLine("Paciente encontrado:");
            Console.WriteLine(patient1.ShowInformation());
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("PACIENTE NO ENCONTRADOOOO.");
        }
        return patient1;
    }
    public void AssignPetToPatient(int patientId, string petName)
    {
        var patient = patients.FirstOrDefault(p => p.id == patientId);
        var pet = petService.GetPetByName(petName);

        if (patient == null)
        {
            Console.WriteLine("Paciente no encontrado.");
            return;
        }
        if (pet == null)
        {
            Console.WriteLine("Mascota no encontrada.");
            return;
        }

        patient.AddPet(pet);
        Console.WriteLine("Mascota asignada al paciente.");
    }

    // Buscar un paciente por nombre SIN pedir por consola
    public Patient? GetPatientByName(string name)
    {
        return patients.FirstOrDefault(p => p.name == name);
    }
}
