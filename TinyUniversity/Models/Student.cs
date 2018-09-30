using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TinyUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string Fullname
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }

        //Navigation properties (Relationships)
        public ICollection<Enrollment> Enrollments { get; set; } //A Student has many Enrollments
    }
}
