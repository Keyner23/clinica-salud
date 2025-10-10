
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
var appoimentService = new AppointmentService(new AppointmentRepository());


var menu = new Menu();
int opcion;
int rol = menu.ShowRoleMenu();
bool salir = false;


do
{
    opcion = -1;
    switch (rol)
    {
        // OWNER
        case 1:
            opcion = menu.showMenuCliente();
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("----- REGISTRARSE COMO DUEÑO-----");
                    patientService.AddPatient();
                    break;
                case 2:
                    Console.WriteLine("----- VER MI INFORMACION-----");
                    Console.Write("Ingrese su nombre: ");
                    string nameCliente = Console.ReadLine() ?? "";
                    patientService.SearchPatient(nameCliente);
                    break;
                case 3:
                    Console.WriteLine("----- REGISTRAR MASCOTA -----");
                    petService.AskAndAddPet(patientService);
                    break;
                case 4:
                    Console.WriteLine("----- CREAR CITA -----");
                    appoimentService.AddAppointment();
                    break;
                case 5:
                    Console.WriteLine("----- VER MIS CITAS MASCOTA -----");
                    Console.Write("Ingrese el nombre de su mascota: ");
                    string petName = Console.ReadLine() ?? "";
                    appoimentService.ShowAppointmentsByPetName(petName);
                    break;

                case 6:
                    Console.WriteLine("----- VOLVIENDO AL MENU PRINCIPAL -----");
                    rol = menu.ShowRoleMenu();
                    break;

                case 7:
                    Console.WriteLine("----- SALIENDO DEL SISTEMA -----");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("----- Opción no válida -----");
                    break;
            }
            break;

        // VETERINARIAN
        case 2:
            opcion = menu.showMenuVeterinario();
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("----- REGISTRAR VETERINARIO -----");
                    veterinarianService.AddVeterinarian();
                    break;
                case 2:
                    Console.WriteLine("----- VOLVIENDO AL MENU PRINCIPAL -----");
                    rol = menu.ShowRoleMenu();
                    break;
                case 3:
                    Console.WriteLine("----- SALIENDO DEL SISTEMA -----");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("----- Opción no válida -----");
                    break;
            }
            break;

        // ADMIN
        case 3:
            opcion = menu.showMenu();
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("----- REGISTRAR DUEÑO -----");
                    patientService.AddPatient();
                    break;
                case 2:
                    Console.WriteLine("---- VER PACIENTES -----");
                    patientService.ShowPatients();
                    break;
                case 3:
                    Console.WriteLine("----- BUSCAR PACIENTE -----");
                    Console.Write("Ingrese el nombre del paciente a buscar: ");
                    string nameAdmin = Console.ReadLine() ?? "";
                    patientService.SearchPatient(nameAdmin);
                    break;
                case 4:
                    Console.WriteLine("----- REGISTRAR MASCOTA -----");
                    petService.AskAndAddPet(patientService);
                    break;
                case 5:
                    Console.WriteLine("----- REGISTRAR VETERINARIO -----");
                    veterinarianService.AddVeterinarian();
                    break;
                case 6:
                    Console.WriteLine("----- VER VETERINARIOS -----");
                    veterinarianService.ShowVeterinarian();
                    break;

                case 7:
                    Console.WriteLine("----- VER CITAS -----");
                    appoimentService.GetAllAppoiments();
                    break;
                case 8:
                    Console.WriteLine("----- VOLVIENDO AL MENU PRINCIPAL -----");
                    rol = menu.ShowRoleMenu();
                    break;
                case 9:
                    Console.WriteLine("----- SALIENDO DEL SISTEMA -----");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("----- Opción no válida -----");
                    break;
            }
            break;

        default:
            Console.WriteLine("Rol no válido. Reinicia el programa.");
            salir = true;
            break;
    }

    if (!salir)
    {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

} while (!salir);