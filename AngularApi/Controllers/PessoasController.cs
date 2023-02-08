using AngularApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly Contexto _contexto;

        public PessoasController(Contexto contexto)
        {
            _contexto = contexto;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetAllPeopleAsync()
        {
            return await _contexto.Pessoas.ToListAsync();
        }

        [HttpGet("{PessoaId}")]   
        public async Task<ActionResult<Pessoa>> GetPeopleById(int PessoaId)
        {
            Pessoa pessoa = await _contexto.Pessoas.FindAsync(PessoaId);

            if (pessoa == null)
            {
                return NotFound(); 
            }

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> SavePeopleAsync(Pessoa pessoa)
        {
            await _contexto.Pessoas.AddAsync(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePeopleAsync(Pessoa pessoa)
        {
            _contexto.Pessoas.Update(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{PessoaId}")]
        public async Task<ActionResult<Pessoa>> DeletePeopleAsync(int PessoaId)
        {
            Pessoa pessoa = await _contexto.Pessoas.FindAsync(PessoaId);

            _contexto.Remove(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }
    }
}
