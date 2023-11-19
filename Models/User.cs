#pragma warning disable CS8618

// Uso de Anotaciones
using System.ComponentModel.DataAnnotations;

namespace FormValidationsPractice.Models
{
    public class User
    {
        // [Required(ErrorMessage = "Name is required")]
        // [MinLength(3, ErrorMessage = "El largo minimo para el nombre es de 4 caracteres")]
        [NameIsEmpty]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        public string Email { get; set; }
        [FutureDate]
        public DateTime Date { get; set; }
    }

    public class NameIsEmptyAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string name)
            {
                // Evalúa si el largo es menor a 3
                if (name.Length < 3)
                {

                    return new ValidationResult("El nombre debe ser tener un largo mínimo de 3 caracteres");
                }
            }
            return ValidationResult.Success;

        }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Evalúa si el valor pasado es una fecha lo asigna a la variable date
            if (value is DateTime date)
            {
                if (date > DateTime.Now)
                {
                    // Retorna una nuevalidación personalizada
                    return new ValidationResult("La fecha es superior a la fecha de hoy");
                }
            }
            return ValidationResult.Success;
        }
    }

}