using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejemplo1WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSaludar_Click(object sender, EventArgs e)
        {

            string elemento = txtNombre.Text;
            lwElementos.Items.Add(elemento);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbColor.Items.Add("Rojo");
            cmbColor.Items.Add("Verde");
            cmbColor.Items.Add("Amarillo");
        }

        private void btnVerPerfil_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            DateTime fecha = dtpFechaDeNacimiento.Value;

            //operador ternario
            string chocolate = ckbChocolate.Checked == true ? "Le gusta el chocolate" : "No le gusta :(";
            string tipo;
            if(rbtMuggle.Checked) {
                tipo = "Muggle";
            } else if(rbtWizard.Checked) {

                tipo = "Wizard";

            } else
            {
                tipo = "Squibs";
            }

            string colorFavorito = cmbColor.SelectedItem.ToString();
            string numeroFavorito = numNumeroFavorito.Value.ToString();

            string mensaje = chocolate + ", es " + tipo + ", su color es " + colorFavorito + " y su numero favorito es " + numeroFavorito;
            MessageBox.Show("Nombre: " + nombre + " Fecha de Nac: " + fecha + ", " + mensaje);
        }
    }
}
