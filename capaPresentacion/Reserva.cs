using capaDatos.Reserva;
using capaEntidad.Reserva;
using capaNegocio.Reserva;
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
    public partial class Reserva : Form
    {
        public Reserva()
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
            txtAdultos.Text = "";
            txtNinos.Text = "";
            txtHabitacion.Text = "";
            cmb_huesped.Text = "";
            cmb_empleado.Text = "";
            txtPrecio.Text = "";
            cmb_pago.Text = "";
            cmb_usuario.Text = "";
        }

        private void EstadoTexto(bool Estado)
        {
            txtAdultos.Enabled = Estado;
            txtNinos.Enabled = Estado;
            txtHabitacion.Enabled = Estado;
            cmb_huesped.Enabled = Estado;
            txtPrecio.Enabled = Estado;
            cmb_empleado.Enabled = Estado;
            cmb_pago.Enabled = Estado;
            cmb_usuario.Enabled = Estado;
            fh_llegada.Enabled = Estado;
            fh_salida.Enabled = Estado;
            fh_reserva.Enabled = Estado;
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
            Dreserva datos = new Dreserva();
            cmb_usuario.DataSource = datos.Listar_usuario();
            cmb_usuario.ValueMember = "Id_usuario";
            cmb_usuario.DisplayMember = "usuario";
        }

        private void cargar_huesped()
        {
            Dreserva datos = new Dreserva();
            cmb_huesped.DataSource = datos.Listar_huesp();
            cmb_huesped.ValueMember = "id_huesped";
            cmb_huesped.DisplayMember = "nombre";
        }

        private void cargar_empleado()
        {
            Dreserva datos = new Dreserva();
            cmb_empleado.DataSource = datos.Listar_emple();
            cmb_empleado.ValueMember = "id_empleado";
            cmb_empleado.DisplayMember = "nombre";
        }
        private void Formato_em()
        {
            dgv_data.Columns[0].Width = 110;
            dgv_data.Columns[0].HeaderText = "Id_reserva";
            dgv_data.Columns[1].Width = 110;
            dgv_data.Columns[1].HeaderText = "Huespedes";
            dgv_data.Columns[2].Width = 110;
            dgv_data.Columns[2].HeaderText = "Empleado";
            dgv_data.Columns[3].Width = 110;
            dgv_data.Columns[3].HeaderText = "Fecha_llegada";
            dgv_data.Columns[4].Width = 110;
            dgv_data.Columns[4].HeaderText = "Fecha_salida";
            dgv_data.Columns[5].Width = 110;
            dgv_data.Columns[5].HeaderText = "Precio_total";
            dgv_data.Columns[6].Width = 110;
            dgv_data.Columns[6].HeaderText = "Metodo_pago";
            dgv_data.Columns[7].Width = 110;
            dgv_data.Columns[7].HeaderText = "Cantidad_habitacion";
            dgv_data.Columns[8].Width = 110;
            dgv_data.Columns[8].HeaderText = "Cantidad_adultos";
            dgv_data.Columns[9].Width = 110;
            dgv_data.Columns[9].HeaderText = "Cantidad_niños";
            dgv_data.Columns[10].Width = 110;
            dgv_data.Columns[10].HeaderText = "Fecha_reserva";
            dgv_data.Columns[11].Width = 110;
            dgv_data.Columns[11].HeaderText = "Usuario";
            dgv_data.Columns[12].Visible = false;
            dgv_data.Columns[13].Visible = false;
            dgv_data.Columns[14].Visible = false;
        }
        private void Listar_reserva(string valor)
        {
            try
            {
                dgv_data.DataSource = Nreserva.Listar_reserva(valor);
                this.Formato_em();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void selecciona_items_em()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_data.CurrentRow.Cells["Id_reserva"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visaulizar", "Aviso sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.n_codigo = Convert.ToInt32(dgv_data.CurrentRow.Cells["Id_reserva"].Value);
                cmb_huesped.Text = Convert.ToString(dgv_data.CurrentRow.Cells["nombre"].Value);
                cmb_empleado.Text = Convert.ToString(dgv_data.CurrentRow.Cells["nombre"].Value);
                fh_llegada.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Fecha_llegada"].Value);
                fh_salida.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Fecha_salida"].Value);
                txtPrecio.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Precio_total"].Value);
                cmb_pago.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Metodo_pago"].Value);
                txtHabitacion.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Cantidad_habitacion"].Value);
                txtAdultos.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Cantidad_adultos"].Value);
                txtNinos.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Cantidad_niños"].Value);
                fh_reserva.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Fecha_reserva"].Value);
                cmb_usuario.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Usuario"].Value);
            }
        }
        #endregion

        private void Reserva_Load(object sender, EventArgs e)
        {
            this.cargar_huesped();
            this.cargar_empleado();
            this.cargar_usuario();
            this.Listar_reserva("%");
            this.EstadoTexto(false);
            dgv_data.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            this.esta_guardada = 1;
            this.n_codigo = 0;
            this.LimpiarTexto();
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            cmb_huesped.Select();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            this.esta_guardada = 2;
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            cmb_huesped.Select();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarTexto();
            this.EstadoTexto(false);
            this.EstadoBotones(true);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (cmb_huesped.Text == string.Empty ||
                 cmb_empleado.Text == string.Empty ||
                 txtHabitacion.Text == string.Empty ||
                 txtNinos.Text == string.Empty ||
                 txtAdultos.Text == string.Empty ||
                 txtPrecio.Text == string.Empty ||
                 cmb_pago.Text == string.Empty)
            {
                MessageBox.Show("Este cmapo no puede estar vacio", "Aviso del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string respuesta = "";
                Ereserva reserva = new Ereserva();
                reserva.id_reserva = this.n_codigo;
                reserva.id_huesped = Convert.ToInt32(cmb_huesped.SelectedValue);
                reserva.id_empleado = Convert.ToInt32(cmb_empleado.SelectedValue);
                reserva.fecha_llegada = Convert.ToDateTime(fh_llegada.Text.Trim());
                reserva.fecha_salida = Convert.ToDateTime(fh_salida.Text.Trim()); 
                reserva.precio_total = Convert.ToDecimal (txtPrecio.Text.Trim());
                reserva.metodo_pago = cmb_pago.Text.Trim();
                reserva.cantidad_habitacion = Convert.ToInt32(txtHabitacion.Text.Trim());
                reserva.cantidad_adultos = Convert.ToInt32(txtAdultos.Text.Trim());
                reserva.cantidad_niños = Convert.ToInt32(txtNinos.Text.Trim());
                reserva.fecha_reserva = Convert.ToDateTime(fh_reserva.Text.Trim());
                reserva.id_usuario = Convert.ToInt32(cmb_usuario.SelectedValue);
                respuesta = Nreserva.Guardar_reserva(esta_guardada, reserva);
                if (respuesta == "Ok")
                {
                    this.Listar_reserva("%");
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

        private void btn_estado_Click(object sender, EventArgs e)
        {

            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea desactivar el registro?", "Aviso del sistema",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                string respuesta = "";
                respuesta = Nreserva.Estado_reserva(n_codigo);
                if (respuesta.Equals("Ok"))
                {
                    this.Listar_reserva("%");
                    //this.Estado(false);
                    //esta_guardada = 0;

                    n_codigo = 0;

                    txtAdultos.Text = "";
                    txtNinos.Text = "";
                    txtHabitacion.Text = "";
                    cmb_empleado.Text = "";
                    cmb_huesped.Text = "";
                    txtPrecio.Text = "";
                    cmb_pago.Text = "";
                    cmb_usuario.Text = "";
                    fh_reserva.Text = "";
                    fh_salida.Text = "";
                    fh_llegada.Text = "";




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

        private void btn_reporte_Click(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void estraer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            estraer.Visible = true;
            maximizar.Visible = false;
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            estraer.Visible = false;
            maximizar.Visible = true;
        }

        private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selecciona_items_em();
        }
    }
}
