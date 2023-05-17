using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GruppoOilPrototipo.view
{
    public class SettingsMenager
    {
        static private string _portaAttuale;
        static private int _maxMisurazioni;
        static private string FilePathPorta;
        static private string FilePathMax;
        public SettingsMenager()
        {
            FilePathMax= Path.Combine(Application.StartupPath, "Impostazioni", "MaxMisurazioni.config");
            FilePathPorta= Path.Combine(Application.StartupPath, "Impostazioni", "Porta.config");
            StreamReader sr = new StreamReader(FilePathPorta);
            Porta = sr.ReadLine();
            sr.Close();
            sr = new StreamReader(FilePathMax);
            MaxMisurazioni = int.Parse(sr.ReadLine());
            sr.Close();
        }
        public static string Porta
        {
            get { if (_portaAttuale == null)
                {
                    return "COM5";
                } else 
                return _portaAttuale; }
            private set { _portaAttuale = value; }
        }
        public static int MaxMisurazioni
        {
            get { return _maxMisurazioni; }
            private set {_maxMisurazioni = value; }
        }
        private void Scrivi(string port, string filePath)
        {

            File.Delete(filePath);
            StreamWriter sw = new StreamWriter(filePath);
            port = port.Trim();
            port = port.ToUpper();
            sw.Write(port);
            sw.Close();
        }
        public void SetPorta(decimal nPorta)
        {

            if (nPorta < 0)
            {
                throw new Exception("Porta non valida");
            }
            Scrivi("COM" + nPorta, FilePathPorta);
            Porta = "COM" + nPorta;
        }
        public void SetMax(int Max)
        {
            if (Max < 0) throw new Exception("Numero non valido");
            Scrivi(Max.ToString(), FilePathMax);
            MaxMisurazioni = MaxMisurazioni;
        }
    }
}
