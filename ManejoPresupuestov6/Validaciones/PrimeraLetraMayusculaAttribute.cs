using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuestov6.Validaciones
{
    public class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Verificar si la primera letra es mayuscula
            //return base.IsValid(value, validationContext);
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var primeraLetra = value.ToString()[0].ToString();
            if (primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("Primera Letra debe ser Mayuscula");
            }
            return ValidationResult.Success;
        }
    }
}
