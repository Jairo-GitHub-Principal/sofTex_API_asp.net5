
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Models;


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

        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Pessoa p){

            dc.pessoa.Add(p);
            await dc.SaveChangesAsync();
            return Created("pessoa cadastrada", p) ;
        }


        [HttpGet("oi")]
        public string oi(){
            return "Hello World";
        }

        
    }
}