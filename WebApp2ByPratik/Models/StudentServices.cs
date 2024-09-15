namespace WebApp2ByPratik.Models
{
    public class StudentServices : IStudentServices
    {
        public string GetStudentName()
        {
            string Name = "Pratik Shah \nRoll_No: 64/077 \nWebApp2ByPratik ";
            return Name;
        }

        public List<Student> GetStudentList()
        { 
            List<Student> StudentList = new List<Student>();
            StudentList.Add(new Student { ID = 1, Name = "Pratik" });
            StudentList.Add(new Student { ID = 2, Name = "David" });
            return StudentList;
        }
    }
}
