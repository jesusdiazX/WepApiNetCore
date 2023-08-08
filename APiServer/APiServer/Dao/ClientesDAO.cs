using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using APiServer.Models;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APiServer.Dao
{
    public class ClientesDAO
    {

        dbConecxion conecta= new dbConecxion();
        public List<Clientes> lista()
        {
            List<Clientes> lis = new List<Clientes>();

          // string conecxion = "Server=tcp:serverdemoazuresql.database.windows.net,1433;Initial Catalog=DemoAzure;Persist Security Info=False;User ID=sqlserver01;Password=Demo$SQL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            /// conecxion ="Data Source=HYBOOK-PLUS\\SQLEXPRESS;Initial Catalog=Tienda;Integrated Security=True";
            // conecxion = _configuration.GetConnectionString("MyDbConnection");
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conecta.CadenaConecxionSQL());
            SqlCommand cmd = new SqlCommand("SELECT * FROM clientes", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lis.Add(new Clientes
                {
                    ClienteId = Convert.ToInt32(dr["ClienteId"].ToString()),
                    Nombre = dr["Nombre"].ToString(),
                    Apellidos = dr["Apellidos"].ToString(),
                    Direccion= dr["Direccion"].ToString()
                });



            }
            return lis;
        }

        public Clientes GetClientes(int ClienteId)
        {
            Clientes product = new Clientes();

            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("GetClientes", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ClienteId", ClienteId));
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                    product.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                product.Nombre = dr["Nombre"].ToString();
                product.Apellidos = dr["Apellidos"].ToString();
                product.Direccion = dr["Direccion"].ToString();

            }


        
            return product;
        }

        public Clientes addPost(Clientes cl)
        {
            Clientes product = new Clientes();
           
            //conecxion = "Data Source=HYBOOK-PLUS\\SQLEXPRESS;Initial Catalog=Tienda;Integrated Security=True";
            // conecxion = _configuration.GetConnectionString("MyDbConnection");
            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("PostClientes", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@Nombre", cl.Nombre));
            cmd1.Parameters.Add(new SqlParameter("@Apellidos",cl.Apellidos));
            cmd1.Parameters.Add(new SqlParameter("@Direccion", cl.Direccion));
        


            //Open the Connection

            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {
                product.ClienteId = i;
                // Console.WriteLine("Records Inserted Successfully.");
            }

            return product;
        }

        public Clientes UpdatePut(Clientes cl)
        {
            Clientes product = new Clientes();

            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("UpdatePutCliente", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ClienteId", cl.ClienteId));
            cmd1.Parameters.Add(new SqlParameter("@Nombre", cl.Nombre));
            cmd1.Parameters.Add(new SqlParameter("@Apellidos", cl.Apellidos));
            cmd1.Parameters.Add(new SqlParameter("@Direccion", cl.Direccion));
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.ClienteId = Convert.ToInt32(dr[0].ToString());
                product.Nombre = dr[1].ToString();

            }


            return product;
        }


        public Clientes DeleteProducto(int ClienteId)
        {
            Clientes product = new Clientes();
            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("DeleteProducto", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ClienteId", ClienteId));

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.ClienteId = Convert.ToInt32(dr[0].ToString());
                //product.Nombre = dr[1].ToString();

            }


            return product;
        }



        public Clientes login(string user,string password)
        {
            Clientes product = new Clientes();
            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("getUser", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@user", user));
            cmd1.Parameters.Add(new SqlParameter("@pwd", password));

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                product.Nombre = dr["Nombre"].ToString();
                product.Apellidos = dr["Apellidos"].ToString();
                product.Direccion = dr["Direccion"].ToString();

            }


            return product;
        }

         public List<ClienteArticulo> RelacionCliente()
        {
            List<ClienteArticulo> lis = new List<ClienteArticulo>();

            // string conecxion = "Server=tcp:serverdemoazuresql.database.windows.net,1433;Initial Catalog=DemoAzure;Persist Security Info=False;User ID=sqlserver01;Password=Demo$SQL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string sql = "select ArtClienteId,Nombre,Apellidos,Codigo,Descripcion from [dbo].[ArticulosClientes] ac\r\ninner join Clientes c on c.ClienteId=ac.ClienteId\r\ninner join Articulos a on a.ArticuloId=ac.ArticuloId";
            /// conecxion ="Data Source=HYBOOK-PLUS\\SQLEXPRESS;Initial Catalog=Tienda;Integrated Security=True";
            // conecxion = _configuration.GetConnectionString("MyDbConnection");
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conecta.CadenaConecxionSQL());
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lis.Add(new ClienteArticulo
                {
                    ArtClienteId = Convert.ToInt32(dr["ArtClienteId"].ToString()),
                    Nombre = dr["Nombre"].ToString(),
                    Apellidos = dr["Apellidos"].ToString(),
                    Descripcion= dr["Descripcion"].ToString()
                });



            }
            return lis;
        }


    }
}
