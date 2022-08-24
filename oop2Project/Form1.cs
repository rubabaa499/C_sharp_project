using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace oop2Project
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConString.con);
        public static string user;
        public static string Cus_Id;
        public static string Emp_Id;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormForgotPass frgt = new FormForgotPass();
            this.Hide();
            frgt.Tag = this;//
            frgt.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string email = txtusername.Text.Trim();
            string pass = txtpassword.Text.Trim();

            if (email == "admin" && txtpassword.Text == "123")
            {
                FormAdminView admin = new FormAdminView();
                this.Hide();
                admin.Tag = this;
                admin.Show();
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cus where email='" + email + "';" +
                    "select * from Emp where email='" + email + "';";
                
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows == true)
                {
                    cmd.CommandText = ("select * from Cus where email='" + email + "'and pass='" + pass + "' ");
                    sdr.Close();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        user = email;
                        Cus_Id = sdr.GetString(2);
                        FormBooking Cus = new FormBooking();
                        this.Hide();
                        Cus.Tag = this;
                        Cus.Show();
                    }
                    else MessageBox.Show("Wrong Pass");
                }
                else
                {
                    sdr.NextResult();//
                    if (sdr.HasRows)
                    {
                        sdr.Close();
                        cmd.CommandText = ("select * from  Emp where email='" + email + "'and pass='" + pass + "'");
                        sdr = cmd.ExecuteReader();

                        if (sdr.HasRows)
                        {
                            sdr.Read();
                            user = email;
                            Emp_Id = sdr.GetString(2);

                            FormEmployeeView Emp = new FormEmployeeView();
                            this.Hide();
                            Emp.Tag = this;
                            Emp.Show();
                        }
                        else MessageBox.Show("Wrong Pass");
                    }
                    else MessageBox.Show("Invalid Username/Password");
                }
                con.Close();
            }
        }

        private void btnlogin_MouseEnter(object sender, EventArgs e)
        {
            btnlogin.BackColor = Color.GreenYellow;
        }

        private void btnlogin_MouseLeave(object sender, EventArgs e)
        {
            btnlogin.BackColor = SystemColors.ActiveCaption;///
        }

        private void btnregistration_Click(object sender, EventArgs e)
        {
            FormReg Reg = new FormReg();
            this.Hide();
            Reg.Tag = this;
            Reg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Emp_Id = ""; //
            Cus_Id = ""; //
        }
    }
}
