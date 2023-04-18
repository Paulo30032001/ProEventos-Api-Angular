using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using Microsoft.AspNetCore.Http;
namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //PRESTAR ATENÇÃO NO DESVIO DA ROTA API/CONTROLLER 
    public class EventosController : ControllerBase
    {
      private readonly IEventosService service; // RECEBENDO CLASSE GENERICA DE ACESSO A DADOS

 
        public EventosController(IEventosService service) 
        {
          this.service=service;        
        }
          
    
        
        [HttpGet]  //Get=Pegar Dados
        // rota:https://localhost:5001/api/Evento
        public async Task<IActionResult> Get()
        {
            try
            {
             var eventos = await service.GetAllEventosAsync(true);
            if(eventos == null)
            {
                return NotFound("Nenhum evento encontrato"); // retorna um 404
            }


            return Ok(eventos);  //200
            /*RETORNA 200 OU SEJA A REQUISIÇÃO FOI REALIZADA COM SUCESSO E DENTRO DELE RETORNA UM OBJETO EM FORMATO JSON
            RETURN OK(OBJECT)*/
            }
            catch(Exception e)
            {
               //PARA RETORNAR UM STATUS CODE DO RESPONSE DO PROTOCOLO HTTP 

            // O THIS AQUI SE REFERE AO PROPRIO CONTROLLER QUE IMPLEMENTA 
            //CONTROLLER BASE POR ISSO CONSEGUE RETORNAR UM VERBO DO PROTOCOLO HTTP
            //POR QUE SE TRATA DE UMA ROTA
               return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar recuperar eventos, Erro:{e.Message}");

            }
            

        }

        [HttpGet("{id}")]
        /* necessario quanto temos mais de uma rota do mesmo verbo 
         ou seja estamos modificando diferenciando a rota 
        GET=> rota:https://localhost:5001/api/Evento/{id}
        */
        public async Task<IActionResult> GetById(int id)



        {
             try
             {
                var evento=  await service.GetEventoByIdAsync(id,true); 
                return Ok(evento);
            // aqui mesmo que for null irá retornar um new evento por que como está sendo usado como um get
            // a rota não pode retornar um null
             }
             

             catch(Exception e)
            {
               //PARA RETORNAR UM STATUS CODE DO RESPONSE DO PROTOCOLO HTTP 

            // O THIS AQUI SE REFERE AO PROPRIO CONTROLLER QUE IMPLEMENTA 
            //CONTROLLER BASE POR ISSO CONSEGUE RETORNAR UM VERBO DO PROTOCOLO HTTP
            //POR QUE SE TRATA DE UMA ROTA
               return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar recuperar eventos, Erro:{e.Message}");

            } 
        }
          
    
        //rota:https://localhost:5001/api/Evento/{tema}/tema
        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
             var eventos = await service.GetAllEventosByTemaAsync(tema,true);
            if(eventos == null)
            {
                return NotFound("Evento por tema não encontrato");
            }


            return Ok(eventos);  
            /*RETORNA 200 OU SEJA A REQUISIÇÃO FOI REALIZADA COM SUCESSO E DENTRO DELE RETORNA UM OBJETO EM FORMATO JSON
            RETURN OK(OBJECT)*/
            }
            catch(Exception e)
            {
               //PARA RETORNAR UM STATUS CODE DO RESPONSE DO PROTOCOLO HTTP 

            // O THIS AQUI SE REFERE AO PROPRIO CONTROLLER QUE IMPLEMENTA 
            //CONTROLLER BASE POR ISSO CONSEGUE RETORNAR UM VERBO DO PROTOCOLO HTTP
            //POR QUE SE TRATA DE UMA ROTA
               return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar recuperar eventos, Erro:{e.Message}");

            }
            

        }


        [HttpPost]
        // rota= post> https://localhost:5001/api/Evento Post=Inserção de dados
        public async Task<IActionResult> Post(Evento model)
        {
           try
           {
            var evento =  await  service.AddEventos(model);

             if(evento==null){return BadRequest("Erro ao tentar adicionar evento");} 
             //BadRequest Retorna 400

             return Ok();
           }
           catch(Exception e)
           {
              return this.StatusCode(StatusCodes.Status500InternalServerError,
              $"Erro ao tentar inserir evento,Erro:${e.Message}");
           }
        }

        [HttpPut("{id}")] 
         // rota= put> https://localhost:5001/api/Evento/8  Put=Atualizar dados
        public async Task<IActionResult>Put(int id,Evento model)
        {
           try
           {
             var evento= await  service.UpdateEvento(id,model);

             if(evento==null){return BadRequest("Erro ao tentar editar evento");} 
             //BadRequest Retorna 400

             return Ok(evento);
           }
           catch(Exception e)
           {
              return this.StatusCode(StatusCodes.Status500InternalServerError,
              $"Erro ao tentar editar evento,Erro:${e.Message}");
           }
        }


        [HttpDelete("{id}")] 
       // rota= delete> https://localhost:5001/api/Evento/8 Delete= Remover
        public async Task<IActionResult>Delete(int id)
        {
            try
           {
             var delete= await  service.DeleteEvento(id);

             if(!delete)
             {
                return BadRequest("Erro ao tentar excluir evento"); // 400;
             }

             return Ok();
           }
           catch(Exception e)
           {
              return this.StatusCode(StatusCodes.Status500InternalServerError,
              $"Erro ao tentar excluir evento,Erro:${e.Message}");
           }
        }

    }
}
