
using clinica_salud.Interfaces;
using clinica_salud.repositories;
using clinica_salud.Repositories;
using clinica_salud.services;
using clinica_salud.Services;



var patientRepository = new PatientRepository();
var petRepository = new PetRepository();
IVeterinarianRepository veterinarian = new VeterinarianRepository();

var petService = new PetService(petRepository);
var patientService = new PatientService(patientRepository, petService);
var veterinarianService = new VeterinarianService(veterinarian);




var menu = new Menu();
int opcion;

do
{
    opcion = menu.showMenu();

    switch (opcion)
    {
        case 1:
            Console.WriteLine("");
            Console.WriteLine("----- REGISTRAR DUEÑO -----");
            patientService.AddPatient();
            break;

        case 2:
            Console.WriteLine("");
            Console.WriteLine("---- VER PACIENTES -----");
            patientService.ShowPatients();
            break;

        case 3:
            Console.WriteLine("");
            Console.WriteLine("----- BUSCAR PACIENTE -----");
            Console.Write("Ingrese el nombre del paciente a buscar: ");
            string name = Console.ReadLine() ?? "";
            patientService.SearchPatient(name);
            break;

        case 4:
            Console.WriteLine("");
            Console.WriteLine("----- REGISTRAR MASCOTA -----");
            petService.AskAndAddPet(patientService);
            break;

        case 5:
            Console.WriteLine("");
            Console.WriteLine("----- REGISTRAR VETERINARIO -----");
            veterinarianService.AddVeterinarian();
            break;
        case 6:
            Console.WriteLine("");
            Console.WriteLine("----- VER VETERINARIOS -----");
            veterinarianService.ShowVeterinarian();
            break;

        case 7:
            Console.WriteLine("");
            Console.WriteLine("----- SALIENDO -----");
            break;

        default:
            Console.WriteLine("");
            Console.WriteLine("-----Opción no válida-----");
            break;
    }


    if (opcion != 7)
    {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

} while (opcion != 7);
