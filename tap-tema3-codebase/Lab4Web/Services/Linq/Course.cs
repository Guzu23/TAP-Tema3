namespace Lab4Web.Services.Linq
{
    public class Course
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public Course(string Name, int Credits)
        {
            Random rnd = new Random();
            int count = Database.Students.Count;
            int random = rnd.Next(0, count);
            this.StudentId = Database.Students[random].Id;
            this.Name = Name;
            this.Credits = Credits;
        }
    }
}
