using System.ComponentModel.DataAnnotations;

namespace PetGuardianAPI.Entidades
{
    public class adoptantes
    {
        [Key]
        public int id { get; set; }
        public string nombreAdoptante { get; set; }
        public int numeroDocumento { get; set; }
        public int numeroContacto { get; set; }
        public int numeroEmergencia { get; set; }
        public string foto { get; set; }
        public string direccionResidencia { get; set; }
    }
}
