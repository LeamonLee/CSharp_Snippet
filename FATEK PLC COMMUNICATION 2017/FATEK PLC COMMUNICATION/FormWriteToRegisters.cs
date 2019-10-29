using IndustrialNetworks.FatekCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustrialNetworks.FatekApp
{
    public delegate void EventWriteToPLCChanged();
    public partial class FormWriteToRegisters : Form
    {
        private FatekCommunication objFatekCommunication = null;
        public EventWriteToPLCChanged eventWriteToPLCChanged = null;

        public FormWriteToRegisters(FatekCommunication fatekCommunication)
        {
            InitializeComponent();
            objFatekCommunication = fatekCommunication;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                object[] data = new object[6]
                {
                    ushort.Parse(txtWM32.Text),
                    ushort.Parse(txtWM33.Text),
                    ushort.Parse(txtWM34.Text),
                    ushort.Parse(txtWM35.Text),
                    ushort.Parse(txtWM36.Text),
                    ushort.Parse(txtWM37.Text)
                };
                objFatekCommunication.WriteMultipeRegisters(1, (ushort)data.Length, MemoryType.M, 32, DataType.WORD, data);
                if (eventWriteToPLCChanged != null) eventWriteToPLCChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
