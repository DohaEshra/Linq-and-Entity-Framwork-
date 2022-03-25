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
    public partial class SalesFrom : Form
    {
        CompanyProjectEntities1 ent = new CompanyProjectEntities1();
        public SalesFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//add
        {
            int id = int.Parse(textBox1.Text);
            var select = (from o in ent.SalesOrders where o.so_ID == id select o).FirstOrDefault();
            var ppp = (from p in ent.Products where p.Prod_name == comboBox1.SelectedItem select p.Prod_id).First();
            var ccc = (from c in ent.Customers where c.Cst_name == comboBox2.SelectedItem select c.Cst_name).First();

            if (select != null)// exists
            {
                Warehouse_prod_salesOrd wps = new Warehouse_prod_salesOrd();
                wps.so_ID = int.Parse(textBox1.Text);
                wps.W_name = textBox3.Text;
                wps.Prod_id = ppp;
                wps.quantity = int.Parse(textBox5.Text);
          
                ent.Warehouse_prod_salesOrd.Add(wps);
               

            }
            else //doesnt exist
            {
                
                  ent.insert_SalesOrder(int.Parse(textBox1.Text), DateTime.Today, ccc, textBox3.Text, ppp, int.Parse(textBox5.Text));
                
               
                
            }
            ent.SaveChanges();
            dataGridView1.DataSource = ent.Warehouse_prod_salesOrd.ToList();
            dataGridView1.Columns.Remove("product");
            dataGridView1.Columns.Remove("salesorder");
            dataGridView1.Columns.Remove("warehouse");
            textBox1.Text  = textBox3.Text  = textBox5.Text = string.Empty;

        }

        private void SalesFrom_Load(object sender, EventArgs e)//onload
        {
            dataGridView1.DataSource = ent.Warehouse_prod_salesOrd.ToList();
            dataGridView1.Columns.Remove("product");
            dataGridView1.Columns.Remove("salesorder");
            dataGridView1.Columns.Remove("warehouse");
            var products = from p in ent.Products select p;
            foreach(Product pp in products)
            {
                comboBox1.Items.Add(pp.Prod_name);
            }
            var customerss = from c in ent.Customers select c;
            foreach (Customer cc in customerss)
            {
                comboBox2.Items.Add(cc.Cst_name);
            }
        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            var ppp = (from p in ent.Products where p.Prod_name == comboBox1.SelectedItem select p.Prod_id).First();
            var ccc = (from c in ent.Customers where c.Cst_name == comboBox2.SelectedItem select c.Cst_name).First();

            ent.update_SalesOrder(int.Parse(textBox1.Text), DateTime.Today, ccc, textBox3.Text, ppp, int.Parse(textBox5.Text));
            dataGridView1.DataSource = ent.Warehouse_prod_salesOrd.ToList();
            dataGridView1.Columns.Remove("product");
            dataGridView1.Columns.Remove("salesorder");
            dataGridView1.Columns.Remove("warehouse");
            textBox1.Text  = textBox3.Text = textBox5.Text = string.Empty;


        }

        private void button3_Click(object sender, EventArgs e)// add customer
        {
            CustomersForm cf = new CustomersForm();
            cf.Show();
        }
    }
}
