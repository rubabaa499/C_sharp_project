
namespace oop2Project
{
    partial class FormEmployeeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployeeView));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddBus = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBusName = new System.Windows.Forms.TextBox();
            this.labelSerial = new System.Windows.Forms.Label();
            this.textBusSerial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboFrom = new System.Windows.Forms.ComboBox();
            this.comboTime = new System.Windows.Forms.ComboBox();
            this.comboFormat = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboTo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textFare = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelCus_Id = new System.Windows.Forms.Label();
            this.labelTicketId = new System.Windows.Forms.Label();
            this.labelCusName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelSeatNo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboRequests = new System.Windows.Forms.ComboBox();
            this.btnReject = new System.Windows.Forms.Button();
            this.dataGridBusList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(612, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Employee View ";
            // 
            // btnAddBus
            // 
            this.btnAddBus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBus.Location = new System.Drawing.Point(237, 530);
            this.btnAddBus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddBus.Name = "btnAddBus";
            this.btnAddBus.Size = new System.Drawing.Size(92, 28);
            this.btnAddBus.TabIndex = 10;
            this.btnAddBus.Text = "Add";
            this.btnAddBus.UseVisualStyleBackColor = true;
            this.btnAddBus.Click += new System.EventHandler(this.btnAddBus_Click_1);
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(1072, 332);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(85, 27);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(147, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Bus name :";
            // 
            // textBusName
            // 
            this.textBusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBusName.Location = new System.Drawing.Point(268, 286);
            this.textBusName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBusName.Name = "textBusName";
            this.textBusName.Size = new System.Drawing.Size(168, 26);
            this.textBusName.TabIndex = 14;
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerial.Location = new System.Drawing.Point(149, 247);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(89, 19);
            this.labelSerial.TabIndex = 15;
            this.labelSerial.Text = "Serial No :";
            this.labelSerial.Visible = false;
            // 
            // textBusSerial
            // 
            this.textBusSerial.Enabled = false;
            this.textBusSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBusSerial.Location = new System.Drawing.Point(268, 244);
            this.textBusSerial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBusSerial.Name = "textBusSerial";
            this.textBusSerial.Size = new System.Drawing.Size(168, 26);
            this.textBusSerial.TabIndex = 16;
            this.textBusSerial.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(233, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Update Bus List ";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(345, 530);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 28);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(852, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cus Id :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(833, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 21;
            this.label4.Text = "Ticket Id :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(973, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 22);
            this.label7.TabIndex = 23;
            this.label7.Text = "Cancel Ticket Requests";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(100, 678);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 34);
            this.button4.TabIndex = 24;
            this.button4.Text = "Exit ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(1, 678);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(85, 34);
            this.button6.TabIndex = 32;
            this.button6.Text = "Logout ";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.Location = new System.Drawing.Point(656, 98);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(115, 38);
            this.btnProfile.TabIndex = 34;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(180, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 19);
            this.label11.TabIndex = 35;
            this.label11.Text = "From :";
            // 
            // comboFrom
            // 
            this.comboFrom.AllowDrop = true;
            this.comboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFrom.FormattingEnabled = true;
            this.comboFrom.Location = new System.Drawing.Point(268, 335);
            this.comboFrom.Margin = new System.Windows.Forms.Padding(4);
            this.comboFrom.Name = "comboFrom";
            this.comboFrom.Size = new System.Drawing.Size(168, 24);
            this.comboFrom.TabIndex = 36;
            // 
            // comboTime
            // 
            this.comboTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTime.FormattingEnabled = true;
            this.comboTime.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboTime.Location = new System.Drawing.Point(268, 471);
            this.comboTime.Margin = new System.Windows.Forms.Padding(4);
            this.comboTime.Name = "comboTime";
            this.comboTime.Size = new System.Drawing.Size(79, 24);
            this.comboTime.TabIndex = 37;
            // 
            // comboFormat
            // 
            this.comboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFormat.FormattingEnabled = true;
            this.comboFormat.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.comboFormat.Location = new System.Drawing.Point(356, 471);
            this.comboFormat.Margin = new System.Windows.Forms.Padding(4);
            this.comboFormat.Name = "comboFormat";
            this.comboFormat.Size = new System.Drawing.Size(80, 24);
            this.comboFormat.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(181, 474);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 19);
            this.label12.TabIndex = 39;
            this.label12.Text = "Time :";
            // 
            // comboTo
            // 
            this.comboTo.AllowDrop = true;
            this.comboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTo.FormattingEnabled = true;
            this.comboTo.Location = new System.Drawing.Point(268, 382);
            this.comboTo.Margin = new System.Windows.Forms.Padding(4);
            this.comboTo.Name = "comboTo";
            this.comboTo.Size = new System.Drawing.Size(168, 24);
            this.comboTo.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(201, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 19);
            this.label6.TabIndex = 40;
            this.label6.Text = "To :";
            // 
            // textFare
            // 
            this.textFare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFare.Location = new System.Drawing.Point(268, 428);
            this.textFare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textFare.Name = "textFare";
            this.textFare.Size = new System.Drawing.Size(168, 26);
            this.textFare.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(185, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 19);
            this.label8.TabIndex = 42;
            this.label8.Text = "Fare :";
            // 
            // labelCus_Id
            // 
            this.labelCus_Id.AutoSize = true;
            this.labelCus_Id.BackColor = System.Drawing.Color.Transparent;
            this.labelCus_Id.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCus_Id.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCus_Id.Location = new System.Drawing.Point(928, 241);
            this.labelCus_Id.Name = "labelCus_Id";
            this.labelCus_Id.Size = new System.Drawing.Size(20, 22);
            this.labelCus_Id.TabIndex = 44;
            this.labelCus_Id.Text = "_";
            // 
            // labelTicketId
            // 
            this.labelTicketId.AutoSize = true;
            this.labelTicketId.BackColor = System.Drawing.Color.Transparent;
            this.labelTicketId.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTicketId.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTicketId.Location = new System.Drawing.Point(928, 288);
            this.labelTicketId.Name = "labelTicketId";
            this.labelTicketId.Size = new System.Drawing.Size(20, 22);
            this.labelTicketId.TabIndex = 45;
            this.labelTicketId.Text = "_";
            // 
            // labelCusName
            // 
            this.labelCusName.AutoSize = true;
            this.labelCusName.BackColor = System.Drawing.Color.Transparent;
            this.labelCusName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCusName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCusName.Location = new System.Drawing.Point(1163, 244);
            this.labelCusName.Name = "labelCusName";
            this.labelCusName.Size = new System.Drawing.Size(20, 22);
            this.labelCusName.TabIndex = 47;
            this.labelCusName.Text = "_";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1064, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 19);
            this.label10.TabIndex = 46;
            this.label10.Text = "Cus Name :";
            // 
            // labelSeatNo
            // 
            this.labelSeatNo.AutoSize = true;
            this.labelSeatNo.BackColor = System.Drawing.Color.Transparent;
            this.labelSeatNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeatNo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSeatNo.Location = new System.Drawing.Point(923, 331);
            this.labelSeatNo.Name = "labelSeatNo";
            this.labelSeatNo.Size = new System.Drawing.Size(20, 22);
            this.labelSeatNo.TabIndex = 49;
            this.labelSeatNo.Text = "_";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(843, 334);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 19);
            this.label13.TabIndex = 48;
            this.label13.Text = "Seat No :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1063, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 19);
            this.label9.TabIndex = 50;
            this.label9.Text = "Request Id :";
            // 
            // comboRequests
            // 
            this.comboRequests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRequests.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRequests.FormattingEnabled = true;
            this.comboRequests.Location = new System.Drawing.Point(1167, 289);
            this.comboRequests.Margin = new System.Windows.Forms.Padding(4);
            this.comboRequests.Name = "comboRequests";
            this.comboRequests.Size = new System.Drawing.Size(179, 27);
            this.comboRequests.TabIndex = 51;
            this.comboRequests.SelectedIndexChanged += new System.EventHandler(this.comboRequests_SelectedIndexChanged);
            // 
            // btnReject
            // 
            this.btnReject.Enabled = false;
            this.btnReject.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.Location = new System.Drawing.Point(1163, 331);
            this.btnReject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(85, 27);
            this.btnReject.TabIndex = 52;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // dataGridBusList
            // 
            this.dataGridBusList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBusList.Location = new System.Drawing.Point(513, 388);
            this.dataGridBusList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridBusList.Name = "dataGridBusList";
            this.dataGridBusList.ReadOnly = true;
            this.dataGridBusList.RowHeadersWidth = 51;
            this.dataGridBusList.RowTemplate.Height = 24;
            this.dataGridBusList.Size = new System.Drawing.Size(903, 279);
            this.dataGridBusList.TabIndex = 31;
            this.dataGridBusList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBusList_CellClick);
            // 
            // FormEmployeeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::oop2Project.Properties.Resources.photo_1544620347_c4fd4a3d59571;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1448, 715);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.comboRequests);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelSeatNo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.labelCusName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelTicketId);
            this.Controls.Add(this.labelCus_Id);
            this.Controls.Add(this.textFare);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboFormat);
            this.Controls.Add(this.comboTime);
            this.Controls.Add(this.comboFrom);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridBusList);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBusSerial);
            this.Controls.Add(this.labelSerial);
            this.Controls.Add(this.textBusName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnAddBus);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormEmployeeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.FormViewEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddBus;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBusName;
        private System.Windows.Forms.Label labelSerial;
        private System.Windows.Forms.TextBox textBusSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboFrom;
        private System.Windows.Forms.ComboBox comboTime;
        private System.Windows.Forms.ComboBox comboFormat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textFare;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelCus_Id;
        private System.Windows.Forms.Label labelTicketId;
        private System.Windows.Forms.Label labelCusName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelSeatNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboRequests;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.DataGridView dataGridBusList;
    }
}
