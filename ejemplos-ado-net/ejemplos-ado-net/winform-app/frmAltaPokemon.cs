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

namespace winform_app
{
    public partial class frmAltaPokemon : Form
    {

        private Pokemon pokemon = null;

        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        public frmAltaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
            Text = "Modificar Pokemon";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                if(pokemon == null)
                {
                    pokemon = new Pokemon();
                } 

                pokemon.Nombre = txtNom.Text;
                pokemon.Descripcion = txtDescr.Text;
                pokemon.UrlImagen = txtUrl.Text;
                pokemon.Tipo = (Elemento)cmbTipo.SelectedItem;
                pokemon.Debilidad = (Elemento)cmbDeb.SelectedItem;
                pokemon.Numero = int.Parse(txtNum.Text);

                if(pokemon.Id != 0)
                {
                    negocio.modificar(pokemon);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(pokemon);
                    MessageBox.Show("Agregado exitosamente");
                }


                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();

            try
            {
                cmbTipo.DataSource = elementoNegocio.listar();
                cmbTipo.ValueMember = "Id";
                cmbTipo.DisplayMember = "Descripcion";
                cmbDeb.DataSource = elementoNegocio.listar();
                cmbDeb.ValueMember = "Id";
                cmbDeb.DisplayMember = "Descripcion";

                if(pokemon != null)
                {
                    txtNum.Text = pokemon.Numero.ToString();
                    txtNom.Text = pokemon.Nombre;
                    txtDescr.Text = pokemon.Descripcion;
                    txtUrl.Text = pokemon.UrlImagen;
                    cargarImagen(pokemon.UrlImagen);
                    cmbTipo.SelectedValue = pokemon.Tipo.Id;
                    cmbDeb.SelectedValue = pokemon.Debilidad.Id;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrl.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pcbImg.Load(imagen);
            }
            catch (Exception)
            {

                pcbImg.Load("https://static0.gamerantimages.com/wordpress/wp-content/uploads/2022/05/whos-that-pokemon.jpg");
            }

        }

    }
}
