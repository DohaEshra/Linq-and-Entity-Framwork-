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
    public partial class PurchasingForm : Form
    {
        CompanyProjectEntities1 ent = new CompanyProjectEntities1();
        public PurchasingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//add
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                var select = (from o in ent.PurchasingOrders where o.po_id == id select o).FirstOrDefault();
                var sss = (from s in ent.Suppliers where s.Sup_name == comboBox1.SelectedItem select s.Sup_name).First();
                var ppp = (from pr in ent.Products where pr.Prod_name == comboBox2.SelectedItem select pr.Prod_id).First();

              
                if (select != null)// po exists
                {
                    Warehouse_prod_PurchOrd wpp = new Warehouse_prod_PurchOrd();
                    wpp.Po_id= int.Parse(textBox1.Text);
                    wpp.W_name = textBox3.Text;
                    wpp.Prod_id = ppp;
                    wpp.quantity = int.Parse(textBox5.Text);
                    wpp.production_date = Convert.ToDateTime(textBox6.Text).Date;
                    wpp.Expiration_Dur = int.Parse(textBox7.Text);
                    ent.Warehouse_prod_PurchOrd.Add(wpp);
                    warehouse_products wp = (from w in ent.warehouse_products where w.prod_id == ppp select w).FirstOrDefault();
                    wp.quantity += wpp.quantity;
                    



            }
                else if(select ==null) //doesnt exist
            {

                var p = ent.insert_PurchasingOrder(int.Parse(textBox1.Text), DateTime.Today.Date, sss, textBox3.Text, ppp, int.Parse(textBox5.Text), Convert.ToDateTime(textBox6.Text).Date, int.Parse(textBox7.Text)).FirstOrDefault();
                  
                    
                   
               

                }
                ent.SaveChanges();
               
            }
            catch(Exception error)
            {
                
            }
            ent.SaveChanges();
            dataGridView1.DataSource = ent.Warehouse_prod_PurchOrd.ToList();
        
            dataGridView1.Columns.Remove("product");
            dataGridView1.Columns.Remove("purchasingorder");
            dataGridView1.Columns.Remove("warehouse");
            textBox1.Text = textBox3.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
           

        }

        private void PurchasingForm_Load(object sender, EventArgs e)//onload
        {
           
            dataGridView1.DataSource = ent.Warehouse_prod_PurchOrd.ToList();
            dataGridView1.Columns.Remove("product");
            dataGridView1.Columns.Remove("purchasingorder");
            dataGridView1.Columns.Remove("warehouse");
            var sups = from s in ent.Suppliers select s;
            foreach (Supplier s in sups)
            {
                comboBox1.Items.Add(s.Sup_name);
            }
            var prods = from p in ent.Products select p;
            foreach (Product p in prods)
            {
                comboBox2.Items.Add(p.Prod_name);
            }



        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            var sss = (from s in ent.Suppliers where s.Sup_name == comboBox1.SelectedItem select s.Sup_name).First();
            var ppp = (from pr in ent.Products where pr.Prod_name == comboBox2.SelectedItem select pr.Prod_id).First();

            ent.update_PurchasingOrder(int.Parse(textBox1.Text), DateTime.Today, sss, textBox3.Text, ppp, int.Parse(textBox5.Text), Convert.ToDateTime(textBox6.Text), int.Parse(textBox7.Text));
            ent.SaveChanges();
            dataGridView1.DataSource = ent.Warehouse_prod_PurchOrd.ToList();

            dataGridView1.Columns.Remove("product");
            dataGridView1.Columns.Remove("purchasingorder");
            dataGridView1.Columns.Remove("warehouse");
            textBox1.Text  = textBox3.Text  = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;

        }

        private void button3_Click(object sender, EventArgs e)//add supplier
        {
            SuppliersForm sf = new SuppliersForm();
            sf.Show();
        }

        private void button4_Click(object sender, EventArgs e)//add product 
        {
            ProductsForm pf = new ProductsForm();
            pf.Show();
        }
    }
}
