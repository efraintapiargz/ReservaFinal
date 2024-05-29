using Microsoft.EntityFrameworkCore;
using ReservaFinal.Modelos;

namespace ReservaFinal.Repositorio
{
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
            var persona = await _context.Habitaciones.FindAsync(id);
            if (persona != null)
            {
                _context.Habitaciones.Remove(persona);
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
            var personaactual = await _context.Habitaciones.FindAsync(id);
            if (personaactual != null)
            {
                personaactual.TipoHabitacion = habitacion.TipoHabitacion;
                personaactual.Estado = habitacion.Estado;
                personaactual.PrecioNoche = habitacion.PrecioNoche;
                await _context.SaveChangesAsync();
            }
        }

    }
}