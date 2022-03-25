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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WarehouseForm wf = new WarehouseForm();
            wf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductsForm pf = new ProductsForm();
            pf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomersForm cf = new CustomersForm();
            cf.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SuppliersForm sf = new SuppliersForm();
            sf.Show();
        }

      
    }
}
