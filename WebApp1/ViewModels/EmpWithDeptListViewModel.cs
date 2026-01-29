using System.ComponentModel.DataAnnotations;
using WebApp1.Models;

namespace WebApp1.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public List<Department>? DeptList { get; set; }
        //----------------------Employee 
        public int Id { get; set; }

        //something determine input type
        //[DataType(DataType.Password)]
        public string Name { get; set; }//prorepty type determin input ytpe (string text) | (int : number)|(bool :check)
        
        public int Salary { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name="Profile Image")]
        public string? ImageURl { get; set; }

        public int DepartmentId { get; set; }
    }
}
