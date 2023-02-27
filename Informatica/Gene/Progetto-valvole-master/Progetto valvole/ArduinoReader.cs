using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototipo
{
    public class ArduinoReader
    {
        SerialPortReader Reader;
        bool state = false;
        //false lettura in pausa , true lettura attiva
        public ArduinoReader()
        {
            Reader=new SerialPortReader();
        }
        public void inzio()
        {
            
            Reader.start();
        }
        public void fine()
        {
            Reader.stop();
        }
    }
}

