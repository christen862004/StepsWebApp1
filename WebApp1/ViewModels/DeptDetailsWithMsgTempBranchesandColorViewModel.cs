using Microsoft.CodeAnalysis.Operations;
using WebApp1.Models;

namespace WebApp1.ViewModels
{
    public class DeptDetailsWithMsgTempBranchesandColorViewModel
    {
        //Send Some Model Inof | Hide Structre
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        //Add Some Extra inof
        public string Color { get; set; }
        public int Temp { get; set; }
        public string Message { get; set; }

        //Merage
        public List<string> Branches { get; set; }
    }
    class EmpWithDDeptDEtailsVM
    {
        public int EmpID { get; set; }
        public int DeptID { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
    }
}
