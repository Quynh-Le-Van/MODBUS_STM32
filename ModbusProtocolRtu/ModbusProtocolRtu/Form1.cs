using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ModbusProtocolRtu
{
    public partial class Form1 : Form
    {
        public byte SID;
        public byte fn;
        public ushort startAddr;
        public ushort numRegs;
        public ushort[] data = new ushort[150];
        public byte err;

        public Form1()
        {
            InitializeComponent();            
        }


        /* tao ma crc  */
        public byte[] CRC16_Check_A(byte[] mess) //Ham CRC 16
        {
            UInt16 crc = 0xFFFF;
            char crc_lsb;

            for (int i = 0; i < mess.Length-2; i++)
            {
                crc ^= (UInt16)mess[i];

                for (int j = 0; j < 8; j++)
                {
                    crc_lsb = (char)(crc & 0x0001);
                    crc = (UInt16)((crc >> 1) & 0x7FFF);
                    if (crc_lsb == 1)
                    {
                        crc ^= 0xA001;
                    }
                }
            }

            byte[] tmp = new byte[2];
            tmp[0] = (byte)(crc & 0x00FF);
            tmp[1] = (byte)((crc >> 8) & 0x00FF);

            return tmp;

        }

        // ghi 4 byte dau tien cua dataframe (vi 4 byte dau giong nhau )
        public byte[] fisrt4Byte(int lenght)
        {
            byte[] mess = new byte[lenght];
            mess[0] = SID;
            mess[1] = fn;
            mess[2] = (byte)((startAddr >> 8) & 0x00FF);
            mess[3] = (byte)(startAddr & 0x00FF);

            return mess;
        }

        // read holding register (function 03H) 
        public void Read_Register_Fnc03(byte Fn, ushort staraddr, ushort numregs)
        {
            byte[] tmp;
            byte[] mess = new byte[8];

            fn = Fn;
            startAddr = staraddr;
            numRegs = numregs;

            // gui 
            mess = fisrt4Byte(8);
            mess[4] = (byte)((numRegs >> 8) & 0x00FF);
            mess[5] = (byte)(numRegs & 0x00FF);
            byte[] crc = new byte[2];
            crc = CRC16_Check_A(mess);
            mess[6] = crc[0];
            mess[7] = crc[1];

            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            serialPort1.Write(mess, 0, mess.Length);

            // hien thi
            textBoxsend.Text = BitConverter.ToString(mess); // chuyen sang so hex 


            // nhan
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            tmp = new byte[5 + numRegs * 2];

            for(int i=0; i<tmp .Length; i++)
            {
                tmp[i] = (byte)serialPort1.ReadByte();
            }

            // hien thi
            textBoxreceive.Text = BitConverter.ToString(tmp);
            for(int i=0;i<numRegs;i++)
            {
                int result= (int)((tmp[3 + 2 * i] << 8) | tmp[3 + 2 * i + 1]);
                textBoxvalue3.AppendText( result.ToString() + Environment.NewLine);
            }

        }

        // write multiple registers (function_10H)
        public void Multiple_Registers_10H(byte Fn, ushort staraddr, ushort numregs,ushort[] data)
        {
            byte[] tmp;
            byte[] mess = new byte[9 + numregs * 2];

            fn = Fn;
            startAddr = staraddr;
            numRegs = numregs;

            // gui
            mess = fisrt4Byte(mess.Length);
            mess[4] = (byte)((numRegs >> 8) & 0x00FF);
            mess[5] = (byte)(numRegs & 0x00FF);
            mess[6] = (byte)((numRegs & 0x00FF)*2);

            for(byte i=0;i<numRegs;i++)
            {
                mess[7 + i * 2] = (byte)((data[i] >> 8) & 0x00FF);
                mess[7 + i * 2 + 1 ] = (byte)(data[i] & 0x00FF);
            }

            byte[] crc = new byte[2];
            crc = CRC16_Check_A(mess);
            mess[7+ numRegs*2] = crc[0];
            mess[8 + numRegs * 2] = crc[1];

            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            serialPort1.Write(mess, 0, mess.Length);
            textBoxsend10.Text = BitConverter.ToString(mess); // chuyen sang so hex

            // nhan 
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            tmp = new byte[8];
            for(int i=0; i<8; i++)
            {
                tmp[i] = (byte)(serialPort1.ReadByte());
            }
            textBoxreceive10.Text = BitConverter.ToString(tmp);
        }


        private void buttonconnect_Click(object sender, EventArgs e)
        {
            if (comboBoxbaudrate.Text == "" || comboBoxdatabits.Text == "" || comboBoxparity.Text == "" || comboBoxportname.Text == "")
            {
                const string message = "Choose connect type pleaes .";
                MessageBox.Show(message,"Warming", MessageBoxButtons.OK);
            }
            else
            {
                serialPort1.PortName = comboBoxportname.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBoxbaudrate.Text);
                serialPort1.DataBits = Convert.ToInt32(comboBoxdatabits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxparity.Text);
                serialPort1.Open();
            }
        }

        private void buttondisconnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxportname.Items.AddRange(ports);
        }

        private void buttonsend03_Click(object sender, EventArgs e)
        {
            textBoxvalue3.Clear();

            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("Please connect .", "Warming", MessageBoxButtons.OK);
            }
            else
            {
                if (textBoxid.Text == "" || textBoxstartaddr.Text == "" || textBoxnumreg.Text == "" || textBoxfn.Text=="")
                {
                    MessageBox.Show("Please complete blank textbox .", "Warming", MessageBoxButtons.OK);
                }
                else
                {
                    SID = byte.Parse(textBoxid.Text);
                    startAddr = ushort.Parse(textBoxstartaddr.Text);
                    numRegs = ushort.Parse(textBoxnumreg.Text);

                    // gui data frame            
                    Read_Register_Fnc03(3, startAddr, numRegs);
                }
            }
            
        }
   
        private void buttonsend10_Click(object sender, EventArgs e)
        {

            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("Please connect .", "Warming", MessageBoxButtons.OK);
            }
            else
            {
                if (textBoxid10.Text == "" || textBoxstartaddr10.Text == "" || textBoxnumreg10.Text == "" || textBoxfn10.Text == "" )
                {
                    MessageBox.Show("Please complete blank textbox .", "Warming", MessageBoxButtons.OK);
                }
                else
                {   
                    // lay gia tri trong cac textBox
                    SID = byte.Parse(textBoxid10.Text);
                    startAddr = ushort.Parse(textBoxstartaddr10.Text);
                    numRegs = ushort.Parse(textBoxnumreg10.Text);

                    // kiem tra textBox Value Registers
                    if (textBoxvalue.Lines.Count() != numRegs)
                    {
                        MessageBox.Show("Check a number of value of registers in textBox !!", "Warming", MessageBoxButtons.OK);
                    }
                    else
                    {
                        for (int i = 0; i < numRegs; i++)
                        {
                            data[i] = ushort.Parse(textBoxvalue.Lines[i]);
                        }
                    }

                    // gui dataframe
                    Multiple_Registers_10H(16, startAddr, numRegs, data);
                }
            }
           
        }


    }

}
