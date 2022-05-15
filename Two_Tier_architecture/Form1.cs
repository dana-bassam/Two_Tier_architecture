using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Two_Tier_architecture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=SoftwareArchitectureCourse;Integrated Security=True");


        private void load_data()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Register", conn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            conn.Close();
        }


        private void btnsave_Click_1(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "" || txtsalery.Text == "" || txttax.Text == "" || txtage.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("please fill the cell first");
            }
            else
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("insert into Register(id,name,gender,salery,age,tax)values('" + txtid.Text + "','" + txtname.Text + "','" + comboBox1.Text + "','" + txtsalery.Text + "','" + txtage.Text + "','" + txttax.Text + "')", conn);

                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("data entered succesfully");
                panel1.Enabled = false;

            }
        }

        private void btnview_Click_1(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            load_data();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (panel1.Enabled == true)
            {

                if (txtid.Text == "" || txtname.Text == "" || txtsalery.Text == "" || txttax.Text == "" || txtage.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("please fill the cell first");
                }
                else
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("UPDATE Register SET id ='" + txtid.Text + "',name = '" + txtname.Text + "',Gender = '" + comboBox1.Text + "', Salery = '" + txtsalery.Text + "',age = '" + txtage.Text + "',tax = '" + txttax.Text + "' where id ='" + txtid.Text + "'", conn);

                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("data updated succesfully");
                    load_data();
                    panel1.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("please select what you want to update");
            }
        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            if (panel1.Enabled == true)
            {

                if (txtid.Text == "" || txtname.Text == "" || txtsalery.Text == "" || txttax.Text == "" || txtage.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("please select the record");
                }
                else
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("delete from Register where id ='" + txtid.Text + "'", conn);

                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("data deleted succesfully");
                    load_data();
                    panel1.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("please select the record first");
            }
        }

        private void btnnew_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = false;
            panel1.Enabled = true;

            txtid.Text = "";
            txtname.Text = "";
            txtsalery.Text = "";
            txtage.Text = "";
            txttax.Text = "";
            comboBox1.Text = "";
        }

        private void srchbtn_Click_1(object sender, EventArgs e)
        {
            if (txtnamesrch.Text == "")
            {
                MessageBox.Show("cells are empty");
            }

            else
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Register where name LIKE '%" + txtnamesrch.Text + "%'", conn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Enabled = true;
            txtid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtsalery.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtage.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txttax.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
