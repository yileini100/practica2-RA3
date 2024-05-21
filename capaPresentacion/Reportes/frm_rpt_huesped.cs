using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion.Reportes
{
    public partial class frm_rpt_huesped : Form
    {
        public frm_rpt_huesped()
        {
            InitializeComponent();
        }

        private void frm_rpt_huesped_Load(object sender, EventArgs e)
        {
            this.sp_listar_huespedTableAdapter.Fill(this.dataSet_Reserva.sp_listar_huesped,valor: txt_p1.Text);
            this.reportViewer1.RefreshReport();
        }

       
    }
}
