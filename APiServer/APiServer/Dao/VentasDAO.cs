using APiServer.Models;
using System.Data;
using System.Data.SqlClient;

namespace APiServer.Dao
{
    public class VentasDAO
    {


        dbConecxion conecta = new dbConecxion();
        public Ventas addPost(Ventas Art)
        {
            Ventas product = new Ventas();

            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("InsertPostVenta", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ClienteId", Art.clienteId));
            cmd1.Parameters.Add(new SqlParameter("@ArticuloId", Art.articuloId));
            cmd1.Parameters.Add(new SqlParameter("@FEcha", Art.fecha));
        



            //Open the Connection

            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {
                product.clienteId = i;
                // Console.WriteLine("Records Inserted Successfully.");
            }

            return product;
        }

    }
}
