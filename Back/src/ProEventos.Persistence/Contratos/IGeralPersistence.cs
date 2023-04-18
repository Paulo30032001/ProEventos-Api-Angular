using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
    public interface IGeralPersistence
    {
        //GERAL TODAS AS OPERAÇÕES (COMUNS VÃO SER IMPLEMENTADAS AQUI)
        void Add <t> (t entity) where t : class; 

        void Update <t> (t entity) where t : class;

        void Delete  <t> (t entity) where t : class;

        void DeleteRange <t> (t[] entity) where t : class;

        Task<bool> SaveChangesAsync();
    }
}