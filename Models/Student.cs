namespace InfoTech.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Teacher Teacher { get; set; }

        public int TeacherId { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }

        public Student()
        {
        }

        public Student(string name)
        {
            Name = name;
        }
    }
}
