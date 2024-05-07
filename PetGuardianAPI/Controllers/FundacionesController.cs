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
    public class FundacionesController : ControllerBase
    {
        private readonly ApplicationDbContext _contextDataBase;
        private readonly IMapper mapper;

        public FundacionesController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this._contextDataBase = applicationDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FundacionDTO>>> GetFundaciones() 
        {
            var entidades = await _contextDataBase.fundaciones.ToListAsync();
            var entidadesDTOs = mapper.Map<List<FundacionDTO>>(entidades);
            return entidadesDTOs;
        }

        [HttpGet("{id}", Name = "FundacionesById")]
        public async Task<ActionResult<FundacionDTO>> GetFundacionesById(int id)
        {
            var entidades = await _contextDataBase.fundaciones.FirstOrDefaultAsync(x => x.id == id);
            if (entidades == null)
            {
                return NotFound();
            }
            var entidadesEncontradas = mapper.Map<FundacionDTO>(entidades);
            return entidadesEncontradas;
        }

        [HttpPost]
        public async Task<ActionResult> PostFundaciones([FromBody] FundacionCreacionDTO fundacionCreacionDTO) 
        {
            var entidades = mapper.Map<fundaciones>(fundacionCreacionDTO);
            _contextDataBase.Add(entidades);
            await _contextDataBase.SaveChangesAsync();
            var fundaciones = mapper.Map<FundacionDTO>(entidades);
            return new CreatedAtRouteResult("FundacionesById", new { id = fundaciones.id }, fundaciones);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutFundaciones(int id, [FromBody] FundacionCreacionDTO fundacionCreacionDTO) 
        {
            var entidades = mapper.Map<fundaciones>(fundacionCreacionDTO);
            entidades.id = id;
            _contextDataBase.Entry(entidades).State = EntityState.Modified;
            await _contextDataBase.SaveChangesAsync();

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFundaciones(int id)
        {
            var existe = await _contextDataBase.fundaciones.AnyAsync(c => c.id == id);
            if (!existe)
            {
                return NotFound();
            }
            _contextDataBase.Remove(new fundaciones() { id = id });
            await _contextDataBase.SaveChangesAsync();
            return NoContent();
        }

    }
}
