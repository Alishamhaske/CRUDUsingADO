using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{

    /// <summary>
    /// not  properly  run
    /// </summary>
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public ProductDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }

        //getcategories
        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            string qry = "select * from Category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                while (dr.Read())
                {
                    Category c = new Category();
                    c.Cid = Convert.ToInt32(dr["cid"]);
                    c.Cname = dr["cname"].ToString();
                    categories.Add(c);
                }
            }
            con.Close();
            return categories;
        }


        ////GetProducts
        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
          
            string qry = "select  p.*,c.cname from Product p inner join Category c on c.cid=p.cid where p.isActive=1";
         
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
           
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();

                    
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["name"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                   
                    p.ImageUrl = dr["imageurl"].ToString();
                  

                    p.IsActive = Convert.ToInt32(dr["isActive"]);
                    p.Cid = Convert.ToInt32(dr["cid"]);
                    p.Cname = Convert.ToString(dr["cname"]);
                    products.Add(p);
                }
            }
            con.Close();
            return products;
        }


        //GetProductById
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string qry = "select p.*,c.cname from Product p inner join Category c on c.cid=p.cid where p.id=@id and p.isActive=1";

            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["name"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                   
                    p.ImageUrl = dr["imageurl"].ToString();
                    
                    p.IsActive = Convert.ToInt32(dr["isActive"]);
                    p.Cid = Convert.ToInt32(dr["cid"]);
                    p.Cname = dr["cname"].ToString();


                }
            }
            con.Close();
            return p;
        }

        //Add product
        public int AddProduct(Product p)
        {
            p.IsActive = 1;
            int result = 0;
            string qry = "insert into Product values(@name,@price,@cid,@imageurl,@isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@price", p.Price);
  
            cmd.Parameters.AddWithValue("@cid", p.Cid);
            cmd.Parameters.AddWithValue("@imageurl", p.ImageUrl);
            cmd.Parameters.AddWithValue("@isActive", p.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
         

        //update product
        public int UpdateProduct(Product p)
        {
            p.IsActive = 1;
            int result = 0;
            string qry = "update Product set name=@name,price=@price,cid=@cid,imageurl=@imageurl where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@price", p.Price);
            
            cmd.Parameters.AddWithValue("@cid", p.Cid);
            cmd.Parameters.AddWithValue("@imageurl", p.ImageUrl);
            cmd.Parameters.AddWithValue("@id", p.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        //delete product soft delete
        public int DeleteProduct(int id)
        {

            int result = 0;
            string qry = "update Product set isActive=0 where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
