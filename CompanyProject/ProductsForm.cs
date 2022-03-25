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
    public partial class ProductsForm : Form
    {
        CompanyProjectEntities1 ent = new CompanyProjectEntities1();
        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)//onload
        {
            dataGridView1.DataSource = ent.Products.ToList();
            dataGridView1.Columns.Remove("Warehouse_prod_PurchOrd");
            dataGridView1.Columns.Remove("Warehouse_prod_SalesOrd");
            dataGridView1.Columns.Remove("productunits");
           



        }

        private void button1_Click(object sender, EventArgs e)//add
        {
            int id = int.Parse(textBox1.Text);
            var select = (from p in ent.Products where p.Prod_id== id select p).FirstOrDefault();
            if (select != null)// product exists
            {
                ProductUnit pu = new ProductUnit();
                pu.Prod_id = id;
                pu.prod_unit = textBox3.Text;
                ent.ProductUnits.Add(pu);
            }
            else //doesnt exists
            {
                ent.insert_prod(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text);

            }
            ent.SaveChanges();
            dataGridView1.DataSource = ent.Products.ToList();
            dataGridView1.Columns.Remove("Warehouse_prod_PurchOrd");
            dataGridView1.Columns.Remove("Warehouse_prod_SalesOrd");
            dataGridView1.Columns.Remove("productunits");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Items.Clear();
            int selectedIndex = e.RowIndex+1;
            MessageBox.Show(selectedIndex.ToString());
            var u = from x in ent.ProductUnits where x.Prod_id == selectedIndex select x;
            foreach(ProductUnit pu in u )
            {
                comboBox1.Items.Add(pu.prod_unit);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            int id = int.Parse(textBox1.Text);
            var select = (from p in ent.Products where p.Prod_id == id select p).FirstOrDefault();
            if (select != null)// product exists
            {
                ent.update_product(id, textBox2.Text);
                ent.SaveChanges();
                dataGridView1.DataSource = ent.Products.ToList();
                dataGridView1.Columns.Remove("Warehouse_prod_PurchOrd");
                dataGridView1.Columns.Remove("Warehouse_prod_SalesOrd");
                dataGridView1.Columns.Remove("productunits");

            }
            

        }

        private void button3_Click(object sender, EventArgs e)//transfer
        {
            TransferForm tf = new TransferForm();
            tf.Show();
        }

        private void button4_Click(object sender, EventArgs e)//expiration
        {
            ExpirationReport er = new ExpirationReport();
            er.Show();
        }

        private void button5_Click(object sender, EventArgs e)//product
        {
            productReport pr = new productReport();
            pr.Show();
        }

        private void button6_Click(object sender, EventArgs e)//remaining period
        {
            remainingPeriodsReport rpr = new remainingPeriodsReport();
            rpr.Show();
        }
    }
}
