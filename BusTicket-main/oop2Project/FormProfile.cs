using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//ffffffff
namespace oop2Project
{
    public partial class FormProfile : Form
    {
        private string role;

        SqlConnection con = new SqlConnection(ConString.con);
        private string vid;
        public FormProfile()
        {
            InitializeComponent();
        }

        private void butconfirm_Click(object sender, EventArgs e)
        {
            if (textConfirmPass.Text != "" && textPass.Text != "")
            {
                if (textConfirmPass.Text == textPass.Text)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    if (role == "Customer")
                        cmd.CommandText = "update Cus set pass = '" + textConfirmPass.Text + "' where Cus_Id='" + Form1.Cus_Id + "'";
                    else
                        cmd.CommandText = "update Emp set pass = '" + textConfirmPass.Text + "' where Emp_Id='" + Form1.Emp_Id + "'";

                    int flag = cmd.ExecuteNonQuery();
                    con.Close();

                    if (flag > 0)
                    {
                        MessageBox.Show("Password Change Successfull");
                        this.textPass.Text = "";
                        this.textConfirmPass.Text = "";
                    }
                    else MessageBox.Show("Error changing Password!");
                }
                else MessageBox.Show(" Password MissMatch ");
            }

            else
            {
                MessageBox.Show(" please enter Password  ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (role == "Customer")
            {
                FormBooking cus = new FormBooking();
                this.Hide();
                cus.Tag = this;
                cus.Show();
            }
            else
            {
                FormEmployeeView emp = new FormEmployeeView();
                this.Hide();
                emp.Tag = this;
                emp.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string query;

            if (Form1.Cus_Id != "" && Form1.Emp_Id == "")
            {
                query = " select  * from Cus where Cus_Id='" + Form1.Cus_Id + "'";
                role = "Customer";
            }

            else if (Form1.Cus_Id == "" && Form1.Emp_Id != "")
            {
                query = " select  * from Emp where Emp_Id='" + Form1.Emp_Id + "'";
                role = "Employee";
            }
            else return;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();

            textName.Text = sdr.GetString(0);
            textAddress.Text = sdr.GetString(1);
            textPhone.Text = sdr.GetString(3);
            textEmail.Text = sdr.GetString(6);
            vid = textVac.Text = sdr.GetString(8);
            string imagePath;

            if (role == "Employee")
                imagePath = sdr.GetString(10);
            else
                imagePath = sdr.GetString(9);

            if (imagePath != "")
            {
                if (pictureBox1.Image != null)
                    pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                pictureBox1.Image = new Bitmap(imagePath);
            }

            con.Close();

            if (vid == "N/A" || vid == "")
            {
                btnUpdate.Enabled = true;
                textVac.Text = "N/A";
            }
            else textVac.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vid == "N/A" || vid == "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                if (role == "Customer")
                    cmd.CommandText = "update Cus set vacc = 'Yes', vac_id = '" + textVac.Text + "' where Cus_Id='" + Form1.Cus_Id + "'";
                else
                    cmd.CommandText = "update Emp set vacc = 'Yes', vac_id = '" + textVac.Text + "' where Emp_Id='" + Form1.Emp_Id + "'";

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Vaccine Information update Successfull");
                btnUpdate.Enabled = false;
            }
        }
    }
}
