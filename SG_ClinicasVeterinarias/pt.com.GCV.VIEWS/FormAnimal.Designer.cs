
namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS
{
    partial class FormAnimal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnimal));
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guna2ComboBoxSex = new Guna.UI2.WinForms.Guna2ComboBox();
            this.last_visit = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.Date_Death = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2ComboBoxTypeAnimal = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2ComboBoxOwner = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Date_of_Birth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2TextBoxWeight = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2TextBoxRace = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Cancel = new Guna.UI2.WinForms.Guna2Button();
            this.Save = new Guna.UI2.WinForms.Guna2Button();
            this.Close = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Close.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(358, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 37);
            this.label5.TabIndex = 10;
            this.label5.Text = "Form Animal";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.guna2ComboBoxSex);
            this.groupBox1.Controls.Add(this.last_visit);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Date_Death);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.guna2ComboBoxTypeAnimal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.guna2ComboBoxOwner);
            this.groupBox1.Controls.Add(this.Date_of_Birth);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.guna2TextBoxWeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.guna2TextBoxRace);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 445);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animals";
            // 
            // guna2ComboBoxSex
            // 
            this.guna2ComboBoxSex.AutoRoundedCorners = true;
            this.guna2ComboBoxSex.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBoxSex.BorderRadius = 17;
            this.guna2ComboBoxSex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBoxSex.FillColor = System.Drawing.Color.PapayaWhip;
            this.guna2ComboBoxSex.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxSex.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxSex.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBoxSex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBoxSex.ItemHeight = 30;
            this.guna2ComboBoxSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.guna2ComboBoxSex.Location = new System.Drawing.Point(12, 256);
            this.guna2ComboBoxSex.Name = "guna2ComboBoxSex";
            this.guna2ComboBoxSex.Size = new System.Drawing.Size(176, 36);
            this.guna2ComboBoxSex.TabIndex = 19;
            // 
            // last_visit
            // 
            this.last_visit.Animated = true;
            this.last_visit.AutoRoundedCorners = true;
            this.last_visit.BackColor = System.Drawing.Color.Transparent;
            this.last_visit.BorderRadius = 14;
            this.last_visit.Checked = true;
            this.last_visit.FillColor = System.Drawing.Color.PapayaWhip;
            this.last_visit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.last_visit.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.last_visit.Location = new System.Drawing.Point(283, 266);
            this.last_visit.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.last_visit.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.last_visit.Name = "last_visit";
            this.last_visit.Size = new System.Drawing.Size(197, 31);
            this.last_visit.TabIndex = 18;
            this.last_visit.Value = new System.DateTime(2023, 6, 15, 14, 43, 26, 890);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(278, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Last Visit ";
            // 
            // Date_Death
            // 
            this.Date_Death.Animated = true;
            this.Date_Death.AutoRoundedCorners = true;
            this.Date_Death.BackColor = System.Drawing.Color.Transparent;
            this.Date_Death.BorderRadius = 14;
            this.Date_Death.Checked = true;
            this.Date_Death.FillColor = System.Drawing.Color.PapayaWhip;
            this.Date_Death.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Date_Death.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.Date_Death.Location = new System.Drawing.Point(283, 372);
            this.Date_Death.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.Date_Death.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Date_Death.Name = "Date_Death";
            this.Date_Death.Size = new System.Drawing.Size(197, 31);
            this.Date_Death.TabIndex = 16;
            this.Date_Death.Value = new System.DateTime(2023, 6, 15, 14, 43, 26, 890);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(278, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Date of Death";
            // 
            // guna2ComboBoxTypeAnimal
            // 
            this.guna2ComboBoxTypeAnimal.AutoRoundedCorners = true;
            this.guna2ComboBoxTypeAnimal.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBoxTypeAnimal.BorderRadius = 17;
            this.guna2ComboBoxTypeAnimal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBoxTypeAnimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBoxTypeAnimal.FillColor = System.Drawing.Color.PapayaWhip;
            this.guna2ComboBoxTypeAnimal.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxTypeAnimal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxTypeAnimal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBoxTypeAnimal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBoxTypeAnimal.ItemHeight = 30;
            this.guna2ComboBoxTypeAnimal.Items.AddRange(new object[] {
            "Cat ",
            "Dog ",
            "Bird ",
            "Rodent"});
            this.guna2ComboBoxTypeAnimal.Location = new System.Drawing.Point(283, 63);
            this.guna2ComboBoxTypeAnimal.Name = "guna2ComboBoxTypeAnimal";
            this.guna2ComboBoxTypeAnimal.Size = new System.Drawing.Size(176, 36);
            this.guna2ComboBoxTypeAnimal.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(278, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Type of Animal";
            // 
            // guna2ComboBoxOwner
            // 
            this.guna2ComboBoxOwner.AutoRoundedCorners = true;
            this.guna2ComboBoxOwner.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBoxOwner.BorderRadius = 17;
            this.guna2ComboBoxOwner.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBoxOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBoxOwner.FillColor = System.Drawing.Color.PapayaWhip;
            this.guna2ComboBoxOwner.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxOwner.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxOwner.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBoxOwner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBoxOwner.ItemHeight = 30;
            this.guna2ComboBoxOwner.Location = new System.Drawing.Point(17, 63);
            this.guna2ComboBoxOwner.Name = "guna2ComboBoxOwner";
            this.guna2ComboBoxOwner.Size = new System.Drawing.Size(176, 36);
            this.guna2ComboBoxOwner.TabIndex = 12;
            // 
            // Date_of_Birth
            // 
            this.Date_of_Birth.Animated = true;
            this.Date_of_Birth.AutoRoundedCorners = true;
            this.Date_of_Birth.BackColor = System.Drawing.Color.Transparent;
            this.Date_of_Birth.BorderRadius = 14;
            this.Date_of_Birth.Checked = true;
            this.Date_of_Birth.FillColor = System.Drawing.Color.PapayaWhip;
            this.Date_of_Birth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Date_of_Birth.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.Date_of_Birth.Location = new System.Drawing.Point(25, 372);
            this.Date_of_Birth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.Date_of_Birth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Date_of_Birth.Name = "Date_of_Birth";
            this.Date_of_Birth.Size = new System.Drawing.Size(197, 31);
            this.Date_of_Birth.TabIndex = 11;
            this.Date_of_Birth.Value = new System.DateTime(2023, 6, 15, 14, 43, 26, 890);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Date of Birth ";
            // 
            // guna2TextBoxWeight
            // 
            this.guna2TextBoxWeight.AutoRoundedCorners = true;
            this.guna2TextBoxWeight.BackColor = System.Drawing.Color.PeachPuff;
            this.guna2TextBoxWeight.BorderRadius = 17;
            this.guna2TextBoxWeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBoxWeight.DefaultText = "";
            this.guna2TextBoxWeight.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBoxWeight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBoxWeight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxWeight.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxWeight.FillColor = System.Drawing.Color.PapayaWhip;
            this.guna2TextBoxWeight.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxWeight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBoxWeight.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxWeight.Location = new System.Drawing.Point(283, 162);
            this.guna2TextBoxWeight.Name = "guna2TextBoxWeight";
            this.guna2TextBoxWeight.PasswordChar = '\0';
            this.guna2TextBoxWeight.PlaceholderText = "";
            this.guna2TextBoxWeight.SelectedText = "";
            this.guna2TextBoxWeight.Size = new System.Drawing.Size(200, 36);
            this.guna2TextBoxWeight.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(278, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Weight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sex";
            // 
            // guna2TextBoxRace
            // 
            this.guna2TextBoxRace.AutoRoundedCorners = true;
            this.guna2TextBoxRace.BackColor = System.Drawing.Color.PeachPuff;
            this.guna2TextBoxRace.BorderRadius = 17;
            this.guna2TextBoxRace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBoxRace.DefaultText = "";
            this.guna2TextBoxRace.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBoxRace.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBoxRace.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxRace.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxRace.FillColor = System.Drawing.Color.PapayaWhip;
            this.guna2TextBoxRace.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxRace.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBoxRace.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxRace.Location = new System.Drawing.Point(6, 162);
            this.guna2TextBoxRace.Name = "guna2TextBoxRace";
            this.guna2TextBoxRace.PasswordChar = '\0';
            this.guna2TextBoxRace.PlaceholderText = "";
            this.guna2TextBoxRace.SelectedText = "";
            this.guna2TextBoxRace.Size = new System.Drawing.Size(200, 36);
            this.guna2TextBoxRace.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Race";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Owner Name ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(611, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Cancel
            // 
            this.Cancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Cancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Cancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Cancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Cancel.FillColor = System.Drawing.Color.DarkSalmon;
            this.Cancel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(204, 542);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(180, 45);
            this.Cancel.TabIndex = 19;
            this.Cancel.Text = "Cancel";
            // 
            // Save
            // 
            this.Save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Save.FillColor = System.Drawing.Color.DarkSalmon;
            this.Save.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.ForeColor = System.Drawing.Color.White;
            this.Save.Location = new System.Drawing.Point(414, 542);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(180, 45);
            this.Save.TabIndex = 18;
            this.Save.Text = "Save";
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.LightSalmon;
            this.Close.Controls.Add(this.guna2Button1);
            this.Close.Location = new System.Drawing.Point(-1, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(970, 30);
            this.Close.TabIndex = 20;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(937, 2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(30, 25);
            this.guna2Button1.TabIndex = 16;
            this.guna2Button1.Text = "X";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // FormAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(968, 637);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAnimal";
            this.Text = "FormAnimal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Close.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2DateTimePicker Date_of_Birth;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxRace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBoxOwner;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBoxTypeAnimal;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2DateTimePicker Date_Death;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2DateTimePicker last_visit;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBoxSex;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button Cancel;
        private Guna.UI2.WinForms.Guna2Button Save;
        private Guna.UI2.WinForms.Guna2Panel Close;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}