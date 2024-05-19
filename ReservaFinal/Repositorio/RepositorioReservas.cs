using Microsoft.EntityFrameworkCore;
using ReservaFinal.Modelos;
using ReservaFinal.Repositorio;

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
        return await _context.Reservas.FindAsync(id);
    }

    public async Task<List<Reserva>> GetAll()
    {
        return await _context.Reservas.ToListAsync();
    }

    public async Task Update(int id, Reserva reserva)
    {
        var reservaActual = await _context.Reservas.FindAsync(id);
        if (reservaActual != null)
        {
            reservaActual.ClienteId = reserva.ClienteId;
            reservaActual.FechaReserva = reserva.FechaReserva;
            reservaActual.FechaEntrada = reserva.FechaEntrada;
            reservaActual.FechaSalida = reserva.FechaSalida;
            reservaActual.NumeroHabitaciones = reserva.NumeroHabitaciones;
            reservaActual.Estado = reserva.Estado;
            await _context.SaveChangesAsync();
        }
    }
}