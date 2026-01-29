using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class GreaterThanAttribute:ValidationAttribute
    {
        public int CompareValue { get; set; }
        public GreaterThanAttribute(int val)
        {
            CompareValue = val;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int Salary = int.Parse(value.ToString());
            if (Salary > CompareValue)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"Salary Must be Greater Than {CompareValue}");
        }
    }
}
