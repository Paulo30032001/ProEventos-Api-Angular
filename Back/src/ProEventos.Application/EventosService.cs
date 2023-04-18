using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Persistence.Contratos;
using ProEventos.Domain;

namespace ProEventos.Application
{
    public class EventosService : IEventosService
    {
        private readonly IGeralPersistence IGeralPersistence;
        private readonly IEventosPersistence IEventosPersistence;

        public EventosService(IGeralPersistence IGeralPersistence, IEventosPersistence IEventosPersistence)
        {
            this.IGeralPersistence = IGeralPersistence;
            this.IEventosPersistence = IEventosPersistence;
        }

        public async Task<Evento> AddEventos(Evento Evento)
        {
            try
            {
                IGeralPersistence.Add<Evento>(Evento); // especificando o tipo mais não é necessario

                if (await IGeralPersistence.SaveChangesAsync())
                {
                    return await IEventosPersistence.GetEventoByIdAsync(Evento.Id, false);
                }

                return null; // tipo referencia aceita null    


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public async Task<Evento> UpdateEvento(int Id, Evento Evento)
        {
            try
            {
                var evento = await IEventosPersistence.GetEventoByIdAsNoTrackingAsync(Id, false);
                if (evento == null || Evento.Id != Id) // coisa minha
                {
                    throw new Exception("Evento invalido");
                }
                IGeralPersistence.Update<Evento>(Evento);

                if (await IGeralPersistence.SaveChangesAsync())
                {
                    return  await IEventosPersistence.GetEventoByIdAsync(Id, false); 
                    //DEIXEI IGUAL AO DO PROFESSOR POIS É IMPORTANTE SALIENTEAR 
                    //É POSSIVEL INCLUIR LOTES/REDESSOCIAIS APARTIR DE UM EVENTO 
                    // MAIS NÃO EDITAR/EXCLUIR
                }

                return null;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }




        }
        public async Task<bool> DeleteEvento(int Id)
        {
            var Evento = await IEventosPersistence.GetEventoByIdAsync(Id,false);
            if (Evento == null)
            {
                throw new Exception("Evento invalido");
            }
            try
            {
                IGeralPersistence.Delete(Evento);
                return await IGeralPersistence.SaveChangesAsync(); // retorna true ou false
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool IncluirPalestrantes = false)
        {
            try
            {
                var Eventos = await IEventosPersistence.GetAllEventosAsync(IncluirPalestrantes);

                if (Eventos == null)
                {
                    return null;
                }

                return Eventos;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes = false)
        {
            try
            {
                var Eventos = await IEventosPersistence.GetAllEventosByTemaAsync(Tema,IncluirPalestrantes);

                if (Eventos == null)
                {
                    return null;
                }

                return Eventos;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int Id, bool IncluirPalestrantes = false)
        {
             try
            {
                var Eventos = await IEventosPersistence.GetEventoByIdAsync(Id,IncluirPalestrantes);

                if (Eventos == null)
                {
                    return null;
                }

                return Eventos;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}