using MEM2.Data.MEM2;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        public async Task<List<Evento>> GetEventosAsyncFilter(string termo)
        {
            return await _context.Evento
                .Where( x => (x.Titulo == termo || x.Categoria == termo))
                 .AsNoTracking().ToListAsync();
        }


        public async  Task<Evento> GetEvento(int eventoID)
        {
            return await _context.Evento
                .FirstOrDefaultAsync(x => x.Id == eventoID);
        }

        public async void SetSeguido(string idMail,int idEvento )
        {
            List<Seguidos> ListSeguidos =  _context.Seguidos.Where(x => x.SeguidosId > 0).ToList();

            List<AspNetUsers> User = _context.AspNetUsers.Where(x => x.Email == idMail).ToList();

            int counter = ListSeguidos.Count();
            String idUser = User.First().Id;

            Seguidos Seguidos = new Seguidos();

            Seguidos.FkEventoId = idEvento;
            Seguidos.FkUtilizadorId = idUser;
            Seguidos.SeguidosId = counter + 1;


            Boolean add = false;

            if (counter == 0) { add = true; }
            else
            {
                foreach (var Seguido in ListSeguidos)
                {
                    if (Seguido.FkUtilizadorId == Seguidos.FkUtilizadorId && Seguido.FkEventoId == Seguidos.FkEventoId)
                    {
                        add = false;
                    }
                    else
                    {
                        add = true;
                    }
                }
            }

            

            Debug.WriteLine(counter);
            Debug.WriteLine(Seguidos.SeguidosId);

            if (add) {
                _context.Seguidos.Add(Seguidos);
                await _context.SaveChangesAsync();
            }
            






        }

    }
}
