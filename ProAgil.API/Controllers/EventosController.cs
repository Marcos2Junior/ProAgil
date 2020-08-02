using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [Route("site/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        public DataContext _context { get; }
        public EventosController(DataContext context) => _context = context;


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
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(result);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }
    }
}