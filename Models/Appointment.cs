using System.Diagnostics.Contracts;
using clinica_salud.models;

namespace clinica_salud.Models;

using System.Collections.Generic;

public class Appointment
{
    public List<Veterinarian> veterinarian { get; set; }

    public List<Pet> pets { get; set; }

    public DateTime Date { get; set; }
    public string Reason { get; set; }

    public Appointment(List<Veterinarian> veterinarians, List<Pet> pets, DateTime date, string reason)
    {
        this.veterinarian = veterinarians;
        this.pets = pets;
        Date = date;
        Reason = reason;
    }

    public string ShowInformation()
    {
        string vetsInfo = string.Join("; ", veterinarian.Select(v => v.name));
        string petsInfo = string.Join("; ", pets.Select(p => p.name));

        return $"Fecha: {Date}, Razón: {Reason}, Veterinarios: [{vetsInfo}], Mascota: [{petsInfo}]";
    }
}
