using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetGuardianAPI.AzureService;
using PetGuardianAPI.DTOs;
using PetGuardianAPI.Entidades;

namespace PetGuardianAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalesController : ControllerBase
    {
        private readonly ApplicationDbContext _contextDataBase;
        private readonly IMapper mapper;
        public readonly IAlmacenadorArchivos AlmacenadorArchivos;
        public readonly string contenedor = "Animales";


        public AnimalesController(ApplicationDbContext applicationDbContext, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos)
        {
            this._contextDataBase = applicationDbContext;
            this.mapper = mapper;
            this.AlmacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalesDTO>>> GetAnimales() 
        {
            var animales = await _contextDataBase.animales.ToListAsync();
            return mapper.Map<List<AnimalesDTO>>(animales);
        }


        [HttpGet("{id:int}", Name = "AnimalesById")]
        public async Task<ActionResult<AnimalesDTO>> GetAnimalesById(int id)
        {
            var animales = await _contextDataBase.animales.FirstOrDefaultAsync(x=>x.id == id);
            if (animales == null)
            {
                return NotFound();
            }
            return mapper.Map<AnimalesDTO>(animales);
        }

        [HttpPost]
        public async Task<ActionResult> PostAnimales([FromForm] AnimalCreacionDTO animalCreacionDTO)
        {
            var animales = mapper.Map<animales>(animalCreacionDTO);

            if (animalCreacionDTO.imagen != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await animalCreacionDTO.imagen.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(animalCreacionDTO.imagen.FileName);
                    animales.imagen = await AlmacenadorArchivos.GuardarArchivo(contenido, extension,
                        contenedor, animalCreacionDTO.imagen.ContentType);
                }
            }

            _contextDataBase.Add(animales);
            await _contextDataBase.SaveChangesAsync();
            var entidadDTO = mapper.Map<AnimalesDTO>(animales);
            return new CreatedAtRouteResult("AnimalesById", new { id = animales.id }, entidadDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAnimales(int id, [FromForm] AnimalCreacionDTO animalCreacionDTO)
        {
            var animalesDb = await _contextDataBase.animales.FirstOrDefaultAsync(x => x.id == id);

            if (animalesDb == null) { return NotFound(); }

            animalesDb = mapper.Map(animalCreacionDTO, animalesDb);

            if (animalCreacionDTO.imagen != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await animalCreacionDTO.imagen.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(animalCreacionDTO.imagen.FileName);
                    animalesDb.imagen = await AlmacenadorArchivos.EditarArchivo(contenido, extension, contenedor,
                        animalesDb.imagen,
                        animalCreacionDTO.imagen.ContentType);
                }
            }
            await _contextDataBase.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchAnimales(int id, [FromBody] JsonPatchDocument<AnimalPatchDTO> PatchDocument)
        {
            if (PatchDocument == null)
            {
                return BadRequest();
            }

            var entidadDB = await _contextDataBase.animales.FirstOrDefaultAsync(x => x.id == id);
            if (entidadDB == null)
            {
                return NotFound();
            }
            var entidadDTO = mapper.Map<AnimalPatchDTO>(entidadDB);
            PatchDocument.ApplyTo(entidadDTO, ModelState);

            var entidadValida = TryValidateModel(entidadDTO);
            if (!entidadValida)
            {
                return BadRequest(ModelState);
            }
            mapper.Map(entidadDTO, entidadDB);

            await _contextDataBase.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnimales(int id)
        {
            var existe = await _contextDataBase.animales.AnyAsync(c => c.id == id);
            if (!existe)
            {
                return NotFound();
            }
            _contextDataBase.Remove(new animales() { id = id });
            await _contextDataBase.SaveChangesAsync();
            return NoContent();
        }
    }
}
