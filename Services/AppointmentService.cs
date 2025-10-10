using clinica_salud.Db;
using clinica_salud.Interfaces;
using clinica_salud.models;
using clinica_salud.Models;

namespace clinica_salud.Services;

public class AppointmentService
{
    private readonly IAppoimentRepository _appointmentRepository;

    public AppointmentService(IAppoimentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public void AddAppointment()
    {
        try
        {
            Console.WriteLine("Escriba el nombre del veterinario:");
            string? vetName = Console.ReadLine();

            var vetEncontrado = Database.veterinarians
                .FirstOrDefault(v => v.name.Equals(vetName, StringComparison.OrdinalIgnoreCase));

            if (vetEncontrado == null)
            {
                Console.WriteLine("El veterinario no se encuentra registrado en el sistema.");
                return;
            }

            Console.WriteLine($"Veterinario encontrado: {vetEncontrado.name}\n");

            Console.WriteLine("Escriba el nombre del paciente:");
            string? patientName = Console.ReadLine();

            var patientEncontrado = Database.patients
                .FirstOrDefault(p => p.name.Equals(patientName, StringComparison.OrdinalIgnoreCase));

            if (patientEncontrado == null)
            {
                Console.WriteLine("El paciente no se encuentra registrado en el sistema.");
                return;
            }

            Console.WriteLine(patientEncontrado.ShowInformation());
            Console.WriteLine();

            Console.WriteLine("Escriba el nombre de la mascota:");
            string? petName = Console.ReadLine();

            var petEncontrado = patientEncontrado.pets
                .FirstOrDefault(p => p.name.Equals(petName, StringComparison.OrdinalIgnoreCase));

            if (petEncontrado == null)
            {
                Console.WriteLine("La mascota no se encuentra registrada para este paciente.");
                return;
            }

            Console.WriteLine("Ingrese la fecha de la cita (Formato: yyyy-MM-dd):");
            string? dateInput = Console.ReadLine();

            if (!DateTime.TryParse(dateInput, out DateTime date))
            {
                Console.WriteLine("Error: Formato de fecha inválido.");
                return;
            }

            Console.WriteLine("Ingrese la razón de la cita:");
            string? reason = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(reason))
            {
                Console.WriteLine("Error: La razón no puede estar vacía.");
                return;
            }

            var newAppointment = new Appointment(
                new List<Veterinarian> { vetEncontrado },
                new List<Pet> { petEncontrado },
                date,
                reason
            );

            _appointmentRepository.AddAppoiment(newAppointment);
            Console.WriteLine("-----CITA CREADA CORRECTAMENTE.-----");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear cita: {ex.Message}");
        }
    }

    public void GetAllAppoiments()
    {
        var appointments = _appointmentRepository.GetAllAppoiments();
        if (appointments.Count == 0)
        {
            Console.WriteLine("No hay citas registradas.");
            return;
        }

        foreach (var appointment in appointments)
        {
            Console.WriteLine(appointment.ShowInformation());
            Console.WriteLine();
        }
    }
}
