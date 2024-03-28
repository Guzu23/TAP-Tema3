namespace Lab4Web.Services.Linq
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Year { get; set; }
        public bool Active { get; set; }
        public string ImageProfile { get; set; }
        public Student(string name, int age, DateTime BirthDate, int Year, string Group, string ImageProfile)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Age = age;
            this.BirthDate = BirthDate;
            this.Year = Year;
            this.Group = Group;
            this.ImageProfile = ImageProfile;
            this.Active = true;
        }

        public void SetActive(bool active)
        {
            this.Active = active;
        }


    }
}
