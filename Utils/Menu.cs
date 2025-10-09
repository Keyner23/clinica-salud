namespace clinica_salud.services;

public class Menu
{
    public int ShowRoleMenu()
    {
        Console.Clear();
        Console.WriteLine("=== BIENVENIDO A LA VETERINARIA KABO-PETS ===");
        Console.WriteLine("");
        Console.WriteLine("Seleccione su rol:");
        Console.WriteLine("1. Cliente / Dueño");
        Console.WriteLine("2. Veterinario");
        Console.WriteLine("3. Administrador");
        Console.Write("Ingrese una opción: ");

        if (int.TryParse(Console.ReadLine(), out int rol))
            return rol;
        else
            return 0;
    }

    public int showMenuCliente()
    {
        Console.Clear();
        Console.WriteLine("=== MENÚ CLIENTE ===");
        Console.WriteLine("1. Registrar dueño");
        Console.WriteLine("2. Buscar paciente");
        Console.WriteLine("3. Registrar mascota");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");
        return int.TryParse(Console.ReadLine(), out int opcion) ? opcion : 0;
    }

    public int showMenuVeterinario()
    {
        Console.Clear();
        Console.WriteLine("=== MENÚ VETERINARIO ===");
        Console.WriteLine("1. Registrarse como veterinario");
        Console.WriteLine("2. Salir");
        Console.Write("Seleccione una opción: ");
        return int.TryParse(Console.ReadLine(), out int opcion) ? opcion : 0;
    }


    public int showMenu()
    {
        Console.Clear();
        Console.WriteLine("=== BIENVENIDOS A LA VETERINARIA KABO-PETS ===");
        Console.WriteLine("");
        Console.WriteLine("1. Registrar paciente");
        Console.WriteLine("2. Listar pacientes");
        Console.WriteLine("3. Buscar paciente");
        Console.WriteLine("4. Registrar mascota");
        Console.WriteLine("5. Registrar veterinario");
        Console.WriteLine("6. Ver todos los veterinarios");
        Console.WriteLine("7. Salir");
        Console.Write("Seleccione una opción: ");

        if (int.TryParse(Console.ReadLine(), out int opcion))
        {
            return opcion;
        }
        else
        {
            Console.WriteLine("Opción inválida.");
            return -1;
        }
    }
}