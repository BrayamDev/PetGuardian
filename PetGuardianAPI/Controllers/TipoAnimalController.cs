using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetGuardianAPI.DTOs;
using PetGuardianAPI.Entidades;
using PetGuardianAPI.Migrations;

namespace PetGuardianAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAnimalController : ControllerBase
    {
        private readonly ApplicationDbContext _contextDataBase;
        private readonly IMapper mapper;

        public TipoAnimalController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this._contextDataBase = applicationDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoAnimalDTO>>> GetTipoAnimal()
        {
            var entidades = await _contextDataBase.tipoAnimal.ToListAsync();
            var entidadesDTOs = mapper.Map<List<TipoAnimalDTO>>(entidades);
            return entidadesDTOs;
        }

        [HttpGet("{id}", Name = "GetTipoAnimalById")]
        public async Task<ActionResult<TipoAnimalDTO>> GetTipoAnimalById(int id) 
        {
            var entidades = await _contextDataBase.tipoAnimal.FirstOrDefaultAsync(x=>x.id == id);
            if (entidades == null)
            {
                return NotFound();
            }
            var entidadEncontrada = mapper.Map<TipoAnimalDTO>(entidades);
            return entidadEncontrada; 
        }
        [HttpPost]
        public async Task<ActionResult> PostTipoAnimal([FromBody] TipoAnimalCreacionDTO tipoAnimalCreacionDTO)
        {
            var entidadesTipoAnimal = mapper.Map<tipoAnimal>(tipoAnimalCreacionDTO);
            _contextDataBase.Add(entidadesTipoAnimal);
            await _contextDataBase.SaveChangesAsync();
            var tipoAnimal = mapper.Map<TipoAnimalDTO>(entidadesTipoAnimal);
            return new CreatedAtRouteResult("GetTipoAnimalById", new { id = tipoAnimal.id }, tipoAnimal);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutTipoAnimal([FromBody] TipoAnimalCreacionDTO tipoAnimalCreacionDTO, int id)
        {
            var entidades = mapper.Map<tipoAnimal>(tipoAnimalCreacionDTO);
            entidades.id = id;
            _contextDataBase.Entry(entidades).State = EntityState.Modified;
            await _contextDataBase.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoAnimal(int id)
        {
            var existe = await _contextDataBase.tipoAnimal.AnyAsync(c => c.id == id);
            if (!existe)
            {
                return NotFound();
            }
            _contextDataBase.Remove(new tipoAnimal() { id = id });
            await _contextDataBase.SaveChangesAsync();
            return NoContent();
        }
    }
}

