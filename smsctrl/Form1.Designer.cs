namespace smsctrl
{
    partial class SMSCtrl
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMSCtrl));
            this.TimerConnect = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.IPaddr = new System.Windows.Forms.TextBox();
            this.IPport = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.SMSoff = new System.Windows.Forms.TextBox();
            this.SMSon = new System.Windows.Forms.TextBox();
            this.TimeoutConnect = new System.Windows.Forms.TextBox();
            this.AllowErr = new System.Windows.Forms.TextBox();
            this.TimeoutSMS = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.CheckBox();
            this.bgTimer = new System.ComponentModel.BackgroundWorker();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TimerConnect
            // 
            this.TimerConnect.Interval = 1000;
            this.TimerConnect.Tick += new System.EventHandler(this.TimerConnect_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP addres:port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phone number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "SMS off";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Timeout (min)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Allowed errors";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Timeout (sec)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "SMS on";
            // 
            // IPaddr
            // 
            this.IPaddr.Location = new System.Drawing.Point(126, 8);
            this.IPaddr.Name = "IPaddr";
            this.IPaddr.Size = new System.Drawing.Size(159, 22);
            this.IPaddr.TabIndex = 1;
            this.IPaddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IPport
            // 
            this.IPport.Location = new System.Drawing.Point(291, 8);
            this.IPport.Name = "IPport";
            this.IPport.Size = new System.Drawing.Size(55, 22);
            this.IPport.TabIndex = 2;
            this.IPport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(126, 64);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(220, 22);
            this.Phone.TabIndex = 5;
            this.Phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SMSoff
            // 
            this.SMSoff.Location = new System.Drawing.Point(126, 92);
            this.SMSoff.Name = "SMSoff";
            this.SMSoff.Size = new System.Drawing.Size(220, 22);
            this.SMSoff.TabIndex = 6;
            this.SMSoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SMSon
            // 
            this.SMSon.Location = new System.Drawing.Point(126, 120);
            this.SMSon.Name = "SMSon";
            this.SMSon.Size = new System.Drawing.Size(220, 22);
            this.SMSon.TabIndex = 7;
            this.SMSon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TimeoutConnect
            // 
            this.TimeoutConnect.Location = new System.Drawing.Point(126, 36);
            this.TimeoutConnect.Name = "TimeoutConnect";
            this.TimeoutConnect.Size = new System.Drawing.Size(55, 22);
            this.TimeoutConnect.TabIndex = 3;
            this.TimeoutConnect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AllowErr
            // 
            this.AllowErr.Location = new System.Drawing.Point(291, 36);
            this.AllowErr.Name = "AllowErr";
            this.AllowErr.Size = new System.Drawing.Size(55, 22);
            this.AllowErr.TabIndex = 4;
            this.AllowErr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TimeoutSMS
            // 
            this.TimeoutSMS.Location = new System.Drawing.Point(126, 150);
            this.TimeoutSMS.Name = "TimeoutSMS";
            this.TimeoutSMS.Size = new System.Drawing.Size(55, 22);
            this.TimeoutSMS.TabIndex = 8;
            this.TimeoutSMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Appearance = System.Windows.Forms.Appearance.Button;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(268, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "Start";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bgTimer
            // 
            this.bgTimer.WorkerSupportsCancellation = true;
            this.bgTimer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgTimer_DoWork);
            // 
            // Save
            // 
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Save.Location = new System.Drawing.Point(186, 150);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(80, 26);
            this.Save.TabIndex = 16;
            this.Save.Text = "Save Conf";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SMSCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 187);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TimeoutSMS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AllowErr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TimeoutConnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SMSon);
            this.Controls.Add(this.SMSoff);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IPport);
            this.Controls.Add(this.IPaddr);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SMSCtrl";
            this.Text = "SMS Ctrl";
            this.Load += new System.EventHandler(this.SMSCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IPaddr;
        private System.Windows.Forms.TextBox IPport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SMSoff;
        private System.Windows.Forms.TextBox SMSon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TimeoutConnect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AllowErr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TimeoutSMS;
        private System.Windows.Forms.CheckBox button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer TimerConnect;
        private System.ComponentModel.BackgroundWorker bgTimer;
        private System.Windows.Forms.Button Save;
    }
}

