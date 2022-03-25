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
    public partial class TransferForm : Form
    {
        CompanyProjectEntities1 ent = new CompanyProjectEntities1();
        public TransferForm()
        {
            InitializeComponent();
        }
   

        private void TransferForm_Load(object sender, EventArgs e)//onload
        {
           
            dataGridView1.DataSource = ent.warehouse_products.ToList();
            var ware= (from w in ent.warehouse_products select w.w_name).Distinct();
            foreach (var ww in ware)
            {
                comboBox2.Items.Add(ww);
                comboBox3.Items.Add(ww);
            }
            var pro = from p in ent.Products select p.Prod_name;
            foreach (var p in pro)
            {
                comboBox4.Items.Add(p);
         
            }
        }

        private void button1_Click(object sender, EventArgs e)//transfer
        {
            string from = comboBox2.SelectedItem.ToString();
            string to = comboBox3.SelectedItem.ToString();
            string product = comboBox4.SelectedItem.ToString();
            int prod = (from p in ent.Products where p.Prod_name == product select p.Prod_id).First();
            ent.transferProduct(from, to, prod, int.Parse(textBox4.Text));
            ent.SaveChanges();
            dataGridView1.DataSource = ent.warehouse_products.ToList();
        }

        private void button2_Click(object sender, EventArgs e)//ProductMovement
        {
            ProductMovementReport pmr = new ProductMovementReport();
            pmr.Show();
        }
    }
}
