using APiServer.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace APiServer.Dao
{
    public class ProductosDao
    {
        private readonly IConfiguration _configuration;

        public ProductosDao(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public ProductosDao()
        {
        }

        private string conecxion;
        
        public  List<Producto> lista()
        {
            List<Producto> lis = new List<Producto>();

            conecxion = "Server=tcp:serverdemoazuresql.database.windows.net,1433;Initial Catalog=DemoAzure;Persist Security Info=False;User ID=sqlserver01;Password=Demo$SQL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

           /// conecxion ="Data Source=HYBOOK-PLUS\\SQLEXPRESS;Initial Catalog=Tienda;Integrated Security=True";
            // conecxion = _configuration.GetConnectionString("MyDbConnection");
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conecxion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM producto", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lis.Add(new Producto
                {
                    ProductoId = Convert.ToInt32(dr["ProductoId"].ToString()),
                    Producto_Desc = dr["Producto_Desc"].ToString(),
                    Producto_Precio = Convert.ToDecimal(dr["Producto_Precio_Venta"].ToString())
                });



            }
            return  lis;
        }


        public Producto addPost(Producto prod )
        {
            Producto product = new Producto();
            conecxion = "Server=tcp:serverdemoazuresql.database.windows.net,1433;Initial Catalog=DemoAzure;Persist Security Info=False;User ID=sqlserver01;Password=Demo$SQL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            //conecxion = "Data Source=HYBOOK-PLUS\\SQLEXPRESS;Initial Catalog=Tienda;Integrated Security=True";
            // conecxion = _configuration.GetConnectionString("MyDbConnection");
            SqlConnection connection = new SqlConnection(conecxion);
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("PostProducto", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@descripcion", prod.Producto_Desc));
            cmd1.Parameters.Add(new SqlParameter("@PrecioUni", prod.Producto_Precio_unitario));
            cmd1.Parameters.Add(new SqlParameter("@PrecioVenta",prod.Producto_Precio_Venta));
            cmd1.Parameters.Add(new SqlParameter("@Iva", prod.Producto_Iva));

                
                //Open the Connection
                
                int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {
                product.ProductoId = i;
               // Console.WriteLine("Records Inserted Successfully.");
            }
            
            return product;
        }

        public Producto UpdatePut(Producto prod)
        {
            Producto product = new Producto();

            conecxion = "Server=tcp:serverdemoazuresql.database.windows.net,1433;Initial Catalog=DemoAzure;Persist Security Info=False;User ID=sqlserver01;Password=Demo$SQL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            ///conecxion = "Data Source=HYBOOK-PLUS\\SQLEXPRESS;Initial Catalog=Tienda;Integrated Security=True";
            // conecxion = _configuration.GetConnectionString("MyDbConnection");
            SqlConnection connection = new SqlConnection(conecxion);
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("PutProducto", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ProductoId", prod.ProductoId));
            cmd1.Parameters.Add(new SqlParameter("@descripcion", prod.Producto_Desc));
            cmd1.Parameters.Add(new SqlParameter("@PrecioUni", prod.Producto_Precio_unitario));
            cmd1.Parameters.Add(new SqlParameter("@PrecioVenta", prod.Producto_Precio_Venta));
            cmd1.Parameters.Add(new SqlParameter("@Iva", prod.Producto_Iva));
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.ProductoId=Convert.ToInt32( dr[0].ToString());
                product.Producto_Desc= dr[1].ToString();
               
            }

           
            return product;
        }


        public Producto DeleteProducto(int ProductoId)
        {
            Producto product = new Producto();
            conecxion = "Server=tcp:serverdemoazuresql.database.windows.net,1433;Initial Catalog=DemoAzure;Persist Security Info=False;User ID=sqlserver01;Password=Demo$SQL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            // conecxion = "Data Source=HYBOOK-PLUS\\SQLEXPRESS;Initial Catalog=Tienda;Integrated Security=True";
            // conecxion = _configuration.GetConnectionString("MyDbConnection");
            SqlConnection connection = new SqlConnection(conecxion);
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("DeleteProducto", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ProductoId", ProductoId));
         
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.ProductoId = Convert.ToInt32(dr[0].ToString());
                product.Producto_Desc = dr[1].ToString();

            }


            return product;
        }
    }
}
