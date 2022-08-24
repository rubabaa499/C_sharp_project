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

namespace oop2Project
{
    public partial class FormEmployeeView : Form
    {
        SqlConnection con = new SqlConnection(ConString.con);
        private string BusId = "";
        List<string> Route = new List<string>() { "Dhaka", "Coxs Bazar", "Sylhet", "Barisal", "Rajshashi" };
        private string CancelId;
        private string TicketId;

        public FormEmployeeView()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Tag = this;
            login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            FormProfile EmpProfile = new FormProfile();
            this.Hide();
            EmpProfile.Tag = this;
            EmpProfile.Show();
        }

        private void FormViewEmployee_Load(object sender, EventArgs e)
        {
            displayBusData();
            AddCancelRequests();
            // ComboBox From-To Items
            int _i = 0;
            while (_i < Route.Count)
            {
                comboTo.Items.Add(Route[_i]);
                comboFrom.Items.Add(Route[_i]);
                _i++;
            }
        }

        private void dataGridBusList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridBusList.CurrentCell.Value.ToString() == "") return;

            textBusName.Text = dataGridBusList.CurrentRow.Cells[1].Value.ToString();
            BusId = textBusSerial.Text = dataGridBusList.CurrentRow.Cells[0].Value.ToString();
            comboFrom.Text = dataGridBusList.CurrentRow.Cells[2].Value.ToString().Replace(",", " - ");
            comboTo.Text = dataGridBusList.CurrentRow.Cells[3].Value.ToString().Replace(",", " - ");
            comboTime.Text = dataGridBusList.CurrentRow.Cells[4].Value.ToString();
            comboFormat.Text = dataGridBusList.CurrentRow.Cells[5].Value.ToString();
            textFare.Text = dataGridBusList.CurrentRow.Cells[6].Value.ToString();
            ShowSerial();
        }

        private void displayBusData()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select BusId as [Serial No], BusName as [Bus Name], BusFrom as [From], BusTo as [To], Time, TFormat as [Format], Fare From Bus";
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridBusList.DataSource = dt;
            con.Close();
        }

        private void AddCancelRequests()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select CancelTicket.CancelId " +
                "From ((CancelTicket " +
                "INNER JOIN Ticket ON CancelTicket.TicketId = Ticket.TicketId) " +
                "INNER JOIN Cus ON CancelTicket.Cus_Id = Cus.Cus_Id) " +
                "ORDER By CancelTicket.CancelId;";

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows) while (sdr.Read())
                    comboRequests.Items.Add(sdr.GetString(0));

            con.Close();
        }

        private void btnAddBus_Click_1(object sender, EventArgs e)
        {
            string id = "1000";
            string BusName = textBusName.Text;
            string From = comboFrom.Text;
            string To = comboTo.Text;
            string Time = comboTime.Text;
            string TFormat = comboFormat.Text;
            string Fare = textFare.Text;

            // No Route
            if (From == "" || To == "" || To == From)
            {
                MessageBox.Show("Please select Route!");
                return;
            }
            // No Fare
            if (Fare == "" || !Fare.All(char.IsDigit))
            {
                textFare.Focus();
                MessageBox.Show("Please type Seat Fare in numeric!");
                return;
            }
            // No Time
            if (Time == "" || TFormat == "")
            {
                MessageBox.Show("Please select Time!");
                return;
            }

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select BusId from Bus order by BusId desc";

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                sdr.Read();
                id = sdr.GetString(0);

                BusId = (Convert.ToInt32(id) + 1).ToString();
            }
            else BusId = id;
            sdr.Close();

            cmd.CommandText = " Insert into Bus Values('" + BusId + "','" + BusName + "','" +
                From + "','" + To + "','" + Time + "','" + TFormat + "','" + Fare + "')";

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(BusName + " has been Added!");
            displayBusData();
            comboFrom.Text = comboTo.Text = comboTime.Text = comboFormat.Text = null;
            textBusName.Text = textBusSerial.Text = textFare.Text = BusId = null;
            HideSerial();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // No Bus_Id
            if (BusId == "")
            {
                MessageBox.Show("Please Click on the bus from below table.", "Bus Serial is not selected!");
                return;
            }

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from Bus where BusId = '" + BusId + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Bus-" + BusId + " has been Deleted!");
            displayBusData();
            comboFrom.Text = comboTo.Text = comboTime.Text = comboFormat.Text = null;
            textBusName.Text = textBusSerial.Text = textFare.Text = BusId = null;
            HideSerial();
        }

        private void HideSerial()
        {
            textBusSerial.Visible = false;
            labelSerial.Visible = false;
        }

        private void ShowSerial()
        {
            textBusSerial.Visible = true;
            labelSerial.Visible = true;
        }

        private void comboRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            CancelId = comboRequests.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select CancelTicket.Cus_Id, Cus.Name, CancelTicket.TicketId, Ticket.Seat " +
                "From ((CancelTicket " +
                "INNER JOIN Ticket ON CancelTicket.TicketId = Ticket.TicketId) " +
                "INNER JOIN Cus ON CancelTicket.Cus_Id = Cus.Cus_Id) " +
                "Where CancelTicket.CancelId='" + CancelId + "'";

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                labelCus_Id.Text = sdr.GetString(0);
                labelCusName.Text = sdr.GetString(1);
                TicketId = labelTicketId.Text = sdr.GetString(2);
                labelSeatNo.Text = sdr.GetString(3);

                btnAccept.Enabled = true;
                btnReject.Enabled = true;
            }
            else MessageBox.Show("Error receiving cancel request!");
            con.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "Delete From CancelTicket Where CancelId = '" + CancelId + "';" +
                "Delete From Ticket Where TicketId = '" + TicketId + "';";
            if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Ticket has been cancelled!");
            else MessageBox.Show("Error cancelling Ticket!");
            con.Close();

            labelCus_Id.Text = labelCusName.Text = labelTicketId.Text = labelSeatNo.Text = "_";
            comboRequests.Items.Remove(CancelId);
            btnAccept.Enabled = btnReject.Enabled = false;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "Delete From CancelTicket Where CancelId = '" + CancelId + "';";

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Request has been rejected!");
                comboRequests.Items.Remove(CancelId);
            }
            else MessageBox.Show("Error rejecting Request!");
            con.Close();
        }
    }
}
