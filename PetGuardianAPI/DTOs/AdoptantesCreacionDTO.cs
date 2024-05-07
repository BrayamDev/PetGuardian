using System.ComponentModel.DataAnnotations;
using PetGuardianAPI.Validaciones;


namespace PetGuardianAPI.DTOs
{
    public class AdoptantesCreacionDTO : AdoptantePathDTO
    {
        [PesoArchivoValidacion(pesoMaximo:4)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile foto { get; set; }
    }
}