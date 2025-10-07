using clinica_salud.models;
using System.Collections.Generic;

namespace clinica_salud.interfaces
{
    public interface IPatientRepository
    {
        void AddPatient(Patient patient);
        List<Patient> GetAllPatients();
        Patient? GetPatientByName(string name);
        Patient? GetPatientById(int id);
        bool ExistsById(int id);
    }
}


