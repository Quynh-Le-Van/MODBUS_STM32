namespace ModbusProtocolRtu
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.portname = new System.Windows.Forms.Label();
            this.baudrate = new System.Windows.Forms.Label();
            this.parity = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.databits = new System.Windows.Forms.Label();
            this.comboBoxportname = new System.Windows.Forms.ComboBox();
            this.comboBoxbaudrate = new System.Windows.Forms.ComboBox();
            this.comboBoxdatabits = new System.Windows.Forms.ComboBox();
            this.comboBoxparity = new System.Windows.Forms.ComboBox();
            this.buttonconnect = new System.Windows.Forms.Button();
            this.buttondisconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxfn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxstartaddr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxnumreg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxsend = new System.Windows.Forms.TextBox();
            this.textBoxreceive = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonsend03 = new System.Windows.Forms.Button();
            this.buttonsend10 = new System.Windows.Forms.Button();
            this.textBoxreceive10 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxsend10 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxnumreg10 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxstartaddr10 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxfn10 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxid10 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxvalue = new System.Windows.Forms.TextBox();
            this.textBoxvalue3 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // portname
            // 
            this.portname.AutoSize = true;
            this.portname.Location = new System.Drawing.Point(21, 18);
            this.portname.Name = "portname";
            this.portname.Size = new System.Drawing.Size(75, 17);
            this.portname.TabIndex = 0;
            this.portname.Text = "Port Name";
            // 
            // baudrate
            // 
            this.baudrate.AutoSize = true;
            this.baudrate.Location = new System.Drawing.Point(21, 75);
            this.baudrate.Name = "baudrate";
            this.baudrate.Size = new System.Drawing.Size(75, 17);
            this.baudrate.TabIndex = 1;
            this.baudrate.Text = "Baud Rate";
            // 
            // parity
            // 
            this.parity.AutoSize = true;
            this.parity.Location = new System.Drawing.Point(24, 192);
            this.parity.Name = "parity";
            this.parity.Size = new System.Drawing.Size(64, 17);
            this.parity.TabIndex = 2;
            this.parity.Text = "Parity Bit";
            // 
            // databits
            // 
            this.databits.AutoSize = true;
            this.databits.Location = new System.Drawing.Point(24, 134);
            this.databits.Name = "databits";
            this.databits.Size = new System.Drawing.Size(65, 17);
            this.databits.TabIndex = 3;
            this.databits.Text = "Data Bits";
            // 
            // comboBoxportname
            // 
            this.comboBoxportname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxportname.FormattingEnabled = true;
            this.comboBoxportname.Location = new System.Drawing.Point(24, 38);
            this.comboBoxportname.Name = "comboBoxportname";
            this.comboBoxportname.Size = new System.Drawing.Size(121, 24);
            this.comboBoxportname.TabIndex = 4;
            // 
            // comboBoxbaudrate
            // 
            this.comboBoxbaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxbaudrate.FormattingEnabled = true;
            this.comboBoxbaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600 ",
            "19200",
            "115200"});
            this.comboBoxbaudrate.Location = new System.Drawing.Point(24, 95);
            this.comboBoxbaudrate.Name = "comboBoxbaudrate";
            this.comboBoxbaudrate.Size = new System.Drawing.Size(121, 24);
            this.comboBoxbaudrate.TabIndex = 5;
            // 
            // comboBoxdatabits
            // 
            this.comboBoxdatabits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxdatabits.FormattingEnabled = true;
            this.comboBoxdatabits.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.comboBoxdatabits.Location = new System.Drawing.Point(24, 154);
            this.comboBoxdatabits.Name = "comboBoxdatabits";
            this.comboBoxdatabits.Size = new System.Drawing.Size(121, 24);
            this.comboBoxdatabits.TabIndex = 6;
            // 
            // comboBoxparity
            // 
            this.comboBoxparity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxparity.FormattingEnabled = true;
            this.comboBoxparity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.comboBoxparity.Location = new System.Drawing.Point(24, 212);
            this.comboBoxparity.Name = "comboBoxparity";
            this.comboBoxparity.Size = new System.Drawing.Size(121, 24);
            this.comboBoxparity.TabIndex = 7;
            // 
            // buttonconnect
            // 
            this.buttonconnect.Location = new System.Drawing.Point(24, 264);
            this.buttonconnect.Name = "buttonconnect";
            this.buttonconnect.Size = new System.Drawing.Size(121, 30);
            this.buttonconnect.TabIndex = 8;
            this.buttonconnect.Text = "Connect";
            this.buttonconnect.UseVisualStyleBackColor = true;
            this.buttonconnect.Click += new System.EventHandler(this.buttonconnect_Click);
            // 
            // buttondisconnect
            // 
            this.buttondisconnect.Location = new System.Drawing.Point(24, 309);
            this.buttondisconnect.Name = "buttondisconnect";
            this.buttondisconnect.Size = new System.Drawing.Size(121, 30);
            this.buttondisconnect.TabIndex = 9;
            this.buttondisconnect.Text = "Disconnect";
            this.buttondisconnect.UseVisualStyleBackColor = true;
            this.buttondisconnect.Click += new System.EventHandler(this.buttondisconnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Read Holding Registers (FC=03H)";
            // 
            // textBoxid
            // 
            this.textBoxid.Location = new System.Drawing.Point(590, 55);
            this.textBoxid.Name = "textBoxid";
            this.textBoxid.Size = new System.Drawing.Size(100, 22);
            this.textBoxid.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(590, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Slave Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(724, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Function";
            // 
            // textBoxfn
            // 
            this.textBoxfn.Location = new System.Drawing.Point(724, 55);
            this.textBoxfn.Name = "textBoxfn";
            this.textBoxfn.Size = new System.Drawing.Size(100, 22);
            this.textBoxfn.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(852, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Starting Address ";
            // 
            // textBoxstartaddr
            // 
            this.textBoxstartaddr.Location = new System.Drawing.Point(852, 55);
            this.textBoxstartaddr.Name = "textBoxstartaddr";
            this.textBoxstartaddr.Size = new System.Drawing.Size(100, 22);
            this.textBoxstartaddr.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(992, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Number of Points (registers) ";
            // 
            // textBoxnumreg
            // 
            this.textBoxnumreg.Location = new System.Drawing.Point(992, 55);
            this.textBoxnumreg.Name = "textBoxnumreg";
            this.textBoxnumreg.Size = new System.Drawing.Size(100, 22);
            this.textBoxnumreg.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(819, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "DataFrame Send :";
            // 
            // textBoxsend
            // 
            this.textBoxsend.Location = new System.Drawing.Point(821, 134);
            this.textBoxsend.Name = "textBoxsend";
            this.textBoxsend.Size = new System.Drawing.Size(377, 22);
            this.textBoxsend.TabIndex = 20;
            // 
            // textBoxreceive
            // 
            this.textBoxreceive.Location = new System.Drawing.Point(821, 200);
            this.textBoxreceive.Name = "textBoxreceive";
            this.textBoxreceive.Size = new System.Drawing.Size(377, 22);
            this.textBoxreceive.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(819, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "DataFrame Reveiced :";
            // 
            // buttonsend03
            // 
            this.buttonsend03.Location = new System.Drawing.Point(392, 75);
            this.buttonsend03.Name = "buttonsend03";
            this.buttonsend03.Size = new System.Drawing.Size(75, 23);
            this.buttonsend03.TabIndex = 23;
            this.buttonsend03.Text = "Send";
            this.buttonsend03.UseVisualStyleBackColor = true;
            this.buttonsend03.Click += new System.EventHandler(this.buttonsend03_Click);
            // 
            // buttonsend10
            // 
            this.buttonsend10.Location = new System.Drawing.Point(392, 420);
            this.buttonsend10.Name = "buttonsend10";
            this.buttonsend10.Size = new System.Drawing.Size(75, 23);
            this.buttonsend10.TabIndex = 37;
            this.buttonsend10.Text = "Send";
            this.buttonsend10.UseVisualStyleBackColor = true;
            this.buttonsend10.Click += new System.EventHandler(this.buttonsend10_Click);
            // 
            // textBoxreceive10
            // 
            this.textBoxreceive10.Location = new System.Drawing.Point(820, 564);
            this.textBoxreceive10.Name = "textBoxreceive10";
            this.textBoxreceive10.Size = new System.Drawing.Size(383, 22);
            this.textBoxreceive10.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(818, 543);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 17);
            this.label8.TabIndex = 35;
            this.label8.Text = "DataFrame Reveiced :";
            // 
            // textBoxsend10
            // 
            this.textBoxsend10.Location = new System.Drawing.Point(819, 491);
            this.textBoxsend10.Name = "textBoxsend10";
            this.textBoxsend10.Size = new System.Drawing.Size(384, 22);
            this.textBoxsend10.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(817, 470);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 17);
            this.label9.TabIndex = 33;
            this.label9.Text = "DataFrame Send :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(991, 381);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Number of Points (registers) ";
            // 
            // textBoxnumreg10
            // 
            this.textBoxnumreg10.Location = new System.Drawing.Point(991, 404);
            this.textBoxnumreg10.Name = "textBoxnumreg10";
            this.textBoxnumreg10.Size = new System.Drawing.Size(100, 22);
            this.textBoxnumreg10.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(851, 381);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Starting Address ";
            // 
            // textBoxstartaddr10
            // 
            this.textBoxstartaddr10.Location = new System.Drawing.Point(851, 404);
            this.textBoxstartaddr10.Name = "textBoxstartaddr10";
            this.textBoxstartaddr10.Size = new System.Drawing.Size(100, 22);
            this.textBoxstartaddr10.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(723, 381);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 17);
            this.label12.TabIndex = 28;
            this.label12.Text = "Function";
            // 
            // textBoxfn10
            // 
            this.textBoxfn10.Location = new System.Drawing.Point(723, 404);
            this.textBoxfn10.Name = "textBoxfn10";
            this.textBoxfn10.Size = new System.Drawing.Size(100, 22);
            this.textBoxfn10.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(589, 381);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 17);
            this.label13.TabIndex = 26;
            this.label13.Text = "Slave Address";
            // 
            // textBoxid10
            // 
            this.textBoxid10.Location = new System.Drawing.Point(589, 404);
            this.textBoxid10.Name = "textBoxid10";
            this.textBoxid10.Size = new System.Drawing.Size(100, 22);
            this.textBoxid10.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(306, 381);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(246, 17);
            this.label14.TabIndex = 24;
            this.label14.Text = ". Preset Multiple Registers (FC = 10H)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(587, 461);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 17);
            this.label15.TabIndex = 39;
            this.label15.Text = "Value of Register";
            // 
            // textBoxvalue
            // 
            this.textBoxvalue.Location = new System.Drawing.Point(593, 491);
            this.textBoxvalue.Multiline = true;
            this.textBoxvalue.Name = "textBoxvalue";
            this.textBoxvalue.Size = new System.Drawing.Size(132, 171);
            this.textBoxvalue.TabIndex = 40;
            // 
            // textBoxvalue3
            // 
            this.textBoxvalue3.Location = new System.Drawing.Point(590, 131);
            this.textBoxvalue3.Multiline = true;
            this.textBoxvalue3.Name = "textBoxvalue3";
            this.textBoxvalue3.Size = new System.Drawing.Size(132, 171);
            this.textBoxvalue3.TabIndex = 42;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(587, 102);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 17);
            this.label16.TabIndex = 41;
            this.label16.Text = "Value of Register";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 765);
            this.Controls.Add(this.textBoxvalue3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxvalue);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonsend10);
            this.Controls.Add(this.textBoxreceive10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxsend10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxnumreg10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxstartaddr10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxfn10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxid10);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.buttonsend03);
            this.Controls.Add(this.textBoxreceive);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxsend);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxnumreg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxstartaddr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxfn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttondisconnect);
            this.Controls.Add(this.buttonconnect);
            this.Controls.Add(this.comboBoxparity);
            this.Controls.Add(this.comboBoxdatabits);
            this.Controls.Add(this.comboBoxbaudrate);
            this.Controls.Add(this.comboBoxportname);
            this.Controls.Add(this.databits);
            this.Controls.Add(this.parity);
            this.Controls.Add(this.baudrate);
            this.Controls.Add(this.portname);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label portname;
        private System.Windows.Forms.Label baudrate;
        private System.Windows.Forms.Label parity;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label databits;
        private System.Windows.Forms.ComboBox comboBoxportname;
        private System.Windows.Forms.ComboBox comboBoxbaudrate;
        private System.Windows.Forms.ComboBox comboBoxdatabits;
        private System.Windows.Forms.ComboBox comboBoxparity;
        private System.Windows.Forms.Button buttonconnect;
        private System.Windows.Forms.Button buttondisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxfn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxstartaddr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxnumreg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxsend;
        private System.Windows.Forms.TextBox textBoxreceive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonsend03;
        private System.Windows.Forms.Button buttonsend10;
        private System.Windows.Forms.TextBox textBoxreceive10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxsend10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxnumreg10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxstartaddr10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxfn10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxid10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxvalue;
        private System.Windows.Forms.TextBox textBoxvalue3;
        private System.Windows.Forms.Label label16;
    }
}

