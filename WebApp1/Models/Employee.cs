using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    public class Employee
    {
        public int Id { get; set; }

       // [Required] by default put this attribute
        [MaxLength(25)]
        [MinLength(3,ErrorMessage ="Name Must Be More Than 3 character")]
        [Unique]
        public string Name { get; set; }

        // [Range(8000,50000,ErrorMessage ="Salary must between 8000 : 50000")]
        //[GreaterThan(8000)]
        [Remote("CheckSalary","Employee",AdditionalFields ="Name")]
        public int Salary { get; set; }

        //^[a-z]\w{3,10}@(yahoo|gmail|outlook)\.com$ email
        [RegularExpression(@"^\w+\.(jpg|png)$",ErrorMessage ="Image Must be png or jpg")]
        public string? ImageURl { get; set; }//jpg |png (Pattern) shdgashd.jpg |shdgashd.png 

        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        
        //[Required]
        public Department? Department { get; set; }
    }
}
