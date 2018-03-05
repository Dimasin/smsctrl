// Copyright © 2018 Dimasin. All rights reserved.

using System;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace smsctrl
{
    public partial class SMSCtrl : Form
    {
        Int32 count = 0;
        Int32 interval = 1;
        Boolean iconflag = true;
        Boolean smsoffflag = false;
        Boolean smsonflag = false;
        Int32 g_counter = 0;
        Int32 allowerr = 1;
        Int32 tsms = 60;
        Int32 port = 22;
        IPAddress addr;

        const int hr = unchecked((int)0x80004005);
        ProcessStartInfo sms = new ProcessStartInfo("c:\\Program Files (x86)\\MTC SMS-MMS\\mw.exe");
        ProcessStartInfo sms_off;
        ProcessStartInfo sms_on;

        Icon red = Properties.Resources.red;
        Icon gray = Properties.Resources.gray;
        Icon green = Properties.Resources.green;

        public SMSCtrl()
        {
            InitializeComponent();
        }

        private void SMSCtrl_Load(object sender, EventArgs e)
        {
            Process.Start(sms);
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                this.IPaddr.Text = appSettings["ipaddr"];
                this.IPport.Text = appSettings["ipport"];
                this.Phone.Text = appSettings["phone"];
                this.SMSoff.Text = appSettings["smsoff"];
                this.SMSon.Text = appSettings["smson"];
                this.TimeoutConnect.Text = appSettings["tconnect"];
                this.TimeoutSMS.Text = appSettings["tsms"];
                this.AllowErr.Text = appSettings["allowerr"];
                String auto = appSettings["autostart"];
                if ((auto != null) && (auto.Length == 1))
                {
                    Int32 astart = 0;
                    if (!Int32.TryParse(auto, out astart))
                        astart = 0;
                    if (astart == 1)
                    {
                        this.button1.Checked = true;
                        button1_Click(null, null);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "SMS Ctrl";
            if (this.button1.Checked)
            {
                if (!TimerConnect.Enabled)
                {
                    try
                    {
                        //Разбор переменных
                        if (!Int32.TryParse(this.TimeoutConnect.Text, out interval))
                            interval = 1;
                        this.TimeoutConnect.Text = interval.ToString();
                        interval = interval * 60;

                        if (!Int32.TryParse(this.AllowErr.Text, out allowerr))
                            allowerr = 1;
                        this.AllowErr.Text = allowerr.ToString();

                        if (!Int32.TryParse(this.TimeoutSMS.Text, out tsms))
                            tsms = 60;
                        this.TimeoutSMS.Text = tsms.ToString();
                        tsms = tsms * 1000;

                        if (!Int32.TryParse(this.IPport.Text, out port))
                            port = 22;
                        this.IPport.Text = port.ToString();

                        addr = IPAddress.Parse(this.IPaddr.Text);
                        this.IPaddr.Text = addr.ToString();
                        //Задание на запуск процессов
                        sms_off = new ProcessStartInfo("c:\\Program Files (x86)\\MTC SMS-MMS\\mw.exe", "-text " + this.SMSoff.Text.Trim() + " -number " + this.Phone.Text.Trim() + " -silent -newsms");
                        sms_on = new ProcessStartInfo("c:\\Program Files (x86)\\MTC SMS-MMS\\mw.exe", "-text " + this.SMSon.Text.Trim() + " -number " + this.Phone.Text.Trim() + " -silent -newsms");
                    }
                    catch
                    {
                        //Если произошла ошибка, выходим ничего не блокируя и не запуская
                        return;
                    }
                    //Блокируем элементы
                    this.IPaddr.Enabled = false;
                    this.IPport.Enabled = false;
                    this.TimeoutConnect.Enabled = false;
                    this.AllowErr.Enabled = false;
                    this.Phone.Enabled = false;
                    this.SMSoff.Enabled = false;
                    this.SMSon.Enabled = false;
                    this.TimeoutSMS.Enabled = false;
                    //Устанавливаем начальные состояния переменных
                    g_counter = 0;
                    count = 0;
                    button1.Text = "Stop";
                    smsonflag = false;
                    smsoffflag = false;
                    TimerConnect.Enabled = true;
                }
            }
            else
            {
                if (TimerConnect.Enabled)
                {
                    TimerConnect.Enabled = false;
                    this.IPaddr.Enabled = true;
                    this.IPport.Enabled = true;
                    this.TimeoutConnect.Enabled = true;
                    this.AllowErr.Enabled = true;
                    this.Phone.Enabled = true;
                    this.SMSoff.Enabled = true;
                    this.SMSon.Enabled = true;
                    this.TimeoutSMS.Enabled = true;
                    this.Icon = gray;
                    button1.Text = "Start";
                }
            }
        }

        private void TimerConnect_Tick(object sender, EventArgs e)
        {
            //Таймер тикает каждую секунду, а нам нужно чтобы некоторые вещи запускались через каждые interval * 60 секунд
            if (g_counter == 0)
            {
                //Запускаем воркер если он еще не запущен
                if (!bgTimer.IsBusy)
                    bgTimer.RunWorkerAsync();
            }
            //Обеспечиваем пропуск интервала запуска воркера
            if (g_counter != interval)
                g_counter++;
            else
                g_counter = 0;
            //Переключаем иконку каждую секунду
            if (iconflag)
            {
                if (count > 0)
                {
                    this.Icon = red;
                    //Устанавливаем текст окна в зависимости от ситуации
                    if (smsoffflag | smsonflag)
                    {
                        if (smsoffflag)
                            this.Text = "SMS Ctrl - send SMS off";
                        if (smsonflag)
                            this.Text = "SMS Ctrl - send SMS on";
                    }
                    else
                        this.Text = "SMS Ctrl - " + count.ToString();
                }
                else
                {
                    this.Icon = green;
                    this.Text = "SMS Ctrl";
                }
                iconflag = false;
            }
            else
            {
                this.Icon = gray;
                iconflag = true;
            }
        }

        private void bgTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IPEndPoint ep = new IPEndPoint(addr, port);
                TcpClient tcpclnt = new TcpClient();

                tcpclnt.Connect(ep);
                if (tcpclnt.Connected)
                {
                    //Если коннект есть, сбрасываем счетчик
                    count = 0;
                    tcpclnt.Close();
                }
            }
            catch (Exception ex)
            {
                //Считаем ошибки подключения
                if (ex.HResult == hr)
                {
                    count++;
                }
            }
            //Реакция на превышение порога
            if (count >= allowerr)
            {
                //Отправляем СМС если есть какой то текст
                if (!string.IsNullOrEmpty(this.SMSoff.Text))
                {
                    smsoffflag = true;
                    Process.Start(sms_off);
                    //Отправляем вторую СМС если там есть текст
                    if (!string.IsNullOrEmpty(this.SMSon.Text))
                    {
                        Thread.Sleep(tsms);
                        smsonflag = true;
                        Process.Start(sms_on);
                    }
                    //Пауза 10 сек чтобы заголовок сразу не исчез
                    Thread.Sleep(10000);
                }
                //Сброс счетчиков и флагов
                count = 0;
                g_counter = 0;
                smsonflag = false;
                smsoffflag = false;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                //=================================================IPaddr====================
                if (settings["ipaddr"] == null)
                    settings.Add("ipaddr", this.IPaddr.Text);
                else
                    settings["ipaddr"].Value = this.IPaddr.Text;
                //=================================================IPport====================
                if (settings["ipport"] == null)
                    settings.Add("ipport", this.IPport.Text);
                else
                    settings["ipport"].Value = this.IPport.Text;
                //=================================================Phone ====================
                if (settings["phone"] == null)
                    settings.Add("phone", this.Phone.Text);
                else
                    settings["phone"].Value = this.Phone.Text;
                //=================================================SMSoff====================
                if (settings["smsoff"] == null)
                    settings.Add("smsoff", this.SMSoff.Text);
                else
                    settings["smsoff"].Value = this.SMSoff.Text;
                //=================================================SMSon ====================
                if (settings["smson"] == null)
                    settings.Add("smson", this.SMSon.Text);
                else
                    settings["smson"].Value = this.SMSon.Text;
                //=================================================TimeoutConnect============
                if (settings["tconnect"] == null)
                    settings.Add("tconnect", this.TimeoutConnect.Text);
                else
                    settings["tconnect"].Value = this.TimeoutConnect.Text;
                //=================================================TimeoutSMS================
                if (settings["tsms"] == null)
                    settings.Add("tsms", this.TimeoutSMS.Text);
                else
                    settings["tsms"].Value = this.TimeoutSMS.Text;
                //=================================================AllowErr==================
                if (settings["allowerr"] == null)
                    settings.Add("allowerr", this.AllowErr.Text);
                else
                    settings["allowerr"].Value = this.AllowErr.Text;
                //=================================================AutoStart=================
                if (settings["autostart"] == null)
                    settings.Add("autostart", "0");

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
            }
        }
    }
}
