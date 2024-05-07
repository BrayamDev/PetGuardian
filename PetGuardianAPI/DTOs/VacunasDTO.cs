using System.ComponentModel.DataAnnotations;

namespace PetGuardianAPI.DTOs
{
    public class VacunasDTO
    {
        public int id { get; set; }
        [Required]
        [StringLength(80)]
        public string nombreVacuna { get; set; }
        [Required]
        public DateTime fechaCaducidad { get; set; }
    }
}
