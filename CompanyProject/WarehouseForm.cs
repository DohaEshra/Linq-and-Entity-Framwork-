using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyProject
{
    public partial class WarehouseForm : Form
    {
        CompanyProjectEntities1 ent = new CompanyProjectEntities1();

        public WarehouseForm()
        {
            InitializeComponent();
        }
       

        private void WarehouseForm_Load(object sender, EventArgs e)//onload 
        {
           
           
            dataGridView1.DataSource = ent.Warehouses.ToList();
            dataGridView1.Columns.Remove("Warehouse_prod_PurchOrd");
            dataGridView1.Columns.Remove("Warehouse_prod_salesOrd");
        }

        private void button2_Click(object sender, EventArgs e)//update 
        {

            string name = textBox1.Text;
            var ws = (from w in ent.Warehouses where w.W_name == name select w).First(); ;
           
            if (ws != null)
            {
                ws.W_name = textBox1.Text;
                ws.Address = textBox2.Text;
                ws.Manager_id = int.Parse(textBox3.Text);
            }
            ent.SaveChanges();
            dataGridView1.DataSource = ent.Warehouses.ToList();
            dataGridView1.Columns.Remove("Warehouse_prod_PurchOrd");
            dataGridView1.Columns.Remove("Warehouse_prod_salesOrd");
            
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
            
        }

        private void button1_Click(object sender, EventArgs e)//add 
        {
            ent.insert_W(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
            
            ent.SaveChanges();
           
            dataGridView1.DataSource = ent.Warehouses.ToList();
            dataGridView1.Columns.Remove("Warehouse_prod_PurchOrd");
            dataGridView1.Columns.Remove("Warehouse_prod_salesOrd");
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
            
        }

        private void button3_Click(object sender, EventArgs e)//purchasing
        {
            PurchasingForm pf = new PurchasingForm();
            pf.Show();
        }

        private void button4_Click(object sender, EventArgs e)//sales
        {
            SalesFrom sf = new SalesFrom();
            sf.Show();
        }

        private void button5_Click(object sender, EventArgs e)//WarehouseReport
        {
            WarehouseReport wr = new WarehouseReport();
            wr.Show();
        }
    }
}
