﻿using System;
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
    public partial class SuppliersForm : Form
    {
        CompanyProjectEntities1 ent = new CompanyProjectEntities1();
        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void SuppliersForm_Load(object sender, EventArgs e)//onload
        {
            dataGridView1.DataSource = ent.Suppliers.ToList();
            dataGridView1.Columns.Remove("purchasingorders");

        }

        private void button1_Click(object sender, EventArgs e)//add
        {
            ent.insert_sup(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), textBox5.Text, textBox6.Text);
        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            ent.update_sup(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), textBox5.Text, textBox6.Text);
        }
    }
}
