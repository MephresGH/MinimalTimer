using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MinimalTimer
{
public partial class Form1: Form
{
[DllImport("ntdll.dll", SetLastError = true)]
private static extern int NtSetTimerResolution(uint DesiredResolution, bool SetResolution, out uint CurrentResolution);

[DllImport("psapi.dll")]
private static extern int EmptyWorkingSet(IntPtr hwProc);

private Button button1,button2,button3;
private Label label1 = new Label();

		public Form1()
		{
			Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
			Text = "Minimal Multimedia Timer";
			Height = 200;
			Width = 340;
			StartPosition = FormStartPosition.CenterScreen;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;

			label1.Location = new Point (10, 10);
			uint CurrentResolution;
			NtSetTimerResolution(0, false, out CurrentResolution);
			label1.Text = "Current Resolution:\n" + (CurrentResolution * 0.0001) + "ms";
			label1.Size = new System.Drawing.Size(150, 32);
			label1.Font = new Font("Arial", 11, FontStyle.Underline);
			Controls.Add(label1);

			Label label2 = new Label();
			label2.Location = new Point (10, 60);
			label2.Text = "Default Resolution:\n15.625 - 1.0ms";
			label2.Size = new System.Drawing.Size(150, 32);
			label2.Font = new Font("Arial", 11, FontStyle.Underline);
			Controls.Add(label2);

			button1 = new Button();
			button1.Size = new Size(70, 30);
			button1.Location = new Point(10, 130);
			button1.Text = "Maximum";
			Controls.Add(button1);
			button1.Click += (button1_Click);

			button2 = new Button();
			button2.Size = new Size(70, 30);
			button2.Location = new Point(130, 130);
			button2.Text = "Default";
			button2.Enabled = false;
			Controls.Add(button2);
			button2.Click += (button2_Click);

			button3 = new Button();
			button3.Size = new Size(70, 30);
			button3.Location = new Point(250, 130);
			button3.Text = "Close";
			Controls.Add(button3);
			button3.Click += (button3_Click);

			EmptyWorkingSet(Process.GetCurrentProcess().Handle);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			uint CurrentResolution;
			NtSetTimerResolution(0, true, out CurrentResolution);
			label1.Text = "Current Resolution:\n" + (CurrentResolution * 0.0001) + "ms";
			button1.Enabled = false;
			button2.Enabled = true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			uint CurrentResolution;
			NtSetTimerResolution(156250, true, out CurrentResolution);
			label1.Text = "Current Resolution:\n" + (CurrentResolution * 0.0001) + "ms";
			button2.Enabled = false;
			button1.Enabled = true;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
}
}