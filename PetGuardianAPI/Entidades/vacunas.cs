using System.ComponentModel.DataAnnotations;

namespace PetGuardianAPI.Entidades
{
    public class vacunas
    {
        public int id { get; set; }
        [Required]
        [StringLength(80)]
        public string nombreVacuna { get; set; }
        [Required]
        public DateTime fechaCaducidad { get; set; }
    }
}
