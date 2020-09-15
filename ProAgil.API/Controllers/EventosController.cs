using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        public ProAgilContext _context { get; }
        public EventosController(ProAgilContext context) => _context = context;


        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            try
            {
                var result = await _context.Eventos.ToListAsync();
                return Ok(result);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAction(int id)
        {
            try
            {
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(result);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                _context.Add(model);

                await _context.SaveChangesAsync();

                return Created($"/api/eventos/{model.Id}", model);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }
        }
		
		 [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                if (await _context.Eventos.AnyAsync(x => x.Id == id))
                {
                    _context.Update(model);

                    await _context.SaveChangesAsync();

                    return Created($"/api/eventos/{model.Id}", model);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }
        }
		
		 [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
                if (evento == null) return NotFound();

                _context.Remove(evento);

                await _context.SaveChangesAsync();
				return NoContent();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

            return BadRequest();
        }
    }
}