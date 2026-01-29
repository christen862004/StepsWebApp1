using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class UniqueAttribute:ValidationAttribute //can't work in Client Side  (only Server Side)
    {
        StepsContext context = new StepsContext();//????

        public UniqueAttribute()
        {        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Employee? empFRomREquest= validationContext.ObjectInstance as Employee;

            //ask 
            string name = value.ToString();
            Employee? empFRomDb= context.Employees
                .FirstOrDefault(e => e.Name == name && e.DepartmentId == empFRomREquest.DepartmentId);
            if(empFRomDb == null) {
                return ValidationResult.Success;
            }

            return new ValidationResult("Name Already Found :)");//
        }
    }
}
