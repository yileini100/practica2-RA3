using capaDatos.Habitacion;
using capaEntidad.Habitacion;
using capaNegocio.Habitacion;
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
    public partial class Habitacion : Form
    {
        public Habitacion()
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
            cmb_idTipo.Text = "";
            txtCapacidad.Text = "";
            txtNumeroH.Text = "";
            txtPrecioN.Text = "";
            cmb_usuario.Text = "";
            cmb_descripcion.Text = "";
        }

        private void EstadoTexto(bool Estado)
        {
            cmb_idTipo.Enabled = Estado;
            txtCapacidad.Enabled = Estado;
            txtNumeroH.Enabled = Estado;
            txtPrecioN.Enabled = Estado;
            cmb_usuario.Enabled = Estado;
            cmb_descripcion.Enabled = Estado;
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
            Dhabitacion datos = new Dhabitacion();
            cmb_usuario.DataSource = datos.Listar_usuario();
            cmb_usuario.ValueMember = "Id_usuario";
            cmb_usuario.DisplayMember = "usuario";
        }

        private void cargar_tipoH()
        {
            Dhabitacion datos = new Dhabitacion();
            cmb_idTipo.DataSource = datos.Listar_tipoH();
            cmb_idTipo.ValueMember = "id_tipoHabitacion";
            cmb_idTipo.DisplayMember = "tipo_habitacion";
            cmb_descripcion.DataSource = datos.Listar_tipoH();
            cmb_descripcion.ValueMember = "id_tipoHabitacion";
            cmb_descripcion.DisplayMember = "descripcion";
        }
        private void Formato_hues()
        {
            dgv_data.Columns[0].Width = 110;
            dgv_data.Columns[0].HeaderText = "Id_habitacion";
            dgv_data.Columns[1].Width = 110;
            dgv_data.Columns[1].HeaderText = "Tipo_habitacion";
            dgv_data.Columns[2].Width = 110;
            dgv_data.Columns[2].HeaderText = "Descripcion";
            dgv_data.Columns[3].Width = 110;
            dgv_data.Columns[3].HeaderText = "Capacidad";
            dgv_data.Columns[4].Width = 110;
            dgv_data.Columns[4].HeaderText = "Numero_habitacion";
            dgv_data.Columns[5].Width = 110;
            dgv_data.Columns[5].HeaderText = "Precio por noche";
            dgv_data.Columns[6].Width = 110;
            dgv_data.Columns[6].HeaderText = "Usuario";
            dgv_data.Columns[7].Visible = false;
            dgv_data.Columns[8].Visible = false;

        }
        private void Listar_habitacion(string valor)
        {
            try
            {
                dgv_data.DataSource = Nhabitacion.Listar_habitacion(valor);
                this.Formato_hues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void selecciona_items_huesp()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_data.CurrentRow.Cells["Id_habitacion"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visaulizar", "Aviso sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.n_codigo = Convert.ToInt32(dgv_data.CurrentRow.Cells["Id_habitacion"].Value);
                cmb_idTipo.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Tipo_habitacion"].Value);
                cmb_descripcion.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Descripcion"].Value);
                txtCapacidad.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Capacidad"].Value);
                txtNumeroH.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Numero_habitación"].Value);
                txtPrecioN.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Precio_por_noche"].Value);
                cmb_usuario.Text = Convert.ToString(dgv_data.CurrentRow.Cells["Usuario"].Value);
            }
        }
        #endregion

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            this.esta_guardada = 1;
            this.n_codigo = 0;
            this.LimpiarTexto();
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtCapacidad.Select();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            this.esta_guardada = 2;
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtCapacidad.Select();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_estado_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea desactivar el registro?", "Aviso del sistema",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                string respuesta = "";
                respuesta = Nhabitacion.Estado_habitacion(n_codigo);
                if (respuesta.Equals("Ok"))
                {
                    this.Listar_habitacion("%");
                    //this.Estado(false);
                    //esta_guardada = 0;

                    n_codigo = 0;

                    cmb_idTipo.Text = "";
                    cmb_descripcion.Text = "";
                    txtCapacidad.Text = "";
                    txtNumeroH.Text = "";
                    txtPrecioN.Text = "";
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

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listar_habitacion(txt_buscar.Text);
        }

        private void estraer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selecciona_items_huesp();
        }

        private void Habitacion_Load(object sender, EventArgs e)
        {
            
            this.cargar_tipoH();
            this.cargar_usuario();
            this.Listar_habitacion("%");
            this.EstadoTexto(false);
            dgv_data.Enabled = true;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarTexto();
            this.EstadoTexto(false);
            this.EstadoBotones(true);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txtCapacidad.Text == string.Empty ||
              txtNumeroH.Text == string.Empty ||
              txtPrecioN.Text == string.Empty ||
              cmb_idTipo.Text == string.Empty ||
              cmb_descripcion.Text == string.Empty ||
              cmb_usuario.Text == string.Empty)
            {
                MessageBox.Show("Este cmapo no puede estar vacio", "Aviso del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string respuesta = "";
                Ehabitacion habitacion = new Ehabitacion();
                habitacion.id_habitacion = this.n_codigo;
                habitacion.id_TipoHabitacion = Convert.ToInt32(cmb_idTipo.SelectedValue);
                habitacion.capacidad = Convert.ToInt32(txtCapacidad.Text.Trim());
                habitacion.numero_habitación = Convert.ToInt32(txtNumeroH.Text.Trim());
                habitacion.precio_por_noche = Convert.ToDouble(txtPrecioN.Text.Trim());
                habitacion.id_usuario = Convert.ToInt32(cmb_usuario.SelectedValue);
                respuesta = Nhabitacion.Guardar_habitacion(esta_guardada, habitacion);
                if (respuesta == "Ok")
                {
                    this.Listar_habitacion("%");
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

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            Reporte2.Frm_Rpt_Habitacion oRpt1 = new Reporte2.Frm_Rpt_Habitacion();
            oRpt1.txt_p1.Text = txt_buscar.Text;
            oRpt1.ShowDialog();
        }
    }
}
