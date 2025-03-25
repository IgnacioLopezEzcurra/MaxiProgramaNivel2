using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using dominio;
using System.Runtime.Remoting.Messaging;

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
                comando.CommandText = "SELECT Codigo, Nombre, A.Descripcion, ImagenUrl, C.Descripcion Categoria, M.Descripcion Marca, A.Precio, A.IdCategoria, A.IdMarca, A.Id\r\nfrom ARTICULOS A, CATEGORIAS C, MARCAS M\r\nwhere C.Id = A.IdCategoria AND A.IdMarca = M.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    /* if (!(lector.IsDBNull(lector.GetOrdinal("ImagenUrl")))){ 

                     aux.UrlImagen = (string)lector["ImagenUrl"];
                     }*/

                    if (!(lector["ImagenUrl"] is DBNull))           //la opcion mas practica
                        aux.UrlImagen = (string)lector["ImagenUrl"];


                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)lector["Marca"];
                    aux.Marca.Id = (int)lector["IdMarca"];

                    if (!(lector["Precio"] is DBNull))
                    aux.Precio = (decimal)lector["Precio"];
                    //aux.Precio = lector.GetDecimal(lector.GetOrdinal("Precio")); forma mas larga de castear

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
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values ('"+ nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', @idMarca, @idCategoria, @urlImagen, @precio)");
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@urlImagen", nuevo.UrlImagen);
                datos.setearParametro("@precio", nuevo.Precio);
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
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @urlImagen, Precio = @precio where Id = @id");
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@descripcion", modificar.Descripcion);
                datos.setearParametro("@idMarca", modificar.Marca.Id);
                datos.setearParametro("@idCategoria", modificar.Categoria.Id);
                datos.setearParametro("@urlImagen", modificar.UrlImagen);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@id", modificar.Id);

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

    }
}
