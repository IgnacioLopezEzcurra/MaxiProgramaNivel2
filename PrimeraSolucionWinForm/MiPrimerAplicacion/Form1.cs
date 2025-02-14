using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPrimerAplicacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido cabrón");
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Hasta la vista, baby...☺");
        }

        public  void frmPrincipal_Click(object sender, EventArgs e)
        
            {
                MouseEventArgs click = (MouseEventArgs)e;
                if (click.Button == MouseButtons.Left)
                    MessageBox.Show("Presiono el botón Izquierdo", "Atención");
                else if (click.Button == MouseButtons.Right)
                    MessageBox.Show("Presiono el Botón Derecho", "Atención");
                else
                if (click.Button == MouseButtons.Middle)
                    MessageBox.Show("Presiono el botón del Medio", "Atención");
            }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtApellido.Text == "")
            {
                txtApellido.BackColor = Color.Red;
            }
            else
                txtApellido.BackColor = System.Drawing.SystemColors.Control;

            if (txtNombre.Text == "")
            {
                txtNombre.BackColor = Color.Red;
            }
            else
                txtNombre.BackColor = System.Drawing.SystemColors.Control;


            if (txtEdad.Text == "")
            {
                txtEdad.BackColor = Color.Red;
            }
            else
                txtEdad.BackColor = System.Drawing.SystemColors.Control;

            if (txtDireccion.Text == "")
            {
                txtDireccion.BackColor = Color.Red;
            }
            else
                txtDireccion.BackColor = System.Drawing.SystemColors.Control;

            if (txtNombre.Text !="" && txtApellido.Text != "" && txtEdad.Text != "" && txtDireccion.Text != "")
            {
                txtResultado.Text = "Apellido y Nombre: " + txtApellido.Text + ", " + txtNombre.Text +
                   Environment.NewLine + "Edad: " + txtEdad.Text + Environment.NewLine + "Dirección: " + txtDireccion.Text;
            }

        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;

            if ((e.KeyChar) == 13)
                txtDireccion.Focus();
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar) == 13)
                txtNombre.Focus();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar) == 13)
                txtEdad.Focus();
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar) == 13)
                btnAceptar.PerformClick();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
