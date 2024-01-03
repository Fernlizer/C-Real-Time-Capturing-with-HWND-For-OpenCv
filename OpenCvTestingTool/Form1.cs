using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;



namespace OpenCvTestingTool
{
    public partial class Form1 : Form
    {
        private PerformanceMonitor performanceMonitor;

        private IntPtr targetWindowHandle;


        private IntPtr _hwnd = IntPtr.Zero;
        private UIApps _Apps;

        public Form1()
        {
            InitializeComponent();
            performanceMonitor = new PerformanceMonitor();


            // Start the timer to update the values every second
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _Apps = new UIApps(Process.GetProcesses());
            comboBoxProcesses.BeginUpdate();
            comboBoxProcesses.DataSource = _Apps;
            comboBoxProcesses.DisplayMember = "Description";
            comboBoxProcesses.EndUpdate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float cpuUsage = performanceMonitor.GetCpuUsage();
            cpuUsageLabel.Text = $"CPU Usage: {cpuUsage:F2}%";

            float ramUsage = performanceMonitor.GetRamUsage();
            ramUsageLabel.Text = $"RAM Usage: {ramUsage:F2}%";

            float gpuUsage = performanceMonitor.GetGpuUsage();
            gpuUsageLabel.Text = $"GPU Usage: {gpuUsage:F2}%";
        }

        private void comboBoxProcesses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int ind = 0;
            ComboBox cb = sender as ComboBox;
            ind = cb.SelectedIndex;
            _hwnd = _Apps[ind].HWnd;
            //buttonCapture.Enabled = _hwnd != IntPtr.Zero;
            textBoxCaption.Text = _Apps[ind].Caption;
            textBoxClass.Text = _Apps[ind].WindowClass;
            textBoxHWND.Text = string.Format("{0:X}", (int)_hwnd);
        }

        private void Capture_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = CaptureHelper.MakeSnapshot(_hwnd, true, Win32API.WindowShowStyle.Restore);
            pictureBox1.Image = bitmap;
        }

        private void render_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                timer3.Start();
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                pictureBox1.Image = null;
                timer3.Stop();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (!worker.CancellationPending)
            {
                Bitmap bitmap = CaptureHelper.MakeSnapshot(_hwnd, true, Win32API.WindowShowStyle.Restore);

                // Update the PictureBox image on the UI thread
                pictureBox1.Invoke((MethodInvoker)delegate
                {
                    pictureBox1.Image = bitmap;
                });

                // Optional delay to control the rate of updates
                Thread.Sleep(100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (!backgroundWorker2.IsBusy)
            //{
            //    backgroundWorker2.RunWorkerAsync();
            //}


        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker TextOverlayShow = sender as BackgroundWorker;

            while (!TextOverlayShow.CancellationPending)
            {
                TextOverlay.ShowTextOverlay(_hwnd, "Hello, World!", 100, 100, Color.Red, new Font("Arial", 24));
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            TextOverlay.ShowTextOverlay(_hwnd, "Capturing", 100, 100, Color.Red, new Font("Arial", 24));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Activate the target window

            // Calculate the screen coordinates of the click position
            Win32Bot.SimulateMouseClick(_hwnd, 19, 15);
        }
    }
}