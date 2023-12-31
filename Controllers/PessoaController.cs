using System.Runtime.InteropServices;
using System.Collections.Generic;

using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{   
    [Controller]
    [Route("[controller]")]
    public class PessoaController:ControllerBase
    {   

        private DataContext dc;

        public PessoaController(DataContext context){
            this.dc = context;
        }

        [HttpPost("api")] // cadastrar pessoa
        public async Task<ActionResult> cadastrar([FromBody] Pessoa p){

            dc.pessoa.Add(p);
            await dc.SaveChangesAsync();
            return Created("pessoa cadastrada", p) ;
        }

        [HttpGet("api")] // listar pessoa
        public async Task<ActionResult> listar( ){
            
            var dados = await dc.pessoa.ToListAsync();
            return Ok(dados);
         }

         [HttpGet("api/{id}")] // listar por id com metodo find()
         public Pessoa listarID(int id){
            Pessoa p = dc.pessoa.Find(id);
            return p;
         }

         [HttpPut("api")] // metodo atualizar
         public async Task<ActionResult> editar([FromBody] Pessoa p){

                dc.pessoa.Update(p);
                await dc.SaveChangesAsync();
                return Ok(p);
         }

         [HttpDelete("remove/{id}")]  // metodo para remover um registro apartir do id do registro

         public async Task<ActionResult> deletar(int id){
            Pessoa pessoaEcncontrada = dc.pessoa.Find(id);
            dc.pessoa.Remove(pessoaEcncontrada);
            await dc.SaveChangesAsync();
            return Ok(pessoaEcncontrada);
         }

         // outra forma de fazer o delete usando o metodo de listar por id
         [HttpDelete("api/{id}")]
            public async Task<ActionResult> del(int id){
            Pessoa pessoaEncontrada = new Pessoa();

            pessoaEncontrada = listarID(id);

            if(pessoaEncontrada == null){
                return NotFound();
            }else{
                dc.pessoa.Remove(pessoaEncontrada);
                await dc.SaveChangesAsync();
                return Created("registro removido",pessoaEncontrada);
            }
         }



        [HttpGet("oi")]
        public string oi(){
            return "Hello World";
        }

        
    }
}