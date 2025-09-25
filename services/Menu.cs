namespace clinica_salud.services;

public class Menu
{
    public int showMenu()
    {
        Console.Clear();
        Console.WriteLine("=== BIENVENIDOS A LA VETERINARIA KABO-PETS ===");
        Console.WriteLine("");
        Console.WriteLine("1. Registrar paciente");
        Console.WriteLine("2. Listar pacientes");
        Console.WriteLine("3. Buscar paciente");
        Console.WriteLine("4. Salir");
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
