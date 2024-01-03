namespace OpenCvTestingTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            gpuUsageLabel = new Label();
            ramUsageLabel = new Label();
            cpuUsageLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox2 = new GroupBox();
            label3 = new Label();
            textBoxHWND = new TextBox();
            textBoxCaption = new TextBox();
            textBoxClass = new TextBox();
            label2 = new Label();
            label1 = new Label();
            comboBoxProcesses = new ComboBox();
            groupBox3 = new GroupBox();
            stop = new Button();
            render = new Button();
            Capture = new Button();
            pictureBox1 = new PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            timer2 = new System.Windows.Forms.Timer(components);
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            timer3 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(gpuUsageLabel);
            groupBox1.Controls.Add(ramUsageLabel);
            groupBox1.Controls.Add(cpuUsageLabel);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 76);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "System Performance Using";
            // 
            // gpuUsageLabel
            // 
            gpuUsageLabel.AutoSize = true;
            gpuUsageLabel.Location = new Point(6, 49);
            gpuUsageLabel.Name = "gpuUsageLabel";
            gpuUsageLabel.Size = new Size(88, 15);
            gpuUsageLabel.TabIndex = 2;
            gpuUsageLabel.Text = "gpuUsageLabel";
            // 
            // ramUsageLabel
            // 
            ramUsageLabel.AutoSize = true;
            ramUsageLabel.Location = new Point(6, 34);
            ramUsageLabel.Name = "ramUsageLabel";
            ramUsageLabel.Size = new Size(88, 15);
            ramUsageLabel.TabIndex = 1;
            ramUsageLabel.Text = "ramUsageLabel";
            // 
            // cpuUsageLabel
            // 
            cpuUsageLabel.AutoSize = true;
            cpuUsageLabel.Location = new Point(6, 19);
            cpuUsageLabel.Name = "cpuUsageLabel";
            cpuUsageLabel.Size = new Size(87, 15);
            cpuUsageLabel.TabIndex = 0;
            cpuUsageLabel.Text = "cpuUsageLabel";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBoxHWND);
            groupBox2.Controls.Add(textBoxCaption);
            groupBox2.Controls.Add(textBoxClass);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(comboBoxProcesses);
            groupBox2.Location = new Point(12, 94);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 151);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Process";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 112);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 6;
            label3.Text = "HWND :";
            // 
            // textBoxHWND
            // 
            textBoxHWND.Location = new Point(62, 109);
            textBoxHWND.Name = "textBoxHWND";
            textBoxHWND.Size = new Size(132, 23);
            textBoxHWND.TabIndex = 5;
            // 
            // textBoxCaption
            // 
            textBoxCaption.Location = new Point(62, 80);
            textBoxCaption.Name = "textBoxCaption";
            textBoxCaption.Size = new Size(132, 23);
            textBoxCaption.TabIndex = 4;
            // 
            // textBoxClass
            // 
            textBoxClass.Location = new Point(62, 51);
            textBoxClass.Name = "textBoxClass";
            textBoxClass.Size = new Size(132, 23);
            textBoxClass.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 83);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "Caption :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 54);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Class :";
            // 
            // comboBoxProcesses
            // 
            comboBoxProcesses.FormattingEnabled = true;
            comboBoxProcesses.Location = new Point(6, 22);
            comboBoxProcesses.Name = "comboBoxProcesses";
            comboBoxProcesses.Size = new Size(188, 23);
            comboBoxProcesses.TabIndex = 0;
            comboBoxProcesses.SelectionChangeCommitted += comboBoxProcesses_SelectionChangeCommitted;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(stop);
            groupBox3.Controls.Add(render);
            groupBox3.Controls.Add(Capture);
            groupBox3.Location = new Point(12, 251);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 113);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Controller";
            // 
            // stop
            // 
            stop.Location = new Point(8, 80);
            stop.Name = "stop";
            stop.Size = new Size(186, 23);
            stop.TabIndex = 2;
            stop.Text = "Stop And Clear";
            stop.UseVisualStyleBackColor = true;
            stop.Click += stop_Click;
            // 
            // render
            // 
            render.Location = new Point(8, 51);
            render.Name = "render";
            render.Size = new Size(186, 23);
            render.TabIndex = 1;
            render.Text = "Render Capture";
            render.UseVisualStyleBackColor = true;
            render.Click += render_Click;
            // 
            // Capture
            // 
            Capture.Location = new Point(8, 22);
            Capture.Name = "Capture";
            Capture.Size = new Size(186, 23);
            Capture.TabIndex = 0;
            Capture.Text = "Capture";
            Capture.UseVisualStyleBackColor = true;
            Capture.Click += Capture_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(218, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(454, 352);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // backgroundWorker2
            // 
            backgroundWorker2.WorkerSupportsCancellation = true;
            backgroundWorker2.DoWork += backgroundWorker2_DoWork;
            // 
            // timer3
            // 
            timer3.Interval = 50;
            timer3.Tick += timer3_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(119, 45);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Function";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 373);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(700, 412);
            MinimumSize = new Size(700, 412);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Capturing HWND Testing Tool";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private Label gpuUsageLabel;
        private Label ramUsageLabel;
        private Label cpuUsageLabel;
        private GroupBox groupBox2;
        private TextBox textBoxCaption;
        private TextBox textBoxClass;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxProcesses;
        private Label label3;
        private TextBox textBoxHWND;
        private GroupBox groupBox3;
        private Button stop;
        private Button render;
        private Button Capture;
        private PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Timer timer3;
        private Button button1;
    }
}