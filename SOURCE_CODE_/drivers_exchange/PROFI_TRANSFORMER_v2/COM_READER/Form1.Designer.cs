namespace COM_READER
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
            this.tm1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbltime = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button5 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.lblFound = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.textBoxAnw010 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxWRtoPORT = new System.Windows.Forms.TextBox();
            this.textBoxUNIdent = new System.Windows.Forms.TextBox();
            this.buttonWR = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxWrTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxReadTime = new System.Windows.Forms.TextBox();
            this.textBox_0x10_ASK = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_0x68_ANSW = new System.Windows.Forms.TextBox();
            this.listBoxEndHandshake = new System.Windows.Forms.ListBox();
            this.textBox_0x68_ASK = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listBoxStopBits = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxDataBits = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoAvParity = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxBaudRate = new System.Windows.Forms.ListBox();
            this.listBoxAvalPorts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lOADFROMFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOADFROMFILEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.profibusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAVEINFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profibusToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBoxErr = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxOut = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listViewHexFile = new System.Windows.Forms.ListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listViewHewColor = new System.Windows.Forms.ListView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tm1
            // 
            this.tm1.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbltime.Location = new System.Drawing.Point(262, 145);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(0, 20);
            this.lbltime.TabIndex = 23;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button5);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSearch);
            this.splitContainer1.Panel1.Controls.Add(this.lblFound);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Controls.Add(this.lbltime);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.txtTime);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxAnw010);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxWRtoPORT);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxUNIdent);
            this.splitContainer1.Panel1.Controls.Add(this.buttonWR);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxWrTime);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxReadTime);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_0x10_ASK);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_0x68_ANSW);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxEndHandshake);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_0x68_ASK);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxStopBits);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxDataBits);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.listBoAvParity);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxBaudRate);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxAvalPorts);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpen);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1291, 665);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(184, 349);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 37;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(223, 582);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "IN HEX";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "68",
            "10",
            "E5",
            "DC"});
            this.comboBox1.Location = new System.Drawing.Point(5, 577);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 35;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(184, 577);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 23);
            this.button3.TabIndex = 34;
            this.button3.Text = "=>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(146, 577);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 23);
            this.button4.TabIndex = 33;
            this.button4.Text = "<=";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // cmbSearch
            // 
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Items.AddRange(new object[] {
            "68",
            "10",
            "E5",
            "DC"});
            this.cmbSearch.Location = new System.Drawing.Point(5, 548);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(138, 21);
            this.cmbSearch.TabIndex = 32;
            // 
            // lblFound
            // 
            this.lblFound.AutoSize = true;
            this.lblFound.Location = new System.Drawing.Point(277, 553);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(13, 13);
            this.lblFound.TabIndex = 31;
            this.lblFound.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(223, 553);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "FOUND:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 548);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "=>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 548);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "<=";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(175, 301);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 17);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "AUTO SCROLL ALL";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(123, 24);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 20);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "READY";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(240, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Time in sec";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(243, 81);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(46, 20);
            this.txtTime.TabIndex = 20;
            this.txtTime.Text = "1000";
            // 
            // textBoxAnw010
            // 
            this.textBoxAnw010.Location = new System.Drawing.Point(104, 490);
            this.textBoxAnw010.Name = "textBoxAnw010";
            this.textBoxAnw010.Size = new System.Drawing.Size(37, 20);
            this.textBoxAnw010.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 490);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "ANSWER 0x10";
            // 
            // textBoxWRtoPORT
            // 
            this.textBoxWRtoPORT.Location = new System.Drawing.Point(12, 380);
            this.textBoxWRtoPORT.Name = "textBoxWRtoPORT";
            this.textBoxWRtoPORT.Size = new System.Drawing.Size(157, 20);
            this.textBoxWRtoPORT.TabIndex = 17;
            this.textBoxWRtoPORT.Text = "0x680x070x070x680xF0x800x460x3A0x3E0x020x000x3F0x16 ";
            // 
            // textBoxUNIdent
            // 
            this.textBoxUNIdent.Location = new System.Drawing.Point(104, 522);
            this.textBoxUNIdent.Name = "textBoxUNIdent";
            this.textBoxUNIdent.Size = new System.Drawing.Size(37, 20);
            this.textBoxUNIdent.TabIndex = 11;
            // 
            // buttonWR
            // 
            this.buttonWR.Location = new System.Drawing.Point(12, 350);
            this.buttonWR.Name = "buttonWR";
            this.buttonWR.Size = new System.Drawing.Size(157, 23);
            this.buttonWR.TabIndex = 16;
            this.buttonWR.Text = "WRITE MESSAGE TO PORT";
            this.buttonWR.UseVisualStyleBackColor = true;
            this.buttonWR.Click += new System.EventHandler(this.buttonWR_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 522);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "UNIDENT";
            // 
            // textBoxWrTime
            // 
            this.textBoxWrTime.Location = new System.Drawing.Point(94, 323);
            this.textBoxWrTime.Name = "textBoxWrTime";
            this.textBoxWrTime.Size = new System.Drawing.Size(73, 20);
            this.textBoxWrTime.TabIndex = 13;
            this.textBoxWrTime.Text = "500";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Write Time Out";
            // 
            // textBoxReadTime
            // 
            this.textBoxReadTime.Location = new System.Drawing.Point(9, 323);
            this.textBoxReadTime.Name = "textBoxReadTime";
            this.textBoxReadTime.Size = new System.Drawing.Size(73, 20);
            this.textBoxReadTime.TabIndex = 0;
            this.textBoxReadTime.Text = "500";
            // 
            // textBox_0x10_ASK
            // 
            this.textBox_0x10_ASK.Location = new System.Drawing.Point(104, 464);
            this.textBox_0x10_ASK.Name = "textBox_0x10_ASK";
            this.textBox_0x10_ASK.Size = new System.Drawing.Size(37, 20);
            this.textBox_0x10_ASK.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Read Time Out";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 464);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "ASK 0x10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Handshake options:";
            // 
            // textBox_0x68_ANSW
            // 
            this.textBox_0x68_ANSW.Location = new System.Drawing.Point(104, 436);
            this.textBox_0x68_ANSW.Name = "textBox_0x68_ANSW";
            this.textBox_0x68_ANSW.Size = new System.Drawing.Size(37, 20);
            this.textBox_0x68_ANSW.TabIndex = 3;
            // 
            // listBoxEndHandshake
            // 
            this.listBoxEndHandshake.FormattingEnabled = true;
            this.listBoxEndHandshake.Location = new System.Drawing.Point(171, 200);
            this.listBoxEndHandshake.Name = "listBoxEndHandshake";
            this.listBoxEndHandshake.Size = new System.Drawing.Size(118, 95);
            this.listBoxEndHandshake.TabIndex = 10;
            // 
            // textBox_0x68_ASK
            // 
            this.textBox_0x68_ASK.Location = new System.Drawing.Point(104, 410);
            this.textBox_0x68_ASK.Name = "textBox_0x68_ASK";
            this.textBox_0x68_ASK.Size = new System.Drawing.Size(37, 20);
            this.textBox_0x68_ASK.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "StopBits:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 439);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "ANSWER 0x68";
            // 
            // listBoxStopBits
            // 
            this.listBoxStopBits.FormattingEnabled = true;
            this.listBoxStopBits.Location = new System.Drawing.Point(87, 200);
            this.listBoxStopBits.Name = "listBoxStopBits";
            this.listBoxStopBits.Size = new System.Drawing.Size(59, 95);
            this.listBoxStopBits.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 413);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "ASK 0x68";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "DataBits value";
            // 
            // listBoxDataBits
            // 
            this.listBoxDataBits.FormattingEnabled = true;
            this.listBoxDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.listBoxDataBits.Location = new System.Drawing.Point(5, 200);
            this.listBoxDataBits.Name = "listBoxDataBits";
            this.listBoxDataBits.Size = new System.Drawing.Size(19, 56);
            this.listBoxDataBits.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parity options:";
            // 
            // listBoAvParity
            // 
            this.listBoAvParity.FormattingEnabled = true;
            this.listBoAvParity.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None",
            "Mark",
            "Space"});
            this.listBoAvParity.Location = new System.Drawing.Point(171, 81);
            this.listBoAvParity.Name = "listBoAvParity";
            this.listBoAvParity.Size = new System.Drawing.Size(66, 69);
            this.listBoAvParity.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud Rate";
            // 
            // listBoxBaudRate
            // 
            this.listBoxBaudRate.FormattingEnabled = true;
            this.listBoxBaudRate.Items.AddRange(new object[] {
            "50",
            "19200",
            "187500",
            "31250",
            "45450",
            "93750",
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "38400",
            "57600",
            "115200",
            "460800",
            "921600"});
            this.listBoxBaudRate.Location = new System.Drawing.Point(91, 81);
            this.listBoxBaudRate.Name = "listBoxBaudRate";
            this.listBoxBaudRate.Size = new System.Drawing.Size(74, 95);
            this.listBoxBaudRate.TabIndex = 0;
            // 
            // listBoxAvalPorts
            // 
            this.listBoxAvalPorts.FormattingEnabled = true;
            this.listBoxAvalPorts.Location = new System.Drawing.Point(5, 81);
            this.listBoxAvalPorts.Name = "listBoxAvalPorts";
            this.listBoxAvalPorts.Size = new System.Drawing.Size(63, 95);
            this.listBoxAvalPorts.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Ports:";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(5, 27);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(112, 35);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "OPEN SESSION";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lOADFROMFILEToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(303, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lOADFROMFILEToolStripMenuItem
            // 
            this.lOADFROMFILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lOADFROMFILEToolStripMenuItem1,
            this.sAVEINFILEToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.lOADFROMFILEToolStripMenuItem.Name = "lOADFROMFILEToolStripMenuItem";
            this.lOADFROMFILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.lOADFROMFILEToolStripMenuItem.Text = "FILE";
            // 
            // lOADFROMFILEToolStripMenuItem1
            // 
            this.lOADFROMFILEToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profibusToolStripMenuItem});
            this.lOADFROMFILEToolStripMenuItem1.Name = "lOADFROMFILEToolStripMenuItem1";
            this.lOADFROMFILEToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.lOADFROMFILEToolStripMenuItem1.Text = "LOAD FROM FILE";
            // 
            // profibusToolStripMenuItem
            // 
            this.profibusToolStripMenuItem.Name = "profibusToolStripMenuItem";
            this.profibusToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.profibusToolStripMenuItem.Text = "Profibus DP";
            this.profibusToolStripMenuItem.Click += new System.EventHandler(this.profibusToolStripMenuItem_Click);
            // 
            // sAVEINFILEToolStripMenuItem
            // 
            this.sAVEINFILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profibusToolStripMenuItem1});
            this.sAVEINFILEToolStripMenuItem.Name = "sAVEINFILEToolStripMenuItem";
            this.sAVEINFILEToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.sAVEINFILEToolStripMenuItem.Text = "SAVE TO FILE";
            // 
            // profibusToolStripMenuItem1
            // 
            this.profibusToolStripMenuItem1.Name = "profibusToolStripMenuItem1";
            this.profibusToolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.profibusToolStripMenuItem1.Text = "Profibus DP from HEX MAP";
            this.profibusToolStripMenuItem1.Click += new System.EventHandler(this.profibusToolStripMenuItem1_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clearAllToolStripMenuItem.Text = "Clear all";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 665);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxErr);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 639);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SESSION ERRORS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBoxErr
            // 
            this.listBoxErr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxErr.FormattingEnabled = true;
            this.listBoxErr.Location = new System.Drawing.Point(3, 3);
            this.listBoxErr.Name = "listBoxErr";
            this.listBoxErr.Size = new System.Drawing.Size(970, 633);
            this.listBoxErr.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxOut);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 639);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ALL TRAFIC(WITH CONVERSATION)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxOut
            // 
            this.listBoxOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxOut.FormattingEnabled = true;
            this.listBoxOut.Location = new System.Drawing.Point(3, 3);
            this.listBoxOut.Name = "listBoxOut";
            this.listBoxOut.Size = new System.Drawing.Size(970, 633);
            this.listBoxOut.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listViewHexFile);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(976, 639);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SIMPLE HEX VIEW";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listViewHexFile
            // 
            this.listViewHexFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewHexFile.Location = new System.Drawing.Point(0, 0);
            this.listViewHexFile.MultiSelect = false;
            this.listViewHexFile.Name = "listViewHexFile";
            this.listViewHexFile.Size = new System.Drawing.Size(976, 639);
            this.listViewHexFile.TabIndex = 0;
            this.listViewHexFile.UseCompatibleStateImageBehavior = false;
            this.listViewHexFile.View = System.Windows.Forms.View.List;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listViewHewColor);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(976, 639);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "COLORING HEX MAP";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listViewHewColor
            // 
            this.listViewHewColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewHewColor.GridLines = true;
            this.listViewHewColor.Location = new System.Drawing.Point(0, 0);
            this.listViewHewColor.MultiSelect = false;
            this.listViewHewColor.Name = "listViewHewColor";
            this.listViewHewColor.Size = new System.Drawing.Size(976, 639);
            this.listViewHewColor.TabIndex = 0;
            this.listViewHewColor.UseCompatibleStateImageBehavior = false;
            this.listViewHewColor.View = System.Windows.Forms.View.List;
            this.listViewHewColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewHewColor_RightMouseClicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem1.Text = "I DIDNT NOTHING HERE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 665);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tm1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox textBoxAnw010;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxWRtoPORT;
        private System.Windows.Forms.TextBox textBoxUNIdent;
        private System.Windows.Forms.Button buttonWR;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxWrTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxReadTime;
        private System.Windows.Forms.TextBox textBox_0x10_ASK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_0x68_ANSW;
        private System.Windows.Forms.ListBox listBoxEndHandshake;
        private System.Windows.Forms.TextBox textBox_0x68_ASK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listBoxStopBits;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxDataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoAvParity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxBaudRate;
        private System.Windows.Forms.ListBox listBoxAvalPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox listBoxErr;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxOut;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listViewHewColor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lOADFROMFILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem lOADFROMFILEToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sAVEINFILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profibusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profibusToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView listViewHexFile;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button5;
    }
}

