using System.ComponentModel.DataAnnotations;

namespace PetGuardianAPI.Validaciones
{
    public class PesoArchivoValidacion : ValidationAttribute
    {
        private readonly int pesoMaximo;

        public PesoArchivoValidacion(int pesoMaximo)
        {
            this.pesoMaximo = pesoMaximo;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
            if (value == null) 
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null) 
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > pesoMaximo * 1024 * 1024)
            {
                return new ValidationResult($"El peso maximo del archivo no debe ser mayor{pesoMaximo} mb");
            }
        
            return ValidationResult.Success;
        }
    }
}
