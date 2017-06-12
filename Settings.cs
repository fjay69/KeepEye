using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KeepEye2
{
    public partial class Settings : Form
    {
        Microsoft.Win32.RegistryKey rkApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            NumberFormatInfo fodot = new NumberFormatInfo();
            fodot.NumberDecimalDigits = 2;
            fodot.NumberDecimalSeparator = ",";

            worktime.Text = Math.Round(Form1.worktime / 60, 2).ToString(fodot);
            sleeptime.Text = Math.Round(Form1.sleeptime / 60, 2).ToString(fodot);
            pausetime.Text = Math.Round(Form1.pausetime / 60, 2).ToString(fodot);
            pausemult.Text = Form1.pausemult.ToString(fodot);
            followMouse.Checked = Form1.followmouse;
            chRun.Checked = rkApp.GetValue("KeepEye") != null;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chRun.Checked)
                rkApp.SetValue("KeepEye", Application.ExecutablePath);
            else
                rkApp.DeleteValue("KeepEye", false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "English")
                Form1.cul = new CultureInfo("en");
            else if (comboBox1.SelectedItem.ToString() == "Русский")
                Form1.cul = new CultureInfo("ru");

            System.Threading.Thread.CurrentThread.CurrentCulture = Form1.cul;
            System.Threading.Thread.CurrentThread.CurrentUICulture = Form1.cul;
            Controls.Clear();
            InitializeComponent();
        }

        void recordXML()
        {
            XDocument xmldoc = new XDocument(
            new XElement("keepeye",
                new XElement("setting", new XAttribute("id", "worktime"), worktime.Text),
                new XElement("setting", new XAttribute("id", "sleeptime"), sleeptime.Text),
                new XElement("setting", new XAttribute("id", "pausetime"), pausetime.Text),
                new XElement("setting", new XAttribute("id", "pausemult"), pausemult.Text),
                new XElement("setting", new XAttribute("id", "followmouse"), followMouse.Checked ? 1 : 0)
            ));
            StreamWriter tpag = new StreamWriter("settings.xml", false, System.Text.Encoding.UTF8);
            tpag.Write(xmldoc.ToString());
            tpag.Close();
        }

        private void worktime_TextChanged(object sender, EventArgs e)
        {
            Form1.followmouse = followMouse.Checked;
            recordXML();
        }
    }
}
