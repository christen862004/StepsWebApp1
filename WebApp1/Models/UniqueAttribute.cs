using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class UniqueAttribute:ValidationAttribute //can't work in Client Side  (only Server Side)
    {
        StepsContext context;//= new StepsContext();//???? cant r

        public UniqueAttribute()
        { }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            context = validationContext.GetRequiredService<StepsContext>();
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
