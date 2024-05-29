using Microsoft.EntityFrameworkCore;
using ReservaFinal.Modelos;

namespace ReservaFinal.Repositorio
{
    public class RepositorioReservas : IRepositorioReservas
    {
        private readonly ReservaDBContext _context;

        public RepositorioReservas(ReservaDBContext context)
        {
            _context = context;
        }

        public async Task<Reserva> Add(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task Delete(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Reserva?> Get(int id)
        {
            return await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .FirstOrDefaultAsync(r => r.ReservaId == id);
        }

        public async Task<List<Reserva>> GetAll()
        {
            return await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .ToListAsync();
        }

        public async Task<List<Reserva>> GetReservasPorCliente(int clienteId)
        {
            return await _context.Reservas
                .Include(r => r.Habitacion)
                .Where(r => r.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task Update(int id, Reserva reserva)
        {
            var reservaActual = await _context.Reservas.FindAsync(id);
            if (reservaActual != null)
            {
                reservaActual.ClienteId = reserva.ClienteId;
                reservaActual.HabitacionId = reserva.HabitacionId;
                reservaActual.FechaEntrada = reserva.FechaEntrada;
                reservaActual.FechaSalida = reserva.FechaSalida;
                await _context.SaveChangesAsync();
            }
        }
    }
}