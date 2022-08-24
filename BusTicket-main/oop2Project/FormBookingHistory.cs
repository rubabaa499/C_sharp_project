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
    public partial class FormBookingHistory : Form
    {
        SqlConnection con = new SqlConnection(ConString.con);

        public FormBookingHistory()
        {
            InitializeComponent();
        }

        private void comboCancelTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
        }

        private void FormBookingHistory_Load(object sender, EventArgs e)
        {
            displayHistory();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string TicketId = comboTickets.Text;
            string CancelId;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select TicketId, Date From Ticket Where TicketId='" + TicketId + "' And Cus_Id='" + Form1.Cus_Id + "'";

            SqlDataReader sdr = cmd.ExecuteReader();
            if (!sdr.HasRows)   // No Tickets Found
            {
                MessageBox.Show("Please select a ticket", "Ticket not found!");
                con.Close();
                return;
            }

            sdr.Read();
            if (sdr.GetDateTime(1) < DateTime.Today)    // Past Tickets
            {
                MessageBox.Show("Sorry, Cannot cancel the ticket!", "Ticket past cancellation period");
                con.Close();
                return;
            }
            sdr.Close();

            cmd.CommandText = "Select TicketId From CancelTicket Where TicketId='" + TicketId + "'; " +
                "Select CancelId From CancelTicket Order by CancelId desc; ";
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                MessageBox.Show("Already requested to cancel Ticket-" + TicketId);
                con.Close();
                return;
            }

            sdr.NextResult();
            if (sdr.HasRows)
            {
                sdr.Read();
                CancelId = (Convert.ToInt32(sdr.GetString(0)) + 1).ToString();
            }
            else CancelId = "1000";
            sdr.Close();

            cmd.CommandText = " Insert into CancelTicket Values('" + CancelId + "','" + TicketId + "','" + Form1.Cus_Id + "')";
            if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Request sent to cancel the ticket!");
            else MessageBox.Show("Cancel request was not sent!", "Error Request");
            con.Close();
        }

        private void displayHistory()
        {
            comboTickets.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            // Add Items in ComboBoxTickets
            cmd.CommandText = "Select Ticket.TicketId as [Ticket No], Ticket.Seat as [Seat], Bus.BusName as [Bus Name], Date, Ticket.Time as [Time] " +
                "From Ticket " +
                "INNER JOIN Bus ON Ticket.BusId = Bus.BusId " +
                "WHERE Ticket.Cus_Id = '" + Form1.Cus_Id +
                "' AND Ticket.Date >= '" + DateTime.Today +
                "' Order By Ticket.TicketId Desc;";

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                    comboTickets.Items.Add(sdr.GetString(0));
            }
            sdr.Close();

            // Add Items in DataGrid
            cmd.CommandText = "Select Ticket.TicketId as [Ticket No], Ticket.Seat as [Seat], Bus.BusName as [Bus Name], Date, Ticket.Time as [Time] " +
                "From Ticket " +
                "INNER JOIN Bus ON Ticket.BusId = Bus.BusId " +
                "Where Ticket.Cus_Id = '" + Form1.Cus_Id + "' " +
                "Order By Ticket.TicketId Desc;";
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridHistory.DataSource = dt;
            con.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FormBooking().Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }

        private void dataGridHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string TicketId = dataGridHistory.CurrentRow.Cells[0].Value.ToString();
            if (comboTickets.Items.Contains(TicketId))
            {
                btnCancel.Enabled = true;
                comboTickets.Text = TicketId;
            }
            else
            {
                btnCancel.Enabled = false;
                comboTickets.Text = "";
            }
        }
    }
}
