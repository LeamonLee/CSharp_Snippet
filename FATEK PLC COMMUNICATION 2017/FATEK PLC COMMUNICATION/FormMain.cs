using IndustrialNetworks.FatekCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustrialNetworks.FatekApp
{
    public partial class FormMain : Form
    {
        private FatekCommunication objFatekCommunication = null;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                txtResult.AppendText("FATEK PLC COMMUNICATION PROTOCOL VIA SERIALPORT\r\n");
                txtResult.AppendText("===============================================================\r\n");
                txtResult.AppendText(string.Format("1. Port Name: COM5 \r\n"));
                txtResult.AppendText(string.Format("2. BaudRate: 9600 \r\n"));
                txtResult.AppendText(string.Format("3. Parity: Even \r\n"));
                txtResult.AppendText(string.Format("4. DataBits: 7 \r\n"));
                txtResult.AppendText(string.Format("5. StopBits: One \r\n"));

                txtResult.AppendText("===============================================================\r\n");
                txtResult.AppendText("Designed By Industrial Networks\r\n");
                txtResult.AppendText("Skype: katllu\r\n");
                txtResult.AppendText("Mobile: (+84) 909.886.483\r\n");
                txtResult.AppendText("E-mail: hoangluu.automation@gmail.com\r\n");
                txtResult.AppendText("Youtube: https://www.youtube.com/industrialnetworks \r\n");
                txtResult.AppendText(Environment.NewLine);


                objFatekCommunication = new FatekCommunication("COM5", 9600, Parity.Even, 7, StopBits.One);
                objFatekCommunication.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGetPLCStatus_Click(object sender, EventArgs e)
        {
            try
            {
                PLCMode result = objFatekCommunication.GetPLCStatus(1);
                txtResult.AppendText(string.Format("PLC MODE: {0} \r\n", result));
                txtResult.AppendText(Environment.NewLine);
                txtResult.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetPLCInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string result = objFatekCommunication.GetPLCInfo(1);
                txtResult.AppendText(result);
                txtResult.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = objFatekCommunication.SetPLCMode(1, PLCMode.RUN);
                this.btnGetPLCStatus_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = objFatekCommunication.SetPLCMode(1, PLCMode.STOP);
                this.btnGetPLCStatus_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnY2ToY5ON_Click(object sender, EventArgs e)
        {
            try
            {
                int numberOfPoints = 4;
                bool[] status = new bool[numberOfPoints];
                for (int i = 0; i < status.Length; i++)
                {
                    status[i] = true;
                }
                objFatekCommunication.WriteMultipeDiscretes(1, (ushort)status.Length, MemoryType.Y, 2, DataType.BOOL, status);
                btnReadDiscretes_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnY2ToY5OFF_Click(object sender, EventArgs e)
        {
            try
            {
                int numberOfPoints = 4;
                bool[] status = new bool[numberOfPoints];
                for (int i = 0; i < status.Length; i++)
                {
                    status[i] = false;
                }
                objFatekCommunication.WriteMultipeDiscretes(1, (ushort)status.Length, MemoryType.Y, 2, DataType.BOOL, status);
                btnReadDiscretes_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetY2_Click(object sender, EventArgs e)
        {
            try
            {
                objFatekCommunication.WriteSingleDiscrete(1, CommandCode.SINGLE_DISCRETE_CONTROL, RunningCode.Set, MemoryType.Y, 2, DataType.BOOL);
                btnReadDiscretes_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetY2_Click(object sender, EventArgs e)
        {
            try
            {
                objFatekCommunication.WriteSingleDiscrete(1, CommandCode.SINGLE_DISCRETE_CONTROL, RunningCode.Reset, MemoryType.Y, 2, DataType.BOOL);
                btnReadDiscretes_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnM0ToM15ON_Click(object sender, EventArgs e)
        {
            try
            {
                int numberOfPoints = 16;
                bool[] status = new bool[numberOfPoints];
                for (int i = 0; i < status.Length; i++)
                {
                    status[i] = true;
                }
                objFatekCommunication.WriteMultipeDiscretes(1, (ushort)status.Length, MemoryType.M, 32, DataType.BOOL, status);
                txtResult.AppendText(Environment.NewLine);
                btnReadM32ToM47_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnM0ToM15OFF_Click(object sender, EventArgs e)
        {
            try
            {
                int numberOfPoints = 16;
                bool[] status = new bool[numberOfPoints];
                for (int i = 0; i < status.Length; i++)
                {
                    status[i] = false;
                }
                objFatekCommunication.WriteMultipeDiscretes(1, (ushort)status.Length, MemoryType.M, 32, DataType.BOOL, status);
                txtResult.AppendText(Environment.NewLine);
                btnReadM32ToM47_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadDiscretes_Click(object sender, EventArgs e)
        {
            try
            {
                ushort index = 0;
                bool[] result = objFatekCommunication.ReadDiscretes(1, 16, MemoryType.Y, index, DataType.BOOL);
                
                foreach (bool item in result)
                {
                    txtResult.AppendText(string.Format("[ Y{0}={1} ], ", index++, item));
                }
                txtResult.AppendText("\r\n" + Environment.NewLine);
                txtResult.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadRegisters_Click(object sender, EventArgs e)
        {
            try
            {
                ushort index = 32;
                object[] result = objFatekCommunication.ReadRegisters(1, 6, MemoryType.M, index, DataType.WORD);
                
                foreach (object item in result)
                {
                    txtResult.AppendText(string.Format("[ WM{0}={1} ], ", index++, item));
                }
                txtResult.AppendText("\r\n" + Environment.NewLine);
                txtResult.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        private void btnWriteRegisters_Click(object sender, EventArgs e)
        {
            try
            {
                FormWriteToRegisters objFormWriteToRegisters = new FormWriteToRegisters(objFatekCommunication);
                objFormWriteToRegisters.StartPosition = FormStartPosition.CenterParent;
                objFormWriteToRegisters.eventWriteToPLCChanged += new EventWriteToPLCChanged(() =>
                {
                    this.btnReadRegisters_Click(sender, e);
                });
                objFormWriteToRegisters.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadM32ToM47_Click(object sender, EventArgs e)
        {
            try
            {
                ushort index = 32;
                bool[] result = objFatekCommunication.ReadDiscretes(1, 16, MemoryType.M, index, DataType.BOOL);                
                foreach (bool item in result)
                {
                    txtResult.AppendText(string.Format("[ M{0}={1} ], ", index++, item));
                }
                txtResult.AppendText(Environment.NewLine);
                txtResult.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadRandomRegisters_Click(object sender, EventArgs e)
        {
            List<RandomRegister> randomRegisters = new List<RandomRegister>();
            randomRegisters.Add(new RandomRegister() { MemoryType = MemoryType.X, Address = 0, DataType = DataType.WORD });
            randomRegisters.Add(new RandomRegister() { MemoryType = MemoryType.Y, Address = 2, DataType = DataType.BOOL });
            randomRegisters.Add(new RandomRegister() { MemoryType = MemoryType.M, Address = 47, DataType = DataType.BOOL });

            RandomRegister[] result = objFatekCommunication.ReadRadomDiscreteOrRegisters(1, (ushort)randomRegisters.Count, randomRegisters);
            foreach (RandomRegister item in result)
            {
                switch (item.DataType)
                {
                    case DataType.BOOL:
                        txtResult.AppendText(string.Format("[ {0}{1}={2} ], ", item.MemoryType, item.Address, item.Value));
                        break;
                    case DataType.INT:
                    case DataType.WORD:
                        txtResult.AppendText(string.Format("[ W{0}{1}={2} ], ", item.MemoryType, item.Address, item.Value));
                        break;
                    case DataType.DINT:
                    case DataType.DWORD:
                    case DataType.REAL:
                        txtResult.AppendText(string.Format("[ DW{0}{1}={2} ], ", item.MemoryType, item.Address, item.Value));
                        break;
                }

            }
            txtResult.AppendText(Environment.NewLine);
            txtResult.ScrollToCaret();
        }
    }
}
