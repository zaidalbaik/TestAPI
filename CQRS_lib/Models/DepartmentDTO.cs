using System.ComponentModel.DataAnnotations;

namespace CQRS_lib.Models
{
    public class DepartmentDTO
    { 
        public int Id { get; set; }
         
        public string? Name { get; set; }
    }
}
