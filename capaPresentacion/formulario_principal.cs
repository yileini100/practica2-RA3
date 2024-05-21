using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class formulario_principal : Form
    {
        public formulario_principal()
        {
            InitializeComponent();
        }
        private void btnslide_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width == 250)
            {
                menuVertical.Width = 70;
            }
            else
            {
                menuVertical.Width = 250;
            }
        }

        private void iconoCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconoMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconoestraer.Visible = true;
            iconoMaximizar.Visible = false;
        }

        private void iconoestraer_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Normal;
            iconoestraer.Visible = false;
            iconoMaximizar.Visible = true;
        }

        private void iconoMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState =FormWindowState.Minimized;
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();

        }

        private void btn_huesped_Click(object sender, EventArgs e)
        {
            Form formulario = new formulario_huesped();
            formulario.Show();

            //AbrirFormInPanel(new formulario_huesped());
        }

        private void btn_empleado_Click(object sender, EventArgs e)
        {
            Form formulario = new Empleados();
            formulario.Show();
        }

        private void btn_habitacion_Click(object sender, EventArgs e)
        {
            Form formulario = new Habitacion();
            formulario.Show();
        }

        private void btn_reserva_Click(object sender, EventArgs e)
        {
            Form formulario = new Reserva();
            formulario.Show();
        }

        private void btn_cerrarsesion_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Estas seguro de cerrar sesion?","warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            this.Close();
        }

     
    }
}
