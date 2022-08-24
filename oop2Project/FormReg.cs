using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace oop2Project
{
    public partial class FormReg : Form
    {

        string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        SqlConnection con = new SqlConnection(ConString.con);

        private string name;
        private string Address;
        private string Cus_Id;
        private string phn;
        private string nid;
        private string pass;
        private string cpass;
        private string email;
        private string vacc = "";
        private string OTP;
        private int otp;
        private string filePath;
        private OpenFileDialog openFileDialog;
        private string fileExtension;
        private string newPath;
        private string vac_id;
        private bool autocorrect = true;

        public FormReg()
        {
            InitializeComponent();
        }

        private void Send_OTP(string email)
        {
            // Validating E-mail NOT WORKING 
            var data = ValidateEmail(email);

            if (data["autocorrect"] != "" && autocorrect)
            {
                autocorrect = false;
                MessageBox.Show("Is your e-mail " + data["autocorrect"] + "?", "Please re-check your e-mail");
                return;
            }

            if (data["deliverability"] == "UNDELIVERABLE")
            {
                MessageBox.Show("Please provide a Valid E-mail!");
                return;
            }


            // Sending OTP
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

                MessageBox.Show("Your OTP is sent to your Mail.", "Please check your e-mail");

            }
            catch (Exception ex)
            {
                Console.WriteLine("[Unsent OTP]", ex);
                MessageBox.Show("Error sending OTP!");
            }
        }

        private void btnsubmit1_Click(object sender, EventArgs e)
        {
            name = textName.Text.Trim();
            Address = textAddress.Text;
            phn = textPhone.Text;
            nid = textNid.Text;
            pass = textPass.Text.Trim();
            cpass = textCPass.Text;
            email = textEmail.Text.Trim();
            OTP = textOtp.Text;

            if (vacc == "Yes") vac_id = textVacId.Text;
            else vac_id = "N/A";

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please upload an Image!");
                return;
            }

            if (otp.ToString() != OTP)
            {
                MessageBox.Show("Wrong OTP");
                return;
            }

            // Cus_Id
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string query0 = " select  Cus_Id from Cus order by Cus_Id desc";

            cmd.CommandText = query0;
            SqlDataReader sdr = cmd.ExecuteReader();
            string id1 = "1000";
            if (sdr.HasRows)
            {
                sdr.Read();
                id1 = sdr.GetString(0);

                Cus_Id = (Convert.ToInt32(id1) + 1).ToString();
            }
            else Cus_Id = id1;

            // Image copy
            try
            {
                newPath = Path.Combine(Environment.CurrentDirectory, @"Images\Customer\" + Cus_Id + Path.GetExtension(filePath));
                File.Copy(filePath, newPath, true);
            }
            catch (Exception exc)//
            {
                con.Close();
                Console.WriteLine(exc);
                MessageBox.Show("Invalid path!");
                return;
            }

            sdr.Close();
            string query = " Insert into Cus Values('" + name + "','" + Address + "'," +
                "'" + Cus_Id + "','" + phn + "','" + nid + "','" + pass + "','" + email + "'," +
            "'" + vacc + "','" + vac_id + "','" + newPath + "')";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            /*
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb11 = new DataTable();
            sda.Fill(dtb11);*/


            MessageBox.Show("Registration Successfull");
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Tag = this;
            log.Show();
            this.Close();
        }
        public static bool check(params string[] s)
        {
            foreach (string i in s)
            {
                if (i == null || i == String.Empty)
                    return true;
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            vacc = "Yes";
            btnVacYes.BackColor = Color.Green;
            if (btnVacNo.BackColor == Color.Green)
                btnVacNo.UseVisualStyleBackColor = true;
            textVacId.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vacc = "No";
            btnVacNo.BackColor = Color.Green;
            if (btnVacYes.BackColor == Color.Green)
                btnVacYes.UseVisualStyleBackColor = true;
            textVacId.Enabled = false;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            textOtp.Enabled = true;
            btnOtp.Enabled = false;

            email = textEmail.Text;
            Send_OTP(email);
            await Task.Delay(10000); //
            btnOtp.Enabled = true;
            textOtp.Focus();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textName.Text) == true)
            {
                textName.Focus();
                errorProvider1.SetError(this.textName, "name cannot be empty");
            }
            else
            {
                if (!textName.Text.All(i => char.IsLetter(i) || i == ' '))
                {
                    textName.Focus();
                    errorProvider1.SetError(this.textName, "Name cannot be alphanumeric!");
                }
                else
                    errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textAddress.Text) == true)
            {
                textAddress.Focus();
                errorProvider2.SetError(this.textAddress, "address can't be empty");
            }
            else
                errorProvider2.Clear();

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textPhone.Text) == true)
            {
                textPhone.Focus();
                errorProvider3.SetError(this.textPhone, "Phone Number can't be empty");
            }
            else
            {
                if (!textPhone.Text.All(char.IsDigit))
                {
                    textPhone.Focus();
                    errorProvider3.SetError(this.textPhone, " Only Numeric digit !!");
                }
                else if (textPhone.Text.Length != 11)
                {
                    textPhone.Focus();
                    errorProvider3.SetError(this.textPhone, " Must Be 11 Digit !!");
                }

                else
                    errorProvider3.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textNid.Text) == true)
            {
                textNid.Focus();
                errorProvider4.SetError(this.textNid, " NID can't be empty");
            }
            else
            {
                if (!textNid.Text.All(char.IsDigit))
                {
                    textNid.Focus();
                    errorProvider4.SetError(this.textNid, " Only Numeric digit !!");
                }
                else
                    errorProvider4.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textPass.Text) == true)
            {
                textPass.Focus();
                errorProvider5.SetError(this.textPass, "password can'nt be empty");
            }
            else if (textPass.Text.Trim().Length < 5)
            {
                textPass.Focus();
                errorProvider5.SetError(this.textPass, "Password Can't Be less than 5");
            }
            else
                errorProvider5.Clear();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textCPass.Text) == true)
            {
                textCPass.Focus();
                errorProvider6.SetError(this.textCPass, "Confirm password can'nt be empty");
            }
            else if (this.textCPass.Text != textPass.Text)
            {
                textCPass.Focus();
                errorProvider6.SetError(this.textCPass, "Password MisMatch");
            }
            else
            {
                errorProvider6.Clear();
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textOtp.Text) == true)
            {
                textOtp.Focus();
                errorProvider8.SetError(this.textOtp, " verification cannot be empty");

            }
            else if (textOtp.Text != otp.ToString())
            {
                textOtp.Focus();
                errorProvider8.SetError(this.textOtp, " Wrong OTP!");
            }
            else
            {
                btnsubmit1.Enabled = true;
                errorProvider8.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void textVacId_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textVacId.Text) == true)
            {
                textVacId.Focus();
                errorProvider9.SetError(this.textVacId, "Vaccination Id cannot be empty");
            }
            else
            {
                if (!textVacId.Text.All(char.IsDigit))
                {
                    textVacId.Focus();
                    errorProvider9.SetError(this.textVacId, " Only Numeric digit !!");
                }
                else
                    errorProvider9.Clear();
            }
        }

        private dynamic ValidateEmail(string emailToValidate)
        {
            dynamic data;
            try
            {
                string apiKey = "a99e548d4e1b4684a2bcfc37b72f1a2f";    // Replace API_KEY with your API Key
                string responseString = "";
                string apiURL2 = "https://emailvalidation.abstractapi.com/v1/?api_key=" + apiKey + "&email=" + emailToValidate;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL2);
                request.Method = "GET";

                using (WebResponse response = request.GetResponse())
                {
                    Encoding enc = Encoding.GetEncoding(1252); // Windows default Code Page
                    using (StreamReader ostream = new StreamReader(response.GetResponseStream(), enc))
                    {
                        responseString = ostream.ReadToEnd();
                    }
                }

                data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseString);
                return data;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());   //Catch Exception - All errors will be shown here - if there are issues with the API
                return null;
            }
        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEmail.Text) == true)
            {
                textEmail.Focus();
                errorProvider7.SetError(this.textEmail, "Email canont be empty");
            }

            else if (Regex.IsMatch(textEmail.Text, pattern) == false)
            {
                textEmail.Focus();
                errorProvider7.SetError(this.textEmail, "Invalid Format");
            }
            else
            {

                string query1 = " select email from Cus where email= '" + textEmail.Text.Trim() + "'";
                string query2 = " select email from Emp where email= '" + textEmail.Text.Trim() + "'";

                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dtb11 = new DataTable();
                SqlDataAdapter sdae = new SqlDataAdapter(query2, con);
                DataTable dtb12 = new DataTable();
                sda.Fill(dtb11);
                sdae.Fill(dtb12);

                if (dtb11.Rows.Count == 1)
                {
                    textEmail.Focus();
                    errorProvider7.SetError(this.textEmail, "Email Already Exist");
                    btnOtp.Enabled = false;
                }
                else if (dtb12.Rows.Count == 1)
                {
                    textEmail.Focus();
                    errorProvider7.SetError(this.textEmail, "Email Already Exist");
                    btnOtp.Enabled = false;
                }

                else
                {
                    errorProvider7.Clear();
                    btnOtp.Enabled = true;
                }
            }

        }
    }
}
