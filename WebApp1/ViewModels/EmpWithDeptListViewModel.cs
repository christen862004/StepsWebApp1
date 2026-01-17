using WebApp1.Models;

namespace WebApp1.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public List<Department> DeptList { get; set; }
        //----------------------Employee 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string? ImageURl { get; set; }

        public int DepartmentId { get; set; }
    }
}
