using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class D_Categoria
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        public List<E_Categoria> ListCategoria(string buscar)
        {
            SqlDataReader LectorFilas;
            SqlCommand cmd = new SqlCommand("Stored_BuscarCategorias", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", buscar);
            LectorFilas = cmd.ExecuteReader();

            List<E_Categoria> Listar = new List<E_Categoria>();
            while (LectorFilas.Read())
            {
                Listar.Add(new E_Categoria
                {
                    IdCategoria = LectorFilas.GetInt32(0),
                    CodigoCategoria = LectorFilas.GetString(1),
                    Nombre = LectorFilas.GetString(2),
                    Descripcion = LectorFilas.GetString(3),
                }) ;
            }
            conexion.Close();
            LectorFilas.Close();

            return Listar;
        } 
        public void InsertarCat(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("Stored_InsertarCategoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion",categoria.Descripcion);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void EditarCat(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("Stored_editCategoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idCateogira", categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void EliminarCat(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("Stored_EliminarCategoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);
        

            cmd.ExecuteNonQuery();
            conexion.Close();

        }

    }
}
