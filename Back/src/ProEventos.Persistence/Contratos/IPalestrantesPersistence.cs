using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;
namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantesPersistence
    {
          //Palestrantes

       Task<Palestrante[]>GetAllPalestrantesByNomeAsync(string Nome,bool IncluirEventos);

       
        Task<Palestrante[]>GetAllPalestrantesAsync(string Nome ,bool IncluirEventos);


        Task<Palestrante>GetPalestranteByIdAsync(int Id,bool IncluirEventos);

        Task<Palestrante>GetPalestranteByIdAsNoTrackingAsync(int Id,bool IncluirPalestrantes);
        // INCLUIDO OBJETO NÃO RASTRAVEL
    }
}