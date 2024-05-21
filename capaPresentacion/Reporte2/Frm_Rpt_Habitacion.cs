using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion.Reporte2
{
    public partial class Frm_Rpt_Habitacion : Form
    {
        public Frm_Rpt_Habitacion()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Habitacion_Load(object sender, EventArgs e)
        {
            this.sp_listar_habitacionTableAdapter.Fill(this.dataSet_habitacion.sp_listar_habitacion, valor: txt_p1.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
