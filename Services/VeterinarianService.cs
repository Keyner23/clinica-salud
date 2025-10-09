using clinica_salud.Interfaces;
using clinica_salud.Models;

namespace clinica_salud.Services;

public class VeterinarianService
{
    private readonly IVeterinarianRepository _veterinarianRepository;

    public VeterinarianService(IVeterinarianRepository veterinarianRepository)
    {
        _veterinarianRepository = veterinarianRepository;
    }

    public void AddVeterinarian()
    {
        try
        {
            Console.WriteLine("Ingrese el ID del veterinario:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Error: El ID debe ser un número entero.");
                return;
            }
            // if (_veterinarianRepository.ExistsById(id))
            // {
            //     Console.WriteLine("Error: Ya existe un veterinario con ese ID.");
            //     return;
            // }

            Console.WriteLine("Ingrese el nombre del veterinario:");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Error: El nombre no puede estar vacío.");
                return;
            }

            Console.WriteLine("Ingrese la dirección del veterinario:");
            string? address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Error: La dirección no puede estar vacía.");
                return;
            }

            Console.WriteLine("Ingrese el teléfono del veterinario:");
            if (!int.TryParse(Console.ReadLine(), out int phone))
            {
                Console.WriteLine("Error: El teléfono debe ser un número entero.");
                return;
            }

            Console.WriteLine("Ingrese la especialidad:");
            string? specialty = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(specialty))
            {
                Console.WriteLine("Error: La especialidad no puede estar vacía.");
                return;
            }

            var veterinarian = new Veterinarian(id, name, address, phone, specialty);
            _veterinarianRepository.AddVeterinarian(veterinarian);

            Console.WriteLine();
            Console.WriteLine("VETERINARIO REGISTRADO CORRECTAMENTE....");
            Console.WriteLine("------------------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al registrar el veterinario: {ex.Message}");
        }
    }

    public void ShowVeterinarian()
    {
        var veterinarians = _veterinarianRepository.GetAllVeterinarians();

        if (veterinarians.Count == 0)
        {
            Console.WriteLine("No hay veterinarios registrados.");
            return;
        }

        Console.WriteLine("\nLista de veterinarios:");
        foreach (var vaterinarian in veterinarians)
        {
            Console.WriteLine(vaterinarian.ShowInformation());
        }
    }
}
