using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using GruppoOilPrototipo.view;
using System.Threading;


namespace GruppoOilPrototipo
{
    public class SerialPortReader
    {
        private FileMenager data;
        private Form1 form;
        // Create the serial port with basic settings 
        private SerialPort port;
        private System.Threading.Thread CloseDown;
        public FileMenager Data
        {
            get { return data; }
            private set { data = value; }
        }
        public SerialPortReader(Form1 form)
        {
            this.form = form;
            Data = new FileMenager(form);
            port = new SerialPort(SettingsMenager.Porta, 9600, Parity.None, 8, StopBits.One) ;
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }
        public void start()
        {
            port.PortName = SettingsMenager.Porta;
            Data.AvviaMisurazione();
            MessageBox.Show("Avvio riuscito");
            port.Open();
        }
        /*private void CloseSerialOnExit()
        {

            try
            {
                port.DtrEnable = false;
                port.RtsEnable = false;
                port.DiscardInBuffer();
                port.DiscardOutBuffer();
                port.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }*/
        public void stop()
        {
            CloseDown = new System.Threading.Thread(new System.Threading.ThreadStart(CloseSerialOnExit));
            CloseDown.Start();
            MessageBox.Show("Misurazione terminata");
            Data.FineMisurazione();  
        }
        private void CloseSerialOnExit()
        {
            try
            {
                port.Close(); //close the serial port
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //catch any serial port closing error messages
            }
            
        }




        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Get and Show a received line (all characters up to a serial New Line character)
            string line = port.ReadLine();
            if (line != null)
            {
                Data.Input(line);
            }

        }
    }
}
