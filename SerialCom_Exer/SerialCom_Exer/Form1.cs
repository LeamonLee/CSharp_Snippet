using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialCom_Exer
{
    public partial class Form1 : Form
    {
        //console 參數
        private bool Console_receiving = false;
        private Thread t;
        //使用Delegate顯示 Console 畫面
        delegate void displayDelegate(string buffer);

        private SerialPort serialPort1;
        public Form1()
        {
            InitializeComponent();
        }

        public void openCom()
        {
            try
            {
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.PortName = cbComPorts.Text;
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
                serialPort1.Parity = System.IO.Ports.Parity.None;
                serialPort1.ReadTimeout = 100;

                serialPort1.Open();
                if (!serialPort1.IsOpen)
                {
                    MessageBox.Show("ComPort failed to open ");
                    return;
                }
                else
                {
                    rchTxtBoxRcvMsg.AppendText("Port" + cbComPorts.Text + "opened successfully\r\n");
                }
                serialPort1.DataReceived += serialPort1_DataReceived;
            }
            catch (Exception ex)
            {
                serialPort1.Dispose();
                rchTxtBoxRcvMsg.AppendText(ex.Message);
            }
        }

        //Connect COM PORT
        public void connectComPort(string COM, Int32 baud)
        {
            try
            {
                serialPort1 = new SerialPort();

                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }

                //設定 Serial Port 參數
                serialPort1.PortName = COM;
                serialPort1.BaudRate = baud;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = System.IO.Ports.Parity.None;
                serialPort1.ReadTimeout = 100;

                if (!serialPort1.IsOpen)
                {
                    //開啟 Serial Port
                    serialPort1.Open();

                    Console_receiving = true;

                    //開啟執行續做接收動作
                    t = new Thread(OnReceive);
                    t.IsBackground = true;
                    t.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Data receiving event, so that we don't have to keep pulling data in thread.
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(50);  //（毫秒）等待一定時間，確保資料的完整性 int len        
            int len = serialPort1.BytesToRead;
            string receivedata = string.Empty;
            if (len != 0)
            {
                byte[] buff = new byte[len];
                serialPort1.Read(buff, 0, len);
                receivedata = Encoding.Default.GetString(buff);

            }
            rchTxtBoxRcvMsg.AppendText(receivedata + "\r\n");
        }

        public void updateUI(string buffer)
        {
            rchTxtBoxRcvMsg.AppendText(buffer);
        }

        //Console 接收資料
        private void OnReceive()
        {
            Byte[] buffer = new Byte[1024];

            try
            {
                while (Console_receiving)
                {
                    if (serialPort1.BytesToRead > 0)
                    {
                        Int32 length = serialPort1.Read(buffer, 0, buffer.Length);

                        string buf = Encoding.ASCII.GetString(buffer);

                        Array.Resize(ref buffer, length);
                        displayDelegate d = new displayDelegate(updateUI);
                        this.Invoke(d, new Object[] { buf });
                        Array.Resize(ref buffer, 1024);
                    }

                    Thread.Sleep(20);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Console 發送資料
        public void SendData(string sendBuffer)
        {
            if (sendBuffer.Length > 0)
            {
                Byte[] buffer = Encoding.ASCII.GetBytes(sendBuffer);

                try
                {
                    serialPort1.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    closeComPort();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //關閉 Console
        public void closeComPort()
        {
            try
            {
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console_receiving = false;
            //關閉 Serial Port
            closeComPort();
        }

        private void cbComPorts_DropDown(object sender, EventArgs e)
        {
            String[] portnames = SerialPort.GetPortNames();
            foreach (var item in portnames)
            {
                cbComPorts.Items.Add(item);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string strSend = txtBoxSend.Text;
            if(strSend.Length > 0)
            {
                SendData(strSend);
            }
            
        }
    }
}
