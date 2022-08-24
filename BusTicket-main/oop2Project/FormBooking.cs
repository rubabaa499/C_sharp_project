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
    

    public partial class FormBooking : Form
    {
        
        SqlConnection con = new SqlConnection(ConString.con);


        List<string> RouteFrom = new List<string>();
        List<string> BookingSeats = new List<string>();
        List<string> BookedSeats = new List<string>();
        private string From { set; get; }
        private string To { set; get; }
        private string BusId { set; get; }
        private string BusName { set; get; }
        private int fare = 0;

        

        public FormBooking()
        {
            InitializeComponent();
            panelSeat.BackColor = Color.FromArgb(90, Color.AntiqueWhite);
        }

        private void FormBooking_Load(object sender, EventArgs e)
        {
            DateTimePicker.Value = DateTime.Today;
            displayBusData();
            GetRoutes();

            // ComboBoxFrom Items
            int _i = 0;
            while (_i < RouteFrom.Count)
            {
                comboFrom.Items.Add(RouteFrom[_i]);
                _i++;
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            FormProfile CusProfile = new FormProfile();
            this.Hide();
            CusProfile.Tag = this;
            CusProfile.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }

        private void displayBusData()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select BusId as [Serial No], BusName as [Bus Name], BusFrom as [From], BusTo as [To], Time, TFormat as [Format] from Bus";//
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridBusList.DataSource = dt;
            con.Close();
        }

        private void comboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            From = comboFrom.Text;
            comboTo.Items.Clear();//

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Distinct BusTo from Bus Where BusFrom = '" + From + "'";//

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                    comboTo.Items.Add(sdr.GetString(0));
            }

            con.Close();

            // Enable To and Time
            comboTo.Enabled = true;

            // Disable others boxes
            if (DateTimePicker.Enabled || comboTime.Enabled || comboBus.Enabled || btnBookTicket.Enabled)
                DateTimePicker.Enabled = comboTime.Enabled = comboBus.Enabled = btnBookTicket.Enabled = false;
            // Visible select bus
            if (!labelSelectBus.Visible) labelSelectBus.Visible = true;
            // Clear Cost
            if (textCost.Text != "") textCost.Text = "";
            // Disable Seat
            foreach (Button b in panelSeat.Controls.OfType<Button>())//
            {
                if (b.Enabled) b.Enabled = false;
                if (b.Visible) b.Visible = false;
            }

            if (BookingSeats.Count > 0)
                BookingSeats.Clear();//
        }

        private void comboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            To = comboTo.Text;
            comboTime.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Time, TFormat from Bus Where BusFrom='" + From + "' And BusTo ='" + To + "' Order By TFormat";//

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    string BusTime = sdr.GetString(0) + " " + sdr.GetString(1);
                    if (!comboTime.Items.Contains(BusTime))
                        comboTime.Items.Add(BusTime);//
                }
            }

            con.Close();

            // Enable Time
            comboTime.Enabled = true;
            DateTimePicker.Enabled = true;

            // Disable others boxes
            if (comboBus.Enabled || btnBookTicket.Enabled)
                comboBus.Enabled = btnBookTicket.Enabled = false;
            // Visible select bus
            if (!labelSelectBus.Visible) labelSelectBus.Visible = true;
            // Clear Cost
            if (textCost.Text != "") textCost.Text = "";
            // Disable Seat
            foreach (Button b in panelSeat.Controls.OfType<Button>())
            {
                if (b.Enabled) b.Enabled = false;
                if (b.Visible) b.Visible = false;
            }

            if (BookingSeats.Count > 0)
                BookingSeats.Clear();
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)    // Only checks booked seats to show
        {
            
            if (labelSelectBus.Visible) return; // Seats are invisible anyway

            BusId = comboBus.Text.Split('-')[1];//
            BusName = comboBus.Text.Split('-')[0];//
            // Clear Temp Booked Seats
            BookedSeats.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Seat From Ticket Where BusId= '" + BusId + "' And Date='" + DateTimePicker.Value +
                "' And Time='" + comboTime.Text + "' ";

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read()) if (!BookedSeats.Contains(sdr.GetString(0)))
                        BookedSeats.Add(sdr.GetString(0));
            }

            con.Close();

            foreach (Button b in panelSeat.Controls.OfType<Button>())
            {
                // Booked Seat
                if (BookedSeats.Contains(b.Text))
                {
                    b.BackColor = Color.Crimson;
                    b.Enabled = false;
                }
                else if (b.BackColor != Color.Transparent) b.BackColor = Color.Transparent;
                // Enable Other Seats
                if (!BookedSeats.Contains(b.Text) && b.Text != "Driver" && b.Text != "Door" && !b.Enabled)
                    b.Enabled = true;
            }
            if (BookingSeats.Count > 0)
                BookingSeats.Clear();
            textCost.Text = "0";
        }

        private void comboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Time = comboTime.Text.Split(' ')[0];
            string TimeFormat = comboTime.Text.Split(' ')[1];

            comboBus.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select BusId, BusName from Bus Where BusFrom='" + From + "' And BusTo='" + To +
                  "' And Time='" + Time + "' And TFormat='" + TimeFormat + "'";

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    string BusName = sdr.GetString(1) + "-" + sdr.GetString(0);
                    comboBus.Items.Add(BusName);
                }
            }

            con.Close();
            comboBus.Enabled = true;
            // Disable others boxes
            if (btnBookTicket.Enabled) btnBookTicket.Enabled = false;
            // Visible select bus
            if (!labelSelectBus.Visible) labelSelectBus.Visible = true;
            // Clear Cost
            if (textCost.Text != "") textCost.Text = "";
            // Disable Seat
            foreach (Button b in panelSeat.Controls.OfType<Button>())
            {
                if (b.Enabled) b.Enabled = false;
                if (b.Visible) b.Visible = false;
            }

            if (BookingSeats.Count > 0)
                BookingSeats.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String SeatNo = btn.Text;

            if (btn.BackColor != Color.Green)
            {
                btn.BackColor = Color.Green;
                BookingSeats.Add(SeatNo);
            }
            else
            {
                btn.BackColor = Color.Transparent;
                if (BookingSeats.Contains(SeatNo))
                    BookingSeats.Remove(SeatNo);
            }

            UpdateCost();

            // Enable Book Button
            if (BookingSeats.Count > 0)
            {
                if (!btnBookTicket.Enabled)
                    btnBookTicket.Enabled = true;
            }
            else btnBookTicket.Enabled = false;
        }

        private void comboBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusId = comboBus.Text.Split('-')[1];
            BusName = comboBus.Text.Split('-')[0];
            // Clear Temp Booked Seats
            BookedSeats.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Fare From Bus Where BusId= '" + BusId + "'; " +
                "Select Seat From Ticket Where BusId= '" + BusId + "' And Date='" + DateTimePicker.Value +
                "' And Time='" + comboTime.Text + "' ";

            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            fare = Convert.ToInt32(sdr.GetString(0));
            sdr.NextResult();
            if (sdr.HasRows)
            {
                while (sdr.Read()) if (!BookedSeats.Contains(sdr.GetString(0)))
                        BookedSeats.Add(sdr.GetString(0));
            }

            con.Close();

            textCost.Text = "0";
            if (labelSelectBus.Visible) labelSelectBus.Visible = false;//

            foreach (Button b in panelSeat.Controls.OfType<Button>())
            {
                // Booked Seat
                if (BookedSeats.Contains(b.Text)) b.BackColor = Color.Crimson;
                else if (b.BackColor != Color.Transparent) b.BackColor = Color.Transparent;
                // Enable Seat
                if (!BookedSeats.Contains(b.Text) && b.Text != "Driver" && b.Text != "Door" && !b.Enabled)
                    b.Enabled = true;
                // Visible Seat
                if (!b.Visible)
                    b.Visible = true;
            }
        }

        private void UpdateCost()
        {

            fareclc calc1 = delfare1.dld;
            
            
            textCost.Text = calc1(fare, BookingSeats.Count).ToString();

                //(fare , BookingSeats.Count).ToString();
        }
         
        

        private void GetRoutes()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Bus";

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (!RouteFrom.Contains(sdr.GetString(2)))
                        RouteFrom.Add(sdr.GetString(2));
                }
            }
            con.Close();
        }

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            // Same Route
            if (comboTo.Text == comboFrom.Text)
            {
                MessageBox.Show("Please change route!");
                return;
            }

            string TicketId;
            DateTime Date = DateTimePicker.Value;
            string Time = comboTime.Text;
            int count = 0;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select TicketId From Ticket Order by TicketId desc";
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                sdr.Read();
                TicketId = (Convert.ToInt32(sdr.GetString(0)) + 1).ToString();
            }
            else TicketId = "1000";
            sdr.Close();

            BookingSeats.Sort((a, b) => b.CompareTo(a));
            foreach (string Seat in BookingSeats)
            {
                cmd.CommandText = " Insert into Ticket Values('" + TicketId + "','" + Seat + "','" + Form1.Cus_Id + "','" +
                BusId + "','" + Date + "','" + Time + "')";

                TicketId = (Convert.ToInt32(TicketId) + 1).ToString();
                int flag = cmd.ExecuteNonQuery();
                if (flag > 0) count++;
            }
            con.Close();

            if (count == BookingSeats.Count)
            {
                MessageBox.Show("Ticket(s) booked for " + BusName + " on " + Date.ToShortDateString() + " at " + Time);

                foreach (Button b in panelSeat.Controls.OfType<Button>())
                {
                    if (BookingSeats.Contains(b.Text))
                    {
                        if (b.Enabled) b.Enabled = false;
                        b.BackColor = Color.Crimson;
                    }
                }
            }
            else MessageBox.Show("Error booking one or multiple tickets");
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            new FormBookingHistory().Show();
            this.Close();
        }

        private void dataGridBusList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Bus;
            string Time;

            comboFrom.Text = dataGridBusList.CurrentRow.Cells[2].Value.ToString();
            comboTo.Text = dataGridBusList.CurrentRow.Cells[3].Value.ToString();
            Time = dataGridBusList.CurrentRow.Cells[4].Value.ToString();
            Time += " " + dataGridBusList.CurrentRow.Cells[5].Value.ToString();
            comboTime.Text = Time;
            Bus = dataGridBusList.CurrentRow.Cells[1].Value.ToString();
            Bus += "-" + dataGridBusList.CurrentRow.Cells[0].Value.ToString();
            comboBus.Text = Bus;
        }
    }
    
}
