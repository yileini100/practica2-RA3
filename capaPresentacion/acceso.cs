using capaEntidad.Usuario;
using capaNegocio.Usuario;
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
    public partial class acceso : Form
    {
        public acceso()
        {
            InitializeComponent();
        }

        Eusuario objeuser = new Eusuario();
        Nusuario objnuser = new Nusuario();
        formulario_principal frm = new formulario_principal();

        public static string Usuario_nombre;
        public static string Area;

        void login()
        {
            DataTable dt = new DataTable();
            objeuser.usuario = txt_usuario.Text;
            objeuser.contraseña = txt_contraseña.Text;
            dt = objnuser.N_users(objeuser);
            if (dt.Rows.Count > 0)
            {

                MessageBox.Show("BIENVENIDO  " + dt.Rows[0][4].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Usuario_nombre = dt.Rows[0][0].ToString();
                Area = dt.Rows[0][1].ToString();

                frm.ShowDialog();
                acceso login = new acceso();
                login.ShowDialog();
                if (login.DialogResult == DialogResult.OK)
                    Application.Run(new formulario_principal());
                this.Close();
                frm.FormClosed += Login;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btn_iniciar_secion_Click(object sender, EventArgs e)
        {
            login();
            this.Close();   
        }

        private void iconoCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconoMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
       private void Login(object sender, FormClosedEventArgs e)
        {
            txt_usuario.Clear();
            txt_contraseña.Clear();
            this.Show();
            txt_usuario.Focus();
        }
     
    }
}
