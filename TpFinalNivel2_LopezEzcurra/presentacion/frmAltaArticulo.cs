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
                arti.Categoria = (Categoria)cboCategoria.SelectedItem;
                arti.Marca = (Marca)cboMarca.SelectedItem;

                negocio.agregar(arti);
                MessageBox.Show("Agregado exitosamente");
                Close();
           
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboMarca.DataSource = marcaNegocio.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
