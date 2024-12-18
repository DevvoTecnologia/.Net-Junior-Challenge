using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AneisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AneisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Aneis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anel>>> GetAll()
        {
            var aneis = await _context.Aneis.ToListAsync();
            return Ok(aneis);
        }

        // GET: api/Aneis/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Anel>> GetById(int id)
        {
            var anel = await _context.Aneis.FindAsync(id);
            if (anel == null)
                return NotFound();
            return Ok(anel);
        }

        // POST: api/Aneis
        [HttpPost]
        public async Task<ActionResult<Anel>> Create(Anel anel)
        {
            // Regras de negócio:
            // Máximo de:
            // Elfos: 3
            // Anões: 7
            // Homens: 9
            // Sauron: 1
            int max = 0;
            switch (anel.ForjadoPor)
            {
                case "Elfos": max = 3; break;
                case "Anões": max = 7; break;
                case "Homens": max = 9; break;
                case "Sauron": max = 1; break;
                default:
                    max = int.MaxValue; // se não for um desses, sem limite (ou defina outra lógica)
                    break;
            }

            var count = await _context.Aneis.CountAsync(a => a.ForjadoPor == anel.ForjadoPor);
            if (count >= max)
            {
                return BadRequest($"Já existem {count} anéis forjados por {anel.ForjadoPor}. Limite é {max}.");
            }

            _context.Aneis.Add(anel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = anel.Id }, anel);
        }

        // PUT: api/Aneis/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Anel updatedAnel)
        {
            if (id != updatedAnel.Id)
                return BadRequest();

            var anel = await _context.Aneis.FindAsync(id);
            if (anel == null)
                return NotFound();

            // Verifica se ao atualizar não quebra a regra
            if (anel.ForjadoPor != updatedAnel.ForjadoPor) 
            {
                int max = 0;
                switch (updatedAnel.ForjadoPor)
                {
                    case "Elfos": max = 3; break;
                    case "Anões": max = 7; break;
                    case "Homens": max = 9; break;
                    case "Sauron": max = 1; break;
                }

                var count = await _context.Aneis.CountAsync(a => a.ForjadoPor == updatedAnel.ForjadoPor && a.Id != id);
                if (count >= max)
                {
                    return BadRequest($"Não é possível alterar para {updatedAnel.ForjadoPor}. Já existe o máximo de {max}.");
                }
            }

            // Atualiza campos
            anel.Nome = updatedAnel.Nome;
            anel.Poder = updatedAnel.Poder;
            anel.Portador = updatedAnel.Portador;
            anel.ForjadoPor = updatedAnel.ForjadoPor;
            anel.Imagem = updatedAnel.Imagem;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Aneis/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var anel = await _context.Aneis.FindAsync(id);
            if (anel == null)
                return NotFound();

            _context.Aneis.Remove(anel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
