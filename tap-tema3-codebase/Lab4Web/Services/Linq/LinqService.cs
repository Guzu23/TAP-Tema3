namespace Lab4Web.Services.Linq
{
    

    public class LinqService : ILinqService
    {
        public int Test1(int value)
        {
            //Query-expression
            //var query = from student in stUdents
            //            where student.Age >= value
            //                select student;

            //return query.Count();

            //Method-expression 
            return Database.Students.Count(student => student.Age >= value);
        }
    }
}
