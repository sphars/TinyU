using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyUniversity.Models;

namespace TinyUniversity.Data
{
    public class DBInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Student.Any())
            {
                return; // DB has been seeded
            }
            var students = new Student[]
            {
                new Student{Firstname="Chase",Lastname="Greenwood",EnrollmentDate=DateTime.Parse("2015-09-01")},
                new Student{Firstname="Spencer",Lastname="Harston",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{Firstname="Mark",Lastname="Haslam",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{Firstname="Dongmin",Lastname="Kim",EnrollmentDate=DateTime.Parse("2015-09-01")},
                new Student{Firstname="Dewey",Lastname="Lakey",EnrollmentDate=DateTime.Parse("2015-09-01")},
                new Student{Firstname="Nicholas",Lastname="Lambert",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{Firstname="Amy",Lastname="Lea",EnrollmentDate=DateTime.Parse("2015-09-01")},
                new Student{Firstname="Andrew",Lastname="Merrell",EnrollmentDate=DateTime.Parse("2015-09-01")},
                new Student{Firstname="Belete",Lastname="Nigusie",EnrollmentDate=DateTime.Parse("2015-09-01")},
                new Student{Firstname="Johnathan",Lastname="Warnes",EnrollmentDate=DateTime.Parse("2015-09-01")}
            };
            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { Firstname = "Richard",     Lastname = "Fry",
                    HireDate = DateTime.Parse("2001-03-11") },
                new Instructor { Firstname = "Brian",    Lastname = "Rague",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { Firstname = "Spencer",   Lastname = "Hilton",
                    HireDate = DateTime.Parse("2008-07-01") },
                new Instructor { Firstname = "Drew", Lastname = "Weidman",
                    HireDate = DateTime.Parse("2011-01-15") },
                new Instructor { Firstname = "Linda",   Lastname = "DuHadaway",
                    HireDate = DateTime.Parse("2014-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructor.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Computer Science",     Budget = 350000,
                    StartDate = DateTime.Parse("2017-09-01"),
                    InstructorID  = instructors.Single( i => i.Lastname == "Fry").ID },
                new Department { Name = "Web UX", Budget = 100000,
                    StartDate = DateTime.Parse("2017-09-01"),
                    InstructorID  = instructors.Single( i => i.Lastname == "Hilton").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2017-09-01"),
                    InstructorID  = instructors.Single( i => i.Lastname == "Rague").ID },
                new Department { Name = "Networking",   Budget = 100000,
                    StartDate = DateTime.Parse("2017-09-01"),
                    InstructorID  = instructors.Single( i => i.Lastname == "DuHadaway").ID }
            };

            foreach (Department d in departments)
            {
                context.Department.Add(d);
            }
            context.SaveChanges();


            var courses = new Course[]
            {
                new Course {ID = 1030, Title = "Intro to Engineering",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {ID = 4200, Title = "Wireless Security", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Networking").DepartmentID
                },
                new Course {ID = 4800, Title = "Independent Project", Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Computer Science").DepartmentID
                },
                new Course {ID = 2500, Title = "The User Experience",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Web UX").DepartmentID
                },
                new Course {ID = 3100, Title = "Operating Systems",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Computer Science").DepartmentID
                },
                new Course {ID = 2705, Title = "Local Area Networks",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Networking").DepartmentID
                },
                new Course {ID = 1430, Title = "JavaScript",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Web UX").DepartmentID
                },
            };

            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.Lastname == "Fry").ID,
                    Location = "EH 383" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.Lastname == "Hilton").ID,
                    Location = "TE 273" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.Lastname == "DuHadaway").ID,
                    Location = "TE 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignment.Add(o);
            }
            context.SaveChanges();


            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "JavaScript" ).ID,
                    InstructorID = instructors.Single(i => i.Lastname == "Fry").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "JavaScript" ).ID,
                    InstructorID = instructors.Single(i => i.Lastname == "Hilton").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Local Area Networks" ).ID,
                    InstructorID = instructors.Single(i => i.Lastname == "Rague").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "The User Experience" ).ID,
                    InstructorID = instructors.Single(i => i.Lastname == "DuHadaway").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Operating Systems" ).ID,
                    InstructorID = instructors.Single(i => i.Lastname == "Fry").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Intro to Engineering" ).ID,
                    InstructorID = instructors.Single(i => i.Lastname == "Hilton").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Wireless Security" ).ID,
                    InstructorID = instructors.Single(i => i.Lastname == "Weidman").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Intro to Engineering" ).ID,
                    InstructorID = instructors.Single(i => i.Lastname == "Rague").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignment.Add(ci);
            }
            context.SaveChanges();



            var enrollments = new Enrollment[]
             {
                new Enrollment {
                    StudentID = students.Single(s => s.Lastname == "Greenwood").ID,
                    CourseID = courses.Single(c => c.Title == "Intro to Engineering" ).ID,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.Lastname == "Warnes").ID,
                    CourseID = courses.Single(c => c.Title == "Operating Systems" ).ID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Lastname == "Lakey").ID,
                    CourseID = courses.Single(c => c.Title == "The User Experience" ).ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.Lastname == "Lea").ID,
                    CourseID = courses.Single(c => c.Title == "The User Experience" ).ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.Lastname == "Kim").ID,
                    CourseID = courses.Single(c => c.Title == "Wireless Security" ).ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Lastname == "Harston").ID,
                    CourseID = courses.Single(c => c.Title == "Operating Systems" ).ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Lastname == "Merrell").ID,
                    CourseID = courses.Single(c => c.Title == "Independent Project" ).ID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Lastname == "Lambert").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript").ID,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.Lastname == "Haslam").ID,
                    CourseID = courses.Single(c => c.Title == "Local Area Networks").ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Lastname == "Lea").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript").ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Lastname == "Greenwood").ID,
                    CourseID = courses.Single(c => c.Title == "Independent Project").ID,
                    Grade = Grade.B
                    }
             };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollment.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.ID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollment.Add(e);
                }
            }
            context.SaveChanges();

        }

    }
}
