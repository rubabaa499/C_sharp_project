using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.IO;

namespace oop2Project
{
    public partial class FormAdminView : Form
    {
        private string email;
        private int otp;
        private string OTP;
        private string pass;
        private string filePath;
        private OpenFileDialog openFileDialog; //
        private string fileExtension;
        private string newPath;
        private string name;
        private string Address;
        private string Cus_Id;
        private string Emp_Id;
        private string id = ""; //
        private string phn;
        private string nid;
        // private string cpass;
        private string vacc = " ";
        private string imagePath;

        private string vac_id = "N/A";

        SqlConnection con = new SqlConnection(ConString.con);

        string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";


        public FormAdminView()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            displayCusData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string phn = textPhone.Text;
            string address = textAddress.Text;
            string role;

            // Empty Textbox
            if (check(name, address, phn))
            {
                MessageBox.Show("Please fill Name, Address & Phone details");
                return;
            }
            // Name Alphanumeric
            if (!name.All(i => char.IsLetter(i) || i == ' '))
            {
                textName.Focus();
                MessageBox.Show("Name cannot be alphanumeric!");
                return;
            }
            // Phone Alphanumneric
            if (!phn.All(char.IsDigit))
            {
                textPhone.Focus();
                MessageBox.Show("Phone Number must be Numeric digit !!");
                return;
            }

            if (con.State != ConnectionState.Closed)
                con.Close();

            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            // Radio button
            if (rbtnCustomer.Checked && Convert.ToInt32(id) > 0)
            {
                role = "Customer";
                cmd.CommandText = "update Cus set Name = '" + name + "', Address='" + address + "', phn='" + phn
                    + "' where Cus_Id='" + id + "'";
            }
            else if (rbtnEmployee.Checked && Convert.ToInt32(id) > 0)
            {
                role = "Employee";
                cmd.CommandText = "update Emp set Name = '" + name + "', Address='" + address + "', phn='" + phn
                    + "' where Emp_Id='" + id + "'";
            }
            else
            {
                MessageBox.Show("Please Click on the User from the table", "No user selected!");
                return;
            }

            int flag = cmd.ExecuteNonQuery();
            con.Close();

            if (flag > 0) MessageBox.Show(role + " has been updated!"); //
            else MessageBox.Show("Error while updating " + role + "!");

