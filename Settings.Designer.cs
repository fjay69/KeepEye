namespace KeepEye2
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.followMouse = new System.Windows.Forms.CheckBox();
            this.chRun = new System.Windows.Forms.CheckBox();
            this.worktime = new System.Windows.Forms.TextBox();
            this.sleeptime = new System.Windows.Forms.TextBox();
            this.pausetime = new System.Windows.Forms.TextBox();
            this.pausemult = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // followMouse
            // 
            resources.ApplyResources(this.followMouse, "followMouse");
            this.followMouse.Name = "followMouse";
            this.followMouse.UseVisualStyleBackColor = true;
            this.followMouse.CheckedChanged += new System.EventHandler(this.worktime_TextChanged);
            // 
            // chRun
            // 
            resources.ApplyResources(this.chRun, "chRun");
            this.chRun.Name = "chRun";
            this.chRun.UseVisualStyleBackColor = true;
            this.chRun.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // worktime
            // 
            resources.ApplyResources(this.worktime, "worktime");
            this.worktime.Name = "worktime";
            this.worktime.TextChanged += new System.EventHandler(this.worktime_TextChanged);
            // 
            // sleeptime
            // 
            resources.ApplyResources(this.sleeptime, "sleeptime");
            this.sleeptime.Name = "sleeptime";
            this.sleeptime.TextChanged += new System.EventHandler(this.worktime_TextChanged);
            // 
            // pausetime
            // 
            resources.ApplyResources(this.pausetime, "pausetime");
            this.pausetime.Name = "pausetime";
            this.pausetime.TextChanged += new System.EventHandler(this.worktime_TextChanged);
            // 
            // pausemult
            // 
            resources.ApplyResources(this.pausemult, "pausemult");
            this.pausemult.Name = "pausemult";
            this.pausemult.TextChanged += new System.EventHandler(this.worktime_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1")});
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pausemult);
            this.Controls.Add(this.pausetime);
            this.Controls.Add(this.sleeptime);
            this.Controls.Add(this.worktime);
            this.Controls.Add(this.chRun);
            this.Controls.Add(this.followMouse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox followMouse;
        private System.Windows.Forms.CheckBox chRun;
        private System.Windows.Forms.TextBox worktime;
        private System.Windows.Forms.TextBox sleeptime;
        private System.Windows.Forms.TextBox pausetime;
        private System.Windows.Forms.TextBox pausemult;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}