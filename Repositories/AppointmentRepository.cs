using clinica_salud.Interfaces;
using clinica_salud.Models;

namespace clinica_salud.Repositories
{
    public class AppointmentRepository : IAppoimentRepository
    {
        private readonly List<Appointment> appointments = new();

        public void AddAppoiment(Appointment appointment)
        {
            appointments.Add(appointment);
        }

        public List<Appointment> GetAllAppoiments()
        {
            return appointments;
        }
    }
}
