using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;


namespace presentacion
{
    public partial class frmAltaArticulo : Form
    {
        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo arti = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                arti.Codigo = txtCodigo.Text;
                arti.Nombre = txtNombre.Text;
                arti.Descripcion = txtDescripcion.Text;

                negocio.agregar(arti);
                MessageBox.Show("Agregado exitosamente");
                Close();
           
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
