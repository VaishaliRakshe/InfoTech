namespace InfoTech.Models
{
    public class Teacher
    {
         
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Teacher()
        {
        }

        public Teacher(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}

