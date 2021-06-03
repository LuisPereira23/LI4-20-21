using MEM2.Data.MEM2;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEM2.Data
{
    public class EventoService
    {
        private readonly MEMContext _context;
        public EventoService(MEMContext context)
        {
            _context = context;
        }

        public async Task<List<Evento>>GetEventosAsync(){
            return await _context.Evento
                 .AsNoTracking().ToListAsync();
        }

        public async  Task<Evento> GetEvento(int eventoID)
        {
            return await _context.Evento
                .FirstOrDefaultAsync(x => x.Id == eventoID);
        }

    }
}
