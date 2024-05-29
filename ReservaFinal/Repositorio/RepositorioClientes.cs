using Microsoft.EntityFrameworkCore;
using ReservaFinal.Modelos;

namespace ReservaFinal.Repositorio
{
    public class RepositorioClientes: IRepositorioClientes
    {
        private readonly ReservaDBContext _context;

        public RepositorioClientes(ReservaDBContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Delete(int id)
        {
            var persona = await _context.Clientes.FindAsync(id);
            if (persona != null)
            {
                _context.Clientes.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cliente?> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();   
        }

        public async Task Update(int id, Cliente cliente)
        {
            var personaactual = await _context.Clientes.FindAsync(id);
            if (personaactual != null)
            {
                personaactual.Nombre = cliente.Nombre;
                personaactual.Correo = cliente.Correo;
                personaactual.Telefono = cliente.Telefono;
                await _context.SaveChangesAsync();
            }
        }

    }
}
