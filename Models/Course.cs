
namespace InfoTech.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Course()
        {
        }

        public Course(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
