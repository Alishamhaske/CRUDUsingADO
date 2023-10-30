using System.Data.SqlClient;
namespace CRUDUsingADO.Models
{
    
        public class CourseDAL
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            IConfiguration configuration;
            public CourseDAL(IConfiguration configuration)
            {
                this.configuration = configuration;
                con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
            }


            public List<Course> GetCourses()
            {
                List<Course> courses = new List<Course>();
                string qry = "select * from Course";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                    Course course = new Course();
                    course.Id = Convert.ToInt32(dr["id"]);
                    course.Name = dr["name"].ToString();
                    course.Duration = Convert.ToInt32(dr["duration"]);
                        course.Fee = Convert.ToInt32(dr["fee"]);


                        courses.Add(course);
                    }
                }
                con.Close();
                return courses;
            }
            public Course GetCourseById(int id)
            {
                Course course = new Course();
                string qry = "select * from Course where id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        course.Id = Convert.ToInt32(dr["id"]);
                    course.Name = dr["name"].ToString();
                    course.Duration = Convert.ToInt32(dr["duration"]);
                    course.Fee = Convert.ToInt32(dr["fee"]);


                    }
                }
                con.Close();
                return course;
            }
            //add book
            public int AddCourse(Course course)
            {
                int result = 0;
                string qry = "insert into Course values(@name,@duration,@fee)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", course.Name);
                cmd.Parameters.AddWithValue("@duration", course.Duration);
                cmd.Parameters.AddWithValue("@fee", course.Fee);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }

            //update book
            public int UpdateCourse(Course course)
            {
                int result = 0;
                string qry = "update Course set name=@name,duration=@duration,fee=@fee where id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", course.Name);
                cmd.Parameters.AddWithValue("@duration", course.Duration);
                cmd.Parameters.AddWithValue("@fee", course.Fee);
                cmd.Parameters.AddWithValue("@id", course.Id);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }

            //delete book
            public int DeleteCourse(int id)
            {
                int result = 0;
                string qry = "delete from Course where id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }

        }

    
}
