
using clinica_salud.services;
int opcion;
var service = new PatientService(); //creamos la instacia del servicio para reutilizar sus metodos
var pet = new PetService();
var menu = new Menu();


do

{
    opcion = menu.showMenu();

    switch (opcion)
    {
        case 1:
            Console.WriteLine("");
            Console.WriteLine("----- Registrar paciente -----");
            service.AddPatient();
            break;

        case 2:
            Console.WriteLine("");
            Console.WriteLine("---- Lista de  pacientes -----");
            service.ShowPatients();
            break;
        case 3:
            Console.WriteLine("");
            Console.WriteLine("----- Paciente buscado -----");
            service.SearchPatient("");
            break;
        case 4:
            Console.WriteLine("");
            Console.WriteLine("----- Registrar mascota -----");
            pet.AskAndAddPet(service);
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