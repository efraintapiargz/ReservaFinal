using ReservaFinal.Modelos;

namespace ReservaFinal.Repositorio
{
    public interface IRepositorioHabitaciones
    {
        Task<List<Habitacion>> GetAll();
        Task<Habitacion?> Get(int id);
        Task<Habitacion> Add(Habitacion habitacion);
        Task Update(int id, Habitacion habitacion);
        Task Delete(int id);
    }
}
