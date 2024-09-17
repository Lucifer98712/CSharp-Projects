using Microsoft.Data.SqlClient;
using WebApp3ByPratik.Models;


namespace WebApp3ByPratik.Repository
{
    public class StudentRepo
    {
        String conStr = @"server=PEACE; database=nccLabPratik; trustServerCertificate=true; integrated security=sspi";

        public IEnumerable<Student> GetAllRecords()
        {
            List<Student> listOfStudents = new List<Student>();
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            String selectQuery = " SELECT * FROM student";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Student std = new Student();
                std.id = Convert.ToInt32(rdr["id"]);
                std.name = Convert.ToString(rdr["name"]);
                std.stream = Convert.ToString(rdr["stream"]);
                listOfStudents.Add(std);
            }
            return listOfStudents;
        }

        public void InsertRecord(Student std)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string insertQuery = $"INSERT INTO student VALUES(" + $"'{std.id}', '{std.name}', '{std.stream}')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Student ViewRecord(int sid)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                String viewQuery = " SELECT * FROM student WHERE id = " +
                    $"+{sid}";
                SqlCommand cmd = new SqlCommand(viewQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                Student std = new Student();
                while (rdr.Read())
                {

                    std.id = Convert.ToInt32(rdr["id"]);
                    std.name = Convert.ToString(rdr["name"]);
                    std.stream = Convert.ToString(rdr["stream"]);

                }
                return std;
            }
        }

    }
}
