using System.ComponentModel.DataAnnotations;

namespace WebApp1ByPratik.Models
{
    public class Student
    {
        [Range(1, 1000, ErrorMessage = "ID must be between 1 and 1000")]
        public int StdID { get; set; }

        [Required(ErrorMessage = "Name is required")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]

        public string Address { get; set; }

        [Required(ErrorMessage = "Faculty is required")]

        public string Faculty { get; set; }
    }
}
