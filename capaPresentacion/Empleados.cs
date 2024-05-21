using capaNegocio.Huesped;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocio.Empleado;
using capaEntidad.Empleado;
using capaDatos.Huesped;


namespace capaPresentacion
{
    public partial class Empleados : Form
    {
        public Empleados()
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
            txtCargo.Text = "";
            txtDepartamento.Text = "";
            cmb_usuario.Text = "";
        }

        private void EstadoTexto(bool Estado)
        {
            txtNombre.Enabled = Estado;
            txtApellido.Enabled = Estado;
            txtEmail.Enabled = Estado;
            txtTelefono.Enabled = Estado;
            txtDireccion.Enabled = Estado;
            txtCargo.Enabled = Estado;
            txtDepartamento.Enabled = Estado;
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
        private void Formato_em()
        {
            dgv_data.Columns[0].Width = 110;
            dgv_data.Columns[0].HeaderText = "Id_empleado";
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
            dgv_data.Columns[6].HeaderText = "Cargo";
            dgv_data.Columns[7].Width = 110;
            dgv_data.Columns[7].HeaderText = "Departamento";
            dgv_data.Columns[8].Width = 110;
            dgv_data.Columns[8].HeaderText = "Usuario";
            dgv_data.Columns[9].Visible = false;

        }
        private void Listar_empleado(string valor)
        {
            try
            {
                dgv_data.DataSource = Nempleado.Listar_empleado(valor);
                this.Formato_em();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void selecciona_items_em()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_data.CurrentRow.Cells["Id_empleado"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visaulizar", "Aviso sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.n_codigo = Convert.ToInt32(dgv_data.CurrentRow.Cells["Id_empleado"].Value);
                txtNombre.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Nombre"].Value);
                txtApellido.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Apellido"].Value);
                txtEmail.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Email"].Value);
                txtTelefono.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Telefono"].Value);
                txtDireccion.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Direccion"].Value);
                txtCargo.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Cargo"].Value);
                txtDepartamento.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Departamento"].Value);
                cmb_usuario.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Usuario"].Value);
            }
        }
        #endregion

        private void Empleados_Load(object sender, EventArgs e)
        {
            this.cargar_usuario();
            this.Listar_empleado("%");
            this.EstadoTexto(false);
            dgv_data.Enabled = true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == string.Empty ||
               txtApellido.Text == string.Empty ||
               txtEmail.Text == string.Empty ||
               txtTelefono.Text == string.Empty ||
               txtDireccion.Text == string.Empty ||
               txtCargo.Text == string.Empty ||
               txtDepartamento.Text == string.Empty)
            {
                MessageBox.Show("Este cmapo no puede estar vacio", "Aviso del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string respuesta = "";
                Eempleado empleado = new Eempleado();
                empleado.id_empleado = this.n_codigo;
                empleado.nombre = txtNombre.Text.Trim();
                empleado.apellido = txtApellido.Text.Trim();
                empleado.email = txtEmail.Text.Trim();
                empleado.telefono = Convert.ToDouble(txtTelefono.Text.Trim()); ;
                empleado.direccion = txtDireccion.Text.Trim();
                empleado.cargo = txtCargo.Text.Trim();
                empleado.departamento = txtDepartamento.Text.Trim();
                empleado.id_usuario = Convert.ToInt32(cmb_usuario.SelectedValue);
                respuesta = Nempleado.Guardar_empleado(esta_guardada, empleado);
                if (respuesta == "Ok")
                {
                    this.Listar_empleado("%");
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
            this.Listar_empleado(txt_buscar.Text);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selecciona_items_em();
        }

        private void estraer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconoestraer.Visible = true;
            iconoMaximizar.Visible = false;
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconoestraer.Visible = false;
            iconoMaximizar.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                    this.Listar_empleado("%");
                    //this.Estado(false);
                    //esta_guardada = 0;

                    n_codigo = 0;

                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    txtCargo.Text = "";
                    txtDepartamento.Text = "";
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
    }
    
}