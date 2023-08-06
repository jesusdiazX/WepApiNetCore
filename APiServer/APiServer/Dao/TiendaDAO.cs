using APiServer.Logic;
using APiServer.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace APiServer.Dao
{
    public class TiendaDAO
    {

        dbConecxion conecta = new dbConecxion();
        public List<Tienda> lista()
        {
            List<Tienda> lis = new List<Tienda>();

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conecta.CadenaConecxionSQL());
            SqlCommand cmd = new SqlCommand("SELECT * FROM tienda", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
              

                lis.Add(new Tienda
                {
                    TiendaId = Convert.ToInt32(dr["TiendaId"].ToString()),
                    Sucursal = dr["Sucrsal"].ToString(),
                    Direccion = dr["Direccion"].ToString(),
                   



            }); 



            }
            return lis;
        }


        public Tienda addPost(Tienda Art)
        {
            Tienda product = new Tienda();

            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("PostTienda", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@tiendaid",Art.TiendaId));
            cmd1.Parameters.Add(new SqlParameter("@sucursal", Art.Sucursal));
            cmd1.Parameters.Add(new SqlParameter("@direccion", Art.Direccion));
         


            //Open the Connection

            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {
                product.TiendaId = i;
                // Console.WriteLine("Records Inserted Successfully.");
            }

            return product;
        }

        public Tienda UpdatePut(Tienda Art)
        {
            Tienda product = new Tienda();

            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("UpdatePutTienda", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            
            cmd1.Parameters.Add(new SqlParameter("@tiendaid", Art.TiendaId));
            cmd1.Parameters.Add(new SqlParameter("@sucursal", Art.Sucursal));
            cmd1.Parameters.Add(new SqlParameter("@direccion", Art.Direccion));
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.TiendaId = Convert.ToInt32(dr[0].ToString());
                product.Direccion = dr[1].ToString();


            }


            return product;
        }


        public Tienda DeleteArticulo(int ArticuloId)
        {
            Tienda product = new Tienda();
            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("DeleteTienda", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@TiendaID", ArticuloId));

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.TiendaId = Convert.ToInt32(dr[0].ToString());
                //product.Nombre = dr[1].ToString();

            }


            return product;
        }

        public Tienda GetArticulo(int articuloId)
        {
            Tienda product = new Tienda();
            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("Gettienda", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@Tiendaid", articuloId));

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                product.TiendaId = Convert.ToInt32(dr["TiendaId"].ToString());
                    product.Sucursal = dr["Sucrsal"].ToString();
                     product.Direccion = dr["Direccion"].ToString();
                   



            }


            return product;
        }
    }
}
