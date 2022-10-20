using ManejoPresupuestov6.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuestov6.Models
{
    public class TipoCuenta
    {
        //De la tabla tipos cuentas
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        //[StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe estar entre  {2} y {1}")]
        //[Display(Name = "Nombre del tipo de cuenta")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Nombre != null && Nombre.Length > 0) {
        //        var primeraLetra = Nombre[0].ToString();
        //        if (primeraLetra != primeraLetra.ToUpper()) {
        //            yield return new ValidationResult("La primera letra debe ser mayuscula", new[] { nameof(Nombre) });

        //        }
        //    }
        //}

        /*pruebas de otras validaciones por defecto*/
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        //[EmailAddress(ErrorMessage ="El campo debe ser un correo electronico")]
        //public string Email { get; set; }

        //[Range(minimum:18, maximum:130, ErrorMessage ="La edad debe estar entre {1} y {2}")]
        //public int Edad { get; set; }

        //[Url(ErrorMessage = "El campo Udebe ser una URL Valida")]
        //public string URL { get; set; }

        //[CreditCard(ErrorMessage ="La tarjeta de credito no es valida" )]
        //[Display(Name = "Ingresar Tarjeta de Credito")]
        //public string TarjetaDeCredito { get; set; }
    }
}
