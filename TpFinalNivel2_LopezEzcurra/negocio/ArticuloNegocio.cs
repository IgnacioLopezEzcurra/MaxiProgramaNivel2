using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar() {

            List <Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB;integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Codigo, Nombre, A.Descripcion, ImagenUrl, C.Descripcion Categoria, M.Descripcion Marca\r\nfrom ARTICULOS A, CATEGORIAS C, MARCAS M\r\nwhere C.Id = A.IdCategoria AND A.IdMarca = M.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    /* if (!(lector.IsDBNull(lector.GetOrdinal("ImagenUrl")))){ 

                     aux.UrlImagen = (string)lector["ImagenUrl"];
                     }*/

                    if (!(lector["ImagenUrl"] is DBNull))           //la opcion mas practica
                        aux.UrlImagen = (string)lector["ImagenUrl"];


                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)lector["Categoria"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)lector["Marca"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        
        }

        public void agregar(Articulo nuevo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria) values ('"+ nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', @idMarca, @idCategoria)");
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public void modificar(Articulo modificar)
        {

        }

    }
}
