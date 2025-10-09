using clinica_salud.models;
using clinica_salud.interfaces;
using clinica_salud.repositories;

namespace clinica_salud.services;

public class PatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly PetService _petService;

    public PatientService(IPatientRepository patientRepository, PetService petService)
    {
        _patientRepository = patientRepository;
        _petService = petService;
    }


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
            if (_patientRepository.ExistsById(id))
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

            Console.WriteLine("Ingrese el número de teléfono:");
            if (!int.TryParse(Console.ReadLine(), out int phone))
            {
                Console.WriteLine("Error: El teléfono debe ser un número entero.");
                return;
            }

            Console.WriteLine("Ingrese la dirección:");
            string? address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Advertencia: No se ingresó la dirección.");
            }

            var patient = new Patient(id, name, address, phone);
            _patientRepository.AddPatient(patient);

            Console.WriteLine();
            Console.WriteLine("PACIENTE REGISTRADO CORRECTAMENTE....");
            Console.WriteLine("------------------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
        }
    }

    public void ShowPatients()
    {
        var patients = _patientRepository.GetAllPatients();

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

    public Patient? SearchPatient(string name)
    {
        var patient = _patientRepository.GetPatientByName(name);
        if (patient != null)
        {
            Console.WriteLine("");
            Console.WriteLine("Paciente encontrado:");
            Console.WriteLine(patient.ShowInformation());
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Paciente no encontrado.");
        }
        return patient;
    }

    public void AssignPetToPatient(int patientId, string petName)
    {
        var patient = _patientRepository.GetPatientById(patientId);
        var pet = _petService.GetPetByName(petName);

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

    public Patient? GetPatientByName(string name)
    {
        return _patientRepository.GetPatientByName(name);
    }
}

