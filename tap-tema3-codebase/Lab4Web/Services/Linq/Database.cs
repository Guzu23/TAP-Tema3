namespace Lab4Web.Services.Linq
{
    public static class Database
    {
        public static List<Student> Students = new List<Student>
        {
            new Student("Name1", 21, DateTime.Now, 3, "M531", "Img1"),
            new Student("Name2", 22, DateTime.Now, 3, "M532", "Img2"),
            new Student("Name3", 23, DateTime.Now, 3, "M533", "Img3"),
            new Student("Name4", 24, DateTime.Now, 3, "M533", "Img4"),
            new Student("Name5", 25, DateTime.Now, 2, "M521", "Img5"),
            new Student("Name6", 26, DateTime.Now, 2, "M522", "Img6"),
            new Student("Name7", 27, DateTime.Now, 2, "M523", "Img7"),
            new Student("Name8", 28, DateTime.Now, 2, "M532", "Img8"),
            new Student("Name9", 29, DateTime.Now, 1, "M111", "Img9"),
            new Student("Name10", 30, DateTime.Now, 1, "M114", "Img10"),
            new Student("Name11", 31, DateTime.Now, 1, "M116", "Img11")
        
        };

    public static void addStudent(Student student)
        {
            if (Students.Contains(student))
            {
                Console.WriteLine("The student already exists");
            }
            else
            {
                Students.Add(student);
                Console.WriteLine("Student added!");
            }
        }
        public static void removeVisitor(Guid studentId)
        {
            var student = Students.SingleOrDefault(x => x.Id == studentId);
            if (student != null)
            {
                student.SetActive(false);
                Console.WriteLine("Student is deactivated!");
            }
        }




    }
}
