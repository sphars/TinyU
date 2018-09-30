using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyUniversity.Models
{
    public class CourseAssignment
    {
        public int ID { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        //Navigation (relationships)
        public Instructor Instructor { get; set; } //each course assignment has an instructor and a course
        public Course Course { get; set; }
    }
}