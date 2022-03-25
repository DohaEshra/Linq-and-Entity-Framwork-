using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyProject
{
    public partial class ProductMovementReport : Form
    {
        CompanyProjectEntities1 ent = new CompanyProjectEntities1();
        public ProductMovementReport()
        {
            InitializeComponent();
        }

        private void ProductMovementReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
