using PetGuardianAPI.Entidades;
using PetGuardianAPI.Validaciones;

namespace PetGuardianAPI.DTOs
{
    public class AnimalCreacionDTO : AnimalPatchDTO
    {
        [PesoArchivoValidacion(pesoMaximo: 4)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile imagen { get; set; }
    }
}
