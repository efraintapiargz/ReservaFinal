using ReservaFinal.Modelos;

namespace ReservaFinal.Repositorio
{
    public interface IRepositorioReservas
    {
        Task<List<Reserva>> GetAll();
        Task<Reserva?> Get(int id);
        Task<Reserva> Add(Reserva reserva);
        Task Update(int id, Reserva reserva);
        Task Delete(int id);
    }
}
