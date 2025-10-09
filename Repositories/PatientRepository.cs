using clinica_salud.models;
using clinica_salud.interfaces;


namespace clinica_salud.repositories;

public class PatientRepository : IPatientRepository
{
    private List<Patient> patients = new List<Patient>();

    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
    }

    public List<Patient> GetAllPatients()
    {
        return patients;
    }

    public Patient? GetPatientByName(string name)
    {
        return patients.FirstOrDefault(p => p.name == name);
    }

    public Patient? GetPatientById(int id)
    {
        return patients.FirstOrDefault(p => p.id == id);
    }

    public bool ExistsById(int id)
    {
        return patients.Any(p => p.id == id);
    }

}

