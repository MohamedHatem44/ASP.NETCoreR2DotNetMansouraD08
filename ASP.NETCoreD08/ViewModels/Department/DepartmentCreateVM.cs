using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreD08.ViewModels.Department
{
    public class DepartmentCreateVM
    {
        /*------------------------------------------------------------------*/
        [Display(Name = "Department Name")]
        public required string Name { get; set; }
        /*------------------------------------------------------------------*/
    }
}
