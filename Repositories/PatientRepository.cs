using clinica_salud.models;
using clinica_salud.interfaces;
using clinica_salud.Db;
using clinica_salud.Models;
using System.ComponentModel.Design;

namespace clinica_salud.repositories
{
    public class PatientRepository : IPatientRepository
    {
        public void AddPatient(Patient patient)
        {
            Database.patients.Add(patient);
        }

        public List<Patient> GetAllPatients()
        {
            return Database.patients;
        }

        public Patient? GetPatientByName(string name)
        {
            return Database.patients
                .FirstOrDefault(p => p.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Patient? GetPatientById(int id)
        {
            return Database.patients.FirstOrDefault(p => p.id == id);
        }

        public bool ExistsById(int id)
        {
            return Database.patients.Any(p => p.id == id);
        }
    }
}
