using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class UsersDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public UsersDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }

        public int Register(Users users)
        {
            string qry = "insert into Users values(@username,@email,@password)";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@username", users.UserName);
            cmd.Parameters.AddWithValue("@email", users.Email);
            cmd.Parameters.AddWithValue("@password", users.Password);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            return result;

        }

        public int Login(Users users)
        {
            string qry = "select * from Users where username=@username and  password=@password";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@username", users.UserName);
            cmd.Parameters.AddWithValue("@password", users.Password);
            con.Open();
            dr=cmd.ExecuteReader();
            bool result = dr.HasRows;
            con.Close();
            if(result)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

}
