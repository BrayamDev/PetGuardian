using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetGuardianAPI.DTOs;
using PetGuardianAPI.Entidades;

namespace PetGuardianAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacunasController : ControllerBase
    {
        private readonly ApplicationDbContext _contextDataBase;
        private readonly IMapper mapper;

        public VacunasController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this._contextDataBase = applicationDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VacunasDTO>>> GetVacunas()
        {
            var entidades = await _contextDataBase.vacunas.ToListAsync();
            var entidadesDTOs = mapper.Map<List<VacunasDTO>>(entidades);
            return entidadesDTOs;
        }

        [HttpGet("{id:int}", Name = "VacunasById")]
        public async Task<ActionResult<VacunasDTO>> GetVacunasById(int id)
        {
            var entidades = await _contextDataBase.vacunas.FirstOrDefaultAsync(x=>x.id == id);
            if (entidades == null)
            {
                return NotFound();
            }

            var entidadEncontrada = mapper.Map<VacunasDTO>(entidades);
            return entidadEncontrada;
        }

        [HttpPost]
        public async Task<ActionResult> PostVacunas([FromBody] VacunasCreacionDTO vacunasCreacionDTO)
        {
            var entidadesVacunas = mapper.Map<vacunas>(vacunasCreacionDTO);
            _contextDataBase.Add(entidadesVacunas);
            await _contextDataBase.SaveChangesAsync();

            var vacunas = mapper.Map<VacunasDTO>(entidadesVacunas);
            return new CreatedAtRouteResult("VacunasById", new { id = vacunas.id }, vacunas); 
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutVacunas([FromBody] VacunasCreacionDTO vacunasCreacionDTO, int id)
        {
            var entidades = mapper.Map<vacunas>(vacunasCreacionDTO);
            entidades.id = id;

            _contextDataBase.Entry(entidades).State = EntityState.Modified;
            await _contextDataBase.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVacunas(int id) 
        {
            var existe = await _contextDataBase.vacunas.AnyAsync(c => c.id == id);
            if (!existe)
            {
                return NotFound();
            }
            _contextDataBase.Remove(new vacunas() { id = id});
            await _contextDataBase.SaveChangesAsync();
            return NoContent();
        }
    }
}
