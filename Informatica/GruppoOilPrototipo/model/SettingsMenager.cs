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
        private string _filePathPorta;
        private string _filePathMax;
        static private Form1 _form;
        private string _filePathInfo;
        private static string _id;
        private static string _nome;

        public static string IDValvola
        {
            get { if (_id == null) return "0";
                        return _id; }
            private set { _id = value; }
        }
        public static string NomeValvola
        {
            get {
                if (_nome == null) return "N/A";
                
                    return _nome;
            }
            private set { _nome = value; }
        }
        public string FilePathInfo
        {
            get { return _filePathInfo; }
            private set { _filePathInfo = value; }
        }
        public static Form1 Form
        {
            get { return _form; }
            set
            {
                if (value != null)
                {
                    _form = value;
                }
            }
        }
        public string FilePathPorta
        {
            get { return _filePathPorta; }
            private set { _filePathPorta = value; }
        }
        public string FilePathMax
        {
            get { return _filePathMax; }
            private set { _filePathMax = value; }
        }
        public SettingsMenager()
        {
            FilePathMax= $@"{AppDomain.CurrentDomain.BaseDirectory}Impostazioni/MaxMisurazioni.config";
            FilePathInfo = $@"{AppDomain.CurrentDomain.BaseDirectory}Impostazioni/Info.config";
            FilePathPorta = $@"{AppDomain.CurrentDomain.BaseDirectory}Impostazioni/Porta.config";
            LoadSettings();
        }
        public static string Porta
        {
            get { if (_portaAttuale == null)
                {
                    return "/dev/ttyS0";
                } else 
                return _portaAttuale; }
            private set { _portaAttuale = value; }
        }
        public static int MaxMisurazioni
        {
            get { if(_maxMisurazioni==null)
                    return 100;
                    else return _maxMisurazioni; }
            private set {_maxMisurazioni = value; }
        }
        private void Scrivi(string port, string filePath)
        {

            File.Delete(filePath);
            StreamWriter sw = new StreamWriter(filePath);
            port = port.Trim();
            sw.Write(port);
            sw.Close();
        }
        public void SetPorta(decimal nPorta)
        {
            if (nPorta < 0)
            {
                throw new Exception("Porta non valida");
            } 
            Scrivi("/dev/ttyS" + nPorta, FilePathPorta);
            Porta = "/dev/ttyS" + nPorta;
            if (Form != null)
            {
                Form.VisualizzaImpostazioni();
            }
        }
        public void SetMax(int Max)
        {
            if (Max <= 0) throw new Exception("Numero non valido");
            Scrivi(Max.ToString(), FilePathMax);
            MaxMisurazioni = Max;
            if (Form != null)
            {
                Form.VisualizzaImpostazioni();
            }
        }
        public void LoadSettings()
        {
            StreamReader sr = new StreamReader(FilePathPorta);
            string line = sr.ReadLine();
            sr.Close();
            if (line != null)
            {
                SetPorta((decimal)int.Parse(line.Substring(line.Length - 1)));
            }
            else this.SetPorta(5);
            sr = new StreamReader(this.FilePathMax);
            line = sr.ReadLine();
            sr.Close();
            if (line != null)
            {
                SetMax(int.Parse(line));
            }
            else SetMax(100);
            sr = new StreamReader(FilePathInfo);
            line = sr.ReadLine();
            sr.Close();
            if (line != null)
            {
                try
                {
                    SetInfo(line.Split(';')[0], line.Split(';')[1]);
                }
                catch
                {
                    SetInfo("0", "N/A");
                }
            }
        }
        public void SetInfo(string id, string nome)
        {
            if (String.IsNullOrEmpty(id) && String.IsNullOrEmpty(nome)) throw new Exception("Nome e/o ID non validi");
            Scrivi(id + ";" +nome + ";" , FilePathInfo);
            IDValvola = id;
            NomeValvola = nome;
            if(Form!= null)
            {
                Form.VisualizzaImpostazioni();
            }
         }
    }
}
