using GruppoOilPrototipo.view;
using System;
using System.IO.Ports;
using System.Threading;
using SerialPortLib;
using System.Text;
using System.Windows.Forms;

namespace GruppoOilPrototipo
{
    public class SerialPortReader
    {
        private FileMenager data;
        private Form1 form;
        private SerialPortInput portLinux;
        private SerialPort portWindows;
        private Thread closeDownThread;
        private System.Threading.Thread CloseDown;
        private int angoloPrec;

        public FileMenager Data
        {
            get { return data; }
            private set { data = value; }
        }

        public SerialPortReader(Form1 form)
        {
            this.form = form;
            Data = new FileMenager(form);

            OperatingSystem os = Environment.OSVersion;
            if (os.Platform==PlatformID.Unix) {
                portLinux = new SerialPortInput();
                portLinux.SetPort(SettingsMenager.Porta, 9600);
                portLinux.MessageReceived += delegate (object sender, MessageReceivedEventArgs args)
                {
                    string line = Encoding.UTF8.GetString(args.Data);
                    if (line != null)
                    {
                        misurazioneRicevuta(line); // Log the received data
                    }
                };
            } else
            {
                portWindows = new SerialPort(SettingsMenager.Porta, 9600, Parity.None, 8, StopBits.One);
                portWindows.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            }
        }

        public void start()
        {
            try
            {
                Data.AvviaMisurazione();
                OperatingSystem os = Environment.OSVersion;
                if (os.Platform == PlatformID.Unix)
                {
                    portLinux.Connect();
                }
                else
                {
                    portWindows.PortName = SettingsMenager.Porta;
                    portWindows.Open();
                };


                Console.WriteLine("Avvio riuscito");
            } catch
            {
                Data.FineMisurazione();
            }
        }

        public void stop()
        {
            OperatingSystem os = Environment.OSVersion;
            if (os.Platform == PlatformID.Unix)
            {
                closeDownThread = new Thread(CloseSerialOnExit);
                closeDownThread.Start();
                Console.WriteLine("Misurazione terminata");
            }
            else
            {
                CloseDown = new System.Threading.Thread(new System.Threading.ThreadStart(CloseSerialOnExit));
                CloseDown.Start();
                MessageBox.Show("Misurazione terminata");
            }
            Data.FineMisurazione();
        }

        private void CloseSerialOnExit()
        {
            try
            {
                OperatingSystem os = Environment.OSVersion;
                if (os.Platform == PlatformID.Unix)
                {
                    portLinux.Disconnect(); //close the serial port
                } else portWindows.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); //catch any serial port closing error messages
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Get and Show a received line (all characters up to a serial New Line character)
            string line = portWindows.ReadLine();
            if (line != null)
            {
                misurazioneRicevuta(line);
            }

        }
        private void misurazioneRicevuta(string line)
        {
            string[] tmp;
            try 
            {
                tmp = line.Split(';');
                int angolo = int.Parse(tmp[0]);
                if (angoloPrec != null) 
                {
                    if (angoloPrec > angolo)
                    {
                        line += ";c";
                        data.Input(line);
                    }
                    else if (angoloPrec < angolo)
                    {
                        line += ";a";
                        data.Input(line);
                    } 
                    angoloPrec=angolo;
                }
                

            } catch(Exception ex)
            {
                Console.WriteLine("errore nella misurazione");
            }
            
        }
    }
}
