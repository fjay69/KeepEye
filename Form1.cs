using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace KeepEye2
{
    public partial class Form1 : Form
    {
        static public double worktime, sleeptime, pausetime, pausemult;
        static public Boolean followmouse, time3null;
        static DateTime stageMoment, sleepMoment, lastMouseMoveMoment, x;
        static int stage;
        static uint z1, z2;

        ResourceManager LocRM = new ResourceManager("KeepEye2.Form1", typeof(Form1).Assembly);
        static public CultureInfo cul = new CultureInfo("ru");//Debug

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern bool BlockInput([In, MarshalAs(UnmanagedType.Bool)] bool blc);

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            changeIcon("a");
            if (sleepMoment < DateTime.Now && stage == 0)
            {
                System.Media.SystemSounds.Exclamation.Play();
                notifyIcon1.ShowBalloonTip(10000, "KeepEye", LocRM.GetString("OneMinute"), ToolTipIcon.Info);
                stage = 1;
            }
            if (stageMoment < DateTime.Now)
            {
                switch (stage)
                {
                    case 1:
                        asleep();
                        break;
                    case 2:
                        //BlockInput(false);
                        label1.Text = LocRM.GetString("AnyKey");
                        label1.Left = (SystemInformation.PrimaryMonitorSize.Width / 2) - (label1.Width / 2);
                        label2.Text = "Ожидание";
                        label2.Left = (SystemInformation.PrimaryMonitorSize.Width / 2) - (label2.Width / 2);
                        break;
                }
            }
            else
            {
                label2.Text = (stageMoment - DateTime.Now).ToString("hh':'mm':'ss");
            }
        }

        private void changeIcon(string ab)
        {
            notifyIcon1.Icon = (Icon)Properties.Resources.ResourceManager.GetObject(ab + Math.Ceiling((stageMoment - DateTime.Now).TotalSeconds / worktime * 4).ToString("F0"));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);
            z2 = lastInPut.dwTime;
            if (z1 == z2)
            {
                if (time3null)
                {
                    time3null = false;
                    lastMouseMoveMoment = DateTime.Now;
                }
                if ((DateTime.Now - lastMouseMoveMoment).TotalSeconds > pausetime && timer1.Enabled && followmouse && FindWindow("MediaPlayerClassicW", null) == IntPtr.Zero) PauseUnpause(null, null);
            }
            else
            {
                z1 = z2; time3null = true;
                if (!timer1.Enabled) PauseUnpause(null, null);
            }
        }

        private void PauseUnpause(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                changeIcon("b");
                timer1.Enabled = false;
                x = DateTime.Now;
            }
            else
            {
                stageMoment = stageMoment.AddSeconds(pausemult * (DateTime.Now - x).TotalSeconds);
                if ((stageMoment - DateTime.Now).TotalSeconds > worktime) stageMoment = DateTime.Now.AddSeconds(worktime);
                sleepMoment = stageMoment.AddSeconds(-60);
                if (sleepMoment < DateTime.Now) stage = 1; else stage = 0;
                timer1.Enabled = true;
            }
        }

        private void отслМышьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            отслМышьToolStripMenuItem.Checked = !отслМышьToolStripMenuItem.Checked;
            followmouse = отслМышьToolStripMenuItem.Checked;
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KeepEye 2015 (C) F-JAY");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void режимОтдыхаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            asleep();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewStart();
        }

        private void NewStart()
        {
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                StreamReader strr = new StreamReader("settings.xml", System.Text.Encoding.UTF8);
                xmldoc.LoadXml(strr.ReadToEnd());
                strr.Close();
            }
            catch (FileNotFoundException e)
            {
                xmldoc.LoadXml("<KeepEye></KeepEye>");
            }
            XmlElement setting;
            setting = (XmlElement)xmldoc.DocumentElement.SelectSingleNode("setting[@id='worktime']");
            worktime = (setting == null ? 60.0 : float.Parse(setting.InnerText)) * 60;
            setting = (XmlElement)xmldoc.DocumentElement.SelectSingleNode("setting[@id='sleeptime']");
            sleeptime = (setting == null ? 10.0 : float.Parse(setting.InnerText)) * 60;
            setting = (XmlElement)xmldoc.DocumentElement.SelectSingleNode("setting[@id='pausetime']");
            pausetime = (setting == null ? 1.5 : float.Parse(setting.InnerText)) * 60;
            setting = (XmlElement)xmldoc.DocumentElement.SelectSingleNode("setting[@id='pausemult']");
            pausemult = setting == null ? 5.0 : float.Parse(setting.InnerText);
            setting = (XmlElement)xmldoc.DocumentElement.SelectSingleNode("setting[@id='followmouse']");
            followmouse = setting == null ? true : float.Parse(setting.InnerText) == 1.0;
            отслМышьToolStripMenuItem.Checked = followmouse;
            stageMoment = DateTime.Now.AddSeconds(worktime);
            sleepMoment = stageMoment.AddSeconds(-60);
        }
        
        private void asleep()
        {
            Cursor.Hide();
            timer2.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
            this.Visible = true;
            stage = 2;
            stageMoment = DateTime.Now.AddSeconds(sleeptime);

            label1.Text = LocRM.GetString("UntilText");
            label1.Left = (SystemInformation.PrimaryMonitorSize.Width / 2) - (label1.Width / 2);
            label1.Top = (SystemInformation.PrimaryMonitorSize.Height / 2) - (label1.Height / 2);
            label2.Text = (stageMoment - DateTime.Now).ToString("hh':'mm':'ss");
            label2.Left = (SystemInformation.PrimaryMonitorSize.Width / 2) - (label2.Width / 2);
            label2.Top = (SystemInformation.PrimaryMonitorSize.Height / 2) - (label2.Height / 2) + 30;
            //BlockInput(true);            
        }
    }
}
