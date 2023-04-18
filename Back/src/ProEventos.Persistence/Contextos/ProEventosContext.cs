using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {
      public ProEventosContext (DbContextOptions<ProEventosContext>options) : base(options)  {}

      public DbSet<Evento>Eventos {get;set;}

      public DbSet<Lote>Lotes {get;set;}
      
      public DbSet<Palestrante> Palestrantes {get;set;}

      public DbSet<PalestranteEvento> PalestrantesEventos {get;set;}

      public DbSet<RedeSocial> RedesSociais {get;set;}

      /*AQUI VAMOS CRIAR UM VOID PARA QUE OS DOIS ATRIBUTOS DE PALESTRANTESEVENTOS 
       SEJAM CONSIDERADOS COMO CHAVES ESTRANGEIRAS  
       NA HORA DE CRIAÇÃO OU SEJA DA MIGRATION SERVE PARA ELE ENTENDER QUE ESSA É A CLASSE DE
       JUNÇÃO DE PALESSTRANTE E EVENTOS UMA RELAÇÃO DE MUITOS PRA MUITOS
      */

       protected override void OnModelCreating(ModelBuilder model){
           /*ISSO SIGNIFICA QUE NA HORA DA CRIAÇÃO DA ENTIDADE(TABELA)
            ELE VAI RECONHECER  QUE ESSA É A CLASSE DE JUNÇÃO ENTRE PALESTRANTE E EVENTOS
            QUE EVENTOID ESTÁ PARA PALESTRANTE ID
           */
           model.Entity<PalestranteEvento>()
           .HasKey(PE=>new{PE.EventoId,PE.PalestranteId});

           model.Entity<Evento>()
           .HasMany(x=>x.RedesSociais) //caso tenha  redessociais
            .WithOne(x=>x.Evento) // e cada uma dessas redes sociais com um evento
            .OnDelete(DeleteBehavior.Cascade); // quando for deletar faça a deleção em cascata 

             model.Entity<Palestrante>()
           .HasMany(x=>x.RedesSociais) //caso tenha  redessociais
            .WithOne(x=>x.Palestrante) // e cada uma dessas redes sociais com um evento
            .OnDelete(DeleteBehavior.Cascade); // quando for deletar faça a deleção em cascata 
       }
        
    }
}