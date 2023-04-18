using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
namespace ProEventos.Persistence
{
    public class PalestrantesPersistence : IPalestrantesPersistence
    {
         private readonly ProEventosContext context;
        public PalestrantesPersistence(ProEventosContext context)
        {
            this.context = context;
        }

           /*AQUI E EM PALESTRANTE É PRECISO TRAZER UM BOOLEANO POIS COMO É UMA RELAÇÃO DE MUITOS PRA MUITOS
  DA UM POUCO MAIS DE TRABALHO PARA TRAZER OS PALESTRANTES QUANDO FOR EVENTOS 
    E PRA TRAZER OS PALESTRANTES QUANDO FOR EVENTOS 

 */ 

     #region Palestrantes

          /*TODOS OS EVENTOS JÁ VEM COM FALSE COMO PADRÃO NÃO SENDO NECESSARIO PASSAR*/

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncluirPalestrantes=false)
        {
             var query = context.Palestrantes.AsQueryable();
           if( IncluirPalestrantes)
           {
               query= query.Include(x=>x.PalestrantesEventos).ThenInclude(x=>x.Evento);
           }
            return await context.Palestrantes.Where(x => x.Nome == Nome).ToArrayAsync();
        }


      public async  Task<Palestrante[]> GetAllPalestrantesAsync(string Nome, bool IncluirPalestrantes=false)
        {
           var query = context.Palestrantes.AsQueryable();

           if(IncluirPalestrantes)
           {
             // AQUI ELE CONSEGUE ACESSAR DENTRO DE PALESTRANTE EVENTO O EVENTO
                // NÃO É POSSIVEL ACESSAR LOGO DENTRO DO PRIMEIRO INCLUDE POIS É UMA LISTA
                query= query.Include(x=>x.PalestrantesEventos).ThenInclude(x=>x.Evento);
           }

            return await query
             .Include(x=>x.RedesSociais)
             .ToArrayAsync();

        }


       public async  Task<Palestrante> GetPalestranteByIdAsync(int Id, bool IncluirPalestrantes=false)
        {
              var query = context.Palestrantes.AsQueryable();

           if(IncluirPalestrantes)
           {
             // AQUI ELE CONSEGUE ACESSAR DENTRO DE PALESTRANTE EVENTO O EVENTO
                // NÃO É POSSIVEL ACESSAR LOGO DENTRO DO PRIMEIRO INCLUDE POIS É UMA LISTA
                query= query.Include(x=>x.PalestrantesEventos).ThenInclude(x=>x.Evento);
           }

            return 
              await query
              .Where(x=>x.Id==Id)
             .Include(x=>x.RedesSociais)
              .OrderBy(x=>x.Id)
             .FirstOrDefaultAsync();
        }

         public async  Task<Palestrante> GetPalestranteByIdAsNoTrackingAsync(int Id, bool IncluirPalestrantes=false)
        {
              var query = context.Palestrantes.AsQueryable();

           if(IncluirPalestrantes)
           {
             // AQUI ELE CONSEGUE ACESSAR DENTRO DE PALESTRANTE EVENTO O EVENTO
                // NÃO É POSSIVEL ACESSAR LOGO DENTRO DO PRIMEIRO INCLUDE POIS É UMA LISTA
                query= query.Include(x=>x.PalestrantesEventos).ThenInclude(x=>x.Evento);
           }

            return 
              await query
              .Where(x=>x.Id==Id)
             .Include(x=>x.RedesSociais)
              .OrderBy(x=>x.Id)
             .AsNoTracking().FirstOrDefaultAsync();
        }


        #endregion

    }
    
}