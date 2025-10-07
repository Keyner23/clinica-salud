

using clinica_salud.Interfaces;
using clinica_salud.repositories;
using clinica_salud.services;



var patientRepository = new PatientRepository();
var petRepository = new PetRepository();


var petService = new PetService(petRepository);
var patientService = new PatientService(patientRepository, petService);


var menu = new Menu();
int opcion;

do
{
    opcion = menu.showMenu();

    switch (opcion)
    {
        case 1:
            Console.WriteLine("");
            Console.WriteLine("----- Registrar paciente -----");
            patientService.AddPatient();
            break;

        case 2:
            Console.WriteLine("");
            Console.WriteLine("---- Lista de  pacientes -----");
            patientService.ShowPatients();
            break;

        case 3:
            Console.WriteLine("");
            Console.WriteLine("----- Paciente buscado -----");
            patientService.SearchPatient("");
            break;

        case 4:
            Console.WriteLine("");
            Console.WriteLine("----- Registrar mascota -----");
            petService.AskAndAddPet(patientService);
            break;

        case 5:
            Console.WriteLine("");
            Console.WriteLine("-----Saliendo-----");
            break;

        default:
            Console.WriteLine("");
            Console.WriteLine("-----Opción no válida-----");
            break;
    }

    if (opcion != 5)
    {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

} while (opcion != 5);
