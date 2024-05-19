using Microsoft.EntityFrameworkCore;
using ReservaFinal.Modelos;
using ReservaFinal.Repositorio;

public class RepositorioHabitaciones : IRepositorioHabitaciones
{
    private readonly ReservaDBContext _context;

    public RepositorioHabitaciones(ReservaDBContext context)
    {
        _context = context;
    }

    public async Task<Habitacion> Add(Habitacion habitacion)
    {
        await _context.Habitaciones.AddAsync(habitacion);
        await _context.SaveChangesAsync();
        return habitacion;
    }

    public async Task Delete(int id)
    {
        var habitacion = await _context.Habitaciones.FindAsync(id);
        if (habitacion != null)
        {
            _context.Habitaciones.Remove(habitacion);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Habitacion?> Get(int id)
    {
        return await _context.Habitaciones.FindAsync(id);
    }

    public async Task<List<Habitacion>> GetAll()
    {
        return await _context.Habitaciones.ToListAsync();
    }

    public async Task Update(int id, Habitacion habitacion)
    {
        var habitacionActual = await _context.Habitaciones.FindAsync(id);
        if (habitacionActual != null)
        {
            habitacionActual.TipoHabitacion = habitacion.TipoHabitacion;
            habitacionActual.Estado = habitacion.Estado;
            habitacionActual.PrecioNoche = habitacion.PrecioNoche;
            await _context.SaveChangesAsync();
        }
    }
}