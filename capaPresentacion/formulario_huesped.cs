using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using capaDatos.Huesped;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidad;
using capaEntidad.Huesped;
using capaNegocio;
using capaNegocio.Huesped;
using capaNegocio.Empleado;


namespace capaPresentacion
{
    public partial class formulario_huesped : Form
    {
        public formulario_huesped()
        {
            InitializeComponent();
        }


        #region "Variables"
        int esta_guardada = 0;
        int n_codigo = 0; //Se utiliza para guardar el codigo seleccionado
        #endregion
        #region "Mis Metodos"

        private void LimpiarTexto()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtPais.Text = "";
            cmb_usuario.Text = "";
        }

        private void EstadoTexto(bool Estado)
        {
            txtNombre.Enabled = Estado;
            txtApellido.Enabled = Estado;
            txtEmail.Enabled = Estado;
            txtTelefono.Enabled = Estado;
            txtDireccion.Enabled = Estado;
            txtPais.Enabled = Estado;
            cmb_usuario.Enabled = Estado;
        }

        private void EstadoBotones(bool Estado)
        {
            btn_guardar.Visible = !Estado;
            btn_cancelar.Visible = !Estado;

            btn_nuevo.Enabled = Estado;
            btn_actualizar.Enabled = Estado;
            btn_estado.Enabled = Estado;
            btn_reporte.Enabled = Estado;
            btn_salir.Enabled = Estado;
            
            dgv_data.Enabled = Estado;
            btn_buscar.Enabled = Estado;
            txt_buscar.Enabled = Estado;
        }

        private void cargar_usuario()
        {
           Dhuesped datos = new Dhuesped();
            cmb_usuario.DataSource = datos.Listar_usuario();
            cmb_usuario.ValueMember = "Id_usuario";
            cmb_usuario.DisplayMember = "usuario";
        }
        private void Formato_hues()
        {
            dgv_data.Columns[0].Width = 110;
            dgv_data.Columns[0].HeaderText = "Id_huesped";
            dgv_data.Columns[1].Width = 110;
            dgv_data.Columns[1].HeaderText = "Nombre";
            dgv_data.Columns[2].Width = 110;
            dgv_data.Columns[2].HeaderText = "Apellido";
            dgv_data.Columns[3].Width = 110;
            dgv_data.Columns[3].HeaderText = "Email";
            dgv_data.Columns[4].Width = 110;
            dgv_data.Columns[4].HeaderText = "Teleono";
            dgv_data.Columns[5].Width = 110;
            dgv_data.Columns[5].HeaderText = "Direccion";
            dgv_data.Columns[6].Width = 110;
            dgv_data.Columns[6].HeaderText = "País";
            dgv_data.Columns[7].Width = 110;
            dgv_data.Columns[7].HeaderText = "Usuario";
            dgv_data.Columns[8].Visible = false;

        }
        private void Listar_huesped(string valor)
        {
            try
            {
                dgv_data.DataSource = Nhuesped.Listar_huesped(valor);
                this.Formato_hues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void selecciona_items_huesp()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_data.CurrentRow.Cells["Id_huesped"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visaulizar", "Aviso sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.n_codigo = Convert.ToInt32(dgv_data.CurrentRow.Cells["Id_huesped"].Value);
                txtNombre.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Nombre"].Value);
                txtApellido.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Apellido"].Value);
                txtEmail.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Email"].Value);
                txtTelefono.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Telefono"].Value);
                txtDireccion.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Direccion"].Value);
                txtPais.Text = Convert.ToString(dgv_data.CurrentRow.Cells["País"].Value);
                cmb_usuario.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Usuario"].Value);
            }
        }
        #endregion

        private void formulario_huesped_Load(object sender, EventArgs e)
        {
            this.cargar_usuario();
            this.Listar_huesped("%");
            this.EstadoTexto(false);
            dgv_data.Enabled = true;
        }

        private void btn_guardar_Click_1(object sender, EventArgs e)
        {
            if (txtNombre.Text == string.Empty ||
                txtApellido.Text == string.Empty ||
                txtEmail.Text == string.Empty ||
                txtTelefono.Text == string.Empty ||
                txtDireccion.Text == string.Empty ||
                txtPais.Text == string.Empty )
            {
                MessageBox.Show("Este cmapo no puede estar vacio", "Aviso del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string respuesta = "";
                Ehuesped ehuesped = new Ehuesped();
                ehuesped.id_huesped = this.n_codigo;
                ehuesped.nombre = txtNombre.Text.Trim();
                ehuesped.apellido = txtApellido.Text.Trim();
                ehuesped.email = txtEmail.Text.Trim();
                ehuesped.telefono = Convert.ToDouble(txtTelefono.Text.Trim()); ;
                ehuesped.direccion = txtDireccion.Text.Trim();
                ehuesped.pais = txtPais.Text.Trim();
                ehuesped.id_usuario = Convert.ToInt32(cmb_usuario.SelectedValue);
                respuesta = Nhuesped.Guardar_huesped(esta_guardada, ehuesped);
                if (respuesta == "Ok")
                {
                    this.Listar_huesped("%");
                    MessageBox.Show("Datos guardados correctamente.", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.n_codigo = 0;
                    this.LimpiarTexto();
                    this.EstadoTexto(false);
                    this.EstadoBotones(true);
                    
                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void iconoCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconoestraer_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconoestraer.Visible = false;
            iconoMaximizar.Visible = true;
        }

        private void iconoMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconoestraer.Visible = true;
            iconoMaximizar.Visible = false;
        }

        private void iconoMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            this.esta_guardada = 1;
            this.n_codigo = 0;
            this.LimpiarTexto();
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtNombre.Select();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarTexto();
            this.EstadoTexto(false);
            this.EstadoBotones(true);
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            this.esta_guardada = 2;
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtNombre.Select();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listar_huesped(txt_buscar.Text);
        }

        private void btn_estado_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea desactivar el registro?", "Aviso del sistema",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                string respuesta = "";
                respuesta = Nempleado.Estado_empleado(n_codigo);
                if (respuesta.Equals("Ok"))
                {
                    this.Listar_huesped("%");
                    //this.Estado(false);
                    //esta_guardada = 0;

                    n_codigo = 0;

                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    txtPais.Text = "";
                    cmb_usuario.Text = "";




                    MessageBox.Show("Registro desactivado", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso del sistema", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selecciona_items_huesp();
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.frm_rpt_huesped oRpt1 = new Reportes.frm_rpt_huesped();
            oRpt1.txt_p1.Text = txt_buscar.Text;
            oRpt1.ShowDialog();
        }
    }
}
