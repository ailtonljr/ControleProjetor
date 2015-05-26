using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace ControleProjetor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOn_Click(object sender, EventArgs e)
        {
            byte[] cmd = new byte[] { 0x7E, 0x50, 0x4e, 0x0D, 0x56, 0x39, 0x39, 0x53, 0x30, 0x30, 0x30, 0x31, 0x0D };
            sendCommand(cmd);
           
            
            

        }


        private void sendCommand(byte[] cmd)
        {
            foreach (String port in SerialPort.GetPortNames())
            {
                try
                {
                    serialPort1.PortName = port;

                   

                    serialPort1.Open();
                    serialPort1.Write(cmd, 0, cmd.Length);
                    Thread.Sleep(100);


                }
                catch (Exception)
                {
                }
                finally
                {
                    serialPort1.Close();
                }
            }
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            //Vivitek D5 - 0x7E, 0x50, 0x46, 0x0D
            //Vivitek D8 - 0x56, 0x39, 0x39, 0x53, 0x30, 0x30, 0x30, 0x32, 0x0D 

            byte[] cmd = new byte[] { 0x7E, 0x50, 0x46, 0x0D, 0x56, 0x39, 0x39, 0x53, 0x30, 0x30, 0x30, 0x32, 0x0D };
            sendCommand(cmd);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Comentário
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

        }
    }
}