            if (role == "Customer") displayCusData();
            else if (role == "Employee") displayEmpData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }


        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFilter.Text == "Customer")
            {
                displayCusData();
                //hide salary
                textSalary.Visible = false;
                labelSalary.Visible = false;
            }
            else if (comboFilter.Text == "Employee")
            {
                displayEmpData();
                //view salary
                textSalary.Visible = true;
                labelSalary.Visible = true;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboFilter.SelectedIndex);
            if (comboVac.Text == "Yes")
            {
                vacc = "Yes";//
            }
            else if (comboVac.Text == "No")
            {
                vacc = "No";//
            }
            else MessageBox.Show("Select vaccine Status ");
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textemail.Text) == true)
            {
                textemail.Focus();
                errorProvider1.SetError(this.textemail, "Email can'nt be empty");
            }
            else if (Regex.IsMatch(textemail.Text, pattern) == false)
            {
                textemail.Focus();
                errorProvider1.SetError(this.textemail, "Invalid Format");
            }
            else errorProvider1.Clear();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textotp.Text))
            {
                textotp.Focus();
                errorProvider3.SetError(this.textotp, " OTP can't be empty");

            }
            else if (textotp.Text != otp.ToString())
            {
                textotp.Focus();
                errorProvider3.SetError(this.textotp, " Wrong OTP!");
            }
            else
            {
                //btnsubmit1.Enabled = true;
                errorProvider3.Clear();
            }
        }

        private void Send_OTP(string email)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("busticket.booking01@gmail.com");
                msg.To.Add(email);
                msg.Subject = "C# Project Verification Code";
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
        private void button2_Click(object sender, EventArgs e)
        {
            email = textemail.Text;
            Send_OTP(email);
            textotp.Enabled = true;
            textotp.Focus();//
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string role;
            string query;
            string salary = textSalary.Text;
            string cid = "1000";
            string eid = "100";

            name = textName.Text;
            Address = textAddress.Text;
            phn = textPhone.Text;
            nid = textNid.Text;
            pass = textpass.Text;
            email = textemail.Text;
            OTP = textotp.Text;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            // Radio button
            if (rbtnCustomer.Checked)//
            {
                role = "Customer";
                cmd.CommandText = " select Cus_Id from Cus order by Cus_Id desc";//
            }
            else if (rbtnEmployee.Checked)
            {
                role = "Employee";
                cmd.CommandText = " select Emp_Id from Emp order by Emp_Id desc";
            }
            else
            {
                MessageBox.Show("select user ");
                return;
            }

            // Empty Textbox
            if (check(name, Address, phn, nid, pass) || (role == "Employee" && check(salary)))
            {
                MessageBox.Show("Please fill all details");
                return;
            }
            // Name Alphanumeric
            if (!name.All(i => char.IsLetter(i) || i == ' '))
            {
                textName.Focus();
                MessageBox.Show("Name cannot be alphanumeric!");
                return;
            }
            // Phone Alphanumneric
            if (!phn.All(char.IsDigit))
            {
                textPhone.Focus();
                MessageBox.Show("Phone is Only Numeric digit !!");
                return;
            }
            // NID Alphanumeric
            if (!nid.All(char.IsDigit))
            {
                textNid.Focus();
                MessageBox.Show("NID is Only Numeric digit !!");
                return;
            }
            // Salary Alphanumneric
            if (!salary.All(char.IsDigit))
            {
                textSalary.Focus();
                MessageBox.Show("Salary is  Only Numeric digit !!");
                return;
            }
            // No Picture
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please upload an Image!");
                return;
            }
            // No Vaccine Status
            if (comboVac.Text == "Yes/No")
            {
                MessageBox.Show("Please select vaccine status!");
                return;
            }
            // Wrong Otp
            if (otp.ToString() != OTP)
            {
                MessageBox.Show("Wrong OTP");
                return;
            }

            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();

            // Get Id && Insert Profile
            if (role == "Customer")
            {
                if (sdr.HasRows)
                {
                    cid = sdr.GetString(0);
                    Cus_Id = (Convert.ToInt32(cid) + 1).ToString();
                }
                else Cus_Id = cid;

                try
                {
                    newPath = Path.Combine(Environment.CurrentDirectory, @"Images\Customer\" + Cus_Id + Path.GetExtension(filePath));//
                    File.Copy(filePath, newPath, true);//
                }
                catch (Exception exc)//
                {
                    Console.WriteLine(exc);
                    MessageBox.Show("Invalid path!");
                    return;
                }

                query = " Insert into Cus Values('" + name + "','" + Address + "'," +
                "'" + Cus_Id + "','" + phn + "','" + nid + "','" + pass + "','" + email + "'," +
                "'" + vacc + "','" + vac_id + "','" + newPath + "')";
            }

            else if (role == "Employee")
            {
                if (sdr.HasRows)
                {
                    eid = sdr.GetString(0);
                    Emp_Id = (Convert.ToInt32(eid) + 1).ToString();
                }
                else Emp_Id = eid;

                try
                {
                    newPath = Path.Combine(Environment.CurrentDirectory, @"Images\Employee\" + Emp_Id + Path.GetExtension(filePath));
                    File.Copy(filePath, newPath, true);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                    MessageBox.Show("Invalid path!");
                    return;
                }

                query = " Insert into Emp Values('" + name + "','" + Address + "'," +
                "'" + Emp_Id + "','" + phn + "','" + nid + "','" + pass + "','" + email + "'," +
                "'" + vacc + "','" + vac_id + "','" + salary + "','" + newPath + "')";
            }
            else
            {
                MessageBox.Show("Cannot found user");
                sdr.Close();
                con.Close();
                return;
            }

            sdr.Close();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery(); //


            MessageBox.Show(role + " Inserted");
            if (role == "Customer") displayCusData();
            else displayEmpData();
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Supported files|*.jpg;*.jpeg;*.png";
            openFileDialog.ValidateNames = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                filePath = openFileDialog.FileName;
                this.fileExtension = Path.GetExtension(filePath); //Get the file extension
            }

        }

        private void displayCusData()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Cus";
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            if (comboFilter.Text != "Customer")
                comboFilter.Text = "Customer";
           
            textName.Text = "";
            textAddress.Text = "";
            textPhone.Text = "";
            textNid.Text = "";
            //comboVac.Text = "YES/NO";
            //textemail.Text = "";
            //textpass.Text = "";
            //textotp.Text = "";
           textSalary.Text = "";
            pictureBox1.Image = null;
        }

        private void displayEmpData()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Emp";
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            if (comboFilter.Text != "Employee")
                comboFilter.Text = "Employee";
            textName.Text = "";
            textAddress.Text = "";
            textPhone.Text = "";
            textNid.Text = "";
            //comboVac.Text = "YES/NO";
           // textemail.Text = "";
           // textpass.Text = "";
           // textotp.Text = "";
            textSalary.Text = "";
            pictureBox1.Image = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.Value.ToString() == "") return;

            id = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            name = textName.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textAddress.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textNid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textpass.Text = "";//dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textemail.Text = ""; //dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboVac.Text = "";//dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textotp.Text = "";

            //if (comboFilter.Text == "Employee")
            //if (dataGridView1.CurrentRow.Cells[7].OwningColumn.Name == "salary")
            if (Convert.ToInt32(id) < 1000)
            {
                rbtnEmployee.Checked = true;
                textSalary.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                comboFilter.Text = "Employee";
                imagePath = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textSalary.Visible = true;
                labelSalary.Visible = true;
            }
            else
            {
                rbtnCustomer.Checked = true;
                imagePath = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                comboFilter.Text = "Customer";
                textSalary.Visible = false;
                labelSalary.Visible = false;
            }

            if (!File.Exists(imagePath)) Console.WriteLine("File Not Found", imagePath);
            else
            {
                if (pictureBox1.Image != null)//
                    pictureBox1.Image.Dispose();//
                pictureBox1.Image = null;
                pictureBox1.Image = new Bitmap(imagePath);
            }


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string search = textSearch.Text;
            if (search.Length < 1) return;

            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //
            if (comboFilter.Text == "Customer") //
            {
                cmd.CommandText = "select * from Cus where Name like '%" + search + "%'";//

                SqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                // SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (sdr.HasRows)
                {
                    sdr.Close();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    comboFilter.Text = "Customer";//
                                                  //view salary
                    textSalary.Visible = false;
                    labelSalary.Visible = false;
                }

                else
                {
                    MessageBox.Show("Unable to find any user with \"" + search + "\"", "No Result");

                }
                sdr.Close();

                textName.Text = "";
                textAddress.Text = "";
                textPhone.Text = "";
                textNid.Text = "";
               comboVac.Text = "YES/NO";
                textemail.Text = "";
                textpass.Text = "";
                textotp.Text = "";
                textSalary.Text = "";
                pictureBox1.Image = null;
            }
            else
            {
                //sdr.Close();
                cmd.CommandText = "select * from Emp where Name like '%" + search + "%'";
                SqlDataReader sdr1 = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (sdr1.HasRows)
                {
                    sdr1.Close();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    //con.Close();
                    comboFilter.Text = "Employee";
                    //hide salary
                    textSalary.Visible = true;
                    labelSalary.Visible = true;
                }
                else
                    MessageBox.Show("Unable to find any user with \"" + search + "\"", "No Result");

            }
            con.Close();
            textSearch.Text = "";

            textName.Text = "";
            textAddress.Text = "";
            textPhone.Text = "";
            textNid.Text = "";
            comboVac.Text = "YES/NO";
            textemail.Text = "";
            textpass.Text = "";
            textotp.Text = "";
            textSalary.Text = "";
            pictureBox1.Image = null;
        }

        private void rbtnCustomer_Click(object sender, EventArgs e)
        {
            //hide salary
            textSalary.Visible = false;
            labelSalary.Visible = false;
        }

        private void rbtnEmployee_Click(object sender, EventArgs e)
        {
            //view salary
            textSalary.Visible = true;
            labelSalary.Visible = true;
        }

        //Check All Boxes If null or Empty
        public static bool check(params string[] s)
        {
            foreach (string i in s) if (i == null || i == String.Empty)
                    return true;
            return false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("Please Click on the User from below table", "No user selected!");
                return;
            }
            // Id and Name no match
            if (name != textName.Text && imagePath.Length < 1)
            {
                MessageBox.Show("Please Click on the User from below table", "Error finding user!");
                return;
            }

            // Delete Query
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            if (rbtnCustomer.Checked && id != "")
                cmd.CommandText = "Delete from Cus where Cus_Id = '" + id + "'";

            else if (rbtnEmployee.Checked && id != "")
                cmd.CommandText = "Delete from Emp where Emp_Id = '" + id + "'";
            else
            {
                MessageBox.Show("Please Click on the User from below table", "Error finding user!");
                con.Close();
                return;
            }

            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
            //File.GetAccessControl
            File.Delete(imagePath);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User has been deleted", "Deleted!");

            //else MessageBox.Show("No user was deleted", "Error!");
            con.Close();

            if (rbtnCustomer.Checked) displayCusData();
            else displayEmpData();
        }
    }
}
