using PetGuardianAPI.Entidades;
using PetGuardianAPI.Migrations;
using PetGuardianAPI.Validaciones;

namespace PetGuardianAPI.DTOs
{
    public class AnimalPatchDTO
    {
        public string nombreAnimal { get; set; }
        public string urlDocumentos { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string estadoSalud { get; set; }
        public string observaciones { get; set; }
        public string procedencia { get; set; }
        public bool estado { get; set; }
        public int edad { get; set; }
        public string raza { get; set; }
        public string sexo { get; set; }

        public int tipoAnimalId { get; set; }
        public int vacunasId { get; set; }

        public int fundacionId { get; set; }
        public int adoptanteId { get; set; }
    }
}
