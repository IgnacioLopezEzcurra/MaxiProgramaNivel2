using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class frmDetalles : Form
    {

        private Articulo articulo = null;
        public frmDetalles(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            cargarInfo();
            cargarImagen(articulo.UrlImagen);
        }
        
        private void cargarInfo()
        {
            txtDetalles.Text = "Nombre: " + articulo.Nombre + Environment.NewLine + Environment.NewLine +
               "Descripción:  " + articulo.Descripcion + Environment.NewLine + Environment.NewLine +
               "Marca: " + articulo.Marca + Environment.NewLine + Environment.NewLine +
               "Categoría: " + articulo.Categoria + Environment.NewLine + Environment.NewLine +
               "Precio: $" + articulo.Precio + Environment.NewLine + Environment.NewLine +
               "Código: " + articulo.Codigo;
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNtN2O8GLWKd2e1flZtF-fX0J8cwnjN78qVA&s");
            }
        }

    }
}
