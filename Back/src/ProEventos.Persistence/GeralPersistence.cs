using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Contratos;
using ProEventos.Persistence.Contextos;
namespace ProEventos.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly ProEventosContext context;
        public GeralPersistence(ProEventosContext context)
        {
            this.context = context;
        }

        public void Add<t>(t entity) where t : class
        {
            context.Add(entity);
        }

        public void Update<t>(t entity) where t : class
        {
            context.Update(entity);
        }

        public void Delete<t>(t entity) where t : class
        {
            context.Remove(entity);
        }

        public void DeleteRange<t>(t[] entity) where t : class
        {
            context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                int Retorno = await context.SaveChangesAsync(); // retorno é um inteiro
                if (Retorno > 0) { return true; } else { return false; }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }


        }

     
}

}