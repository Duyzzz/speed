using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace levaduy2021603366
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort.Open();
            textBox1.Hide();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void serialPort_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {

        }
        string data = "";
        int speed = 0;  
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int result = 0;
            data = serialPort.ReadLine();
            if(int.TryParse(data, out result))
            {
                speed = result;
                textBox1.Text = speed.ToString() + " rpm";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(serialPort.IsOpen)
            {
                serialPort.Write("o");
                textBox1.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write("n");
                textBox1.Hide();
            }
        }
    }
}
