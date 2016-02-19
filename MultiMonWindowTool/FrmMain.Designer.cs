namespace MultiMonWindowTool
{
    partial class FrmMain
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
            this.lvWindows = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnMove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMovePrimary = new System.Windows.Forms.Button();
            this.btnMoveSecondary = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.radioScreenArea = new System.Windows.Forms.RadioButton();
            this.radioWindow = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioCapSecondary = new System.Windows.Forms.RadioButton();
            this.radioCapPrimary = new System.Windows.Forms.RadioButton();
            this.radioCapSelected = new System.Windows.Forms.RadioButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvWindows
            // 
            this.lvWindows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWindows.FullRowSelect = true;
            this.lvWindows.GridLines = true;
            this.lvWindows.HideSelection = false;
            this.lvWindows.Location = new System.Drawing.Point(0, 0);
            this.lvWindows.Name = "lvWindows";
            this.lvWindows.Size = new System.Drawing.Size(508, 277);
            this.lvWindows.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvWindows.TabIndex = 0;
            this.lvWindows.UseCompatibleStateImageBehavior = false;
            this.lvWindows.View = System.Windows.Forms.View.Details;
            this.lvWindows.SelectedIndexChanged += new System.EventHandler(this.lvWindows_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Window Title";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PID";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "X Y";
            this.columnHeader3.Width = 150;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(27, 16);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(118, 47);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(45, 69);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 3;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(45, 95);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 5;
            this.txtY.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y";
            // 
            // btnMovePrimary
            // 
            this.btnMovePrimary.Location = new System.Drawing.Point(190, 16);
            this.btnMovePrimary.Name = "btnMovePrimary";
            this.btnMovePrimary.Size = new System.Drawing.Size(118, 47);
            this.btnMovePrimary.TabIndex = 6;
            this.btnMovePrimary.Text = "Move To Primary Monitor";
            this.btnMovePrimary.UseVisualStyleBackColor = true;
            this.btnMovePrimary.Click += new System.EventHandler(this.bntMovePrimary_Click);
            // 
            // btnMoveSecondary
            // 
            this.btnMoveSecondary.Location = new System.Drawing.Point(345, 16);
            this.btnMoveSecondary.Name = "btnMoveSecondary";
            this.btnMoveSecondary.Size = new System.Drawing.Size(118, 47);
            this.btnMoveSecondary.TabIndex = 7;
            this.btnMoveSecondary.Text = "Move To Secondary Monitor";
            this.btnMoveSecondary.UseVisualStyleBackColor = true;
            this.btnMoveSecondary.Click += new System.EventHandler(this.btnMoveSecondary_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(20, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(456, 238);
            this.listBox1.TabIndex = 8;
            // 
            // picPreview
            // 
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(461, 277);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 9;
            this.picPreview.TabStop = false;
            // 
            // radioScreenArea
            // 
            this.radioScreenArea.AutoSize = true;
            this.radioScreenArea.Location = new System.Drawing.Point(15, 11);
            this.radioScreenArea.Name = "radioScreenArea";
            this.radioScreenArea.Size = new System.Drawing.Size(124, 17);
            this.radioScreenArea.TabIndex = 10;
            this.radioScreenArea.Text = "Capture Screen Area";
            this.radioScreenArea.UseVisualStyleBackColor = true;
            this.radioScreenArea.CheckedChanged += new System.EventHandler(this.radioScreenArea_CheckedChanged);
            // 
            // radioWindow
            // 
            this.radioWindow.AutoSize = true;
            this.radioWindow.Checked = true;
            this.radioWindow.Location = new System.Drawing.Point(145, 11);
            this.radioWindow.Name = "radioWindow";
            this.radioWindow.Size = new System.Drawing.Size(104, 17);
            this.radioWindow.TabIndex = 11;
            this.radioWindow.TabStop = true;
            this.radioWindow.Text = "Capture Window";
            this.radioWindow.UseVisualStyleBackColor = true;
            this.radioWindow.CheckedChanged += new System.EventHandler(this.radioWindow_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioWindow);
            this.groupBox1.Controls.Add(this.radioScreenArea);
            this.groupBox1.Location = new System.Drawing.Point(569, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 34);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Location = new System.Drawing.Point(836, 14);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(88, 17);
            this.chkAutoRefresh.TabIndex = 13;
            this.chkAutoRefresh.Text = "Auto Refresh";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvWindows);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.picPreview);
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Size = new System.Drawing.Size(973, 277);
            this.splitContainer1.SplitterDistance = 508;
            this.splitContainer1.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.chkAutoRefresh);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnMoveSecondary);
            this.panel1.Controls.Add(this.btnMovePrimary);
            this.panel1.Controls.Add(this.txtY);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtX);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 124);
            this.panel1.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioCapSecondary);
            this.groupBox2.Controls.Add(this.radioCapPrimary);
            this.groupBox2.Controls.Add(this.radioCapSelected);
            this.groupBox2.Location = new System.Drawing.Point(512, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 34);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // radioCapSecondary
            // 
            this.radioCapSecondary.AutoSize = true;
            this.radioCapSecondary.Location = new System.Drawing.Point(280, 11);
            this.radioCapSecondary.Name = "radioCapSecondary";
            this.radioCapSecondary.Size = new System.Drawing.Size(154, 17);
            this.radioCapSecondary.TabIndex = 12;
            this.radioCapSecondary.Text = "Capture Secondary Monitor";
            this.radioCapSecondary.UseVisualStyleBackColor = true;
            this.radioCapSecondary.CheckedChanged += new System.EventHandler(this.radioCapSecondary_CheckedChanged);
            // 
            // radioCapPrimary
            // 
            this.radioCapPrimary.AutoSize = true;
            this.radioCapPrimary.Location = new System.Drawing.Point(128, 11);
            this.radioCapPrimary.Name = "radioCapPrimary";
            this.radioCapPrimary.Size = new System.Drawing.Size(137, 17);
            this.radioCapPrimary.TabIndex = 11;
            this.radioCapPrimary.Text = "Capture Primary Monitor";
            this.radioCapPrimary.UseVisualStyleBackColor = true;
            this.radioCapPrimary.CheckedChanged += new System.EventHandler(this.radioCapPrimary_CheckedChanged);
            // 
            // radioCapSelected
            // 
            this.radioCapSelected.AutoSize = true;
            this.radioCapSelected.Checked = true;
            this.radioCapSelected.Location = new System.Drawing.Point(15, 11);
            this.radioCapSelected.Name = "radioCapSelected";
            this.radioCapSelected.Size = new System.Drawing.Size(107, 17);
            this.radioCapSelected.TabIndex = 10;
            this.radioCapSelected.TabStop = true;
            this.radioCapSelected.Text = "Capture Selected";
            this.radioCapSelected.UseVisualStyleBackColor = true;
            this.radioCapSelected.CheckedChanged += new System.EventHandler(this.radioCapSelected_CheckedChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(973, 405);
            this.splitContainer2.SplitterDistance = 277;
            this.splitContainer2.TabIndex = 16;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 405);
            this.Controls.Add(this.splitContainer2);
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MultiMon Window Tool";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvWindows;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMovePrimary;
        private System.Windows.Forms.Button btnMoveSecondary;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.RadioButton radioScreenArea;
        private System.Windows.Forms.RadioButton radioWindow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioCapSecondary;
        private System.Windows.Forms.RadioButton radioCapPrimary;
        private System.Windows.Forms.RadioButton radioCapSelected;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

