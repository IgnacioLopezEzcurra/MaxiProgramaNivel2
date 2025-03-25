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

        private Articulo articulo = null;

        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Articulo arti = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {

                // Validar si el precio ingresado es válido
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("Formato de precio inválido. Por favor, use coma (,) para separar decimales y no ingrese letras ni otros caracteres.", "Error en el precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Termina la ejecución si el precio es inválido.
                }

                // Si se ingresó un punto, mostrar mensaje y no continuar
                if (txtPrecio.Text.Contains("."))
                {
                    MessageBox.Show("El punto (.) no es un separador válido. Por favor, use coma (,) para separar decimales.", "Error en el precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Detiene la ejecución si se detecta un punto.
                }

                if(articulo == null) {

                    articulo = new Articulo();
                }
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.UrlImagen = txtUrlImagen.Text;
                    articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                    articulo.Marca = (Marca)cboMarca.SelectedItem;
                    articulo.Precio = decimal.Parse(txtPrecio.Text); 

                if(articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente");
                }



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
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";


                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtUrlImagen.Text = articulo.UrlImagen;
                    cargarImagen(articulo.UrlImagen);
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    txtPrecio.Text = articulo.Precio.ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
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
