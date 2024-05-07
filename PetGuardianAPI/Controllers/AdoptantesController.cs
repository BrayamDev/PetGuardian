using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetGuardianAPI.AzureService;
using PetGuardianAPI.DTOs;
using PetGuardianAPI.Entidades;
using PetGuardianAPI.Migrations;

namespace PetGuardianAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptantesController : ControllerBase
    {
        private readonly ApplicationDbContext _contextDataBase;
        private readonly IMapper mapper;
        public readonly IAlmacenadorArchivos AlmacenadorArchivos;
        public readonly string contenedor = "Adoptantes";


        public AdoptantesController(ApplicationDbContext applicationDbContext, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos)
        {
            this._contextDataBase = applicationDbContext;
            this.mapper = mapper;
            this.AlmacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdoptantesDTO>>> GetAdoptantes()
        {
            var entidades = await _contextDataBase.adoptantes.ToListAsync();
            return mapper.Map<List<AdoptantesDTO>>(entidades);
        }

        [HttpGet("{id:int}", Name = "AdoptantesById")]
        public async Task<ActionResult<AdoptantesDTO>> GetAdoptantesById(int id)
        {
            var entidades = await _contextDataBase.adoptantes.FirstOrDefaultAsync(x => x.id == id);
            if (entidades == null)
            {
                return NotFound();
            }
            return mapper.Map<AdoptantesDTO>(entidades);
        }

        [HttpPost]
        public async Task<ActionResult> PostAdoptantes([FromForm] AdoptantesCreacionDTO adoptantesCreacionDTO)
        {
            var entidad = mapper.Map<adoptantes>(adoptantesCreacionDTO);

            if (adoptantesCreacionDTO.foto != null)
            {
                using (var memoryStream = new MemoryStream()) 
                {
                    await adoptantesCreacionDTO.foto.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(adoptantesCreacionDTO.foto.FileName);
                    entidad.foto = await AlmacenadorArchivos.GuardarArchivo(contenido, extension, 
                        contenedor, adoptantesCreacionDTO.foto.ContentType);  
                }
            }
            _contextDataBase.Add(entidad);
            await _contextDataBase.SaveChangesAsync();
            var entidadDTO = mapper.Map<AdoptantesDTO>(entidad); 
            return new CreatedAtRouteResult("AdoptantesById", new { id = entidad.id }, entidadDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAdoptantes(int id, [FromForm] AdoptantesCreacionDTO adoptantesCreacionDTO) 
        {
            var AdoptanteDb = await _contextDataBase.adoptantes.FirstOrDefaultAsync(x => x.id == id);

            if (AdoptanteDb == null){ return NotFound();}

            AdoptanteDb = mapper.Map(adoptantesCreacionDTO, AdoptanteDb);       

            if (adoptantesCreacionDTO.foto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await adoptantesCreacionDTO.foto.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(adoptantesCreacionDTO.foto.FileName);
                    AdoptanteDb.foto = await AlmacenadorArchivos.EditarArchivo(contenido,extension,contenedor,
                        AdoptanteDb.foto, 
                        adoptantesCreacionDTO.foto.ContentType);
                }
            }
            await _contextDataBase.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchAdoptantes(int id , [FromBody] JsonPatchDocument<AdoptantePathDTO> PatchDocument) 
        {
            if (PatchDocument == null)
            {
                return BadRequest();
            }

            var entidadDB = await _contextDataBase.adoptantes.FirstOrDefaultAsync(x => x.id == id);
            if (entidadDB == null)
            {
                return NotFound();
            }
            var entidadDTO = mapper.Map<AdoptantePathDTO>(entidadDB);
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
        public async Task<ActionResult> DeleteAdoptantes(int id)
        {
            var existe = await _contextDataBase.adoptantes.AnyAsync(c => c.id == id);
            if (!existe)
            {
                return NotFound();
            }
            _contextDataBase.Remove(new adoptantes() { id = id });
            await _contextDataBase.SaveChangesAsync();
            return NoContent();
        }
    }
}
