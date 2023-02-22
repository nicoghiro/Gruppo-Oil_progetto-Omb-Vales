using System.IO.Ports;

namespace csharp_serial
{
    public class Program
    {
        DataMenager data = new DataMenager();
        static void Main(string[] args)
        {
            SerialPortReader reader = new SerialPortReader();
            reader.start();

            Console.WriteLine("Press a key to finish");
            Console.ReadLine();
        }
    }

    public class SerialPortReader

    {
        // Create the serial port with basic settings 
        private SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);

        public void start()
        {
            //set the event handler
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

            // Begin communications 
            port.Open();


        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Get and Show a received line (all characters up to a serial New Line character)
            data.input(port.ReadLine());
        }
    }
}