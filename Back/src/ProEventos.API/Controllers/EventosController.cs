using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
using ProEventos.API.Data;
namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
      private readonly DataContext _context; // RECEBENDO CONTEXT NA CONTROLLER 


        public EventosController(DataContext _context) 
        {
          this._context=_context;        
        }

        [HttpGet] 
        // rota:https://localhost:5001/api/Evento
        public IEnumerable<Evento> Get()
        {

            return _context.Eventos; // é POSSIVEL POIS AQUI ESTAMOS RETORNANDO UMA COLEÇÃO GENERICA

        }

        [HttpGet("{id}")]
        // necessario quanto temos mais de uma rota do mesmo verbo 
        // ou seja estamos modificando diferenciando a rota 
        //GET=> rota:https://localhost:5001/api/Evento/{id}
        public Evento GetEventoById(int id)
        {
             
            return _context.Eventos.Where(x => x.EventoId == id).FirstOrDefault(); 
            // aqui mesmo que for null irá retornar um new evento por que como está sendo usado como um get
            // a rota não pode retornar um null  
        }


        [HttpPost]
        // rota= post> https://localhost:5001/api/Evento
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")] // os Protocolos + Verbos serão explicados na proxima aula 
                          // rota= put> https://localhost:5001/api/Evento/8
        public string Put(int id)
        {
            return $"Exemplo de Put com id={id}";
        }


        [HttpDelete("{id}")] // os Protocolos + Verbos serão explicados na proxima aula 
                             // rota= delete> https://localhost:5001/api/Evento/8
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id={id}";
        }
    }
}
