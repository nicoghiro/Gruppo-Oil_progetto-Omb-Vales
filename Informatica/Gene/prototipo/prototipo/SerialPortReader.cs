using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace csharp_serial
{
    public class SerialPortReader
    {

        private DataMenager data;
        private DataMenager Data
        {
            get { return data; }
            set
            {
                if (data != null)
                    data = value;
            }
        }
        public SerialPortReader(DataMenager data1)
        {
            Data = data1;
        }



        // Create the serial port with basic settings 
        private SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);

        public void start()
        {
            //set the event handler
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

            // Begin communications 
            port.Open();

        }
        public void stop()
        {
            port.Close();
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Get and Show a received line (all characters up to a serial New Line character)
            //data.input(port.ReadLine());


        }
    }
}
