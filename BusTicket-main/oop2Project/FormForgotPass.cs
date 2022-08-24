using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop2Project
{
    public partial class FormForgotPass : Form
    {
        public int otp;
        SqlConnection con = new SqlConnection(ConString.con);


        public FormForgotPass()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "update Cus set pass = '" + textBox3.Text + "' where email = '" + textBox1.Text + "'";

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Password Change Successfull");

                Form1 f1 = new Form1();
                this.Hide();
                f1.Tag = this;
                f1.Show();

            }
            /* else
             {
                 MessageBox.Show(" Password MissMatch ");
             }*/

        }

        private void send_otp(string email)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("busticket.booking01@gmail.com");
                msg.To.Add(textBox1.Text);
                msg.Subject = "Your Recovery OTP ";
                Random rand = new Random();
                otp = rand.Next(1000, 9999);
                msg.Body = otp.ToString();

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "busticket.booking01@gmail.com";
                ntcd.Password = "Project001";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);

                MessageBox.Show("Your Mail is sended");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            send_otp(textBox1.Text);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            string query = " select email from Cus where email= '" + textBox1.Text.Trim() + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb11 = new DataTable();
            sda.Fill(dtb11);

            if (dtb11.Rows.Count == 1)
            {

                errorProvider1.Clear();
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                // MessageBox.Show("Email Address does not exist");
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Email Address does not exist");

            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, " verrification can'nt be empty");

            }
            else if (textBox2.Text != otp.ToString())
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, " Wrong OTP!");
            }
            else
            {
                // btnsubmit1.Enabled = true;
                errorProvider2.Clear();

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, " Password can'nt be empty");

            }
            else
            {
                // btnsubmit1.Enabled = true;
                button2.Enabled = true;
                errorProvider3.Clear();

            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, " Password can'nt be empty");

            }
            if (textBox4.Text != textBox3.Text)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, " Password MisMatch");

            }

            else
            {
                // btnsubmit1.Enabled = true;

                errorProvider4.Clear();

            }
        }
    }
}
