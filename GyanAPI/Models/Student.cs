using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GyanAPI.Models
{
    public class Student
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pls Enter Your Name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pls Enter Your Gender!")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Pls Enter Your Address!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Pls Enter Your Course Name!")]
        public string Course { get; set; }
        [Required(ErrorMessage = "Pls Enter Your City!")]
        public string City { get; set; }
        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }
        public string Subject { get; set; }
        public Country CountryName { get; set; }
    }
}
