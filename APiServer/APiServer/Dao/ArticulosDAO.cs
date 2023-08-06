using APiServer.Logic;
using APiServer.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace APiServer.Dao
{
    public class ArticulosDAO
    {

        dbConecxion conecta = new dbConecxion();
        public List<Articulo> lista()
        {
            List<Articulo> lis = new List<Articulo>();

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conecta.CadenaConecxionSQL());
            SqlCommand cmd = new SqlCommand("SELECT * FROM Articulos", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                string? v = dr["imagen"].ToString();
                string encodedStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(v));
                //string inputStr = Encoding.UTF8.GetString(Convert.FromBase64String(v));

                lis.Add(new Articulo
                {
                    ArticuloId = Convert.ToInt32(dr["ArticuloId"].ToString()),
                    Codigo = dr["Codigo"].ToString(),
                    Descripcion = dr["Descripcion"].ToString(),
                    Precio = Convert.ToDecimal(dr["Precio"].ToString()),
                    Stock = Convert.ToDecimal(dr["Stock"].ToString()),
                    imagen = Convert.ToBase64String(Encoding.UTF8.GetBytes(v))



            }); 



            }
            return lis;
        }


        public Articulo addPost(Articulo Art)
        {
            Articulo product = new Articulo();

            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("PostArticulo", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@Codigo",Art.Codigo));
            cmd1.Parameters.Add(new SqlParameter("@Descripcion", Art.Descripcion));
            cmd1.Parameters.Add(new SqlParameter("@Precio", Art.Precio));
            cmd1.Parameters.Add(new SqlParameter("@Stock", Art.Stock));
           // cmd1.Parameters.Add(new SqlParameter("@imagen", Art.imagen));



            //Open the Connection

            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {
                product.ArticuloId = i;
                // Console.WriteLine("Records Inserted Successfully.");
            }

            return product;
        }

        public Articulo UpdatePut(Articulo Art)
        {
            Articulo product = new Articulo();

            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("UpdatePutArticulo", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ArticuloId", Art.ArticuloId));        
            cmd1.Parameters.Add(new SqlParameter("@Codigo", Art.Codigo));
            cmd1.Parameters.Add(new SqlParameter("@Descripcion", Art.Descripcion));
            cmd1.Parameters.Add(new SqlParameter("@Precio", Art.Precio));
            cmd1.Parameters.Add(new SqlParameter("@Stock", Art.Stock));
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.ArticuloId = Convert.ToInt32(dr[0].ToString());
                product.Descripcion = dr[1].ToString();


            }


            return product;
        }


        public Articulo DeleteArticulo(int ArticuloId)
        {
            Articulo product = new Articulo();
            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("DeleteArticulo", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ArticuloID", ArticuloId));

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.ArticuloId = Convert.ToInt32(dr[0].ToString());
                //product.Nombre = dr[1].ToString();

            }


            return product;
        }

        public Articulo GetArticulo(int articuloId)
        {
            Articulo product = new Articulo();
            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("GetArticulo", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ArticuloID", articuloId));

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.ArticuloId = Convert.ToInt32(dr[0].ToString());
                product.Codigo =dr[1].ToString();
                product.Descripcion = dr[2].ToString();
                //product.Nombre = dr[1].ToString();
                product.Precio = Convert.ToDecimal(dr["Precio"].ToString());
                product.Stock = Convert.ToDecimal(dr["Stock"].ToString());



            }


            return product;
        }
    }
}
