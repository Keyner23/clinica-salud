using clinica_salud.models;


namespace clinica_salud.services
{
    public class PetService
    {
        private List<Pet> pets = new List<Pet>();

        public void AddPet(Pet pet)
        {
            pets.Add(pet);
            Console.WriteLine("Mascota agregada correctamente.");
        }

        public List<Pet> GetAllPets()
        {
            return pets;
        }

        public Pet GetPetByName(string name)
        {
            return pets.FirstOrDefault(p => p.name == name);
        }

        public bool RemovePet(string name)
        {
            var pet = GetPetByName(name);
            if (pet != null)
            {
                pets.Remove(pet);
                return true;
            }
            return false;
        }


        //method create pet with pacient
        public void AskAndAddPet(PatientService patientService)
        {
            Console.Write("Ingrese el nombre del dueño: ");
            string dueño = Console.ReadLine();

            var owner = patientService.GetPatientByName(dueño);
            if (owner == null)
            {
                Console.WriteLine("No se encontró un paciente con ese nombre. No se puede crear la mascota.");
                return;
            }

            Console.Write("Ingrese el nombre de la mascota: ");
            string name = Console.ReadLine();

            Console.Write("Ingrese la especie de la mascota: ");
            string species = Console.ReadLine();

            Console.Write("Ingrese la raza de la mascota: ");
            string race = Console.ReadLine();

            int age;
            while (true)
            {
                Console.Write("Ingrese la edad de la mascota: ");
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido para la edad.");
                }
            }

            Pet newPet = new Pet(name, species, race, age);

            AddPet(newPet);

            owner.AddPet(newPet);

            Console.WriteLine($"Mascota agregada correctamente al paciente {dueño}.");
        }
    }
}
