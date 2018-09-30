using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TinyUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int ID { get; set; }
        public int StudentID { get; set; } //FK
        public int CourseID { get; set; } //FK
        public Grade? Grade { get; set; }

        //Navigation properties (relationships)
        public Student Student { get; set; } //Each Enrollment has a Student and Course
        public Course Course { get; set; }

    }
}
